
Partial Class SimuladorOLD
    Inherits System.Web.UI.Page
    Dim miViaje As viaje

    Public P_PuertoOrigenEnlace As String = ""
    Public P_PuertoDestinoEnlace As String = ""
    Public P_NavieraEnlace As String = ""
    Const C_PanelSimulador As Long = 1320
    Const C_PanelParametrosHeight As Long = 600
    Const C_PanelBotonesHeight As Long = 60
    Const C_PanelResumenHeight As Long = 90
    Const C_PanelResultadosHeight As Long = 480
    Const C_PanelLogoFomentoHeight As Long = 90

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Try
                Me.txtVelocidad.Text = Datos.ConfiguracionLeer("velocidad")
                Me.txtVelocidadAcarreoOrigen.Text = Datos.ConfiguracionLeer("velocidadAcarreoOrigen")
                Me.txtVelocidadAcarreoDestino.Text = Datos.ConfiguracionLeer("velocidadAcarreoDestino")
                Me.txtCosteKm.Text = Datos.ConfiguracionLeer("costekm")
                Me.txtCosteKmAcarreoOrigen.Text = Datos.ConfiguracionLeer("costeKmAcarreoOrigen")
                Me.txtCosteKmAcarreoDestino.Text = Datos.ConfiguracionLeer("costeKmAcarreoDestino")
                Me.txtToneladasTransportadas.Text = Datos.ConfiguracionLeer("toneladasTransportadas")
                Me.txtPeajes.Text = "0"
                Dim dt As Data.DataTable = viaje.TodosPuertos

                Me.txtListBoxLineas.Items.Add(New ListItem("TODAS", "TODAS"))
                Me.txtListBoxLineas.Items.Add(New ListItem("RECOMENDADAS", "RECOMENDADAS"))
                'Me.txtListBoxLineas.Items.Add(New ListItem("EN SERVICIO", "ENSERVICIO"))
                'Me.txtListBoxLineas.Items.Add(New ListItem("EN ESTUDIO", "EN ESTUDIO"))

                For Each dr In dt.Rows
                    Me.txtListBoxLineas.Items.Add(New ListItem(dr.Item("PuertoOrigen") + " ↔ " & dr.Item("PuertoDestino") & " a través de " & dr.Item("Naviera"), dr.Item("ID")))
                Next
                Me.txtListBoxLineas.Items(0).Selected = True
                Me.PanelParametros.Height = New System.Web.UI.WebControls.Unit(C_PanelParametrosHeight)
                Me.PanelBotones.Height = New System.Web.UI.WebControls.Unit(C_PanelBotonesHeight)
                Me.PanelResumen.Height = New System.Web.UI.WebControls.Unit(1)
                Me.PanelResultados.Height = New System.Web.UI.WebControls.Unit(1)
                Me.panelLogoFomento.Height = New System.Web.UI.WebControls.Unit(C_PanelLogoFomentoHeight)
                Me.PanelSimulador.Height = New System.Web.UI.WebControls.Unit( _
                                           C_PanelParametrosHeight + _
                                           C_PanelBotonesHeight + _
                                           C_PanelLogoFomentoHeight + _
                                           5)

                Me.PanelResumen.Visible = False
                Me.PanelResultados.Visible = False
                Me.txtOrigen.Focus()

            Catch ex As Exception
                LabelError.Text = ex.Message
            End Try
        End If
    End Sub

    Private Function Validar() As Boolean
        Me.LabelError.Text = String.Empty
        If Me.htxtOrigenLarge.Value = String.Empty Then
            Me.LabelError.Text = "Error en Origen"
            Me.txtOrigen.Focus()
            Return False
            Exit Function
        End If
        If Me.htxtDestinoLarge.Value = String.Empty Then
            Me.LabelError.Text = "Error en Destino"
            Me.txtDestino.Focus()
            Return False
            Exit Function
        End If
        If Me.txtToneladasTransportadas.Text = String.Empty Then
            Me.LabelError.Text = "Error toneladas transportadas"
            Me.txtToneladasTransportadas.Focus()
            Return False
            Exit Function
        End If
        If Me.txtCosteKm.Text = String.Empty Then
            Me.LabelError.Text = "Error en Coste Km"
            Me.txtCosteKm.Focus()
            Return False
            Exit Function
        End If
        If Me.txtCosteKmAcarreoOrigen.Text = String.Empty Then
            Me.LabelError.Text = "Error en Coste Km Accareo Origen"
            Me.txtCosteKmAcarreoOrigen.Focus()
            Return False
            Exit Function
        End If
        If Me.txtCosteKmAcarreoDestino.Text = String.Empty Then
            Me.LabelError.Text = "Error en Coste Km Accareo Destino"
            Me.txtCosteKmAcarreoDestino.Focus()
            Return False
            Exit Function
        End If
        If Me.txtVelocidad.Text = String.Empty Then
            Me.LabelError.Text = "Error en velocidad"
            Me.txtVelocidad.Focus()
            Return False
            Exit Function
        End If
        If Me.txtVelocidadAcarreoOrigen.Text = String.Empty Then
            Me.LabelError.Text = "Error en velocidad acarreo Origen"
            Me.txtVelocidadAcarreoOrigen.Focus()
            Return False
            Exit Function
        End If
        If Me.txtVelocidadAcarreoDestino.Text = String.Empty Then
            Me.LabelError.Text = "Error en velocidad acarreo Destino"
            Me.txtVelocidadAcarreoDestino.Focus()
            Return False
            Exit Function
        End If
        If Me.txtPeajes.Text = String.Empty Then
            Me.txtPeajes.Text = "0"
        End If
        Return True
    End Function

    Protected Sub btCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Try

            If Not Me.Validar Then
                Exit Sub
            End If
            Me.txtOrigen.Text = Funciones.StringNormalizar(Me.txtOrigen.Text)
            Me.txtDestino.Text = Funciones.StringNormalizar(Me.txtDestino.Text)
            Me.htxtOrigen.Value = Funciones.StringNormalizar(Me.htxtOrigen.Value)
            Me.htxtDestino.Value = Funciones.StringNormalizar(Me.htxtDestino.Value)
            Me.txtOrigenLarge.Text = Funciones.StringNormalizar(Me.htxtOrigenLarge.Value)
            Me.txtDestinoLarge.Text = Funciones.StringNormalizar(Me.htxtDestinoLarge.Value)
            Me.htxtOrigenLarge.Value = Funciones.StringNormalizar(Me.htxtOrigenLarge.Value)
            Me.htxtDestinoLarge.Value = Funciones.StringNormalizar(Me.htxtDestinoLarge.Value)

            Me.PanelResumen.Visible = True
            Me.PanelResultados.Height = New System.Web.UI.WebControls.Unit(480)
            Me.PanelResultados.Visible = True

            Me.PanelParametros.Height = New System.Web.UI.WebControls.Unit(C_PanelParametrosHeight)
            Me.PanelBotones.Height = New System.Web.UI.WebControls.Unit(C_PanelBotonesHeight)
            Me.PanelResumen.Height = New System.Web.UI.WebControls.Unit(C_PanelResumenHeight)
            Me.PanelResultados.Height = New System.Web.UI.WebControls.Unit(C_PanelResultadosHeight)
            Me.panelLogoFomento.Height = New System.Web.UI.WebControls.Unit(C_PanelLogoFomentoHeight)
            Me.PanelSimulador.Height = New System.Web.UI.WebControls.Unit( _
                                       C_PanelParametrosHeight + _
                                       C_PanelBotonesHeight + _
                                       C_PanelResumenHeight + _
                                       C_PanelResultadosHeight + _
                                       C_PanelLogoFomentoHeight)


            CalcularResultados()
            PintarResultadosTerrestre()
            PintarResultadosTotales()
            'btImprimir.Visible = True
            'Page.MaintainScrollPositionOnPostBack = True
            Page.SetFocus(Me.LabelTituloTotales)

        Catch ex As Exception
            Me.LabelError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCalcularMapa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcularMapa.Click
        Try
            If Not Me.Validar Then
                Exit Sub
            End If
            Me.txtOrigen.Text = Funciones.StringNormalizar(Me.txtOrigen.Text)
            Me.txtDestino.Text = Funciones.StringNormalizar(Me.txtDestino.Text)
            Me.htxtOrigen.Value = Funciones.StringNormalizar(Me.htxtOrigen.Value)
            Me.htxtDestino.Value = Funciones.StringNormalizar(Me.htxtDestino.Value)
            Me.txtOrigenLarge.Text = Funciones.StringNormalizar(Me.htxtOrigenLarge.Value)
            Me.txtDestinoLarge.Text = Funciones.StringNormalizar(Me.htxtDestinoLarge.Value)
            Me.htxtOrigenLarge.Value = Funciones.StringNormalizar(Me.htxtOrigenLarge.Value)
            Me.htxtDestinoLarge.Value = Funciones.StringNormalizar(Me.htxtDestinoLarge.Value)
            CalcularResultados()
            PintarResultadosTerrestre()
            PintarResultadosTotales()
            'miViaje.WhereMisViajesCondicion = CalcularWhereCondicion()

            Response.Redirect(".\Navegador.aspx", False)
        Catch ex As Exception
            Me.LabelError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btNuevaSimulacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevaSimulacion.Click
        Me.Response.Redirect(Me.Request.Path)
    End Sub

    Public Sub seleccionar(ByVal sender As Object, ByVal e As DataListCommandEventArgs)
        miViaje = Session("miViaje")
        PintarResultadosTerrestre()
        Dim dt As Data.DataTable = miViaje.misViajes
        Me.DataList1.DataSource = dt
        If e.CommandArgument = "+" Then
            Me.DataList1.SelectedIndex = e.Item.ItemIndex
        Else
            Me.DataList1.SelectedIndex = -1
        End If
        Me.DataList1.DataBind()
        Me.DataList1.Visible = True
        Page.MaintainScrollPositionOnPostBack = True
        Page.SetFocus(Me.DataList1)
    End Sub


    Private Sub CalcularResultados()
        miViaje = New viaje(Me.htxtOrigenLarge.Value, Me.htxtDestinoLarge.Value) 'cOrigen, cDestino)
        miViaje.origenOriginal = Me.htxtOrigen.Value
        miViaje.destinoOriginal = Me.htxtDestino.Value
        miViaje.costeKm = Funciones.Coma2Punto(Me.txtCosteKm.Text)
        miViaje.costeKmAcarreoOrigen = Funciones.Coma2Punto(Me.txtCosteKmAcarreoOrigen.Text)
        miViaje.costeKmAcarreoDestino = Funciones.Coma2Punto(Me.txtCosteKmAcarreoDestino.Text)
        miViaje.Velocidad = CType(Funciones.Coma2Punto(Me.txtVelocidad.Text), Single)
        miViaje.VelocidadAcarreoOrigen = CType(Funciones.Coma2Punto(Me.txtVelocidadAcarreoOrigen.Text), Single)
        miViaje.VelocidadAcarreoDestino = CType(Funciones.Coma2Punto(Me.txtVelocidadAcarreoDestino.Text), Single)
        miViaje.Peajes = CType(Funciones.Coma2Punto(Me.txtPeajes.Text), Double)
        miViaje.toneladasTransportadas = CType(Funciones.Coma2Punto(Me.txtToneladasTransportadas.Text), Double)
        miViaje.costeExternoKmTnCarretera = Funciones.Coma2Punto(Datos.ConfiguracionLeer("costeExternoCarretera"))
        miViaje.costeExternoKmTnMaritimo = Funciones.Coma2Punto(Datos.ConfiguracionLeer("costeExternoMaritimo"))
        miViaje.costeEmisionCO2KmTnCarretera = Funciones.Coma2Punto(Datos.ConfiguracionLeer("costeEmisionCO2Carretera"))
        miViaje.costeEmisionCO2KmTnMaritimo = Funciones.Coma2Punto(Datos.ConfiguracionLeer("costeEmisionCO2Maritimo"))

        miViaje.FachadaAtlantica = Me.txtFachadaAtlantica.Checked
        miViaje.FachadaMediterranea = Me.txtFachadaMediterranea.Checked
        miViaje.FachadaCantabrica = Me.txtFachadaCantabrica.Checked

        miViaje.AltaFrecuencia = Me.txtAltaFrecuencia.Checked

        miViaje.RecargoMercanciaPeligrosa = Me.txtRecargoMercanciaPeligrosa.Checked
        miViaje.RecargoRefrigerado = Me.txtRecargoRefrigerado.Checked
        miViaje.CarreteraHoras = 0 'CType(Me.txtCarreteraHoras.Text, Single)
        miViaje.WhereMisViajes = CalcularWhere()
        miViaje.WhereMisViajesCondicion = CalcularWhereCondicion()
        miViaje.CalcularMisViajes()
        If Me.rbDistancia.Checked Then
            'criterioRecomendado = " ( DistanciaTotal<=" + CType(miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
            miViaje.ResultadosOrden = "DistanciaTotal"
        End If
        If Me.RBCoste.Checked Then
            'criterioRecomendado = " ( CosteTotal<=" + CType(miViaje.costeKm * miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
            miViaje.ResultadosOrden = "CosteTotal"
        End If
        If Me.RBTiempo.Checked Then
            'criterioRecomendado = " ( TiempoTotal<=" + CType(miViaje.tiempoTerrestre, String).Replace(",", ".") & " ) "
            miViaje.ResultadosOrden = "TiempoTotal"
        End If
        Session("miViaje") = miViaje
    End Sub
    Private Function CalcularWhereCondicion() As String
        Dim criterioRecomendado As String = ""
        'CriterioRecomendado
        If Me.txtListBoxLineas.Items(1).Selected Then 'RECOMENDADAS
            If Me.rbDistancia.Checked Then
                criterioRecomendado = " ( DistanciaTotal<=" + CType(miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
                miViaje.ResultadosOrden = "DistanciaTotal"
            End If
            If Me.RBCoste.Checked Then
                criterioRecomendado = " ( CosteTotal<=" + CType(miViaje.costeKm * miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
                miViaje.ResultadosOrden = "CosteTotal"
            End If
            If Me.RBTiempo.Checked Then
                criterioRecomendado = " ( TiempoTotal<=" + CType(miViaje.tiempoTerrestre, String).Replace(",", ".") & " ) "
                miViaje.ResultadosOrden = "TiempoTotal"
            End If
        End If
        Return criterioRecomendado
    End Function


    Private Function CalcularWhere() As String

        Dim criterioAltaFrecuencia As String = ""
        Dim criterioFachada As String = ""
        Dim criterioIDLinea As String = ""
        Dim x As Integer = 0, filtro As String = ""


        'CriterioIDLinea
        For x = 2 To Me.txtListBoxLineas.Items.Count - 1
            If Me.txtListBoxLineas.Items(x).Selected Then
                If criterioIDLinea <> String.Empty Then criterioIDLinea += " OR "
                criterioIDLinea += "LineaID=" + Me.txtListBoxLineas.Items(x).Value + " "
            End If
        Next
        If criterioIDLinea <> String.Empty Then
            criterioIDLinea = "( " & criterioIDLinea & ")"
        End If

        'CriterioAltaFrecuencia
        If Me.txtAltaFrecuencia.Checked Then
            criterioAltaFrecuencia = " (FrecuenciaMensual>=" & Funciones.Coma2Punto(Datos.ConfiguracionLeer("AltaFrecuencia")) & ") "
        End If

        'CriterioFachada
        If Me.txtFachadaAtlantica.Checked Then
            criterioFachada = " Fachada='ATLANTICA' "
        End If
        If Me.txtFachadaMediterranea.Checked Then
            If criterioFachada <> String.Empty Then criterioFachada += " OR "
            criterioFachada += " Fachada='MEDITERRANEA' "
        End If
        If Me.txtFachadaCantabrica.Checked Then
            If criterioFachada <> String.Empty Then criterioFachada += " OR "
            criterioFachada += " Fachada='CANTABRICA' "
        End If
        If criterioFachada <> String.Empty Then criterioFachada = "( " & criterioFachada & ") "


        Dim cWhere As String
        cWhere = criterioIDLinea
        If criterioAltaFrecuencia <> String.Empty Then
            If cWhere <> String.Empty Then cWhere += " AND "
            cWhere += criterioAltaFrecuencia
        End If
        If criterioFachada <> String.Empty Then
            If cWhere <> String.Empty Then cWhere += " AND "
            cWhere += criterioFachada
        End If

        Return cWhere

    End Function
    Private Sub PintarResultadosTerrestre()
        Try
            Encabezado(Me.TablaResultadosTerrestre)
            Me.LabelTituloTerrestre.Visible = True
            Dim r As New TableRow
            Dim celda(5) As TableCell
            celda(0) = New TableCell : celda(0).Text = miViaje.origenOriginal & " -- " & miViaje.destinoOriginal
            celda(1) = New TableCell() : celda(1).Text = CType(miViaje.costeKm * miViaje.distanciaTerrestre + miViaje.Peajes, Decimal).ToString("N0")
            celda(2) = New TableCell() : celda(2).Text = CType(miViaje.tiempoTerrestre, Decimal).ToString("F1")
            celda(3) = New TableCell() : celda(3).Text = CType(miViaje.distanciaTerrestre, Decimal).ToString("N0")
            celda(4) = New TableCell() : celda(4).Text = CType(miViaje.distanciaTerrestre * miViaje.costeExternoKmTnCarretera * miViaje.toneladasTransportadas, Decimal).ToString("N0")
            celda(5) = New TableCell() : celda(5).Text = CType(miViaje.distanciaTerrestre * miViaje.costeEmisionCO2KmTnCarretera * miViaje.toneladasTransportadas, Decimal).ToString("N0")


            celda(0).CssClass = "txtverdanasmall"
            celda(1).CssClass = "txtverdanasmallderecha"
            celda(2).CssClass = "txtverdanasmallderecha"
            celda(3).CssClass = "txtverdanasmallderecha"
            celda(4).CssClass = "txtverdanasmallderechaverde"
            celda(5).CssClass = "txtverdanasmallderechaverde"
            r.Cells.AddRange(celda)
            Me.TablaResultadosTerrestre.Rows.Add(r)
        Catch ex As Exception
            LabelError.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Sub PintarResultadosTotales()
        Try
            Dim criterioRecomendado As String = ""
            Dim criterioAltaFrecuencia As String = ""
            Dim criterioFachada As String = ""
            Dim criterioIDLinea As String = ""
            Dim x As Integer = 0, filtro As String = ""

            Dim dt As Data.DataTable = miViaje.misViajes
            Dim dr As Data.DataRow

            Me.LabelTituloTotales.Visible = True
            Me.LabelTituloTotales.Text = "Transporte Intermodal con líneas marítimas existentes."

            For Each dr In dt.Rows
                Dim coste As Single
                coste = dr.Item("CosteTotalsinRecargos")
                If Me.txtRecargoRefrigerado.Checked = True Then coste += dr.Item("RecargoRefrigerado")
                If Me.txtRecargoMercanciaPeligrosa.Checked = True Then coste += dr.Item("RecargoMercanciaPeligrosa")
                If Me.txtRecargoCabezaTractora.Checked = True Then coste += dr.Item("RecargoCabezaTractora")
                dr.Item("CosteTotal") = coste
            Next

            'CriterioRecomendado
            If Me.rbDistancia.Checked Then
                dt.DefaultView.Sort = "DistanciaTotal"
                criterioRecomendado = " ( DistanciaTotal<=" + CType(miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
            End If
            If Me.RBCoste.Checked Then
                dt.DefaultView.Sort = "CosteTotal"
                criterioRecomendado = " ( CosteTotal<=" + CType(miViaje.costeKm * miViaje.distanciaTerrestre, String).Replace(",", ".") & " ) "
            End If
            If Me.RBTiempo.Checked Then
                dt.DefaultView.Sort = "TiempoTotal"
                criterioRecomendado = " ( TiempoTotal<=" + CType(miViaje.tiempoTerrestre, String).Replace(",", ".") & " ) "
            End If


            If Not Me.txtListBoxLineas.Items(0).Selected Then 'TODAS
                If Me.txtListBoxLineas.Items(1).Selected Then 'RECOMENDADAS
                    filtro = criterioRecomendado
                End If
            End If
            If filtro <> String.Empty Then
                dt.DefaultView.RowFilter = filtro
            End If
            dt.TableName = "Resultados"
            Me.DataList1.DataSource = dt.DefaultView
            Me.DataList1.DataBind()

            If dt.DefaultView.ToTable.Rows.Count = 0 Then
                Me.LabelErrorDataList.Text = "No se han encontrado datos que cumplan los criterios seleccionados"
                Me.LabelErrorDataList.Visible = True
                Me.DataList1.Visible = False
            Else
                Me.LabelErrorDataList.Text = ""
                Me.LabelErrorDataList.Visible = False
                Me.DataList1.Visible = True
            End If

        Catch ex As Exception
            LabelError.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Sub Encabezado(ByVal t As Table)
        Dim r As New TableRow
        Dim celda(5) As TableCell
        celda(0) = New TableCell : celda(0).Text = "Origen-Destino" : celda(0).CssClass = "titularazul"
        celda(1) = New TableCell : celda(1).Text = "Coste (Eur)" : celda(1).CssClass = "titularazulderecha"
        celda(2) = New TableCell : celda(2).Text = "Tiempo (Horas)" : celda(2).CssClass = "titularazulderecha"
        celda(3) = New TableCell : celda(3).Text = "Distancia (Km)" : celda(3).CssClass = "titularazulderecha"
        celda(4) = New TableCell : celda(4).Text = "Costes Ext (Eur)" : celda(4).CssClass = "titularverdederecha"
        celda(5) = New TableCell : celda(5).Text = "Emisiones CO2 (Kg)" : celda(5).CssClass = "titularverdederecha"
        r.Cells.AddRange(celda)
        t.Rows.Add(r)
    End Sub



End Class
