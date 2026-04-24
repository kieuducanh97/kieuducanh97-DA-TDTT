document.addEventListener("DOMContentLoaded", () => {
    setupSlider();
    setupLoadMore();
    setupBackToTop();
});

function setupSlider() {
    const slider = document.querySelector("[data-slider]");
    if (!slider) {
        return;
    }

    const slides = Array.from(slider.querySelectorAll("[data-slide]"));
    const dots = Array.from(slider.querySelectorAll("[data-slide-dot]"));
    const prevButton = slider.querySelector("[data-slide-prev]");
    const nextButton = slider.querySelector("[data-slide-next]");
    let activeIndex = 0;

    const render = (index) => {
        activeIndex = (index + slides.length) % slides.length;
        slides.forEach((slide, slideIndex) => {
            slide.classList.toggle("is-active", slideIndex === activeIndex);
        });
        dots.forEach((dot, dotIndex) => {
            dot.classList.toggle("is-active", dotIndex === activeIndex);
        });
    };

    prevButton?.addEventListener("click", () => render(activeIndex - 1));
    nextButton?.addEventListener("click", () => render(activeIndex + 1));
    dots.forEach((dot, index) => {
        dot.addEventListener("click", () => render(index));
    });

    setInterval(() => render(activeIndex + 1), 5000);
    render(0);
}

function setupLoadMore() {
    const cards = Array.from(document.querySelectorAll("[data-job-card]"));
    const button = document.querySelector("[data-load-more]");
    const initialCount = 6;
    const step = 3;
    let visibleCount = 0;

    if (!cards.length || !button) {
        return;
    }

    const render = () => {
        visibleCount = Math.min(visibleCount + step, cards.length);
        cards.forEach((card, index) => {
            card.classList.toggle("is-visible", index < visibleCount);
        });
        button.hidden = visibleCount >= cards.length;
    };

    visibleCount = Math.min(initialCount, cards.length);
    cards.forEach((card, index) => {
        card.classList.toggle("is-visible", index < visibleCount);
    });
    button.hidden = visibleCount >= cards.length;
    button.addEventListener("click", render);
}

function setupBackToTop() {
    const button = document.querySelector("[data-back-to-top]");
    if (!button) {
        return;
    }

    button.addEventListener("click", () => {
        window.scrollTo({ top: 0, behavior: "smooth" });
    });
}
