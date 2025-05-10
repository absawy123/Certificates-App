
//Handle Reference popup to add new reference
document.getElementById("saveReference").addEventListener("click", async function () {
    const inputField = document.getElementById("newReferenceName");
    const referenceValue = inputField.value.trim();
    console.log(referenceValue);

    if (!referenceValue) {
        toastr.error("Please enter a reference standard name.");
        return;
    }

    try {
        const response = await fetch("/Reference/Add", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(referenceValue) // Sending as string
        });

        if (!response.ok) {
            throw new Error("Failed to add reference.");
        }

        const jsonResponse = await response.json();
        const newOptionValue = jsonResponse.value;

        // Add the new reference to the select dropdown
        const selectElement = document.getElementById("ReferenceStandard");
        const newOption = document.createElement("option");
        newOption.value = newOptionValue;
        newOption.textContent = newOptionValue;
        selectElement.appendChild(newOption);

        // Close the modal safely
        const modalElement = document.getElementById("addReferenceModal");
        const modalInstance = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        modalInstance.hide();

        // Clear input field
        inputField.value = "";
        toastr.success("Reference added successfully!", { timeOut: 300 });

    } catch (error) {
        console.error("Error:", error);
        alert("An error occurred while adding the reference.");
    }
});

//Handle Equipment Name popup to add new Equipment
document.getElementById("saveEquipment").addEventListener("click", async function () {
    const inputField = document.getElementById("newEquipmentName");
    const equipmentValue = inputField.value.trim();

    if (!equipmentValue) {
        toastr.error("Please enter an equipment name.");
        return;
    }

    try {
        const response = await fetch("/InspectedItem/Add", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(equipmentValue) // Sending as string
        });

        if (!response.ok) {
            throw new Error("Failed to add equipment.");
        }

        const jsonResponse = await response.json();
        const newOptionValue = jsonResponse.value;

        // Add the new equipment to the select dropdown
        const selectElement = document.getElementById("EquipmentName");
        const newOption = document.createElement("option");
        newOption.value = newOptionValue;
        newOption.textContent = newOptionValue;
        selectElement.appendChild(newOption);

        // Close the modal safely
        const modalElement = document.getElementById("addEquipmentModal");
        const modalInstance = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        modalInstance.hide();

        // Clear input field
        inputField.value = "";
        toastr.success("Equipment name added successfully!", { timeOut: 300 });

    } catch (error) {
        console.error("Error:", error);
        alert("An error occurred while adding the equipment.");
    }
});

//Handle Length popup to add new Length
document.getElementById("saveLengthUnit").addEventListener("click", async function () {
    const inputField = document.getElementById("newLengthUnit");
    const lengthValue = inputField.value.trim();

    if (!lengthValue) {
        toastr.error("Please enter a length unit.");
        return;
    }

    try {
        const response = await fetch("/AppUnit/AddLength", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(lengthValue) // Sending as string
        });

        if (!response.ok) {
            throw new Error("Failed to add length.");
        }

        const jsonResponse = await response.json();
        const newOptionValue = jsonResponse.value;

        // Add the new length unit to the select dropdown
        const selectElement = document.getElementById("LengthUnit");
        const newOption = document.createElement("option");
        newOption.value = newOptionValue;
        newOption.textContent = newOptionValue;
        selectElement.appendChild(newOption);

        // Close the modal safely
        const modalElement = document.getElementById("addLengthModal");
        const modalInstance = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        modalInstance.hide();

        // Clear input field
        inputField.value = "";
        toastr.success("Length added successfully!", { timeOut: 300 });

    } catch (error) {
        console.error("Error:", error);
        alert("An error occurred while adding the length.");
    }
});


//Handle Unit popup to add new Unit
document.getElementById("saveLoadUnit").addEventListener("click", async function () {
    const inputField = document.getElementById("newLoadUnit");
    const unitValue = inputField.value.trim();

    if (!unitValue) {
        toastr.error("Please enter a unit name.");
        return;
    }

    try {
        const response = await fetch("/AppUnit/AddUnit", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(unitValue)
        });

        const jsonResponse = await response.json();
        const responeMessage = jsonResponse.message

        if (!response.ok) {
            toastr.error(responeMessage, { timeOut: 300 });
            return;
        }

        const newUnitValue = jsonResponse.Value;

        // Add new unit to dropdown
        const selectElement = document.getElementById("LoadUnit");
        const newOption = document.createElement("option");
        newOption.value = newUnitValue;
        newOption.textContent = newUnitValue;
        selectElement.appendChild(newOption);

        // Hide the modal
        const modalElement = document.getElementById("addLoadUnitModal");
        const modalInstance = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        modalInstance.hide();

        // Clear input field
        inputField.value = "";
        toastr.success("Unit added successfully!", { timeOut: 300 });

    } catch (error) {
        console.error("Error:", error);
        toastr.error("An error occurred while adding the unit.");
    }
});




