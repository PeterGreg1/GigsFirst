var id;
var numofstyles;
var zmax;
var noticeboardid;

function getLastOrderID() {
    // this gets the initial id of the note
    $.get('/Admin/Ajax/Noticeboard/Default.aspx?noticeboardid=' + noticeboardid + '&type=getlastorderid', doSomethingWithData);
}

function getHighestZIndex() {
    // this gets the initial id of the note
    $.get('/Admin/Ajax/Noticeboard/Default.aspx?noticeboardid=' + noticeboardid + '&type=getmaxzindex', doSomethingWithData2);
   }

   function getExpiryDate(noteid) {
   	// this gets the expiry date of the selected note
   	$('#hf_expirynoteid').val(noteid);
   	$.get('/Admin/Ajax/Noticeboard/Default.aspx?noticeboardid=' + noticeboardid + '&type=getexpirydate&id=' + noteid, doSomethingWithData3);
}

function getURL(noteid) {
    // this gets the expiry date of the selected note
    $('#hf_urlnoteid').val(noteid);
    $.get('/Admin/Ajax/Noticeboard/Default.aspx?noticeboardid=' + noticeboardid + '&type=geturl&id=' + noteid, doSomethingWithData4);
}


function doSomethingWithData(data) {
    id = parseInt(data);
}

function doSomethingWithData2(data) {
    zmax = parseInt(data);
   }

   function doSomethingWithData3(data) {
   		$('#tb_expirydate').val(data);
 }

 function doSomethingWithData4(data) {
     $('#tb_url').val(data);
 }

 $(function() {
     $("#containment-wrapper [id^=note]").draggable({
         containment: "#containment-wrapper",
         scroll: false,
         stop: function(event, ui) {
             // ajax call to save new position of note
             var left = ($(this).position().left);
             var top = ($(this).position().top);
             var thisid = $(this).attr('id');
             $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=savpos&id=' + thisid + '&left=' + left + '&top=' + top });
         }
     });
     $("#containment-wrapper [id^=note]").resizable({
         containment: "#containment-wrapper",
         stop: function(event, ui) {
             var position = ui.position;
             var width = ui.size.width;
             var height = ui.size.height;
             var thisid = $(this).attr('id');
             if ((position.left + width) > $("#containment-wrapper").width()) {
                 width = $("#containment-wrapper").width() - position.left;
             }
             if ((position.top + height) > $("#containment-wrapper").height()) {
                 height = $("#containment-wrapper").height() - position.top;
             }
             $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=savresize&id=' + thisid + '&width=' + width + '&height=' + height });
         }
     });
     $("#containment-wrapper .bringtofront").click(function() {
         $(this).parent().parent().siblings("#containment-wrapper [id^=note]").each(function() {
             var cur = $(this).css('zIndex');
             zmax = cur > zmax ? $(this).css('zIndex') : zmax;
         });
         $(this).parent().parent().css('zIndex', zmax + 1);
         var thisid = $(this).attr('id');
         thisid = thisid.replace("bringtofront", "")
         $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=changezindex&id=' + thisid + '&zindex=' + (zmax + 1) });
     });

     // if a calendar note we dont want to allow it to resize
     $(".calendardate").resizable('destroy');

     $("#containment-wrapper [id^=note] textarea").autogrow();
     $("#containment-wrapper [id^=note] textarea").change(function() {
         var thisid = $(this).attr('id');
         var thisvalue = $(this).val();
         thisvalue = thisvalue.replace(/\n/g, '[B]');
         $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=updatetext&id=' + thisid + '&content=' + thisvalue });
     });

     $('.window .close').click(function(e) {
         //Cancel the link behavior
         e.preventDefault();

         $('#mask').hide();
         $('.window').hide();
     });

     // expiry date click
     $(".expirylink").click(function(e) {
         e.preventDefault();
         var thisposleft = e.pageX - 8;
         var thispostop = e.pageY + 8;
         var id = $(this).attr('href');
         $(id).css('top', thispostop);
         $(id).css('left', thisposleft);
         $(id).fadeIn(250);
         var myid = $(this).attr('id');
         myid = myid.replace("expiry", "")
         getExpiryDate(myid);
     });

     // url click
     $(".urllink").click(function(e) {
         e.preventDefault();
         var thisposleft = e.pageX - 8;
         var thispostop = e.pageY + 8;
         var id = $(this).attr('href');
         $(id).css('top', thispostop);
         $(id).css('left', thisposleft);
         $(id).fadeIn(250);
         var myid = $(this).attr('id');
         myid = myid.replace("url", "")
         getURL(myid);
     });

 });

