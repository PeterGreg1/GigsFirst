jQuery(document).ready(function () {
    $(".mask").hover(function () {
        clearMask();
    });
    $(".mask").click(function () {
        clearMask();
    });
    $(".socialicons img")
    .mouseover(function () {
        var src = $(this).attr("src").match(/[^\.]+/) + "over.png";
        $(this).attr("src", src);
    })
    .mouseout(function () {
        var src = $(this).attr("src").replace("over.png", ".png");
        $(this).attr("src", src);
    });
    $('.loginslider').cycle({
        fx: 'scrollHorz',
        speed: 'slow',
        timeout: 6000,
        slideExpr: '.section',
        autostop: 0
    }).cycle('pause');
});

function popDDMessage(message1, message2, cssclass) {
    var returnMessage = [message1, message2];
    jQuery('body').showMessage({
        'thisMessage': returnMessage,
        'className': cssclass,
        'opacity': 100,
        'displayNavigation': false,
        'autoClose': true,
        'delayTime': 3000,
        'zIndex': '999999999999999'
    });
}

function goToURL(URL) {
    $(location).attr('href', URL);
}

function clearText(thefield) {
    if (thefield.defaultValue == thefield.value)
        thefield.value = ""
}

function showPopUp(divid) {

    //panel to popup
    var id = '#' + divid

    //Get the screen height and width
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    //Set heigth and width to mask to fill up the whole screen
    $('.mask').css({ 'width': maskWidth, 'height': maskHeight - 4 });

    //transition effect		
    $('.mask').fadeIn(200);
    $('.mask').fadeTo(0, 0.7);

    //Get the window height and width
    var winH = $(window).height();
    var winW = $(window).width();

    $(id).css("position", "absolute");
    $(id).css("top", ($(window).height() - $(id).height()) / 2 + $(window).scrollTop() + "px");
    $(id).css("left", ($(window).width() - $(id).width()) / 2 + $(window).scrollLeft() + "px");

    //transition effect
    $(id).fadeIn(200);

}

//if mask is clicked
function clearMask() {
    $('.mask').hide();
    $('.floatingpanel').hide();
    $('.search').hide();
    $('.textresize').hide();
};