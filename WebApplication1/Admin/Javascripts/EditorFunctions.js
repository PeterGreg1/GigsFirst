function ShowMyImageDialog(button, width, padding)
{
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor=CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/imagepicker.aspx?width=" + width + "&padding=" + padding, editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowMyFlashDialog(button)
{
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor=CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/flashpicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowMyVideoDialog(button)
{
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor=CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/videopicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowLocalFileDialog(button) {
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor = CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/SharedFileLinkPicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowInternalLinkDialog(button) {
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor = CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/internallinkpicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowInternalFileLinkDialog(button) {
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor = CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(null, "/admin/popups/internalfilelinkpicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowExternalLinkDialog(button) {
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor = CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(this, "/admin/popups/localfilelinkpicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}
function ShowGoogleMapDialog(button) {
    //use CuteEditor_GetEditor(elementinsidetheEditor) to get the cute editor instance
    var editor = CuteEditor_GetEditor(button);
    //show the dialog page , and pass the editor as newwin.dialogArguments
    //(handler,url,args,feature)
    var newwin = editor.ShowDialog(this, "/admin/popups/googlemappicker.aspx", editor, "dialogWidth:840px;dialogHeight:500px;resizable:1;scrollLeft:1;");
}