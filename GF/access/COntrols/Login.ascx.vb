
Partial Class Access_Controls_Login
    Inherits System.Web.UI.UserControl
    Private _redirectURL As String = ""

    Public Event LoginResult(ByVal booAuthorised As Boolean, ByVal strUsername As String)

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Page.IsValid Then
            Dim booValid As Boolean = False
            Dim strUsername As String = tbUsername.Text
            If ValidateUser(strUsername, tbPassword.Text) Then
                booValid = True
            Else
                '// Check if it's an e-mail they have entered and get username from it
                strUsername = Membership.GetUserNameByEmail(tbUsername.Text)
                If ValidateUser(strUsername, tbPassword.Text) Then
                    booValid = True
                Else
                    booValid = False
                End If
            End If
            If booValid Then
                FormsAuthentication.SetAuthCookie(strUsername, False)
                RaiseEvent LoginResult(True, strUsername)
            Else
                Dim csName1 As String = "PopUpScript"
                Dim cstext1 As String = "popDDMessage('Sorry your username could not be found in our system.','Please try again.','messagedderror');"
                If Not Page.ClientScript.IsClientScriptBlockRegistered(csName1) Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, csName1, cstext1, True)
                End If
                RaiseEvent LoginResult(False, strUsername)
            End If
        End If
    End Sub

    Function ValidateUser(username As String, password As String) As Boolean
        If Membership.ValidateUser(username, password) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub btnPasswordRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPasswordRequest.Click
        If Page.IsValid Then
            Dim username As String = Membership.GetUserNameByEmail(tbReminderEmail.Text)
            Dim user As MembershipUser = Membership.GetUser(username)
            If Not user Is Nothing Then
                Dim strBody As String = "Your password is: " & user.GetPassword
                SendEmail("GigsFirst - Password retrieval", "passwordretrieval@gigsfirst.com", user.Email, strBody, "", "text")
                Dim csName1 As String = "PopUpScript"
                Dim cstext1 As String = "popDDMessage('Your password has been e-mailed to you.','Please check your inbox.','messageddsuccess');"
                If Not Page.ClientScript.IsClientScriptBlockRegistered(csName1) Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, csName1, cstext1, True)
                End If
            Else
                Dim csName1 As String = "PopUpScript"
                Dim cstext1 As String = "popDDMessage('Sorry no account associated with this e-mail address could be found in our system.','Please try again.','messagedderror');"
                If Not Page.ClientScript.IsClientScriptBlockRegistered(csName1) Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, csName1, cstext1, True)
                End If
            End If
        End If
    End Sub

End Class
