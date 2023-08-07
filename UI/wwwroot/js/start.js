var myNavBar = document.getElementById('myNavBar');
myNavBar.style.backgroundColor = '#321450';
myNavBar.style.border = '#321450';
// Get all a from nav
var navLinks = document.querySelectorAll('nav a');
// Change text color UI from standart to red
if (navLinks) {
    navLinks.forEach(function (link) {
        link.style.color = 'red';
    });
}
myNavBar === null || myNavBar === void 0 ? void 0 : myNavBar.addEventListener('mouseover', function () {
    myNavBar.style.animation = 'waveEffect 5s linear infinite';
});
myNavBar === null || myNavBar === void 0 ? void 0 : myNavBar.addEventListener('mouseleave', function () {
    myNavBar.style.animation = 'none';
});
//# sourceMappingURL=start.js.map