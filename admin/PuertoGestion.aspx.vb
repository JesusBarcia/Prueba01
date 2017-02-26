
Partial Class PuertoGestion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Me.Request.QueryString("ID") = String.Empty Then
                Me.txtID.Value = "0"
            Else
                Me.txtID.Value = Me.Request.QueryString("ID")
            End If
            If Me.Request.QueryString("Accion") = String.Empty Then
                Me.txtAccion.Value = ""
            Else
                Me.txtAccion.Value = CType(Me.Request.QueryString("Accion"), String).ToUpper
            End If
            Select Case Me.txtAccion.Value
                Case "EDIT"
                    Me.btnEnviar.Text = "Modificar"
                    Dim obj As New Puerto(Me.txtID.Value)
                    obj2txt(obj)
                    Me.txtTerminal.Focus()
                    Me.lblAccion.Text = "MODIFICAR"

                Case "DELETE"
                    Me.btnEnviar.Text = "Borrar"
                    Dim obj As New Puerto(Me.txtID.Value)
                    obj2txt(obj)
                    Me.btnCancelar.Focus()
                    Me.lblAccion.Text = "BORRAR"

                Case "ADD"
                    Me.btnEnviar.Text = "Alta"
                    Me.txtID.Value = 0
                    blancos()
                    Me.txtTerminal.Focus()
                    Me.lblAccion.Text = "AÑADIR"
            End Select
        End If
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim obj As New Puerto
        Dim cMensaje As String = ""
        obj.ID = Me.txtID.Value
        txt2obj(obj)
        Select Case Me.txtAccion.Value
            Case "EDIT"
                obj.Save()
                cMensaje = "Puerto modificado"
            Case "DELETE"
                obj.Delete()
                cMensaje = "Puerto borrado"
            Case "ADD"
                obj.Save()
                cMensaje = "Puerto añadido"
        End Select

        Response.Redirect("mensaje.aspx?mensaje=" & cMensaje & "&url=puertoListado.aspx")
    End Sub

    Private Sub obj2txt(ByVal obj As Puerto)
        With obj
            Me.txtNombre.Text = .Nombre
            Me.txtLOGO.Text = .Logo
            Me.txtTerminal.Text = .Terminal
            Me.txtServiciosComplementarios.Text = .ServiciosComplementarios
            Me.txtDatosContacto.Text = .DatosContacto
            Me.txtInformacionReservas.Text = .InformacionReservas
        End With
    End Sub

    Private Sub txt2obj(ByVal obj As Puerto)
        With obj
            .Nombre = Me.txtNombre.Text
            .Logo = Me.txtLOGO.Text
            .Terminal = Me.txtTerminal.Text
            .ServiciosComplementarios = Me.txtServiciosComplementarios.Text
            .DatosContacto = Me.txtDatosContacto.Text
            .InformacionReservas = Me.txtInformacionReservas.Text
            .Save()
        End With
    End Sub
    Private Sub blancos()
        Me.txtNombre.Text = ""
        Me.txtLOGO.Text = ""
        Me.txtTerminal.Text = ""
        Me.txtServiciosComplementarios.Text = ""
        Me.txtDatosContacto.Text = ""
        Me.txtInformacionReservas.Text = ""
    End Sub


End Class
