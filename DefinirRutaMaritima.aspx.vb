Imports System.Data
Imports System.Data.OleDb

Partial Class DefinirRutaMaritima
    Inherits System.Web.UI.Page
    
    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim LineaID As Integer = 0
        Dim dt As System.Data.DataTable = LineasListaUnica()
        If Not Me.IsPostBack Then
            For Each dr As System.Data.DataRow In dt.Rows
                cmbLineas.Items.Add(New ListItem(dr.Item("PuertoOrigen") & "-" & dr.Item("PuertoDestino") & " a través de " & dr.Item("Naviera"), dr.Item("LineaID")))
            Next
            Dim cLineaID As String = Me.Request.QueryString("LineaID")
            If cLineaID <> String.Empty Then
                cmbLineas.SelectedValue = CType(cLineaID, Integer)
            Else
                cmbLineas.SelectedIndex = 0
            End If
            Me.txtOrden.Text = 1
            Me.txtDatos.Text = ""
        End If

        LineaID = cmbLineas.SelectedValue
        CrearScript(LineaID)
        Me.LabelError.Text = "LineaID=" & LineaID

    End Sub

    Private Sub CrearScript(ByVal LineaID As Integer)
        '        Dim cad As New StringBuilder
        Dim csType As Type = Me.[GetType]()
        Dim arrGPSName As String = "arrLineaCoordenadaGPS"

        ' Calcular las coordenadas GPS del trayecto marítimo
        Dim arrGPSValue As String = Funciones.LineaGetCoordenadaGPS(LineaID)
        Me.Page.ClientScript.RegisterArrayDeclaration(arrGPSName, arrGPSValue)


    End Sub
    Private Function LineasListaUnica() As System.Data.DataTable
        'Devuelve los datos de todos los puertos
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT LineaGPS.LineaID, Lineas.PuertoOrigen, Lineas.PuertoDestino, Lineas.Naviera " & _
                           "FROM LineaGPS INNER JOIN Lineas ON LineaGPS.LineaID = Lineas.Id " & _
                           "GROUP BY LineaGPS.LineaID, Lineas.PuertoOrigen, Lineas.PuertoDestino, Lineas.Naviera"
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function
    
    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim c As String = Me.txtDatos.Text
        Dim ar As String() = c.Split("@")
        GrabarCoordenadasbyLineaID(Me.cmbLineas.SelectedValue, ar)
        Response.Redirect("./DefinirRutaMaritima.aspx?LineaID=" & Me.cmbLineas.SelectedValue)



    End Sub

    Private Sub GrabarCoordenadasbyLineaID(ByVal LineaID As Integer, ByVal ar As String())
        ' Grabar las coordenadas LineaGPS
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "Delete * FROM LineaGPS Where LineaID=" & LineaID & " AND Orden<>1 AND Orden<>99"
            .ExecuteNonQuery()
        End With
        Dim nElementos As Integer = ar.GetUpperBound(0) / 2
        Dim aElementos(nElementos, 1) As Double
        For x As Integer = 0 To nElementos - 1
            aElementos(x, 0) = CType(ar(x * 2).Replace(".", ","), Double)
            aElementos(x, 1) = CType(ar(x * 2 + 1).Replace(".", ","), Double)
        Next


        For x As Integer = 1 To nElementos - 1
            With comm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO LineaGPS (LineaID, Orden, Latitud,Longitud,  NombreMappoint, Nombre) " & _
                               " SELECT " & LineaID & " as Expr1, " & _
                               "        " & x * 2 & " as Expr2, " & _
                               "        " & aElementos(x, 0).ToString.Replace(",", ".") & " as Expr3, " & _
                               "        " & aElementos(x, 1).ToString.Replace(",", ".") & " as Expr4, " & _
                               "       '' as Expr5, " & _
                               "       '' as Expr6"
                .ExecuteNonQuery()
            End With

        Next

        cn.Close()
    End Sub
End Class
