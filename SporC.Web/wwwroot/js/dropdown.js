document.addEventListener("DOMContentLoaded", function () {
    var dropdownButtons = document.querySelectorAll(".dropdown-button");

    dropdownButtons.forEach(function (button) {
        button.addEventListener("click", function (event) {
            event.stopPropagation(); // Prevents the click event from reaching the document
            var postId = button.dataset.postId;
            var dropdown = button.closest(".card-list").querySelector(".dropdown");

            console.log("Button Clicked:", postId);

            if (dropdown) {
                dropdown.classList.toggle("active");
                console.log("Dropdown Toggled:", postId);
            }
        });
    });

    // Close dropdown when clicking outside
    document.addEventListener("click", function (event) {
        var dropdowns = document.querySelectorAll('.dropdown');
        dropdowns.forEach(function (dropdown) {
            dropdown.classList.remove('active');
            console.log("Dropdown Closed");
        });
    });
});