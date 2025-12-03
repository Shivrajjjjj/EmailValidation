// site.js
// You can add general site-wide JavaScript here

document.addEventListener("DOMContentLoaded", function () {
    console.log("Site.js loaded successfully");

    // Example global function
    window.smoothScroll = function (id) {
        const element = document.getElementById(id);
        if (element) {
            element.scrollIntoView({ behavior: "smooth" });
        }
    };
});
