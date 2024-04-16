// Get the modal elements
const userModal = document.getElementById("userModal");
const userBtn = document.querySelector(".user");
const userClose = document.querySelector(".user-close");
const imageInput = document.getElementById("imageInput");
const userImage = document.getElementById("userImage");
const overlay = document.querySelector(".overlay");
const changeImageButton = document.querySelector(".change-image");
const deleteImageButton = document.querySelector(".delete-image");
const savedInstruments = {};

// Function to create delete button for an instrument
function createDeleteButton() {
    const deleteButton = document.createElement("button");
    deleteButton.classList.add("delete-instrument");
    deleteButton.innerHTML = "&times;";
    deleteButton.style.color = "red";

    deleteButton.addEventListener("click", function () {
        const instrument = this.parentElement;
        instrument.remove();

        const savedInstrumentsCount = document.querySelectorAll("#userModal .save-instruments").length;
        if (savedInstrumentsCount === 0) {
            const saveLists = document.querySelector("#userModal .save-lists");
            const noListElement = document.createElement("div");
            noListElement.classList.add("nolist");
            noListElement.textContent = "You did not save";
            saveLists.appendChild(noListElement);
        }
    });

    return deleteButton;
}

// Function to create PDF button for an instrument
function createPdfButton(pdfPath) {
    const pdfButton = document.createElement("div");
    pdfButton.classList.add("get-pdf");

    const pdfIcon = document.createElement("img");
    pdfIcon.src = "/img/pdf-svgrepo-com.png";
    pdfButton.appendChild(pdfIcon);

    pdfButton.addEventListener("click", function () {
        console.log("PDF Path:", pdfPath);
        window.open(pdfPath, "_blank");
    });

    return pdfButton;
}

// Add PDF buttons for each tool in the second modal
const modalToolWrappers = document.querySelectorAll("#userModal .tool_wrapper");
modalToolWrappers.forEach(toolWrapper => {
    const pdfPath = toolWrapper.getAttribute("data-pdf");
    if (pdfPath) {
        const pdfButton = createPdfButton(pdfPath);
        const savedImgElement = toolWrapper.querySelector(".saved_img");
        savedImgElement.appendChild(pdfButton);
    }
});

// Save button click event in the first modal
const saveButton = document.querySelector("#myModal .small-square-save");
saveButton.addEventListener("click", function () {
    const toolTitle = document.querySelector("#myModal .tool-title").textContent;

    if (!savedInstruments[toolTitle]) {
        savedInstruments[toolTitle] = true;

        const notification = document.getElementById("notification");
        notification.classList.add("show");

        setTimeout(function () {
            notification.classList.remove("show");
        }, 2000);

        const noListElement = document.querySelector("#userModal .nolist");
        if (noListElement) {
            noListElement.remove();
        }

        const saveLists = document.querySelector("#userModal .save-lists");
        const newElement = document.createElement("div");
        newElement.textContent = toolTitle;
        newElement.classList.add("save-instruments");

        const savedImgElement = document.createElement("div");
        const imgLink = document.querySelector("#myModal .square").style.backgroundImage;
        savedImgElement.classList.add("saved_img");
        savedImgElement.style.backgroundImage = imgLink;
        const deleteButton = createDeleteButton();
        const pdfButton = createPdfButton();

        newElement.appendChild(deleteButton);
        newElement.appendChild(pdfButton);
        newElement.appendChild(savedImgElement);
        saveLists.appendChild(newElement);
    } else {
        alert("This instrument is already saved!");
    }
});

// Close notification function
function closeNotification() {
    const notification = document.getElementById("notification");
    notification.classList.remove("show");
}

// Show overlay when hovering over the user profile
document.querySelector(".user-profile").addEventListener("mouseenter", () => {
    overlay.style.display = "block";
});

// Hide overlay when not hovering over the user profile
document.querySelector(".user-profile").addEventListener("mouseleave", () => {
    overlay.style.display = "none";
});

// Change image button click event
changeImageButton.addEventListener("click", () => {
    imageInput.click();
});

// Handle file selection
imageInput.addEventListener("change", event => {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        const newImageSrc = e.target.result;
        userImage.src = newImageSrc;
        userBtn.style.backgroundImage = `url(${newImageSrc})`;
    };

    reader.readAsDataURL(file);
});

// Delete image button click event
deleteImageButton.addEventListener("click", () => {
    const defaultImageSrc = "/path/to/default/image.jpg";
    userImage.src = defaultImageSrc;
    userBtn.style.backgroundImage = `url(${defaultImageSrc})`;
});

// Open the modal when the user clicks on the button
userBtn.addEventListener("click", () => {
    userModal.style.display = "block";
});

// Close the modal when the user clicks on <span> (x)
userClose.addEventListener("click", () => {
    userModal.style.display = "none";
});

// Close the modal when the user clicks anywhere outside of it
window.addEventListener("click", event => {
    if (event.target == userModal) {
        userModal.style.display = "none";
    }
});
