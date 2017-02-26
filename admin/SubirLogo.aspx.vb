
Partial Class admin_SubirLogo
    Inherits System.Web.UI.Page
    

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim cMensaje As String = ""
        Me.lblError.Text = String.Empty
        If Me.FileUpload.HasFile Then
            If Me.FileUpload.PostedFile.ContentType.ToLower = "image/jpg" Or _
                Me.FileUpload.PostedFile.ContentType.ToLower = "image/jpeg" Or _
                Me.FileUpload.PostedFile.ContentType.ToLower = "image/gif" Or _
                Me.FileUpload.PostedFile.ContentType.ToLower = "image/png" Then
                Me.FileUpload.SaveAs(Server.MapPath("~/Images/") + Me.FileUpload.FileName.ToString)
                Response.Redirect("mensaje.aspx?mensaje=Fichero " & Me.FileUpload.FileName.ToString & " grabado &url=DisposicionListado.aspx?CapituloID=" & ViewState("txtCapituloID"))
            Else
                Me.lblError.Text = "Error. Sólo se admiten  archivos en formato jpg, gif o png"
                Me.lblError.Visible = True
                Exit Sub
            End If
        End If

    End Sub
End Class
