
// Handle visable links that each user can see 
document.addEventListener("DOMContentLoaded", function () {
    const role = localStorage.getItem("Role"); 

    // Get navigation links
    const certificateLink = document.getElementById("certificate");
    const clientLink = document.getElementById("Client");
    const jobLink = document.getElementById("Job");
    const userLink = document.getElementById("User");

    // Function to hide elements
    function hideElement(element) {
        if (element) {
            element.style.display = "none";
        }
    }

    // Show links based on role
    if (role === "SuperAdmin") {

    } else if (role === "Admin") {
        hideElement(userLink); 
    } else if (role === "Inspector") {
        hideElement(userLink); 
        hideElement(clientLink); 
    } else {
        // If the role is not recognized, hide all links
        hideElement(certificateLink);
        hideElement(clientLink);
        hideElement(jobLink);
        hideElement(userLink);
    }
});

// Handle clients redirect
document.addEventListener("DOMContentLoaded", function () {

    const clientLink = document.getElementById("Client");

    if (clientLink) {
        clientLink.addEventListener("click", function (e) {
            e.preventDefault(); 
            window.location.href = "users/client.html";  
        });
    }
});






