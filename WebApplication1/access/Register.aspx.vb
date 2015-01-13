Partial Class Access_Register
    Inherits System.Web.UI.Page

    Private strReturnURL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strReturnURL = Request("returnurl")
        If strReturnURL = "" Then
            strReturnURL = "/access/user/myprofile.aspx"
        End If
        If Not Page.IsPostBack Then
            If User.Identity.IsAuthenticated Then
                Response.Redirect(strReturnURL)
            End If
        End If
    End Sub

    Sub btnAdd_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If Page.IsValid Then
            If AddUser() Then
                FormsAuthentication.SetAuthCookie(tbUsername.Text, False)
                Response.Redirect(strReturnURL)
            End If
        End If
    End Sub

    Function AddUser() As Boolean
        Dim status As MembershipCreateStatus
        Dim user As MembershipUser = Membership.CreateUser(tbUsername.Text, tbPassword1.Text, tbEmail.Text, Nothing, Nothing, True, status)
        If user Is Nothing Then
            litErrors.Text = GetErrorMessage(status)
            Return False
        Else
            Roles.AddUserToRole(tbUsername.Text, "member")
            Dim userId As Guid = user.ProviderUserKey
            Dim newUser As User = New User
            newUser.UserID = userId
            newUser.Email = tbEmail.Text
            UserManager.AddUser(newUser)
            Return True
        End If
    End Function

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvUsername.ServerValidate
        If Membership.GetUser(tbUsername.Text, False) Is Nothing Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Function GetErrorMessage(ByVal status As MembershipCreateStatus) As String
        Select Case status
            Case MembershipCreateStatus.DuplicateUserName
                GetErrorMessage = "Username already exists. Please enter a different user name."
            Case MembershipCreateStatus.DuplicateEmail
                GetErrorMessage = "A username for that e-mail address already exists. Please enter a different e-mail address."
            Case MembershipCreateStatus.InvalidPassword
                GetErrorMessage = "The password provided is invalid. Please enter a valid password value."
            Case MembershipCreateStatus.InvalidEmail
                GetErrorMessage = "The e-mail address provided is invalid. Please check the value and try again."
            Case MembershipCreateStatus.InvalidAnswer
                GetErrorMessage = "The password retrieval answer provided is invalid. Please check the value and try again."
            Case MembershipCreateStatus.InvalidQuestion
                GetErrorMessage = "The password retrieval question provided is invalid. Please check the value and try again."
            Case MembershipCreateStatus.InvalidUserName
                GetErrorMessage = "The user name provided is invalid. Please check the value and try again."
            Case MembershipCreateStatus.ProviderError
                GetErrorMessage = "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."
            Case MembershipCreateStatus.UserRejected
                GetErrorMessage = "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."
            Case Else
                GetErrorMessage = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
        End Select
    End Function

    Protected Sub btnCheckUsername_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckUsername.Click
        If IsUniqueUsername(tbUsername.Text) Then
            litUsernameStatus.Text = "username available"
        Else
            litUsernameStatus.Text = "username not available"
        End If
    End Sub
End Class
