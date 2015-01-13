// tab functionality

$(document).ready(function() {
    $(".mask").click(function(e) {
        $(this).hide();
        $('.floatingpanel').hide();
    });
});

function doTabs() {
    $(document).ready(function() {
        $(".tabcontent").hide();
        $("#tabcontent1").show();

        $(".tab").click(function(e) {
            e.preventDefault();
            $(".tab").removeClass('active');
            $(this).addClass('active');
            $(".tabcontent").hide();
            var reldiv = $(this).attr('rel');
            $('#' + reldiv).show();
        });
    })
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
    $('.mask').fadeTo(0, 0.2);

    //Get the window height and width
    var winH = $(window).height();
    var winW = $(window).width();

    $(id).css("position", "absolute");
    $(id).css("top", ($(window).height() - $(id).height()) / 2 + $(window).scrollTop() + "px");
    $(id).css("left", ($(window).width() - $(id).width()) / 2 + $(window).scrollLeft() + "px");

    //transition effect
    $(id).fadeIn(200);

}

function showImagePickerPopUp(divid) {

    //panel to popup
    var id = '#' + divid

    //Get the screen height and width
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    //Set heigth and width to mask to fill up the whole screen
    $('.mask').css({ 'width': maskWidth, 'height': maskHeight - 4 });

    //transition effect		
    $('.mask').fadeIn(200);
    $('.mask').fadeTo(0, 0.2);

    //Get the window height and width
    var winH = $(window).height();
    var winW = $(window).width();

    $(id).css("position", "absolute");
    $(id).css("top", ($(window).height() - 500) / 2 + $(window).scrollTop() + "px");
    $(id).css("left", ($(window).width() - $(id).width()) / 2 + $(window).scrollLeft() + "px");

    //transition effect
    $(id).show();

}

//if mask is clicked
function clearMask() {
    $('.mask').hide();
    $('.floatingpanel').hide();
};
