
Partial Class admin_Mensaje
    Inherits System.Web.UI.Page
    Public url As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblMensaje.Text = Me.Request.QueryString("mensaje")
        url = Me.Request.QueryString("URL")
    End Sub
End Class