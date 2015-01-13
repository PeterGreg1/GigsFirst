Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq

Namespace ControlOverrides

    Public Class customCheckBoxList
        Inherits CheckBoxList
        Public Overrides ReadOnly Property Items() As ListItemCollection
            Get
                Dim l As ListItemCollection = MyBase.Items
                For Each itm As ListItem In l
                    itm.Attributes.Add("alt", itm.Value)
                Next
                Return l
            End Get
        End Property

    End Class

End Namespace