function makeNote(typeid, content) {
    // set intial height & width
    var nwidth = 220;
    var nheight = 248;
    // random number to determine random position
    var randomnumber = new String(Math.floor(Math.random() * 201));
    // random number to determine random style
    var randomnumber2 = new String(Math.floor(Math.random() * numofstyles));
    // declare the content container
    var divcontent
    // specify content depending on type
    if (typeid == 1) {
        divcontent = '<div style="z-index:' + zmax + ';width:' + nwidth + 'px;min-height:' + nheight + 'px;" id="note' + id + '" class="note' + randomnumber2 + '">';
        divcontent = divcontent + '<div class="leftshadow"></div>'
        divcontent = divcontent + '<div class="icons">'
        divcontent = divcontent + '<a href="#" title="delete note" onclick="deleteNote(' + id + ')"><img src="/access/images/noticeboard/icons/delete.png" title="delete note" /></a>'
        divcontent = divcontent + '<a href="#" title="change style" id="linkstyle' + id + '" onclick="changeMyStyle(' + id + ',' + randomnumber2 + ');return false;"><img src="/access/images/noticeboard/icons/changestyle.png" title="change style" /></a>'
        divcontent = divcontent + '<a href="#dialogchangeexpiry" title="set expiry" id="expirylink' + id + '"><img src="/access/images/noticeboard/icons/setexpiry.png" title="set expiry" /></a>'
        divcontent = divcontent + '<a href="#dialogchangeurl" title="set url" id="urllink' + id + '" onclick="setURL(' + id + ');"><img src="/access/images/noticeboard/icons/changeurl.png" title="set url" /></a>'
        divcontent = divcontent + '<a title="bring too front" href="#" id="bringtofront' + id + '" class="bringtofront"><img src="/access/images/noticeboard/icons/bringtofront.png" title="bring to front" /></a>'
        divcontent = divcontent + '</div>'
        divcontent = divcontent + '<div class="noteinner"><textarea id="textarea' + id + '" value="' + content + '" onkeyup="updateText(this)">' + content + '</textarea></div>';
        divcontent = divcontent + '</div>'
        $('#containment-wrapper').append(divcontent);
    }
    if (typeid == 2) {
        nheight = 230;
        divcontent = '<div style="z-index:' + zmax + ';width:' + nwidth + 'px;height:' + nheight + 'px;" id="note' + id + '" class="imageuploadpreview">';
        divcontent = divcontent + '<div class="icons">'
        divcontent = divcontent + '<a href="#" title="delete note" onclick="deleteNote(' + id + ')"><img src="/access/images/noticeboard/icons/delete.png" title="delete note" /></a>'
        divcontent = divcontent + '<span id="changeimage' + id + '"><img src="/access/images/noticeboard/icons/changepic.png" title="change image" /></span>'
        divcontent = divcontent + '<a href="#dialogchangeexpiry" title="set expiry" id="expirylink' + id + '" onclick="setExpiry(' + id + ');"><img src="/access/images/noticeboard/icons/setexpiry.png" title="set expiry" /></a>'
        divcontent = divcontent + '<a href="#dialogchangeurl" title="set url" id="urllink' + id + '" onclick="setURL(' + id + ');"><img src="/access/images/noticeboard/icons/changeurl.png" title="set url" /></a>'
        divcontent = divcontent + '<a title="bring too front" href="#" id="bringtofront' + id + '" class="bringtofront"><img src="/access/images/noticeboard/icons/bringtofront.png" title="bring to front" /></a>'
        divcontent = divcontent + '</div>'
        divcontent = divcontent + '<div style="height:' + nheight + '" id="imagepreview' + id + '" class="imageuploadpreviewinner"></div>'
        divcontent = divcontent + '</div>'
        $('#containment-wrapper').append(divcontent);
        createUploader(id);
    }
    if (typeid == 3) {
        nwidth = 180;
        nheight = 170;
        divcontent = '<div style="z-index:' + zmax + ';width:' + nwidth + 'px;min-height:' + nheight + 'px;" id="note' + id + '" class="calendardate"><div class="delete">';
        divcontent = divcontent + '<div class="icons">'
        divcontent = divcontent + '<a href="#" title="delete note" onclick="deleteNote(' + id + ')"><img src="/access/images/noticeboard/icons/delete.png" title="delete note" /></a>'
        divcontent = divcontent + '<a href="#dialogchangeexpiry" title="set expiry" id="expirylink' + id + '" onclick="setExpiry(' + id + ');"><img src="/access/images/noticeboard/icons/setexpiry.png" title="set expiry" /></a>'
        divcontent = divcontent + '<a title="bring too front" href="#" id="bringtofront' + id + '" class="bringtofront"><img src="/access/images/noticeboard/icons/bringtofront.png" title="bring to front" /></a>'
        divcontent = divcontent + '</div>'
        divcontent = divcontent + '<div><input type="text" id="title' + id + '" value="Insert date here"  onkeyup="updateTitle(this)" maxlength="250" /></div>\<div><textarea id="textarea' + id + '" value="' + content + '" onkeyup="updateText(this)">' + content + '</textarea></div>'
        divcontent = divcontent + '</div>'
        $('#containment-wrapper').append(divcontent);
    }
    // make note draggable
    $('#note' + id).draggable({
        containment: "#containment-wrapper",
        scroll: false,
        stop: function(event, ui) {
            var left = ($(this).position().left);
            var top = ($(this).position().top);
            var thisid = $(this).attr('id');
            $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=savpos&id=' + thisid + '&left=' + left + '&top=' + top });
        }
    });
    // make text area autogrow
    $('#textarea' + id).autogrow();
    // when focus is taken off text area then make a ajax call to save text
    $('#textarea' + id).change(function() {
        var thisid = $(this).attr('id');
        var thisvalue = $(this).val();
        thisvalue = thisvalue.replace(/\n/g, '[B]');
        $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=updatetext&id=' + thisid + '&content=' + thisvalue });
    });
    // if type doesnt equal 3 (date) then make the note resizable
    if (typeid != 3) {
        $('#note' + id).resizable({
        containment: "#containment-wrapper",
        stop: function(event, ui) {
            var position = ui.position;
            var width = ui.size.width;
            var height = ui.size.height;
            var thisid = $(this).attr('id');
            if ((position.left + width) > $("#containment-wrapper").width()) {
                width = $("#containment-wrapper").width() - position.left;
            }
            if ((position.top + height) > $("#containment-wrapper").height()) {
                height = $("#containment-wrapper").height() - position.top;
            }
            $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=savresize&id=' + thisid + '&width=' + width + '&height=' + height });
        }
    });
}
    // set the position of the note with the random number generated before
    $('#note' + id).position({
        of: $("#containment-wrapper"),
        my: 'center' + " " + 'center',
        at: 'center' + " " + 'center',
        offset: randomnumber,
        collision: 'none' + ' ' + 'none'
    });
    // bring to front click
    $('#bringtofront' + id).click(function() {
        $(this).parent().parent().siblings('#note' + id).each(function() {
            var cur = $(this).css('zIndex');
            zmax = cur > zmax ? $(this).css('zIndex') : zmax;
        });
        $(this).parent().parent().css('zIndex', zmax + 1);
        var thisid = $(this).attr('id');
        thisid = thisid.replace("bringtofront", "")
        $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=changezindex&id=' + thisid + '&zindex=' + (zmax + 1) });
    });
    // get cordinates/style of note so we can save new note to database using ajax
    var left = ($("#note" + id).position().left);
    var top = ($("#note" + id).position().top);
    var style = $("#note" + id).attr('class');
    // expiry date click
    $('#expirylink' + id).click(function(e) {
        e.preventDefault();
        var thisposleft = e.pageX - 8;
        var thispostop = e.pageY + 8;
        var thishref = $(this).attr('href');
        $(thishref).css('top', thispostop);
        $(thishref).css('left', thisposleft);
        $(thishref).fadeIn(250);
        var thisid = $(this).attr('id');
        thisid = thisid.replace("expirylink", "")
        $('#hf_expirynoteid').val(thisid);
    });
    // url click
    $('#urllink' + id).click(function(e) {
        e.preventDefault();
        var thisposleft = e.pageX - 8;
        var thispostop = e.pageY + 8;
        var thishref = $(this).attr('href');
        $(thishref).css('top', thispostop);
        $(thishref).css('left', thisposleft);
        $(thishref).fadeIn(250);
        var thisid = $(this).attr('id');
        thisid = thisid.replace("urllink", "")
        $('#hf_urlnoteid').val(thisid);
    });
    $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=savnewnote&notetype=' + typeid + '&id=note' + id + '&left=' + left + '&top=' + top + '&style=' + style + '&width=' + nwidth + '&height=' + nheight + '&zindex=' + zmax });
    // update note id so next note created is incremented by 1
    id = id + 1;
    zmax = zmax + 1;
}

