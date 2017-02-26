Imports System.Collections.Generic

Partial Class LineasGestion
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
            'Cargar datos de Naviera y puertos
            Dim oListaNaviera As List(Of Naviera) = Naviera.Lista
            Dim oListaPuerto As List(Of Puerto) = Puerto.Lista
            Me.cbNavieraFicha.Items.Clear()
            Me.cbNavieraFicha.Items.Add(New ListItem("", 0))
            For Each nav In oListaNaviera
                Me.cbNavieraFicha.Items.Add(New ListItem(nav.De & " - " & nav.A, nav.ID))
            Next

            Me.cbPuertoOrigen.Items.Add(New ListItem("", 0))
            Me.cbPuertoDestino.Items.Add(New ListItem("", 0))
            For Each pue In oListaPuerto
                Me.cbPuertoOrigen.Items.Add(New ListItem(pue.Nombre, pue.ID))
                Me.cbPuertoDestino.Items.Add(New ListItem(pue.Nombre, pue.ID))
            Next
            Select Case Me.txtAccion.Value
                Case "EDIT"
                    Me.btnEnviar.Text = "Modificar"
                    Dim oLinea As New Linea(Me.txtID.Value)
                    obj2txt(oLinea)
                    Me.txtPuertoOrigen.Focus()
                    Me.lblAccion.Text = "MODIFICAR"

                Case "DELETE"
                    Me.btnEnviar.Text = "Borrar"
                    Dim oLinea As New Linea(Me.txtID.Value)
                    obj2txt(oLinea)
                    Me.btnCancelar.Focus()
                    Me.lblAccion.Text = "BORRAR"

                Case "ADD"
                    Me.btnEnviar.Text = "Alta"
                    Me.txtID.Value = 0
                    blancos()
                    Me.txtPuertoOrigen.Focus()
                    Me.lblAccion.Text = "AÑADIR"
            End Select
        End If
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim oLinea As New Linea
        Dim cMensaje As String = ""
        oLinea.ID = Me.txtID.Value
        txt2obj(oLinea)
        Select Case Me.txtAccion.Value
            Case "EDIT"
                oLinea.Save()
                cMensaje = "Linea modificada"
            Case "DELETE"
                oLinea.Delete()
                cMensaje = "Linea borrada"
            Case "ADD"
                oLinea.Save()
                cMensaje = "Linea añadida"
        End Select

        Response.Redirect("mensaje.aspx?mensaje=" & cMensaje & "&url=LineasListado.aspx")
    End Sub

    Private Sub obj2txt(ByVal oLinea As Linea)
        With oLinea
            Me.txtID.Value = .ID
            Me.txtPuertoOrigen.Text = .PuertoOrigen
            Me.txtPuertoOrigenMappoint.Text = .PuertoOrigenMappoint
            Me.txtPuertoOrigenLongitud.Text = .PuertoOrigenLongitud
            Me.txtPuertoOrigenLatitud.Text = .PuertoOrigenLatitud
            Me.cbPuertoOrigen.SelectedValue = .PuertoOrigenObj.ID
            Me.txtPuertoDestino.Text = .PuertoDestino
            Me.txtPuertoDestinoLongitud.Text = .PuertoDestinoLongitud
            Me.txtPuertoDestinoLatitud.Text = .PuertoDestinoLatitud
            Me.txtPuertoDestinoMappoint.Text = .PuertoDestinoMappoint
            Me.cbPuertoDestino.SelectedValue = .PuertoDestinoObj.ID
            Me.txtLinea.Text = .Linea
            Me.txtNaviera.Text = .Naviera
            Me.cbNavieraFicha.SelectedValue = .NavieraFicha.ID
            Me.cbFrecuencia.SelectedValue = .FrecuenciaMensual
            Me.cbFrecuencia.Text = .Frecuencia
            Me.cbTipoTrafico.SelectedValue = .TipoTrafico
            Me.txtDistanciaEnMillas.Text = .DistanciaMillas
            Me.txtTiempoPuertoOrigen.Text = .TiempoPuertoOrigen
            Me.txtTiempoTransito.Text = .TiempoTransito
            Me.txtTiempoPuertoDestino.Text = .TiempoPuertoDestino
            Me.txtFleteMaritimo.Text = .FleteMaritimo
            Me.txtRecargoCabezaTractora.Text = .RecargoCabezaTractora
            Me.txtRecargoBAF.Text = .RecargoBAF
            Me.txtRecargoMercanciaPeligrosa.Text = .RecargoMercanciaPeligrosa
            Me.txtRecargoCCRR.Text = .RecargoCCRR
            Me.txtCapPlataformas.Text = .CapPlataformas
            Me.txtCapPasajeros.Text = .CapPasajeros
            Me.txtCapCoches.Text = .CapCoches
            Me.cbFachada.SelectedValue = .Fachada
            Me.txtVisible.Checked = .Visible
            Me.txtEnlaceComodalWeb.Text = .EnlaceComodalWeb
            Me.cbFleteMensaje.SelectedValue = .FleteMensaje
        End With
    End Sub

    Private Sub txt2obj(ByVal oLinea As Linea)
        With oLinea
            .ID = Me.txtID.Value
            .PuertoOrigen = Me.txtPuertoOrigen.Text
            .PuertoOrigenMappoint = Me.txtPuertoOrigenMappoint.Text
            .PuertoOrigenLongitud = CType(Me.txtPuertoOrigenLongitud.Text, Double)
            .PuertoOrigenLatitud = CType(Me.txtPuertoOrigenLatitud.Text, Double)
            .PuertoOrigenObj.ID = Me.cbPuertoOrigen.SelectedValue
            .PuertoDestino = Me.txtPuertoDestino.Text
            .PuertoDestinoMappoint = Me.txtPuertoDestinoMappoint.Text
            .PuertoDestinoLongitud = CType(Me.txtPuertoDestinoLongitud.Text, Double)
            .PuertoDestinoLatitud = CType(Me.txtPuertoDestinoLatitud.Text, Double)
            .PuertoDestinoObj.ID = Me.cbPuertoDestino.SelectedValue
            .Linea = Me.txtLinea.Text
            .Naviera = Me.txtNaviera.Text
            .NavieraFicha.ID = Me.cbNavieraFicha.SelectedValue
            .FrecuenciaMensual = Me.cbFrecuencia.SelectedItem.Value
            .Frecuencia = Me.cbFrecuencia.SelectedItem.Text
            .TipoTrafico = Me.cbTipoTrafico.SelectedValue
            .DistanciaMillas = Me.txtDistanciaEnMillas.Text
            .TiempoPuertoOrigen = Me.txtTiempoPuertoOrigen.Text
            .TiempoTransito = Me.txtTiempoTransito.Text
            .TiempoPuertoDestino = Me.txtTiempoPuertoDestino.Text
            .FleteMaritimo = Me.txtFleteMaritimo.Text
            .RecargoCabezaTractora = Me.txtRecargoCabezaTractora.Text
            .RecargoBAF = Me.txtRecargoBAF.Text
            .RecargoMercanciaPeligrosa = Me.txtRecargoMercanciaPeligrosa.Text
            .RecargoCCRR = Me.txtRecargoCCRR.Text
            .CapPlataformas = Me.txtCapPlataformas.Text
            .CapPasajeros = Me.txtCapPasajeros.Text
            .CapCoches = Me.txtCapCoches.Text
            .Fachada = Me.cbFachada.SelectedValue
            .Visible = Me.txtVisible.Checked
            .EnlaceComodalWeb = Me.txtEnlaceComodalWeb.Text
            .FleteMensaje = Me.cbFleteMensaje.SelectedItem.Text
            .Save()
        End With
    End Sub
    Private Sub blancos()
        Me.txtID.Value = "0"
        Me.txtPuertoOrigen.Text = ""
        Me.txtPuertoOrigenLongitud.Text = "0"
        Me.txtPuertoOrigenLatitud.Text = "0"
        Me.txtPuertoOrigenMappoint.Text = ""
        Me.cbPuertoOrigen.SelectedValue = ""
        Me.txtPuertoDestino.Text = ""
        Me.txtPuertoDestinoLongitud.Text = "0"
        Me.txtPuertoDestinoLatitud.Text = "0"
        Me.txtPuertoDestinoMappoint.Text = ""
        Me.cbPuertoDestino.SelectedValue = ""
        Me.txtLinea.Text = ""
        Me.txtNaviera.Text = ""
        Me.cbNavieraFicha.SelectedValue = ""
        Me.cbFrecuencia.SelectedValue = ""
        Me.cbFrecuencia.Text = ""
        Me.cbTipoTrafico.SelectedValue = ""
        Me.txtDistanciaEnMillas.Text = "0"
        Me.txtTiempoPuertoOrigen.Text = "0"
        Me.txtTiempoTransito.Text = "0"
        Me.txtTiempoPuertoDestino.Text = "0"
        Me.txtFleteMaritimo.Text = "0"
        Me.txtRecargoCabezaTractora.Text = "0"
        Me.txtRecargoBAF.Text = "0"
        Me.txtRecargoMercanciaPeligrosa.Text = "0"
        Me.txtRecargoCCRR.Text = "0"
        Me.txtCapPlataformas.Text = "0"
        Me.txtCapPasajeros.Text = "0"
        Me.txtCapCoches.Text = "0"
        Me.cbFachada.SelectedValue = ""
        Me.txtVisible.Checked = False
        Me.txtEnlaceComodalWeb.Text = ""
        Me.cbFleteMensaje.SelectedValue = ""
    End Sub


End Class
