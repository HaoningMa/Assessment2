const images = document.querySelectorAll('.image-container img');
let currentIndex = 0;

function showImage(index) {
    images.forEach((img, i) => {
        if (i === index) {
            img.style.display = 'inline-block';
        } else {
            img.style.display = 'none';
        }
    });
}

function nextImage() {
    currentIndex = (currentIndex + 1) % images.length;
    showImage(currentIndex);
}


showImage(currentIndex);

document.addEventListener('click', function (event) {
    nextImage();
});