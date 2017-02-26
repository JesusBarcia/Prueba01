
Partial Class VerNaviera
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Try
            Dim varid As String = "", id As Long = 0
            varid = Me.Request.QueryString("ID")
            If varid = String.Empty Then
                Me.imgNavieraFicha_Logo.ImageUrl = "./images/cross.png"
                Me.lblNavieraFicha_De.Text = "Sin datos"
                Me.lblNavieraFicha_A.Text = "Sin datos"
                Me.lblNavieraFicha_Horario.Text = "Sin datos"
                Me.lblNavieraFicha_DatosContacto.Text = "Sin datos"
                Me.lblNavieraFicha_InformacionReservas.Text = "Sin datos"
            Else
                id = CType(varid, Long)
                Dim obj As New NavieraFicha(id)
                With obj
                    Me.imgNavieraFicha_Logo.ImageUrl = .Logo
                    Me.lblNavieraFicha_De.Text = .De
                    Me.lblNavieraFicha_A.Text = .A
                    Me.lblNavieraFicha_Horario.Text = .Horario
                    Me.lblNavieraFicha_DatosContacto.Text = .DatosContacto
                    Me.lblNavieraFicha_InformacionReservas.Text = .InformacionReservas

                End With

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