function deleteNote(noteid) {
    $('#note' + noteid).remove()
    $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=deletenote&id=note' + noteid });
}

function changeMyStyle(noteid, styleid) {

    $('#linkstyle' + noteid).removeAttr("onclick");

    $('#linkstyle' + noteid).one('click', function() {
        $('#note' + noteid).removeClass('note' + styleid);
        if (styleid > -1 && styleid < numofstyles) {
            styleid = styleid + 1;
            if (styleid == numofstyles) {
                styleid = 0;
            }
        }
        $('#note' + noteid).addClass('note' + styleid);
        changeMyStyle(noteid, styleid);
        $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=changestyle&id=' + noteid + '&style=' + styleid });
    });

}

function updateText(textarea) {
    // This can be cleared if we only want to save on off focus. 
    var thisvalue = $(textarea).val();
    thisvalue = thisvalue.replace(/\n/g, '[B]');
    $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=updatetext&id=' + textarea.id + '&content=' + thisvalue });
}

function updateTitle(textarea) {
    // This can be cleared if we only want to save on off focus. 
    var thisvalue = $(textarea).val();
    thisvalue = thisvalue.replace(/\n/g, '[B]');
    $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=updatetitle&id=' + textarea.id + '&title=' + thisvalue });
   }

   function updateExpiryDate() {
       $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=setexpiry&id=' + $('#hf_expirynoteid').val() + '&expirydate=' + $('#tb_expirydate').val() });
   	$('#mask').hide();
   	$('.window').hide();
}

