Imports System.Net
Imports System.IO
Imports System.Drawing

Partial Class Access_Register
    Inherits System.Web.UI.Page

    Private userId As Guid
    Private strReturnURL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strReturnURL = Request("returnurl")
        If strReturnURL = "" Then
            strReturnURL = "/access/user/myprofile.aspx"
        End If
        If Not Page.IsPostBack Then
            Dim accessToken As String = Request("accessToken")
            If accessToken <> "" Then
                hfAccessCode.Value = accessToken
                Session("accessToken") = accessToken
                Dim facebookUser As User = FacebookManager.GetFacebookUser(accessToken)
                If Not (facebookUser Is Nothing) Then
                    Dim myUser As User = UserManager.GetOAuthUser(facebookUser.OAuthID, "facebook")
                    If Not (myUser Is Nothing) Then
                        FormsAuthentication.SetAuthCookie(myUser.Username, False)
                        Response.Redirect(strReturnURL)
                    Else
                        '// Check if already has exisitng account
                        Dim strUsername As String = Membership.GetUserNameByEmail(facebookUser.Email)
                        If strUsername = "" Then
                            upCompleteRegistration.Visible = True
                        Else
                            upVerifyAccount.Visible = True
                        End If
                    End If
                Else
                    'TODO: trap error
                End If
            Else
                'TODO:
            End If
        End If
    End Sub

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If Page.IsValid Then
            CompleteRegistration()
            FindFriends()
            Response.Redirect(strReturnURL)
        End If
    End Sub

    Sub CompleteRegistration()
        Dim accessToken As String = hfAccessCode.Value
        If accessToken <> "" Then
            Dim facebookUser As User = FacebookManager.GetFacebookUser(accessToken)
            If Not (facebookUser Is Nothing) Then
                Dim strUsername As String = CheckUsername(facebookUser.Username)
                Dim status As MembershipCreateStatus
                Dim strPassword As String = ""
                If tbPassword1.Text = "" AndAlso tbPassword2.Text = "" Then
                    strPassword = Membership.GeneratePassword(10, 0)
                Else
                    strPassword = tbPassword1.Text
                End If
                Dim user As MembershipUser = Membership.CreateUser(strUsername, strPassword, facebookUser.Email, Nothing, Nothing, True, status)
                If user Is Nothing Then
                    'TODO: error trap
                    ' Response.Write(GetErrorMessage(status))
                Else
                    Roles.AddUserToRole(strUsername, "member")
                    userId = user.ProviderUserKey
                    Dim newUser As User = New User
                    newUser.UserID = userId
                    newUser.Email = facebookUser.Email
                    newUser.Firstname = facebookUser.Firstname
                    newUser.Lastname = facebookUser.Lastname
                    newUser.OAuthID = facebookUser.OAuthID
                    newUser.OAuthType = "facebook"
                    UserManager.AddUser(newUser)
                    UserManager.AddOAuthUser(newUser)
                    UploadImage(facebookUser.OAuthID, userId.ToString)
                    FormsAuthentication.SetAuthCookie(facebookUser.Username, False)
                End If
            Else
                'TODO:
            End If
        End If
    End Sub

    Sub FindFriends()
        Dim facebookfriends As UserList = FacebookManager.GetFacebookUserFriends(Session("accessToken"))
        If Not (facebookfriends Is Nothing) Then
            Dim userList As UserList = UserManager.GetRegisteredOAuthFriends(facebookfriends, "facebook")
            UserManager.AddFollow(userId, userList)
        End If
    End Sub

    Function CheckUsername(ByVal username As String, Optional ByVal Attempts As Integer = 1) As String
        If IsUniqueUsername(username) Then
            Return username
        Else
            Select Case Attempts
                Case 1
                    Return CheckUsername(username & Year(DateTime.Now), 2)
                Case Else
                    Return CheckUsername(username & Year(DateTime.Now) & Hour(DateTime.Now) & Minute(DateTime.Now) & Second(DateTime.Now), 3)
            End Select
        End If
    End Function

    Sub HandleAuthorisation(ByVal result As Boolean, ByVal username As String) Handles login1.LoginResult
        If result = True Then
            Dim user As MembershipUser = Membership.GetUser(username)
            If Not user Is Nothing Then
                Dim facebookUser As User = FacebookManager.GetFacebookUser(hfAccessCode.Value)
                If Not facebookUser Is Nothing Then
                    Dim newUser As User = New User
                    newUser.UserID = user.ProviderUserKey
                    newUser.OAuthID = facebookUser.OAuthID
                    newUser.OAuthType = "facebook"
                    UserManager.AddOAuthUser(newUser)
                    userId = user.ProviderUserKey
                    FindFriends()
                    Response.Redirect(strReturnURL)
                Else
                    'TODO:
                End If
            Else
                'TODO:
            End If
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

    Sub UploadImage(ByVal profileid As String, ByVal userid As String)
        Dim url As String = "http://graph.facebook.com/" & profileid & "/picture?type=large"
        Dim filename As String = url.Substring(url.LastIndexOf("/"c) + 1)
        Dim bytes As Byte() = GetBytesFromUrl(url)
        WriteBytesToFile(Server.MapPath("/uploads") + "/" & userid & ".jpg", bytes)
    End Sub

    Public Shared Function GetBytesFromUrl(ByVal url As String) As Byte()
        Dim b As Byte()
        Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Dim myResp As WebResponse = myReq.GetResponse()
        Dim stream As Stream = myResp.GetResponseStream()
        Using br As New BinaryReader(stream)
            b = br.ReadBytes(500000)
            br.Close()
        End Using
        myResp.Close()
        Return b
    End Function

    Public Shared Sub WriteBytesToFile(ByVal fileName As String, ByVal content As Byte())
        Dim fs As New FileStream(fileName, FileMode.Create)
        Dim w As New BinaryWriter(fs)
        Try
            w.Write(content)
        Finally
            fs.Close()
            w.Close()
        End Try
    End Sub


End Class
