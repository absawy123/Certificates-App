
// Handle Logout Button 
document.querySelectorAll(".logout-btn").forEach(button => {
    button.addEventListener("click", async function (event) {
        event.preventDefault(); 

        try {
            const response = await fetch("/Account/Logout", {
                method: "POST",
                headers: { "Content-Type": "application/json" }
            });

            if (response.ok) {
                localStorage.removeItem("Token"); 
                localStorage.removeItem("Role");

                window.location.href = "/pages/login/index.html"; // Redirect to login page


            } else {
                alert("Logout failed!");
            }
        } catch (error) {
            console.error("Error:", error);
            alert("An error occurred!");
        }
    });
});
