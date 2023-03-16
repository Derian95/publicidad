// variable 
var VIDEO_PLAYING_STATE = {
    "PLAYING": "PLAYING",
    "PAUSE": "PAUSE"
}
var videoPlayStatus = VIDEO_PLAYING_STATE.PAUSE
var timeout = null
var waiting = 3000
var swiper = new Swiper(
    '.swiper-container', {
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});

// HTML5 vdo object
var options = {};
var player = videojs('my-player', options);
player.on('ended', function () {
    next()
})

// swiper object
swiper.on('slideChangeTransitionEnd', function () {
    var index = swiper.activeIndex
    var currentSlide = $(swiper.slides[index])
    var currentSlideType = currentSlide.data('slide-type')

    // incase user click next before video ended
    if (videoPlayStatus === VIDEO_PLAYING_STATE.PLAYING) {
        player.pause()
    }

    clearTimeout(timeout)

    switch (currentSlideType) {
        case 'img':
            runNext()
            break;
        case 'vdo':
            player.currentTime(0)
            player.play()
            videoPlayStatus = VIDEO_PLAYING_STATE.PLAYING
            break;
        default:
            throw new Error('invalid slide type');
    }
})

// global function
function prev() {
    swiper.slidePrev();
}

function next() {
    swiper.slideNext();
}

function runNext() {
    timeout = setTimeout(function () {
        next()
    }, waiting)
}

runNext()
