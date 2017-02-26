
Partial Class VerPuerto
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Try
            Dim varid As String = "", id As Long = 0
            varid = Me.Request.QueryString("ID")
            If varid = String.Empty Then

                Me.imgPuertoFicha_Logo.ImageUrl = "./images/cross.png"
                Me.lblPuertoFicha_Terminal.Text = "Sin datos"
                Me.lblPuertoFicha_DatosContacto.Text = "Sin datos"
                Me.lblPuertoFicha_ServiciosComplementarios.Text = "Sin datos"
                Me.lblPuertoFicha_InformacionReservas.Text = "Sin datos"

            Else
                id = CType(varid, Long)
                Dim obj As New PuertoFicha(id)
                With obj
                    Me.imgPuertoFicha_Logo.ImageUrl = .Logo
                    Me.lblPuertoFicha_Terminal.Text = .Terminal
                    Me.lblPuertoFicha_DatosContacto.Text = .DatosContacto
                    Me.lblPuertoFicha_ServiciosComplementarios.Text = .ServiciosComplementarios
                    Me.lblPuertoFicha_InformacionReservas.Text = .InformacionReservas
                End With

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
