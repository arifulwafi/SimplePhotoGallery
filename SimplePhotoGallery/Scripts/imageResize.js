$(document).ready(initializeGrid);

function initializeGrid() {

    $("#grid_slider").slider({
        value: 50,
        max: 80,
        min: 10,
        slide: function (event, ui) {
            $('ul#grid li').css('font-size', ui.value + "px");
            GetNextPage();
        }
    });

    $("ul#grid li img").each(function () {
        var width = $(this).width() / 100 + "em";
        var height = $(this).height() / 100 + "em";
        $(this).css("width", width);
        $(this).css("height", height);
    });
}
