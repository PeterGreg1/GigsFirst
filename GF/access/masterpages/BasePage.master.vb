Imports Authentication

Partial Class master_Base
    Inherits System.Web.UI.MasterPage
    'Private DBCalls As New DBCalls()

    Public _PageTitle As String = "Gigs First"

    Public WriteOnly Property PageID() As Integer
        Set(ByVal value As Integer)
           
        End Set
    End Property

    Public WriteOnly Property PageTitle() As String
        Set(ByVal value As String)
            _PageTitle = value
        End Set
    End Property

    Public WriteOnly Property MetaKeywords() As String
        Set(ByVal value As String)
            meta_keywords.Content = value
        End Set
    End Property

    Public WriteOnly Property MetaDescription() As String
        Set(ByVal value As String)
            meta_description.Content = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
           
        End If
    End Sub
End Class

