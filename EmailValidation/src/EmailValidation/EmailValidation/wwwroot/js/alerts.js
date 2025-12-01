// alerts.js
// Handles showing auto-close alerts and any custom notifications

document.addEventListener("DOMContentLoaded", function () {

    // Auto-hide Bootstrap alerts after 4 seconds
    const alerts = document.querySelectorAll(".alert");
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.classList.remove("show");
        }, 4000);
    });

});

// Function to show dynamic alert popup
function showAlert(message, type = "success") {
    const alertDiv = document.createElement("div");
    alertDiv.className = `alert alert-${type} alert-dismissible fade show position-fixed top-0 end-0 m-3`;
    alertDiv.style.zIndex = "9999";
    alertDiv.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;

    document.body.appendChild(alertDiv);

    // Remove after 5 seconds
    setTimeout(() => {
        alertDiv.remove();
    }, 5000);
}
