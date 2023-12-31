let isDown = false;
let startX;
let scrollLeft;

const container = document.querySelector('.carousel-container');

container.addEventListener('mousedown', (e) => {
    isDown = true;
    startX = e.pageX - container.offsetLeft;
    scrollLeft = container.scrollLeft;
});
container.addEventListener('mouseleave', () => {
    isDown = false;
});
container.addEventListener('mouseup', () => {
    isDown = false;
});
container.addEventListener('mousemove', (e) => {
    if (!isDown) return;
    e.preventDefault();
    const x = e.pageX - container.offsetLeft;
    const walk = (x - startX) * 3; 
    container.scrollLeft = scrollLeft - walk;
});