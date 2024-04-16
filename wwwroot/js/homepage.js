// Получаем ссылки на элементы
const modal = document.querySelector("#myModal");
const closeBtn = document.querySelector(".close");
const square = document.querySelector(".square");
const toolTitleElement = document.querySelector(".tool-title");
const specTitles = document.querySelectorAll(".with-image, .with-image-2, .with-image-3, .with-image-4, .with-image-5, .with-image-6");
const toolWrappers = document.querySelectorAll(".tool_wrapper");

// Для каждого .tool_wrapper добавляем обработчик события
toolWrappers.forEach(toolWrapper => {
    toolWrapper.addEventListener("click", () => {
        // Получаем данные из data-атрибутов
        const imageUrl = toolWrapper.getAttribute("data-image");
        const toolTitle = toolWrapper.querySelector(".text-below").textContent;
        const videoSrc = toolWrapper.getAttribute("data-video-src");
        const paragraphs = [
            toolWrapper.getAttribute("data-paragraph-1"),
            toolWrapper.getAttribute("data-paragraph-2"),
            toolWrapper.getAttribute("data-paragraph-3"),
        ];
        const sliderImages = [
            toolWrapper.getAttribute("data-slider-image-1"),
            toolWrapper.getAttribute("data-slider-image-2"),
            toolWrapper.getAttribute("data-slider-image-3"),
            toolWrapper.getAttribute("data-slider-image-4"),
        ];
        const specTitlesData = [
            toolWrapper.getAttribute("data-spec-title"),
            toolWrapper.getAttribute("data-spec-title-2"),
            toolWrapper.getAttribute("data-spec-title-3"),
            toolWrapper.getAttribute("data-spec-title-4"),
            toolWrapper.getAttribute("data-spec-title-5"),
            toolWrapper.getAttribute("data-spec-title-6")
        ];
        const imageUrls = [
            toolWrapper.getAttribute("data-first-image"),
            toolWrapper.getAttribute("data-second-image"),
            toolWrapper.getAttribute("data-third-image"),
            toolWrapper.getAttribute("data-fourth-image"),
            toolWrapper.getAttribute("data-fifth-image"),
            toolWrapper.getAttribute("data-sixth-image")
        ];

        // Обновляем содержимое модального окна
        square.style.backgroundImage = `url('${imageUrl}')`;
        toolTitleElement.textContent = toolTitle;
        updateSpecs(specTitles, specTitlesData);
        updateImageSpecs(specTitles, imageUrls);
        updateModalContent({ videoSrc, paragraphs, sliderImages });

        modal.style.display = "block"; // Показываем модальное окно
    });
});

// Функция для обновления содержимого модального окна
function updateModalContent({ videoSrc, paragraphs, sliderImages }) {
    const infoSquare = document.querySelector(".info-square");
    const videoElement = infoSquare.querySelector(".video");
    videoElement.setAttribute("src", videoSrc);
    const infoParagraphs = infoSquare.querySelectorAll("p");
    infoParagraphs.forEach((paragraph, index) => {
        paragraph.textContent = paragraphs[index];
    });
    const slides = infoSquare.querySelectorAll(".slide");
    slides.forEach((slide, index) => {
        slide.setAttribute("src", sliderImages[index]);
    });
}

// Функция для обновления названий спецификаций в модальном окне
function updateSpecs(specTitles, specTitlesData) {
    specTitles.forEach((title, index) => {
        title.textContent = specTitlesData[index];
    });
}

// Функция для обновления изображений спецификаций в модальном окне
function updateImageSpecs(specTitles, imageUrls) {
    specTitles.forEach((title, index) => {
        title.style.backgroundImage = `url('${imageUrls[index]}')`;
    });
}

// Закрываем модальное окно при клике на кнопку закрытия
closeBtn.addEventListener("click", () => {
    modal.style.display = "none";
});

// Закрываем модальное окно при клике за его пределами
window.addEventListener("click", event => {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});

// Управление слайдами
let currentSlide = 0;
const slides = document.querySelectorAll(".slide");
const dotsContainer = document.querySelector(".slider-dots");

function showSlide(n) {
    slides[currentSlide].style.display = "none";
    currentSlide = (n + slides.length) % slides.length;
    slides[currentSlide].style.display = "block";
    updateDots();
}

function nextSlide() {
    showSlide(currentSlide + 1);
}

function prevSlide() {
    showSlide(currentSlide - 1);
}

function updateDots() {
    const dots = document.querySelectorAll(".dot");
    dots.forEach(dot => dot.classList.remove("active"));
    dots[currentSlide].classList.add("active");
}

// Создаем круглые индикаторы для слайдов
slides.forEach((slide, index) => {
    const dot = document.createElement("span");
    dot.classList.add("dot");
    dot.addEventListener("click", () => showSlide(index));
    dotsContainer.appendChild(dot);
});

showSlide(currentSlide); // Показываем начальный слайд
