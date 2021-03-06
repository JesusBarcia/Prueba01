﻿
Partial Class NavieraGestion
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
                    Dim oNaviera As New Naviera(Me.txtID.Value)
                    obj2txt(oNaviera)
                    Me.txtDE.Focus()
                    Me.lblAccion.Text = "MODIFICAR"

                Case "DELETE"
                    Me.btnEnviar.Text = "Borrar"
                    Dim oNaviera As New Naviera(Me.txtID.Value)
                    obj2txt(oNaviera)
                    Me.btnCancelar.Focus()
                    Me.lblAccion.Text = "BORRAR"

                Case "ADD"
                    Me.btnEnviar.Text = "Alta"
                    Me.txtID.Value = 0
                    blancos()
                    Me.txtDE.Focus()
                    Me.lblAccion.Text = "AÑADIR"
            End Select
        End If
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim oNaviera As New Naviera
        Dim cMensaje As String = ""
        oNaviera.ID = Me.txtID.Value
        txt2obj(oNaviera)
        Select Case Me.txtAccion.Value
            Case "EDIT"
                oNaviera.Save()
                cMensaje = "Naviera modificada"
            Case "DELETE"
                oNaviera.Delete()
                cMensaje = "Naviera borrada"
            Case "ADD"
                oNaviera.Save()
                cMensaje = "Naviera añadida"
        End Select

        Response.Redirect("mensaje.aspx?mensaje=" & cMensaje & "&url=navieraListado.aspx")
    End Sub

    Private Sub obj2txt(ByVal oNaviera As Naviera)
        With oNaviera
            Me.txtLOGO.Text = .Logo
            Me.txtDE.Text = .De
            Me.txtA.Text = .A
            Me.txtHorario.Text = .Horario
            Me.txtDatosContacto.Text = .DatosContacto
            Me.txtInformacionReservas.Text = .InformacionReservas
        End With
    End Sub

    Private Sub txt2obj(ByVal oNaviera As Naviera)
        With oNaviera
            .Logo = Me.txtLOGO.Text
            .De = Me.txtDE.Text
            .A = Me.txtA.Text
            .Horario = Me.txtHorario.Text
            .DatosContacto = Me.txtDatosContacto.Text
            .InformacionReservas = Me.txtInformacionReservas.Text
            .Save()
        End With
    End Sub
    Private Sub blancos()
        Me.txtLOGO.Text = ""
        Me.txtDE.Text = ""
        Me.txtA.Text = ""
        Me.txtHorario.Text = ""
        Me.txtDatosContacto.Text = ""
        Me.txtInformacionReservas.Text = ""
    End Sub


End Class
