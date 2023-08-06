const myNavBar = document.getElementById('myNavBar');

myNavBar.style.backgroundColor = '#321450';
myNavBar.style.border = '#321450';
// Через TypeScript изменяем цвет текста ссылок внутри nav
const navLinks = document.querySelectorAll('nav a');

// Пример изменения цвета на красный
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
