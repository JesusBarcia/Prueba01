Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Public Class LineaData
    Public Shared _Conn As OleDbConnection
    Public Shared _ConnectionString As String
    Sub New()
        CrearConexion()
    End Sub

    Public Shared Function Add(Lin As Linea) As Long
        Dim id As Long = 0
        Dim sql As String
        Try
            CrearConexion()
            'Parámetros
            Dim pid As New OleDbParameter, pPuertoOrigen As New OleDbParameter, pPuertoDestino As New OleDbParameter
            Dim pPuertoOrigenMappoint As New OleDbParameter, pPuertoDestinoMappoint As New OleDbParameter
            Dim pPuertoOrigenID As New OleDbParameter, pPuertoDestinoID As New OleDbParameter
            Dim pLinea As New OleDbParameter, pNaviera As New OleDbParameter, pNavieraID As New OleDbParameter
            Dim pFrecuencia As New OleDbParameter, pFrecuenciaMensual As New OleDbParameter
            Dim pTipoTrafico As New OleDbParameter, pDistanciaMillas As New OleDbParameter
            Dim pTiempoPuertoOrigen As New OleDbParameter, pTiempoTransito As New OleDbParameter
            Dim pTiempoPuertoDestino As New OleDbParameter
            Dim pTiempoTotalTransporteMaritimo As New OleDbParameter, pFleteMaritimo As New OleDbParameter
            Dim pRecargoCabezaTractora As New OleDbParameter, pRecargoBAF As New OleDbParameter
            Dim pRecargoMercanciaPeligrosa As New OleDbParameter, pRecargoCCRR As New OleDbParameter
            Dim pCapPlataformas As New OleDbParameter, pCapPasajeros As New OleDbParameter
            Dim pCapCoches As New OleDbParameter
            Dim pFachada As New OleDbParameter, pEnlaceComodalWeb As New OleDbParameter
            Dim pFleteMensaje As New OleDbParameter, pVisible As New OleDbParameter

            With pPuertoOrigen
                .ParameterName = "@PuertoOrigen"
                .DbType = DbType.String
                .Value = Lin.PuertoOrigen
            End With
            With pPuertoDestino
                .ParameterName = "@PuertoDestino"
                .DbType = DbType.String
                .Value = Lin.PuertoDestino
            End With
            With pPuertoOrigenMappoint
                .ParameterName = "@PuertoOrigenMappoint"
                .DbType = DbType.String
                .Value = Lin.PuertoOrigenMappoint
            End With
            With pPuertoDestinoMappoint
                .ParameterName = "@PuertoDestinoMappoint"
                .DbType = DbType.String
                .Value = Lin.PuertoDestinoMappoint
            End With
            With pPuertoOrigenID
                .ParameterName = "@PuertoOrigenID"
                .DbType = DbType.Int32
                .Value = Lin.PuertoOrigenObj.ID
            End With
            With pPuertoDestinoID
                .ParameterName = "@PuertoDestinoID"
                .DbType = DbType.Int32
                .Value = Lin.PuertoDestinoObj.ID
            End With
            With pLinea
                .ParameterName = "@Linea"
                .DbType = DbType.String
                .Value = Lin.Linea
            End With
            With pNaviera
                .ParameterName = "@Naviera"
                .DbType = DbType.String
                .Value = Lin.Naviera
            End With
            With pNavieraID
                .ParameterName = "@NavieraID"
                .DbType = DbType.Int32
                .Value = Lin.NavieraFicha.ID
            End With
            With pFrecuencia
                .ParameterName = "@Frecuencia"
                .DbType = DbType.String
                .Value = Lin.Frecuencia
            End With
            With pFrecuenciaMensual
                .ParameterName = "@FrecuenciaMensual"
                .DbType = DbType.Double
                .Value = Lin.FrecuenciaMensual
            End With
            With pTipoTrafico
                .ParameterName = "@TipoTrafico"
                .DbType = DbType.String
                .Value = Lin.TipoTrafico
            End With
            With pDistanciaMillas
                .ParameterName = "@DistanciaMillas"
                .DbType = DbType.Double
                .Value = Lin.DistanciaMillas
            End With
            With pTiempoPuertoOrigen
                .ParameterName = "@TiempoPuertoOrigen"
                .DbType = DbType.Double
                .Value = Lin.TiempoPuertoOrigen
            End With
            With pTiempoTransito
                .ParameterName = "@TiempoTransito"
                .DbType = DbType.Double
                .Value = Lin.TiempoTransito
            End With
            With pTiempoPuertoDestino
                .ParameterName = "@TiempoPuertoDestino"
                .DbType = DbType.Double
                .Value = Lin.TiempoPuertoDestino
            End With
            With pTiempoTotalTransporteMaritimo
                .ParameterName = "@TiempoTotalTransporteMaritimo"
                .DbType = DbType.Double
                .Value = Lin.TiempoTotalTransporteMaritimo
            End With
            With pFleteMaritimo
                .ParameterName = "@FleteMaritimo"
                .DbType = DbType.Double
                .Value = Lin.FleteMaritimo
            End With
            With pRecargoCabezaTractora
                .ParameterName = "@RecargoCabezaTractora"
                .DbType = DbType.Double
                .Value = Lin.RecargoCabezaTractora
            End With
            With pRecargoBAF
                .ParameterName = "@RecargoBAF"
                .DbType = DbType.Double
                .Value = Lin.RecargoBAF
            End With
            With pRecargoMercanciaPeligrosa
                .ParameterName = "@RecargoMercanciaPeligrosa"
                .DbType = DbType.Double
                .Value = Lin.RecargoMercanciaPeligrosa
            End With
            With pRecargoCCRR
                .ParameterName = "@RecargoCCRR"
                .DbType = DbType.Double
                .Value = Lin.RecargoCCRR
            End With
            With pCapPlataformas
                .ParameterName = "@CapPlataformas"
                .DbType = DbType.Double
                .Value = Lin.CapPlataformas
            End With
            With pCapPasajeros
                .ParameterName = "@CapPasajeros"
                .DbType = DbType.Double
                .Value = Lin.CapPasajeros
            End With
            With pCapCoches
                .ParameterName = "@CapCoches"
                .DbType = DbType.Double
                .Value = Lin.CapCoches
            End With
            With pFachada
                .ParameterName = "@Fachada"
                .DbType = DbType.String
                .Value = Lin.Fachada
            End With
            With pEnlaceComodalWeb
                .ParameterName = "@EnlaceComodalWeb"
                .DbType = DbType.String
                .Value = Lin.EnlaceComodalWeb
            End With
            With pFleteMensaje
                .ParameterName = "@FleteMensaje"
                .DbType = DbType.String
                .Value = Lin.FleteMensaje
            End With
            With pVisible
                .ParameterName = "@Visible"
                .DbType = DbType.Boolean
                .Value = Lin.Visible
            End With
            'Commando para modificar la fila
            Dim comm As New OleDbCommand
            _Conn.Open()
            With comm
                .Parameters.Add(pPuertoOrigen) : .Parameters.Add(pPuertoDestino)
                .Parameters.Add(pPuertoOrigenMappoint) : .Parameters.Add(pPuertoDestinoMappoint)
                .Parameters.Add(pPuertoOrigenID) : .Parameters.Add(pPuertoDestinoID)
                .Parameters.Add(pLinea) : .Parameters.Add(pNaviera) : .Parameters.Add(pNavieraID)
                .Parameters.Add(pFrecuencia) : .Parameters.Add(pFrecuenciaMensual)
                .Parameters.Add(pTipoTrafico) : .Parameters.Add(pDistanciaMillas)
                .Parameters.Add(pTiempoPuertoOrigen) : .Parameters.Add(pTiempoTransito)
                .Parameters.Add(pTiempoPuertoDestino)
                .Parameters.Add(pTiempoTotalTransporteMaritimo) : .Parameters.Add(pFleteMaritimo)
                .Parameters.Add(pRecargoCabezaTractora) : .Parameters.Add(pRecargoBAF)
                .Parameters.Add(pRecargoMercanciaPeligrosa) : .Parameters.Add(pRecargoCCRR)
                .Parameters.Add(pCapPlataformas) : .Parameters.Add(pCapPasajeros) : .Parameters.Add(pCapCoches)
                .Parameters.Add(pFachada) : .Parameters.Add(pEnlaceComodalWeb)
                .Parameters.Add(pFleteMensaje) : .Parameters.Add(pVisible)

                .Connection = _Conn
                .CommandType = CommandType.Text
                sql = "INSERT INTO Lineas (PuertoOrigen, PuertoDestino, " & _
                      "                   PuertoOrigenMappoint, PuertoDestinoMappoint, " & _
                      "                   PuertoOrigenID, PuertoDestinoID, " & _
                      "                   Linea, Naviera, NavieraID, " & _
                      "                   Frecuencia, FrecuenciaMensual, " & _
                      "                   TipoTrafico, DistanciaMillas, " & _
                      "                   TiempoPuertoOrigen, TiempoTransito, " & _
                      "                   TiempoPuertoDestino, " & _
                      "                   TiempoTotalTransporteMaritimo, FleteMaritimo, " & _
                      "                   RecargoCabezaTractora, RecargoBAF, " & _
                      "                   RecargoMercanciaPeligrosa, RecargoCCRR, " & _
                      "                   CapPlataformas, CapPasajeros, CapCoches, " & _
                      "                   Fachada, EnlaceComodalWeb, " & _
                      "                   FleteMensaje, Visible)  " & _
                      " VALUES (@PuertoOrigen, @PuertoDestino, " & _
                      "         @PuertoOrigenMappoint, @PuertoDestinoMappoint, " & _
                      "         @PuertoOrigenID, @PuertoDestinoID, " & _
                      "         @Linea, @Naviera, @NavieraID, " & _
                      "         @Frecuencia, @FrecuenciaMensual, " & _
                      "         @TipoTrafico, @DistanciaMillas, " & _
                      "         @TiempoPuertoOrigen, @TiempoTransito, " & _
                      "         @TiempoPuertoDestino, " & _
                      "         @TiempoTotalTransporteMaritimo, @FleteMaritimo, " & _
                      "         @RecargoCabezaTractora, @RecargoBAF, " & _
                      "         @RecargoMercanciaPeligrosa, @RecargoCCRR, " & _
                      "         @CapPlataformas, @CapPasajeros, @CapCoches, " & _
                      "         @Fachada, @EnlaceComodalWeb, " & _
                      "         @FleteMensaje, @Visible) "

                .CommandText = sql
                .ExecuteNonQuery()

                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT TOP 1 ID FROM Lineas ORDER BY ID DESC "
                'Devuelve la fila insertada
                id = .ExecuteScalar
                '.ExecuteNonQuery()
            End With
            GPSInicialSave(id, Lin.PuertoOrigen, Lin.PuertoOrigenMappoint, Lin.PuertoOrigenLongitud, Lin.PuertoOrigenLatitud, _
                            Lin.PuertoDestino, Lin.PuertoDestinoMappoint, Lin.PuertoDestinoLongitud, Lin.PuertoDestinoLatitud)
            Return id
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function

    Public Shared Function Edit(Lin As Linea) As Long
        Try
            CrearConexion()
            'Parámetros
            Dim pid As New OleDbParameter, pPuertoOrigen As New OleDbParameter, pPuertoDestino As New OleDbParameter
            Dim pPuertoOrigenMappoint As New OleDbParameter, pPuertoDestinoMappoint As New OleDbParameter
            Dim pPuertoOrigenID As New OleDbParameter, pPuertoDestinoID As New OleDbParameter
            Dim pLinea As New OleDbParameter, pNaviera As New OleDbParameter, pNavieraID As New OleDbParameter
            Dim pFrecuencia As New OleDbParameter, pFrecuenciaMensual As New OleDbParameter
            Dim pTipoTrafico As New OleDbParameter, pDistanciaMillas As New OleDbParameter
            Dim pTiempoPuertoOrigen As New OleDbParameter, pTiempoTransito As New OleDbParameter
            Dim pTiempoPuertoDestino As New OleDbParameter
            Dim pTiempoTotalTransporteMaritimo As New OleDbParameter, pFleteMaritimo As New OleDbParameter
            Dim pRecargoCabezaTractora As New OleDbParameter, pRecargoBAF As New OleDbParameter
            Dim pRecargoMercanciaPeligrosa As New OleDbParameter, pRecargoCCRR As New OleDbParameter
            Dim pCapPlataformas As New OleDbParameter, pCapPasajeros As New OleDbParameter, pCapCoches As New OleDbParameter
            Dim pFachada As New OleDbParameter, pEnlaceComodalWeb As New OleDbParameter
            Dim pFleteMensaje As New OleDbParameter, pVisible As New OleDbParameter

            With pid
                .ParameterName = "@ID"
                .DbType = DbType.Int32
                .Value = Lin.ID
            End With
            With pPuertoOrigen
                .ParameterName = "@PuertoOrigen"
                .DbType = DbType.String
                .Value = Lin.PuertoOrigen
            End With
            With pPuertoDestino
                .ParameterName = "@PuertoDestino"
                .DbType = DbType.String
                .Value = Lin.PuertoDestino
            End With
            With pPuertoOrigenMappoint
                .ParameterName = "@PuertoOrigenMappoint"
                .DbType = DbType.String
                .Value = Lin.PuertoOrigenMappoint
            End With
            With pPuertoDestinoMappoint
                .ParameterName = "@PuertoDestinoMappoint"
                .DbType = DbType.String
                .Value = Lin.PuertoDestinoMappoint
            End With
            With pPuertoOrigenID
                .ParameterName = "@PuertoOrigenID"
                .DbType = DbType.Int32
                .Value = Lin.PuertoOrigenObj.ID
            End With
            With pPuertoDestinoID
                .ParameterName = "@PuertoDestinoID"
                .DbType = DbType.Int32
                .Value = Lin.PuertoDestinoObj.ID
            End With
            With pLinea
                .ParameterName = "@Linea"
                .DbType = DbType.String
                .Value = Lin.Linea
            End With
            With pNaviera
                .ParameterName = "@Naviera"
                .DbType = DbType.String
                .Value = Lin.Naviera
            End With
            With pNavieraID
                .ParameterName = "@NavieraID"
                .DbType = DbType.Int32
                .Value = Lin.NavieraFicha.ID
            End With
            With pFrecuencia
                .ParameterName = "@Frecuencia"
                .DbType = DbType.String
                .Value = Lin.Frecuencia
            End With
            With pFrecuenciaMensual
                .ParameterName = "@FrecuenciaMensual"
                .DbType = DbType.Double
                .Value = Lin.FrecuenciaMensual
            End With
            With pTipoTrafico
                .ParameterName = "@TipoTrafico"
                .DbType = DbType.String
                .Value = Lin.TipoTrafico
            End With
            With pDistanciaMillas
                .ParameterName = "@DistanciaMillas"
                .DbType = DbType.Double
                .Value = Lin.DistanciaMillas
            End With
            With pTiempoPuertoOrigen
                .ParameterName = "@TiempoPuertoOrigen"
                .DbType = DbType.Double
                .Value = Lin.TiempoPuertoOrigen
            End With
            With pTiempoTransito
                .ParameterName = "@TiempoTransito"
                .DbType = DbType.Double
                .Value = Lin.TiempoTransito
            End With
            With pTiempoPuertoDestino
                .ParameterName = "@TiempoPuertoDestino"
                .DbType = DbType.Double
                .Value = Lin.TiempoPuertoDestino
            End With
            With pTiempoTotalTransporteMaritimo
                .ParameterName = "@TiempoTotalTransporteMaritimo"
                .DbType = DbType.Double
                .Value = Lin.TiempoTotalTransporteMaritimo
            End With
            With pFleteMaritimo
                .ParameterName = "@FleteMaritimo"
                .DbType = DbType.Double
                .Value = Lin.FleteMaritimo
            End With
            With pRecargoCabezaTractora
                .ParameterName = "@RecargoCabezaTractora"
                .DbType = DbType.Double
                .Value = Lin.RecargoCabezaTractora
            End With
            With pRecargoBAF
                .ParameterName = "@RecargoBAF"
                .DbType = DbType.Double
                .Value = Lin.RecargoBAF
            End With
            With pRecargoMercanciaPeligrosa
                .ParameterName = "@RecargoMercanciaPeligrosa"
                .DbType = DbType.Double
                .Value = Lin.RecargoMercanciaPeligrosa
            End With
            With pRecargoCCRR
                .ParameterName = "@RecargoCCRR"
                .DbType = DbType.Double
                .Value = Lin.RecargoCCRR
            End With
            With pCapPlataformas
                .ParameterName = "@CapPlataformas"
                .DbType = DbType.Double
                .Value = Lin.CapPlataformas
            End With
            With pCapPasajeros
                .ParameterName = "@CapPasajeros"
                .DbType = DbType.Double
                .Value = Lin.CapPasajeros
            End With
            With pCapCoches
                .ParameterName = "@CapCoches"
                .DbType = DbType.Double
                .Value = Lin.CapCoches
            End With
            With pFachada
                .ParameterName = "@Fachada"
                .DbType = DbType.String
                .Value = Lin.Fachada
            End With
            With pEnlaceComodalWeb
                .ParameterName = "@EnlaceComodalWeb"
                .DbType = DbType.String
                .Value = Lin.EnlaceComodalWeb
            End With
            With pFleteMensaje
                .ParameterName = "@FleteMensaje"
                .DbType = DbType.String
                .Value = Lin.FleteMensaje
            End With
            With pVisible
                .ParameterName = "@Visible"
                .DbType = DbType.Boolean
                .Value = Lin.Visible
            End With
            'Commando para modificar la fila
            Dim comm As New OleDbCommand
            _Conn.Open()
            With comm
                .Parameters.Add(pPuertoOrigen) : .Parameters.Add(pPuertoDestino)
                .Parameters.Add(pPuertoOrigenMappoint) : .Parameters.Add(pPuertoDestinoMappoint)
                .Parameters.Add(pPuertoOrigenID) : .Parameters.Add(pPuertoDestinoID)
                .Parameters.Add(pLinea) : .Parameters.Add(pNaviera) : .Parameters.Add(pNavieraID)
                .Parameters.Add(pFrecuencia) : .Parameters.Add(pFrecuenciaMensual)
                .Parameters.Add(pTipoTrafico) : .Parameters.Add(pDistanciaMillas)
                .Parameters.Add(pTiempoPuertoOrigen) : .Parameters.Add(pTiempoTransito)
                .Parameters.Add(pTiempoPuertoDestino)
                .Parameters.Add(pTiempoTotalTransporteMaritimo) : .Parameters.Add(pFleteMaritimo)
                .Parameters.Add(pRecargoCabezaTractora) : .Parameters.Add(pRecargoBAF)
                .Parameters.Add(pRecargoMercanciaPeligrosa) : .Parameters.Add(pRecargoCCRR)
                .Parameters.Add(pCapPlataformas) : .Parameters.Add(pCapPasajeros) : .Parameters.Add(pCapCoches)
                .Parameters.Add(pFachada) : .Parameters.Add(pEnlaceComodalWeb)
                .Parameters.Add(pFleteMensaje)
                .Parameters.Add(pVisible)
                .Parameters.Add(pid)

                .Connection = _Conn
                .CommandType = CommandType.Text

                Lin.PuertoOrigen = Lin.PuertoOrigen.Replace(Chr(34), " ")
                Lin.PuertoDestino = Lin.PuertoDestino.Replace(Chr(34), " ")
                Lin.PuertoOrigenMappoint = Lin.PuertoOrigenMappoint.Replace(Chr(34), " ")
                Lin.PuertoDestinoMappoint = Lin.PuertoDestinoMappoint.Replace(Chr(34), " ")
                Lin.Linea = Lin.Linea.Replace(Chr(34), " ")
                Lin.Frecuencia = Lin.Frecuencia.Replace(Chr(34), " ")
                Lin.Naviera = Lin.Naviera.Replace(Chr(34), " ")
                Lin.TipoTrafico = Lin.TipoTrafico.Replace(Chr(34), " ")
                Lin.Fachada = Lin.Fachada.Replace(Chr(34), " ")
                Lin.EnlaceComodalWeb = Lin.EnlaceComodalWeb.Replace(Chr(34), " ")
                Lin.FleteMensaje = Lin.FleteMensaje.Replace(Chr(34), " ")
                .CommandText = "UPDATE Lineas " & _
                               "   SET PuertoOrigen=?,  PuertoDestino=?, " & _
                               "       PuertoOrigenMappoint=?, PuertoDestinoMappoint=?, " & _
                               "       PuertoOrigenID=?, PuertoDestinoID=?, " & _
                               "       Linea=?, Naviera=?, NavieraID=?, " & _
                               "       Frecuencia=?, FrecuenciaMensual=?, " & _
                               "       TipoTrafico=?, DistanciaMillas=?, " & _
                               "       TiempoPuertoOrigen=?, TiempoTransito=?, " & _
                               "       TiempoPuertoDestino=?, " & _
                               "       TiempoTotalTransporteMaritimo=?, FleteMaritimo=?, " & _
                               "       RecargoCabezaTractora=?, RecargoBAF=?, " & _
                               "       RecargoMercanciaPeligrosa=?, RecargoCCRR=?, " & _
                               "       CapPlataformas=?, CapPasajeros=?, CapCoches=?, " & _
                               "       Fachada=?, EnlaceComodalWeb=?, " & _
                               "       FleteMensaje=?, Visible=? " & _
                               " WHERE ID=?"
                '.CommandText = "UPDATE Lineas " & _
                '               "   SET PuertoOrigen='" & Lin.PuertoOrigen & "', " & _
                '               "       PuertoDestino='" & Lin.PuertoDestino & "', " & _
                '               "       PuertoOrigenMappoint='" & Lin.PuertoOrigenMappoint & "', " & _
                '               "       PuertoDestinoMappoint='" & Lin.PuertoDestinoMappoint & "', " & _
                '               "       PuertoOrigenID=" & Lin.PuertoOrigenObj.ID & ", " & _
                '               "       PuertoDestinoID=" & Lin.PuertoDestinoObj.ID & ", " & _
                '               "       Linea='" & Lin.Linea & "', " & _
                '               "       Naviera='" & Lin.Naviera & "', " & _
                '               "       NavieraID=" & Lin.NavieraFicha.ID & ", " & _
                '               "       Frecuencia='" & Lin.Frecuencia & "', " & _
                '               "       FrecuenciaMensual=" & Lin.FrecuenciaMensual & ", " & _
                '               "       TipoTrafico='" & Lin.TipoTrafico & "', " & _
                '               "       DistanciaMillas=" & Lin.DistanciaMillas & ", " & _
                '               "       TiempoPuertoOrigen=" & Lin.TiempoPuertoOrigen & ", " & _
                '               "       TiempoTransito=" & Lin.TiempoTransito & ", " & _
                '               "       TiempoPuertoDestino=?, " & _
                '               "       TiempoTotalTransporteMaritimo=?, FleteMaritimo=?, " & _
                '               "       RecargoCabezaTractora=?, RecargoBAF=?, " & _
                '               "       RecargoMercanciaPeligrosa=?, RecargoCCRR=?, " & _
                '               "       CapPlataformas=?, CapPasajeros=?, CapCoches=?, " & _
                '               "       Fachada=?, EnlaceComodalWeb=?, " & _
                '               "       FleteMensaje=? " & _
                '               " WHERE ID=?"

                .ExecuteNonQuery()
            End With
            'Devuelve ID de la fila modificada
            GPSInicialSave(Lin.ID, Lin.PuertoOrigen, Lin.PuertoOrigenMappoint, Lin.PuertoOrigenLongitud, Lin.PuertoOrigenLatitud, _
                            Lin.PuertoDestino, Lin.PuertoDestinoMappoint, Lin.PuertoDestinoLongitud, Lin.PuertoDestinoLatitud)
            Return Lin.ID
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function
    
    Public Shared Sub Delete(Lin As Linea)
        Dim ta As New System.Data.DataTable, da As New OleDbDataAdapter
        Dim comm As New System.Data.OleDb.OleDbCommand
        Dim comm2 As New System.Data.OleDb.OleDbCommand
        Try
            CrearConexion()
            _Conn.Open()
            Dim p1 As New OleDbParameter
            With p1
                .ParameterName = "@ID"
                .DbType = DbType.Int32
                .Value = Lin.ID
            End With
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "DELETE Lineas " & _
                               " WHERE ID=@ID"
                .Parameters.Add(p1)
                .ExecuteNonQuery()
            End With


            Dim p2 As New OleDbParameter
            With p2
                .ParameterName = "@ID"
                .DbType = DbType.Int32
                .Value = Lin.ID
            End With
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "DELETE LineaGPS " & _
                               " WHERE LineaID=@ID"
                .Parameters.Add(p2)
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Sub

    Public Shared Function GetbyID(ByVal ID As Long) As System.Data.DataRow
        Dim ta As New System.Data.DataTable, da As New OleDbDataAdapter
        Dim comm As New System.Data.OleDb.OleDbCommand
        Try
            CrearConexion()
            Dim p As New OleDbParameter
            With p
                p.ParameterName = "@ID"
                p.DbType = DbType.Int32
                p.Value = ID
            End With
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT *  " & _
                               " FROM Lineas " & _
                               " WHERE ID=@ID"
                .Parameters.Add(p)
            End With
            da.SelectCommand = comm
            da.Fill(ta)
            If ta.Rows.Count = 0 Then
                ta.Rows.Add()
            End If
            Return ta.Rows(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function

    Public Shared Function Lista(Optional ByVal where As String = "", Optional ByVal orden As String = "De") As System.Data.DataTable
        Dim ta As New System.Data.DataTable, da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Try
            CrearConexion()

            If Not where = String.Empty Then
                where = " WHERE " & where
            End If
            orden = " ORDER BY " & orden
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT ID FROM Lineas " & where & orden
            End With
            da.SelectCommand = comm
            da.Fill(ta)
            Return ta
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function

    Public Shared Sub GPSInicialSave(LineaID As Long, PuertoOrigenNombre As String, PuertoOrigenNombreMappoint As String, _
                                                    PuertoOrigenLongitud As Single, PuertoOrigenLatitud As Single, _
                                                    PuertoDestinoNombre As String, PuertoDestinoNombreMappoint As String, _
                                                    PuertoDestinoLongitud As Single, PuertoDestinoLatitud As Single)
        Dim comm As New System.Data.OleDb.OleDbCommand
        Dim sql As String
        Dim dr As OleDbDataReader
        Dim lEncontrado As Boolean = False
        Try
            CrearConexion()
            'Parámetros
            sql = "SELECT * FROM LineaGPS WHERE LineaID=" & LineaID & " AND  Orden=1"
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = sql
            End With
            dr = comm.ExecuteReader
            While dr.Read
                lEncontrado = True
            End While
            dr.Close()
            If lEncontrado Then
                sql = "UPDATE LineaGPS SET Longitud=" & PuertoOrigenLongitud.ToString.Replace(",", ".") & ", Latitud=" & PuertoOrigenLatitud.ToString.Replace(",", ".") & " WHERE LineaID=" & LineaID & " AND Orden=1"
            Else
                sql = "INSERT INTO LineaGPS (LineaID, Orden, Longitud, Latitud, NombreMappoint, Nombre) " & _
                      " SELECT " & LineaID & " AS Expr1, " & _
                      "    1 as Expr2, " & _
                      "    " & PuertoOrigenLongitud.ToString.Replace(",", ".") & " as Expr3, " & _
                      "    " & PuertoOrigenLatitud.ToString.Replace(",", ".") & " as Expr4, " & _
                      "    '" & PuertoOrigenNombreMappoint & "' as Expr5, " & _
                      "    '" & PuertoOrigenNombre & "' as Expr6 "
            End If
            With comm
                .Connection = _Conn
                .CommandText = sql
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With


            sql = "SELECT * FROM LineaGPS WHERE LineaID=" & LineaID & " AND Orden=99"
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = sql
            End With
            dr = comm.ExecuteReader
            lEncontrado = False
            While dr.Read
                lEncontrado = True
            End While
            dr.Close()
            If lEncontrado Then
                sql = "UPDATE LineaGPS SET Longitud=" & PuertoDestinoLongitud.ToString.Replace(",", ".") & ", Latitud=" & PuertoDestinoLatitud.ToString.Replace(",", ".") & " WHERE LineaID=" & LineaID & " AND Orden=99"
            Else
                sql = "INSERT INTO LineaGPS (LineaID, Orden, Longitud, Latitud, NombreMappoint, Nombre) " & _
                      "SELECT " & LineaID & " AS Expr1, " & _
                      "    99 as Expr2, " & _
                      "    " & PuertoDestinoLongitud.ToString.Replace(",", ".") & " as Expr3, " & _
                      "    " & PuertoDestinoLatitud.ToString.Replace(",", ".") & " as Expr4, " & _
                      "    '" & PuertoDestinoNombreMappoint & "' as Expr5, " & _
                      "    '" & PuertoDestinoNombre & "' as Expr6 "
            End If
            With comm
                .Connection = _Conn
                .CommandText = sql
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With



        Catch ex As Exception
        End Try



    End Sub

    Public Shared Sub GPSInicialLeer(ByRef Linea As Linea)

        Dim comm As New System.Data.OleDb.OleDbCommand
        Dim sql As String
        Dim dr As OleDbDataReader
        Try
            CrearConexion()
            _Conn.Open()
            'Parámetros
            sql = "SELECT Longitud, Latitud FROM LineaGPS WHERE LineaID=" & Linea.ID & " AND  Orden=1"
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = sql
            End With
            dr = comm.ExecuteReader
            Linea.PuertoOrigenLongitud = 0
            Linea.PuertoOrigenLatitud = 0
            While dr.Read
                Linea.PuertoOrigenLongitud = IIf(IsDBNull(dr.Item("Longitud")), 0, dr.Item("Longitud"))
                Linea.PuertoOrigenLatitud = IIf(IsDBNull(dr.Item("Latitud")), 0, dr.Item("Latitud"))
            End While
            dr.Close()


            sql = "SELECT Longitud, Latitud FROM LineaGPS WHERE LineaID=" & Linea.ID & " AND  Orden=99"
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = sql
            End With
            dr = comm.ExecuteReader
            Linea.PuertoDestinoLongitud = 0
            Linea.PuertoDestinoLatitud = 0
            While dr.Read
                Linea.PuertoDestinoLongitud = IIf(IsDBNull(dr.Item("Longitud")), 0, dr.Item("Longitud"))
                Linea.PuertoDestinoLatitud = IIf(IsDBNull(dr.Item("Latitud")), 0, dr.Item("Latitud"))
            End While
            dr.Close()

        Catch ex As Exception

        Finally
            _Conn.Close()
        End Try



    End Sub

    Private Shared Sub CrearConexion()
        _ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        If _Conn Is Nothing Then
            _Conn = New OleDbConnection(_ConnectionString)
        End If
    End Sub

End Class