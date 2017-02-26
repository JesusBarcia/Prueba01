
Partial Class VerMapa
    Inherits System.Web.UI.Page
    Dim miViaje As viaje

    Const COL_ANCHO_0 As Integer = 200
    Const COL_ANCHO_1 As Integer = 100
    Const COL_ANCHO_2 As Integer = 100
    Const COL_ANCHO_3 As Integer = 100
    Const COL_ANCHO_TOTAL As Integer = 500

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim LineaID As Integer = 0
        miViaje = CType(Session("miViaje"), viaje)

        If Not Me.IsPostBack Then
            If miViaje.WhereMisViajesCondicion <> String.Empty Then
                miViaje.misViajes.DefaultView.RowFilter = miViaje.WhereMisViajesCondicion
            End If

            For Each dr As System.Data.DataRow In miViaje.misViajes.Rows
                cmbLineas.Items.Add(New ListItem(dr.Item("PuertoOrigen") & "-" & dr.Item("PuertoDestino") & " a través de " & dr.Item("Naviera"), dr.Item("ID")))
            Next
            cmbLineas.SelectedIndex = 0
        End If

        LineaID = cmbLineas.SelectedValue
        Dim dtLinea As System.Data.DataTable = Datos.PuertoLista("LineaID=" & LineaID)
        Me.hypEnlaceComodalWeb.NavigateUrl = dtLinea.Rows(0).Item("EnlaceComodalWeb")
        CrearScript(miViaje.origen, miViaje.destino, LineaID)
        PintarResultadosTerrestre()
        PintarResultadosMaritimos()
    End Sub

    Private Sub CrearScript(ByVal Origen As String, ByVal Destino As String, ByVal LineaID As Integer)
        '        Dim cad As New StringBuilder
        Dim csType As Type = Me.[GetType]()
        Dim arrGPSName As String = "arrLineaCoordenadaGPS"
        Dim arrTrayectoName As String = "arrTrayecto"

        Dim PuertoOrigen As String = ""
        Dim PuertoDestino As String = ""

        ' Calcular las coordenadas GPS del trayecto marítimo
        Dim arrGPSValue As String = Funciones.LineaGetCoordenadaGPS(LineaID)
        Me.Page.ClientScript.RegisterArrayDeclaration(arrGPSName, arrGPSValue)

        'Calcular el punto de origen, puerto de origen, puerto de destino, destino
        Dim dtLinea As System.Data.DataTable = Datos.PuertoLista("LineaID=" & LineaID)
        If dtLinea.Rows.Count > 0 Then
            PuertoOrigen = IIf(IsDBNull(dtLinea.Rows(0).Item("PuertoOrigen")), "", dtLinea.Rows(0).Item("PuertoOrigen"))
            PuertoDestino = IIf(IsDBNull(dtLinea.Rows(0).Item("PuertoDestino")), "", dtLinea.Rows(0).Item("PuertoDestino"))
        End If
        Dim arrTrayectoValue = Chr(34) & Origen & Chr(34) & "," & _
                             Chr(34) & Destino & Chr(34) & "," & _
                             Chr(34) & PuertoOrigen & Chr(34) & "," & _
                             Chr(34) & PuertoDestino & Chr(34)
        Me.Page.ClientScript.RegisterArrayDeclaration(arrTrayectoName, arrTrayectoValue)
    End Sub

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
            celda(4).CssClass = "txtverdanasmallderecha"
            celda(5).CssClass = "txtverdanasmallderecha"
            r.Cells.AddRange(celda)
            Me.TablaResultadosTerrestre.Rows.Add(r)
        Catch ex As Exception
            LabelError.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub PintarResultadosMaritimos()
        Try
            Encabezado(Me.TableResultadosMaritimos)
            Me.LabelTituloTerrestre.Visible = True
            Dim r1 As New TableRow
            Dim celda1(3) As TableCell
            celda1(0) = New TableCell : celda1(0).Text = miViaje.origenOriginal & " --> " & miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoOrigen")

            celda1(1) = New TableCell() : celda1(1).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("costeOrigenPuerto"), Single).ToString("N0")
            celda1(2) = New TableCell() : celda1(2).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("tiempoOrigenPuerto"), Single).ToString("F1")
            celda1(3) = New TableCell() : celda1(3).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("distanciaOrigenPuerto"), Single).ToString("N0")

            celda1(0).CssClass = "txtverdanasmall"
            celda1(1).CssClass = "txtverdanasmallderecha"
            celda1(2).CssClass = "txtverdanasmallderecha"
            celda1(3).CssClass = "txtverdanasmallderecha"
            celda1(0).Width = COL_ANCHO_0 : celda1(1).Width = COL_ANCHO_1 : celda1(2).Width = COL_ANCHO_2 : celda1(3).Width = COL_ANCHO_3
            r1.Cells.AddRange(celda1)
            Me.TableResultadosMaritimos.Rows.Add(r1)

            Dim r2 As New TableRow
            Dim celda2(3) As TableCell
            celda2(0) = New TableCell : celda2(0).Text = miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoOrigen") & " --> " & _
                                                         miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoDestino")

            celda2(1) = New TableCell() : celda2(1).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("costePuertoPuertoconRecargos"), Single).ToString("N0")
            celda2(2) = New TableCell() : celda2(2).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("tiempoPuertoPuerto"), Single).ToString("F1")
            celda2(3) = New TableCell() : celda2(3).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("distanciaPuertoPuerto"), Single).ToString("N0")
            celda2(0).CssClass = "txtverdanasmall"
            celda2(1).CssClass = "txtverdanasmallderecha"
            celda2(2).CssClass = "txtverdanasmallderecha"
            celda2(3).CssClass = "txtverdanasmallderecha"
            celda2(0).Width = COL_ANCHO_0 : celda2(1).Width = COL_ANCHO_1 : celda2(2).Width = COL_ANCHO_2 : celda2(3).Width = COL_ANCHO_3
            celda2(0).Font.Bold = True : celda2(1).Font.Bold = True : celda2(2).Font.Bold = True : celda2(3).Font.Bold = True
            r2.Cells.AddRange(celda2)
            Me.TableResultadosMaritimos.Rows.Add(r2)

            Dim r3 As New TableRow
            Dim celda3(3) As TableCell
            celda3(0) = New TableCell : celda3(0).Text = miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoDestino") & " --> " & _
                                                         miViaje.destinoOriginal
            celda3(1) = New TableCell() : celda3(1).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("costePuertoDestino"), Single).ToString("N0")
            celda3(2) = New TableCell() : celda3(2).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("tiempoPuertoDestino"), Single).ToString("F1")
            celda3(3) = New TableCell() : celda3(3).Text = CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("distanciaPuertoDestino"), Single).ToString("N0")
            celda3(0).CssClass = "txtverdanasmall"
            celda3(1).CssClass = "txtverdanasmallderecha"


            celda3(2).CssClass = "txtverdanasmallderecha"
            celda3(3).CssClass = "txtverdanasmallderecha"
            celda3(0).Width = COL_ANCHO_0 : celda3(1).Width = COL_ANCHO_1 : celda3(2).Width = COL_ANCHO_2 : celda3(3).Width = COL_ANCHO_3
            r3.Cells.AddRange(celda3)
            Me.TableResultadosMaritimos.Rows.Add(r3)


            Dim r4 As New TableRow
            Dim celda4(3) As TableCell
            celda4(0) = New TableCell() : celda4(0).Text = "<b>Total: " & miViaje.origenOriginal & " ↔ " & miViaje.destinoOriginal & "</b>"
            celda4(1) = New TableCell() : celda4(1).Text = "<b>" & CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("costeTotal"), Single).ToString("N0") & "</b>"
            celda4(2) = New TableCell() : celda4(2).Text = "<b>" & CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("tiempoTotal"), Single).ToString("F1") & "</b>"
            celda4(3) = New TableCell() : celda4(3).Text = "<b>" & CType(miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("distanciaTotal"), Single).ToString("N0") & "</b>"

            celda4(0).CssClass = "txtverdanasmall"
            celda4(1).CssClass = "txtverdanasmallderecha"
            celda4(2).CssClass = "txtverdanasmallderecha"
            celda4(3).CssClass = "txtverdanasmallderecha"
            celda4(0).Width = COL_ANCHO_0 : celda4(1).Width = COL_ANCHO_1 : celda4(2).Width = COL_ANCHO_2 : celda4(3).Width = COL_ANCHO_3
            r4.Cells.AddRange(celda4)
            Me.TableResultadosMaritimos.Rows.Add(r4)

            Dim r5 As New TableRow
            Dim celda5(0) As TableCell
            celda5(0) = New TableCell() : celda5(0).Text = "<a href=""./verPuerto.aspx?id=" & _
                                          miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoOrigenID") & """ target=""_blank"">" & _
                                          "Información sobre el Puerto de Origen: Puerto de " & _
                                          miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoOrigen") & ".</a>"
            celda5(0).ColumnSpan = 4
            celda5(0).CssClass = "txtverdanasmall"
            r5.Cells.AddRange(celda5)
            Me.TableResultadosMaritimos.Rows.Add(r5)



            Dim r6 As New TableRow
            Dim celda6(0) As TableCell
            celda6(0) = New TableCell() : celda6(0).Text = "<a href=""./verNaviera.aspx?id=" & _
                                          miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("NavieraID") & """ target=""_blank"">" & _
                                          "Información sobre la Naviera y el Servicio Marítimo.</a>"
            celda6(0).ColumnSpan = 4
            celda6(0).CssClass = "txtverdanasmall"
            r6.Cells.AddRange(celda6)
            Me.TableResultadosMaritimos.Rows.Add(r6)


            Dim r7 As New TableRow
            Dim celda7(0) As TableCell
            celda7(0) = New TableCell() : celda7(0).Text = "<a href=""./verPuerto.aspx?id=" & _
                                          miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoDestinoID") & """ target=""_blank"">" & _
                                          "Información sobre el Puerto de Destino: Puerto de " & _
                                          miViaje.misViajes.Rows(Me.cmbLineas.SelectedIndex).Item("PuertoDestino") & ".</a>"
            celda7(0).ColumnSpan = 4
            celda7(0).CssClass = "txtverdanasmall"
            r7.Cells.AddRange(celda7)
            Me.TableResultadosMaritimos.Rows.Add(r7)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Encabezado(ByVal t As Table)
        Dim r As New TableRow
        Dim celda(5) As TableCell
        celda(0) = New TableCell : celda(0).Text = "Origen-Destino" : celda(0).CssClass = "titularazul"
        celda(1) = New TableCell : celda(1).Text = "Coste (Eur)" : celda(1).CssClass = "titularazulderecha"
        celda(2) = New TableCell : celda(2).Text = "Tiempo (Horas)" : celda(2).CssClass = "titularazulderecha"
        celda(3) = New TableCell : celda(3).Text = "Distancia (Km)" : celda(3).CssClass = "titularazulderecha"
        celda(4) = New TableCell : celda(4).Text = "Costes Externos" : celda(4).CssClass = "titularazulderecha"
        celda(5) = New TableCell : celda(5).Text = "Emisiones CO2" : celda(5).CssClass = "titularazulderecha"
        r.Cells.AddRange(celda)
        t.Rows.Add(r)
    End Sub

End Class
