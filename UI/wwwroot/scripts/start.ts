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
