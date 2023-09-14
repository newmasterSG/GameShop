const myNavBar = document.getElementById('myNavBar');

// Get all a from nav
const navLinks = document.querySelectorAll('nav a');

// Change text color UI from standart to red
if (navLinks) {
    navLinks.forEach(link => {
        (link as HTMLElement).style.color = 'red';
    });
}

myNavBar?.addEventListener('mouseover', () => {
    myNavBar.style.animation = 'waveEffect 5s linear infinite';
});

myNavBar?.addEventListener('mouseleave', () => {
    myNavBar.style.animation = 'none';
});


const asideTag: HTMLElement = document.querySelector("#asideTag");
const asideOverlay: HTMLElement = document.createElement("div");
asideOverlay.style.position = "fixed";
asideOverlay.style.top = '0';
asideOverlay.style.left = '0';
asideOverlay.style.width = '100%';
asideOverlay.style.height = '100%';
asideOverlay.style.background = "rgba(0, 0, 0, 0.5)";
asideOverlay.style.opacity = '0';
asideOverlay.style.transition = "opacity 0.5s";
asideOverlay.style.pointerEvents = "none";
document.body.appendChild(asideOverlay);

asideTag.addEventListener("mouseenter", () => {
    asideOverlay.style.opacity = '1';
});

asideTag.addEventListener("mouseleave", () => {
    asideOverlay.style.opacity = '0';
});