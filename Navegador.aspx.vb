
Partial Class Navegador
    Inherits System.Web.UI.Page
    Dim miViaje As viaje

    Const COL_ANCHO_0 As Integer = 200
    Const COL_ANCHO_1 As Integer = 80
    Const COL_ANCHO_2 As Integer = 80
    Const COL_ANCHO_3 As Integer = 80
    Const COL_ANCHO_4 As Integer = 80
    Const COL_ANCHO_5 As Integer = 80
    Const COL_ANCHO_TOTAL As Integer = 600

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim LineaID As Integer = 0
        miViaje = CType(Session("miViaje"), viaje)
        If Not Me.IsPostBack Then
            If miViaje.WhereMisViajesCondicion <> String.Empty Then
                For Each dr In miViaje.misViajes.Select(miViaje.WhereMisViajesCondicion & " AND Seleccionado", miViaje.ResultadosOrden)
                    cmbLineas.Items.Add(New ListItem(dr.Item("PuertoOrigen") & "-" & dr.Item("PuertoDestino") & " a través de " & dr.Item("Naviera"), dr.Item("ID")))
                Next
            Else
                Dim dt As System.Data.DataTable
                miViaje.misViajes.DefaultView.RowFilter = miViaje.WhereMisViajesCondicion.Replace("LineaID", "ID")

                If miViaje.ResultadosOrden <> String.Empty Then
                    miViaje.misViajes.DefaultView.Sort = miViaje.ResultadosOrden
                End If
                dt = miViaje.misViajes.DefaultView.ToTable
                dt.DefaultView.Sort = miViaje.ResultadosOrden
                For Each dr In dt.Rows
                    cmbLineas.Items.Add(New ListItem(dr.Item("PuertoOrigen") & "-" & dr.Item("PuertoDestino") & " a través de " & dr.Item("Naviera") & "(" & dr.Item(miViaje.ResultadosOrden) & ")", dr.Item("ID")))
                Next
            End If
            cmbLineas.SelectedIndex = 0
        End If

        LineaID = cmbLineas.SelectedValue
        CrearScript(miViaje.origen, miViaje.destino, LineaID)
        PintarResultadosTerrestre()
        PintarResultadosMaritimos()
        Dim dtLinea As System.Data.DataTable = Datos.PuertoLista("LineaID=" & LineaID)
        Me.hypEnlaceComodalWeb.NavigateUrl = IIf(IsDBNull(dtLinea.Rows(0).Item("EnlaceComodalWeb")), "", dtLinea.Rows(0).Item("EnlaceComodalWeb"))
        Me.hypEnlaceComodalWeb2.NavigateUrl = IIf(IsDBNull(dtLinea.Rows(0).Item("EnlaceComodalWeb")), "", dtLinea.Rows(0).Item("EnlaceComodalWeb"))
        Me.hypEnlaceComodalWeb3.NavigateUrl = IIf(IsDBNull(dtLinea.Rows(0).Item("EnlaceComodalWeb")), "", dtLinea.Rows(0).Item("EnlaceComodalWeb"))
    End Sub

    Private Sub CrearScript(ByVal Origen As String, ByVal Destino As String, ByVal LineaID As Integer)
        '        Dim cad As New StringBuilder
        Dim csType As Type = Me.[GetType]()
        Dim arrGPSName As String = "arrLineaCoordenadaGPS"
        Dim arrTrayectoName As String = "arrTrayecto"

        Dim PuertoOrigen As String = ""
        Dim PuertoDestino As String = ""
        Dim PuertoOrigenID As Integer = 0
        Dim PuertoDestinoID As Integer = 0
        Dim Naviera As String = ""
        Dim NavieraID As Integer = 0

        ' Calcular las coordenadas GPS del trayecto marítimo
        Dim arrGPSValue As String = Funciones.LineaGetCoordenadaGPS(LineaID)
        Me.Page.ClientScript.RegisterArrayDeclaration(arrGPSName, arrGPSValue)

        'Calcular el punto de origen, puerto de origen, puerto de destino, destino
        Dim dtLinea As System.Data.DataTable = Datos.PuertoLista("LineaID=" & LineaID)
        Dim drSelected As System.Data.DataRow
        For Each dr As System.Data.DataRow In miViaje.misViajes.Select("ID=" & Me.cmbLineas.SelectedValue)
            drSelected = dr
        Next
        If dtLinea.Rows.Count > 0 Then
            PuertoOrigen = IIf(IsDBNull(dtLinea.Rows(0).Item("PuertoOrigen")), "", dtLinea.Rows(0).Item("PuertoOrigen"))
            PuertoDestino = IIf(IsDBNull(dtLinea.Rows(0).Item("PuertoDestino")), "", dtLinea.Rows(0).Item("PuertoDestino"))
            PuertoOrigenID = drSelected.Item("PuertoOrigenID").ToString
            PuertoDestinoID = drSelected.Item("PuertoDestinoID").ToString
            NavieraID = drSelected.Item("NavieraID").ToString
            Naviera = IIf(IsDBNull(drSelected.Item("Naviera").ToString), "", drSelected.Item("Naviera").ToString)

        End If
        Dim arrTrayectoValue = Chr(34) & Origen & Chr(34) & "," & _
                             Chr(34) & Destino & Chr(34) & "," & _
                             Chr(34) & PuertoOrigen & Chr(34) & "," & _
                             Chr(34) & PuertoDestino & Chr(34) & "," & _
                             Chr(34) & PuertoOrigenID.ToString & Chr(34) & "," & _
                             Chr(34) & PuertoDestinoID.ToString & Chr(34) & "," & _
                             Chr(34) & Naviera & Chr(34) & "," & _
                             Chr(34) & NavieraID.ToString & Chr(34)

        Me.Page.ClientScript.RegisterArrayDeclaration(arrTrayectoName, arrTrayectoValue)
    End Sub

    Private Sub PintarResultadosTerrestre()
        Try
            Encabezado(Me.TablaResultadosTerrestre)
            Me.LabelTituloTerrestre.Visible = True
            Dim r As New TableRow
            Dim celda(5) As TableCell
            celda(0) = New TableCell : celda(0).Text = miViaje.origenOriginal & " --> " & miViaje.destinoOriginal
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
            celda(0).Width = COL_ANCHO_0 : celda(1).Width = COL_ANCHO_1 : celda(2).Width = COL_ANCHO_2 : celda(3).Width = COL_ANCHO_3
            Me.TablaResultadosTerrestre.Rows.Add(r)

        Catch ex As Exception
            LabelError.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Sub PintarResultadosMaritimos()
        Try
            Dim drSelected As System.Data.DataRow
            For Each dr As System.Data.DataRow In miViaje.misViajes.Select("ID=" & Me.cmbLineas.SelectedValue)
                drSelected = dr
            Next
            Encabezado(Me.TableResultadosMaritimos)
            Me.LabelTituloTerrestre.Visible = True
            Dim r1 As New TableRow
            Dim celda1(5) As TableCell
            celda1(0) = New TableCell : celda1(0).Text = miViaje.origenOriginal & " --> " & drSelected.Item("PuertoOrigen")

            celda1(1) = New TableCell() : celda1(1).Text = CType(drSelected.Item("costeOrigenPuerto"), Single).ToString("N0")
            celda1(2) = New TableCell() : celda1(2).Text = CType(drSelected.Item("tiempoOrigenPuerto"), Single).ToString("F1")
            celda1(3) = New TableCell() : celda1(3).Text = CType(drSelected.Item("distanciaOrigenPuerto"), Single).ToString("N0")
            celda1(4) = New TableCell() : celda1(4).Text = CType(drSelected.Item("costesExternosOrigenPuerto"), Single).ToString("N0")
            celda1(5) = New TableCell() : celda1(5).Text = CType(drSelected.Item("costeEmisionCO2OrigenPuerto"), Single).ToString("N0")

            celda1(0).CssClass = "txtverdanasmall"
            celda1(1).CssClass = "txtverdanasmallderecha"
            celda1(2).CssClass = "txtverdanasmallderecha"
            celda1(3).CssClass = "txtverdanasmallderecha"
            celda1(4).CssClass = "txtverdanasmallderechaverde"
            celda1(5).CssClass = "txtverdanasmallderechaverde"

            celda1(0).Width = COL_ANCHO_0 : celda1(1).Width = COL_ANCHO_1 : celda1(2).Width = COL_ANCHO_2 : celda1(3).Width = COL_ANCHO_3 : celda1(4).Width = COL_ANCHO_4 : celda1(5).Width = COL_ANCHO_5
            r1.Cells.AddRange(celda1)
            Me.TableResultadosMaritimos.Rows.Add(r1)

            Dim r2 As New TableRow
            Dim celda2(5) As TableCell
            celda2(0) = New TableCell : celda2(0).Text = drSelected.Item("PuertoOrigen") & " --> " & _
                                                         drSelected.Item("PuertoDestino")

            celda2(1) = New TableCell() : celda2(1).Text = CType(drSelected.Item("costePuertoPuertoconRecargos"), Single).ToString("N0")
            celda2(2) = New TableCell() : celda2(2).Text = CType(drSelected.Item("tiempoPuertoPuerto"), Single).ToString("F1")
            celda2(3) = New TableCell() : celda2(3).Text = CType(drSelected.Item("distanciaPuertoPuerto"), Single).ToString("N0")
            celda2(4) = New TableCell() : celda2(4).Text = CType(drSelected.Item("costesExternosPuertoPuerto"), Single).ToString("N0")
            celda2(5) = New TableCell() : celda2(5).Text = CType(drSelected.Item("costeEmisionCO2PuertoPuerto"), Single).ToString("N0")

            celda2(0).CssClass = "txtverdanasmall"
            celda2(1).CssClass = "txtverdanasmallderecha"
            celda2(2).CssClass = "txtverdanasmallderecha"
            celda2(3).CssClass = "txtverdanasmallderecha"
            celda2(4).CssClass = "txtverdanasmallderechaverde"
            celda2(5).CssClass = "txtverdanasmallderechaverde"

            celda2(0).Width = COL_ANCHO_0 : celda2(1).Width = COL_ANCHO_1 : celda2(2).Width = COL_ANCHO_2 : celda2(3).Width = COL_ANCHO_3 : celda2(4).Width = COL_ANCHO_4 : celda2(5).Width = COL_ANCHO_5
            celda2(0).Font.Bold = True : celda2(1).Font.Bold = True : celda2(2).Font.Bold = True : celda2(3).Font.Bold = True : celda2(4).Font.Bold = True : celda2(5).Font.Bold = True
            r2.Cells.AddRange(celda2)
            Me.TableResultadosMaritimos.Rows.Add(r2)

            Dim r3 As New TableRow
            Dim celda3(5) As TableCell
            celda3(0) = New TableCell : celda3(0).Text = drSelected.Item("PuertoDestino") & " --> " & _
                                                         miViaje.destinoOriginal
            celda3(1) = New TableCell() : celda3(1).Text = CType(drSelected.Item("costePuertoDestino"), Single).ToString("N0")
            celda3(2) = New TableCell() : celda3(2).Text = CType(drSelected.Item("tiempoPuertoDestino"), Single).ToString("F1")
            celda3(3) = New TableCell() : celda3(3).Text = CType(drSelected.Item("distanciaPuertoDestino"), Single).ToString("N0")
            celda3(4) = New TableCell() : celda3(4).Text = CType(drSelected.Item("costesExternosPuertoDestino"), Single).ToString("N0")
            celda3(5) = New TableCell() : celda3(5).Text = CType(drSelected.Item("costeEmisionCO2PuertoDestino"), Single).ToString("N0")

            celda3(0).CssClass = "txtverdanasmall"
            celda3(1).CssClass = "txtverdanasmallderecha"
            celda3(2).CssClass = "txtverdanasmallderecha"
            celda3(3).CssClass = "txtverdanasmallderecha"
            celda3(4).CssClass = "txtverdanasmallderechaverde"
            celda3(5).CssClass = "txtverdanasmallderechaverde"

            celda3(0).Width = COL_ANCHO_0 : celda3(1).Width = COL_ANCHO_1 : celda3(2).Width = COL_ANCHO_2 : celda3(3).Width = COL_ANCHO_3 : celda3(4).Width = COL_ANCHO_4 : celda3(5).Width = COL_ANCHO_5
            r3.Cells.AddRange(celda3)
            Me.TableResultadosMaritimos.Rows.Add(r3)


            Dim r4 As New TableRow
            Dim celda4(5) As TableCell
            celda4(0) = New TableCell() : celda4(0).Text = "<b>Total: " & miViaje.origenOriginal & " *** " & miViaje.destinoOriginal & "</b>"
            celda4(1) = New TableCell() : celda4(1).Text = "<b>" & CType(drSelected.Item("costeTotal"), Single).ToString("N0") & "</b>"
            celda4(2) = New TableCell() : celda4(2).Text = "<b>" & CType(drSelected.Item("tiempoTotal"), Single).ToString("F1") & "</b>"
            celda4(3) = New TableCell() : celda4(3).Text = "<b>" & CType(drSelected.Item("distanciaTotal"), Single).ToString("N0") & "</b>"
            celda4(4) = New TableCell() : celda4(4).Text = "<b>" & CType(drSelected.Item("costesExternosTotal"), Single).ToString("N0") & "</b>"
            celda4(5) = New TableCell() : celda4(5).Text = "<b>" & CType(drSelected.Item("costeEmisionCO2Total"), Single).ToString("N0") & "</b>"


            celda4(0).CssClass = "txtverdanasmall"
            celda4(1).CssClass = "txtverdanasmallderecha"
            celda4(2).CssClass = "txtverdanasmallderecha"
            celda4(3).CssClass = "txtverdanasmallderecha"
            celda4(4).CssClass = "txtverdanasmallderechaverde"
            celda4(5).CssClass = "txtverdanasmallderechaverde"

            celda4(0).Width = COL_ANCHO_0 : celda4(1).Width = COL_ANCHO_1 : celda4(2).Width = COL_ANCHO_2 : celda4(3).Width = COL_ANCHO_3 : celda4(4).Width = COL_ANCHO_4 : celda4(5).Width = COL_ANCHO_5
            r4.Cells.AddRange(celda4)
            Me.TableResultadosMaritimos.Rows.Add(r4)


            Dim r4A As New TableRow
            Dim celda4A(0) As TableCell
            celda4A(0) = New TableCell()
            celda4A(0).Font.Size = 11
            celda4A(0).Text = "<i>" & drSelected.Item("FleteMensaje") & "</i>"
            'El coste del transporte marítimo es orientativo, para mayor precisión por favor consulte a la naviera.</i>"

            celda4A(0).ColumnSpan = 6
            celda4A(0).CssClass = "txtverdanasmall"
            celda4A(0).Width = COL_ANCHO_0 + COL_ANCHO_1 + COL_ANCHO_2 + COL_ANCHO_3 + COL_ANCHO_4 + COL_ANCHO_5
            r4A.Cells.AddRange(celda4A)
            Me.TableResultadosMaritimos.Rows.Add(r4A)


            Dim r5 As New TableRow
            Dim celda5(0) As TableCell
            celda5(0) = New TableCell()
            If drSelected.Item("PuertoOrigenID") = 0 Then
                celda5(0).Text = "Puerto de Origen/Origin Port: <b>Puerto de " & drSelected.Item("PuertoOrigen") & "</b>"
            Else
                celda5(0).Text = "<a href=""./verPuerto.aspx?id=" & _
                                              drSelected.Item("PuertoOrigenID") & """ target=""_blank"">" & _
                                              "Información sobre el Puerto de Origen/Information about Origin Port: Puerto de " & _
                                              drSelected.Item("PuertoOrigen") & ".</a>"

            End If
            celda5(0).ColumnSpan = 6
            celda5(0).CssClass = "txtverdanasmall"
            r5.Cells.AddRange(celda5)
            Me.TableResultadosMaritimos.Rows.Add(r5)



            Dim r6 As New TableRow
            Dim celda6(0) As TableCell
            celda6(0) = New TableCell()

            If drSelected.Item("NavieraID") = 0 Then
                celda6(0).Text = ""
            Else
                celda6(0).Text = "<a href=""./verNaviera.aspx?id=" & _
                                             drSelected.Item("NavieraID") & """ target=""_blank"">" & _
                                            "Información sobre la Naviera y el Servicio Marítimo/Information about the shipping Co. and maritime service.</a>"
            End If

            celda6(0).ColumnSpan = 6
            celda6(0).CssClass = "txtverdanasmall"
            r6.Cells.AddRange(celda6)
            Me.TableResultadosMaritimos.Rows.Add(r6)


            Dim r7 As New TableRow
            Dim celda7(0) As TableCell
            celda7(0) = New TableCell()
            If drSelected.Item("PuertoDestinoID") = 0 Then
                celda7(0).Text = "Puerto de Destino/Destination Port: <b>Puerto de " & drSelected.Item("PuertoDestino") & "</b>"
            Else
                celda7(0).Text = "<a href=""./verPuerto.aspx?id=" & _
                                              drSelected.Item("PuertoDestinoID") & """ target=""_blank"">" & _
                                              "Información sobre el Puerto de Destino: Puerto de " & _
                                              drSelected.Item("PuertoDestino") & ".</a>"

            End If
            celda7(0).ColumnSpan = 6
            celda7(0).CssClass = "txtverdanasmall"
            r7.Cells.AddRange(celda7)
            Me.TableResultadosMaritimos.Rows.Add(r7)


            Dim r8 As New TableRow
            Dim celda8(0) As TableCell
            celda8(0) = New TableCell()
            celda8(0).Text = "(El flete marítimo es orientativo. Para mayor precisión, consulte a la naviera)"
            celda8(0).ColumnSpan = 6
            celda8(0).CssClass = "txtverdanasmall"
            r8.Cells.AddRange(celda8)
            Me.TableResultadosMaritimos.Rows.Add(r8)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Encabezado(ByVal t As Table)
        Dim r As New TableRow
        Dim celda(5) As TableCell
        celda(0) = New TableCell : celda(0).Text = "Orig-Dest/From-To" : celda(0).CssClass = "titularazul"
        celda(1) = New TableCell : celda(1).Text = "Cost. (Eur)" : celda(1).CssClass = "titularazulderecha"
        celda(2) = New TableCell : celda(2).Text = "Tiempo/Transit-Time (Hor)" : celda(2).CssClass = "titularazulderecha"
        celda(3) = New TableCell : celda(3).Text = "Dist. (Km)" : celda(3).CssClass = "titularazulderecha"
        celda(4) = New TableCell : celda(4).Text = "Cost.Ext/ Ext.Cost (Eur)" : celda(4).CssClass = "titularverdederecha"
        celda(5) = New TableCell : celda(5).Text = "Emis CO2 (Kg)" : celda(5).CssClass = "titularverdederecha"
        r.Cells.AddRange(celda)
        t.Rows.Add(r)
    End Sub

    Protected Sub btnNuevaSimulacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevaSimulacion.Click
        Response.Redirect("./simulador.aspx")
    End Sub
End Class
