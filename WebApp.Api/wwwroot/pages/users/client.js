
// handle data table and load it with clients 
document.addEventListener("DOMContentLoaded", function () {
    const table = $("#clientsTable").DataTable();

    $('#clientsTable_filter').addClass('text-end'); 
    $('#clientsTable_filter input')
        .addClass('form-control d-inline-block w-auto') 
        .attr('placeholder', 'Search clients...');

    loadClients();

    function loadClients() {
        const token = localStorage.getItem("Token");

        fetch("/ApplicationUser/GetAllClients", {
            method: "GET",
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Unauthorized or failed request");
                }
                return response.json();
            })
            .then(data => {
                table.clear();
                data.forEach(client => {
                    table.row.add([
                        client.name,
                        client.email,
                        client.address || "N/A",
                        `
                    <div class="form-check form-switch d-flex align-items-center gap-2">
                        <input class="form-check-input activate me-1"
                               type="checkbox" role="switch"
                               data-id="${client.id}"
                               style="width: 3rem; height: 1rem;"
                               ${client.isActive == false ? 'checked' : ''}>
                        <button class="btn btn-warning btn-sm edit-btn" data-id="${client.id}">
                            <i class="bi bi-pencil"></i> Edit
                        </button>                

                    </div>
                    `
                    ]);
                });
                table.draw();
            })
            .catch(error => alert(error.message));
    }



    // Handle Edit Button 
    document.addEventListener("click", function (event) {
        const editBtn = event.target.closest(".edit-btn");
        if (editBtn) {
            const clientId = editBtn.getAttribute("data-id");

            const row = $(editBtn).closest("tr");
            const rowData = $("#clientsTable").DataTable().row(row).data();

            const clientName = rowData[0];
            const clientEmail = rowData[1];
            const clientAddress = rowData[2] === "N/A" ? "" : rowData[2];

            document.getElementById("editClientId").value = clientId;
            document.getElementById("editClientName").value = clientName;
            document.getElementById("editClientEmail").value = clientEmail;
            document.getElementById("editClientAddress").value = clientAddress;

            // Show modal
            const editModal = new bootstrap.Modal(document.getElementById("editClientModal"));
            editModal.show();
        }
    });


    // Edit Form Submit
    document.getElementById("editClientForm").addEventListener("submit", function (e) {
        e.preventDefault();

        const id = document.getElementById("editClientId").value;
        const name = document.getElementById("editClientName").value.trim();
        const email = document.getElementById("editClientEmail").value.trim();
        const address = document.getElementById("editClientAddress").value.trim();

        fetch("/ApplicationUser/UpdateClient", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                id,
                userName: name,
                email,
                address
            })
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to update client.");
                return response.json();
            })
            .then(data => {
                toastr.success("Client updated successfully.");
                const modal = bootstrap.Modal.getInstance(document.getElementById("editClientModal"));
                modal.hide();
                loadClients();
            })
            .catch(error => {
                toastr.error("Error updating client.");
                console.error(error);
            });
    });


    // Handle Toggle Delete Button (Not completed)
    document.addEventListener("change", function (event) {
        if (event.target.classList.contains("activate")) {
            const clientId = event.target.getAttribute("data-id");
            const isChecked = event.target.checked;
           

            // Send the request to remove (soft delete) the client
            fetch(`/ApplicationUser/RemoveClient?id=${clientId}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
            })
                .then(response => {
                    if (!response.ok) throw new Error("Failed to remove client.");
                    return response.json();
                })
                .then(data => {
                    // Success, show success notification
                    if (!isChecked) {
                        toastr.error("Client has been deactivated.");
                    } else {
                        toastr.success("Client has been activated.");
                    }
                })
                .catch(error => {
                    toastr.error("Error deleting client. Please try again.");
                });
        }
    });




    // moved code
    const createClientForm = document.getElementById("createClientForm");
    const clientName = document.getElementById("clientName");
    const clientEmail = document.getElementById("clientEmail");
    const clientAddress = document.getElementById("clientAddress");
    const clientPassword = document.getElementById("clientPassword");
    const submitButton = document.getElementById("submit");
    const createClientModal = new bootstrap.Modal(document.getElementById("createClientModal"));


    // Add event listener when the modal is shown
    document.getElementById("createClientModal").addEventListener("shown.bs.modal", function () {
        submitButton.addEventListener("click", function (event) {
            event.preventDefault(); // Prevent form submission

            let isValid = true;

            // Validation checks
            if (!clientName.value.trim()) {
                toastr.error("Username is required.");
                isValid = false;
            }
            if (!clientEmail.value.trim()) {
                toastr.error("Email is required.");
                isValid = false;
            }
            if (!clientPassword.value.trim()) {
                toastr.error("Password is required.");
                isValid = false;
            }

            if (!isValid) return; // Stop if validation fails

            // Create new client object
            const newClient = {
                username: clientName.value.trim(),
                email: clientEmail.value.trim(),
                address: clientAddress.value.trim() || null, // Address is optional
                password: clientPassword.value.trim()
            };

            // Send request to server
            fetch("/ApplicationUser/AddClient", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(newClient)
            })
                .then(response => {
                    if (!response.ok) throw new Error("Failed to create client.");
                    return response.json();
                })
                .then(() => {
                    createClientModal.hide();  // Close modal
                    createClientForm.reset();  // Reset form
                    loadClients();             // Refresh client list
                    toastr.success("Client created successfully!");
                })
                .catch(() => {
                    toastr.error("Error creating client. Please try again.");
                });
        });
    });


});



// handel fetch userName to show in navbar
document.addEventListener("DOMContentLoaded", function () {
    fetch('/ApplicationUser/GetUserName')
        .then(response => {
            if (!response.ok) {
                throw new Error("User not authenticated");
            }
            return response.text();
        })
        .then(userName => {
            document.getElementById("userNameSpan").innerHTML = `Hi, ${userName}`;
        })
        .catch(error => {
            console.log("Error fetching username:", error);
        });
});




