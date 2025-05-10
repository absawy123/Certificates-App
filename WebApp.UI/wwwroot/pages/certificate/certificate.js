//Handle Increase and decrease count of Load 
document.addEventListener('DOMContentLoaded', function () {
    const decrementButton = document.getElementById('decrementLoad');
    const incrementButton = document.getElementById('incrementLoad');
    const loadInput = document.getElementById('Load');

    decrementButton.addEventListener('click', function () {
        let currentValue = parseInt(loadInput.value);
        if (currentValue > 1) {
            loadInput.value = currentValue - 1;
        }
    });

    incrementButton.addEventListener('click', function () {
        let currentValue = parseInt(loadInput.value);
        loadInput.value = currentValue + 1;
    });

    loadInput.addEventListener('input', function () {
        if (this.value === '' || isNaN(this.value) || parseInt(this.value) < 1) {
            this.value = 1;
        }
    });
});


//Handle Equipment popup to add new equipment
document.addEventListener('DOMContentLoaded', function () {
    const addButton = document.getElementById('addEquipmentButton');
    const modal = new bootstrap.Modal(document.getElementById('addEquipmentModal'));
    const saveButton = document.getElementById('saveEquipment');
    const newEquipmentNameInput = document.getElementById('newEquipmentName');
    const equipmentSelect = document.getElementById('EquipmentName');

    addButton.addEventListener('click', function () {
        modal.show();
    });

    saveButton.addEventListener('click', function () {
        const newName = newEquipmentNameInput.value.trim();
        if (newName) {
            const newOption = document.createElement('option');
            newOption.value = newName;
            newOption.textContent = newName;
            equipmentSelect.appendChild(newOption);
            equipmentSelect.value = newName;
            newEquipmentNameInput.value = '';
            modal.hide();
        } else {
            alert('Please enter an equipment name.');
        }
    });
});


//Handle Reference popup to add new reference
document.addEventListener('DOMContentLoaded', function () {
    const addReferenceButton = document.getElementById('addReferenceButton');
    const referenceModal = new bootstrap.Modal(document.getElementById('addReferenceModal'));
    const saveReferenceButton = document.getElementById('saveReference');
    const newReferenceNameInput = document.getElementById('newReferenceName');
    const referenceSelect = document.getElementById('ReferenceStandard');

    addReferenceButton.addEventListener('click', function () {
        referenceModal.show();
    });

    saveReferenceButton.addEventListener('click', function () {
        const newName = newReferenceNameInput.value.trim();
        if (newName) {
            const newOption = document.createElement('option');
            newOption.value = newName;
            newOption.textContent = newName;
            referenceSelect.appendChild(newOption);
            referenceSelect.value = newName;
            newReferenceNameInput.value = '';
            referenceModal.hide();
        } else {
            alert('Please enter a reference standard name.');
        }
    });
});

//Handle Unit popup to add new unit
document.addEventListener('DOMContentLoaded', function () {
    const addUnitButton = document.getElementById('addUnitButton');
    const unitModal = new bootstrap.Modal(document.getElementById('addUnitModal'));
    const saveUnitButton = document.getElementById('saveUnit');
    const newUnitNameInput = document.getElementById('newUnitName');
    const unitSelect = document.getElementById('Unit');

    addUnitButton.addEventListener('click', function () {
        unitModal.show();
    });

    saveUnitButton.addEventListener('click', function () {
        const newName = newUnitNameInput.value.trim();
        if (newName) {
            const newOption = document.createElement('option');
            newOption.value = newName;
            newOption.textContent = newName;
            unitSelect.appendChild(newOption);
            unitSelect.value = newName;
            newUnitNameInput.value = '';
            unitModal.hide();
        } else {
            alert('Please enter a unit name.');
        }
    });
});

//Handle length popup to add new length
document.addEventListener('DOMContentLoaded', function () {
    const addLengthUnitButton = document.getElementById('addLengthUnitButton');
    const lengthUnitModal = new bootstrap.Modal(document.getElementById('addLengthUnitModal'));
    const saveLengthUnitButton = document.getElementById('saveLengthUnit');
    const newLengthUnitNameInput = document.getElementById('newLengthUnitName');
    const lengthUnitSelect = document.getElementById('LengthUnit');

    addLengthUnitButton.addEventListener('click', function () {
        lengthUnitModal.show();
    });

    saveLengthUnitButton.addEventListener('click', function () {
        const newName = newLengthUnitNameInput.value.trim();
        if (newName) {
            const newOption = document.createElement('option');
            newOption.value = newName;
            newOption.textContent = newName;
            lengthUnitSelect.appendChild(newOption);
            lengthUnitSelect.value = newName;
            newLengthUnitNameInput.value = '';
            lengthUnitModal.hide();
        } else {
            alert('Please enter a length unit name.');
        }
    });
});


//handle api call

fetch("https://localhost:7079/api/Account/Login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email: "admin@example.com", password: "yourpassword" })
})
    .then(response => response.json())
    .then(data => {
        if (data.token) {
            localStorage.setItem("jwtToken", data.token); // Store token
            window.location.href = "dashboard.html"; // Redirect to dashboard
        }
    })
    .catch(error => console.error("Login Error:", error));