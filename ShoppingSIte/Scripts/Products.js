$(document).ready(function () {
    $('#Search').autocomplete({
        source: '/Products/AutoComplete'
    });
    $(".rating").click(function () {
        if ($(this).attr("src") === "/Images/" + "YellowRating.png") {
            decRating($(this), "WhiteRating.png");
        }
        else {
            giveRating($(this), "YellowRating.png");
        }
        $(this).css("cursor", "pointer");
        document.getElementById("Rating").value = $(this).attr("id");
    });
    function giveRating(img, image) {
        img.attr("src", "/Images/" + image)
            .prevAll("img").attr("src", "/Images/" + image);
    }
    function decRating(img, image) {
        img.nextAll("img").attr("src", "/Images/" + image);
    }
});