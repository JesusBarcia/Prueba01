Imports System.Data
Imports System.Data.OleDb
Public Class Datos
    Shared Function PuertoLista(Optional ByVal where As String = "") As System.Data.DataTable
        'Devuelve los datos de todos los puertos
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString

        cn.Open()
        If Not where = String.Empty Then
            where = " AND (" & where & ") "
            where = where.Replace("LineaID", "ID")
        End If
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM lineas WHERE visible=True " & where & " Order By PuertoOrigen, PuertoDestino "
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function
    Shared Function PuertoListaByOrigenyDestino(ByVal OrigenDestino As String) As DataTable
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
            .CommandText = "SELECT * FROM lineas " & _
                           " WHERE visible=True " & _
                           "   AND PuertoOrigen + ' -- ' + PuertoDestino=" & _
                           "'" & OrigenDestino & "'"
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function
    Shared Function NavieraLista(Optional ByVal where As String = "") As DataTable
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        If Not where = String.Empty Then
            where = " ( AND " & where & ") "
        End If
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT Naviera " & _
                           " FROM lineas " & _
                           " WHERE visible=True " & where & _
                           " GROUP BY Naviera "
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        Return dt

    End Function
    Shared Function NavieraFichaByID(ByVal id As Long) As DataRow
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * " & _
                           " FROM naviera " & _
                           " WHERE ID=" & id
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        If dt.Rows.Count = 0 Then
            Return dt.NewRow
        Else
            Return dt.Rows(0)
        End If
    End Function
    Shared Function PuertoFichaByID(ByVal id As Long) As DataRow
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * " & _
                           " FROM puerto " & _
                           " WHERE ID=" & id
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        cn.Close()
        If dt.Rows.Count = 0 Then
            Return dt.NewRow
        Else
            Return dt.Rows(0)
        End If
    End Function
    Shared Function ArchivoJSonGet(ByVal origen As String, ByVal destino As String) As DataRow
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        Dim retorno As System.Data.DataRow
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM ArchivoJSON " & _
                           " WHERE (Origen='" & origen.ToUpper & "' AND Destino='" & destino.ToUpper & "') " & _
                           "    OR (Origen='" & destino.ToUpper & "' AND Destino='" & origen.ToUpper & "') "
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            retorno = dt.NewRow
        Else
            retorno = dt.Rows(0)
            'Actulizar uso
            With comm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE ArchivoJSON " & _
                               "   SET Uso=Uso + 1, " & _
                               "       UltimoAcceso=#" & Now.Date.ToString("yyyy-MM-dd") & "# " & _
                               " WHERE (Origen='" & origen & "' AND Destino='" & destino & "') " & _
                               "    OR (Origen='" & destino & "' AND Destino='" & origen & "') "
                .ExecuteNonQuery()
            End With
        End If
        cn.Close()
        Return retorno
    End Function
    Shared Sub ArchivoJSonSave(ByVal origen As String, ByVal destino As String, ByVal DistanciaTotal As Double, ByVal TiempoTotal As Double)
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            Dim pOrigen As New OleDbParameter("pOrigen", origen.ToUpper)
            Dim pDestino As New OleDbParameter("pDestino", destino.ToUpper)
            Dim pDistanciaTotal As New OleDbParameter("pDistancia", DistanciaTotal)
            Dim pTiempoTotal As New OleDbParameter("pDistancia", TiempoTotal)
            .Parameters.Add(pOrigen)
            .Parameters.Add(pDestino)
            .Parameters.Add(pDistanciaTotal)
            .Parameters.Add(pTiempoTotal)
            .CommandText = "INSERT INTO ArchivoJSON (origen, Destino, Uso, DistanciaTotal, TiempoTotal, Alta, UltimoAcceso) " & _
                           " SELECT @pOrigen as Expr1, " & _
                           "        @pDestino as Expr2, " & _
                           "        1 as Expr4, " & _
                           "        @pDistanciaTotal as Expr5, " & _
                           "        @pTiempoTotal as Expr6, " & _
                           "        #" & Now.Date.ToString("yyyy-MM-dd") & "# as Expr7, " & _
                           "        #" & Now.Date.ToString("yyyy-MM-dd") & "# as Expr8"
            .ExecuteNonQuery()
        End With
        cn.Close()
    End Sub

    Shared Function ConfiguracionLeer(ByVal Nombre As String) As String
        Dim oConn As New OleDb.OleDbConnection
        Dim oComm As New OleDb.OleDbCommand
        Dim cResultado As String = ""
        Try
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
            With oComm
                .Connection = oConn
                .CommandType = CommandType.Text
                .CommandText = "SELECT valor FROM configuracion WHERE Nombre='" & Nombre.ToUpper & "'"
            End With
            oConn.Open()
            cResultado = oComm.ExecuteScalar
        Catch ex As Exception
            Throw New System.Exception("Error. " & ex.Message)
        Finally
            oConn.Close()
        End Try
        Return cResultado
    End Function
    Shared Sub ConfiguracionEscribir(ByVal Nombre As String, ByVal Value As String)
        Dim oConn As New OleDb.OleDbConnection
        Dim oComm As New OleDb.OleDbCommand
        Try
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
            With oComm
                .Connection = oConn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE configuracion SET valor='" & Value & "' WHERE Nombre='" & Nombre.ToUpper & "'"
            End With
            oConn.Open()
            oComm.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error. " & ex.Message)
        Finally
            oConn.Close()
        End Try
    End Sub

    Shared Function LineaGPSGetCoordenadasByLineaID(ByVal LineaID As Integer) As DataTable
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        cn.Open()
        With comm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM LineaGPS " & _
                           " WHERE LineaID=" & LineaID & _
                           "  ORDER BY Orden"
        End With
        da.SelectCommand = comm
        da.Fill(dt)
        Return dt
        cn.Close()
    End Function


    Shared Sub GuardarCoordenadaGPS()
        Dim dt As New System.Data.DataTable
        Dim da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Dim cn As New OleDbConnection
        Try
            cn.ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
            cn.Open()
            With comm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT * " & _
                               " FROM LineaGPS "
            End With
            da.SelectCommand = comm
            da.Fill(dt)
            For Each dr As DataRow In dt.Rows
                Dim coor As CoordenadaGPS = Funciones.GetCoordenadaGPS(dr.Item("NombreMappoint"))
                If coor.Latitud <> 0 Or coor.Longitud <> 0 Then
                    With comm
                        .CommandText = "UPDATE LineaGPS " & _
                                       "   SET Longitud=" & coor.Longitud.ToString.Replace(",", ".") & ", " & _
                                       "       Latitud=" & coor.Latitud.ToString.Replace(",", ".") & _
                                       " WHERE ID=" & dr.Item("ID")
                    End With
                    comm.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            Throw New System.Exception("Error. " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class
