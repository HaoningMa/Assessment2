var audio = document.getElementById("myAudio");
function playOrPauseAudio() {
    if (audio.paused) {
        audio.play();
    } else {
        audio.pause();
        audio.currentTime = 0; 
    }
}