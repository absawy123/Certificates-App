// fetch All Users handeller
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("navUsers").addEventListener("click", function (event) {
        event.preventDefault();
        console.log("start")

        fetch('/Account/GetAllUsers', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json' ,
            }
        })
            .then(response => {
                if (!response.ok) {
                    console.log("Failed to fetch users");
                }
                return response.json();
            })
            .then(data => {
                populateUsersTable(data);
            })
            .catch(error => {
                console.error("Error fetching users:", error);
                toastr.error("Could not fetch users. Try again later.");
            });
    });

    function populateUsersTable(users) {
        let tableHead = document.getElementById("usersTableHead");
        let tableBody = document.getElementById("usersTableBody");

        // Clear previous content
        tableHead.innerHTML = "";
        tableBody.innerHTML = "";

        // Add table headers
        tableHead.innerHTML = `
                <tr>
                    <th>ID</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Actions</th>
                </tr>
            `;

        // Populate table body
        users.forEach(user => {
            let isLocked = user.lockoutEnd && new Date(user.lockoutEnd) > new Date();
            let row = document.createElement("tr");

            row.innerHTML = `
                <td>${user.id}</td>
                <td>${user.userName}</td>
                <td>${user.email}</td>
                <td>
                    <button class="btn ${isLocked ? 'btn-danger' : 'btn-success'} btn-sm lock-btn" data-userid="${user.id}" data-locked="${isLocked}">
                        <i class="bi ${isLocked ? 'bi-lock' : 'bi-unlock'}"></i>
                    </button>
                </td>
            `;

            // Append row to table body
            tableBody.appendChild(row);
        });

        // Add event listeners to lock/unlock buttons
        document.querySelectorAll(".lock-btn").forEach(button => {
            button.addEventListener("click", function () {
                let userId = this.getAttribute("data-userid");
                let isLocked = this.getAttribute("data-locked") === "true";

                if (isLocked) {
                    unlockUser(userId, this);
                } else {
                    lockUser(userId, this);
                }
            });
        });
    }

    function lockUser(userId, button) {
        fetch(`/Account/LockUser?userId=${userId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    toastr.success("User has been locked.");

                    // Update button to lock state
                    button.classList.remove("btn-success");
                    button.classList.add("btn-danger");
                    button.innerHTML = `<i class="bi bi-lock"></i>`;
                    button.setAttribute("data-locked", "true");
                } else {
                    toastr.error("Can't lock user.");
                }
            })
            .catch(error => {
                console.error("Error locking user:", error);
                toastr.error("An error occurred. Please try again.");
            });
    }

    function unlockUser(userId, button) {
        fetch(`/Account/unlock?userId=${userId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    toastr.success("User has been unlocked.");

                    // Update button to unlock state
                    button.classList.remove("btn-danger");
                    button.classList.add("btn-success");
                    button.innerHTML = `<i class="bi bi-unlock"></i>`;
                    button.setAttribute("data-locked", "false");
                } else {
                    toastr.error("Can't unlock user.");
                }
            })
            .catch(error => {
                console.error("Error unlocking user:", error);
                toastr.error("An error occurred. Please try again.");
            });
    }
});

