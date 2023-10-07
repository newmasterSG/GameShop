const asideTag = document.querySelector("#asideTag");
const asideOverlay = document.createElement("div");
const tagsText = document.getElementsByClassName("tags");

asideOverlay.style.position = "fixed";
asideOverlay.style.top = 0;
asideOverlay.style.left = 0;
asideOverlay.style.width = '100%';
asideOverlay.style.height = '100%';
asideOverlay.style.background = "rgba(0, 0, 0, 0.5)";
asideOverlay.style.opacity = 0;
asideOverlay.style.transition = "opacity 0.5s";
asideOverlay.style.pointerEvents = "none";
asideTag.parentNode.appendChild(asideOverlay);

asideTag.addEventListener("mouseenter", () => {
    asideOverlay.style.opacity = 1.8;
    asideTag.style.backgroundColor = "rgba(169, 169, 169, 1)";
    for (var i = 0; i < tagsText.length; i++) {
        tagsText[i].style.color = "#FF0000";
    }
});

asideTag.addEventListener("mouseleave", () => {
    asideOverlay.style.opacity = 0;
    asideTag.style.backgroundColor = "rgba(128, 128, 128)";
    for (var i = 0; i < tagsText.length; i++) {
        tagsText[i].style.color = "rgba(0, 0, 0)";
    }
});