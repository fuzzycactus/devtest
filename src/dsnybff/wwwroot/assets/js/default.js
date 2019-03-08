
var $carousel = $('.main-locations').flickity();

$carousel.on('staticClick.flickity', function (event, pointer, cellElement, cellIndex) {
    if (typeof cellIndex == 'number') {
        $carousel.flickity('selectCell', cellIndex);
    }
});