function updateURL() {
    $.ajax({ url: '/Admin/Ajax/Noticeboard/Default.aspx', type: 'POST', data: 'noticeboardid=' + noticeboardid + '&type=seturl&id=' + $('#hf_urlnoteid').val() + '&url=' + $('#tb_url').val() });
    $('#mask').hide();
    $('.window').hide();
}

function createUploader(noteid) {
    var thumb = $('#imagepreview' + noteid);
    var outerheight = $('#note' + noteid).height();

    new AjaxUpload('changeimage' + noteid, {
        action: '/Admin/Ajax/Noticeboard/Default.aspx?noticeboardid=' + noticeboardid + '&type=uploadimage&id=' + noteid,
        onSubmit: function(file, extension) {
            thumb.attr('style', 'background-image:url(/access/images/noticeboard/ajax-loader.gif);background-repeat:no-repeat;background-position:center;');
        },
        onComplete: function(file, response) {
            thumb.load(function() {
                //thumb.removeClass('imageuploadpreviewinnerloading');
                //thumb.addClass('imageuploadpreviewinner');
                thumb.unbind();
            });
            thumb.attr('style', 'background-image:url(' + response + ');background-repeat:no-repeat;background-position:top left;');
        }
    });
}

function setExpiry() {

}

function setURL() {

}