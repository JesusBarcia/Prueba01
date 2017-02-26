Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Public Class NavieraData
    Public Shared _Conn As OleDbConnection
    Public Shared _ConnectionString As String
    Sub New()
        CrearConexion()
    End Sub
    Public Shared Function Edit(obj As Naviera) As Long
        'Modifica los datos de una persona en la base de datos
        Try
            CrearConexion()
            'Parámetros
            Dim pid As New OleDbParameter, pDe As New OleDbParameter, pA As New OleDbParameter
            Dim pHorario As New OleDbParameter, pDatosContacto As New OleDbParameter, pInformacionReservas As New OleDbParameter, pLogo As New OleDbParameter

            With pid
                .ParameterName = "@ID"
                .DbType = DbType.Int32
                .Value = obj.ID
            End With
            With pDe
                .ParameterName = "@DE"
                .DbType = DbType.String
                .Value = obj.De
            End With
            With pA
                .ParameterName = "@A"
                .DbType = DbType.String
                .Value = obj.A
            End With
            With pHorario
                .ParameterName = "@Horario"
                .DbType = DbType.String
                .Value = obj.Horario
            End With
            With pDatosContacto
                .ParameterName = "@DatosContacto"
                .DbType = DbType.String
                .Value = obj.DatosContacto
            End With
            With pInformacionReservas
                .ParameterName = "@InformacionReservas"
                .DbType = DbType.String
                .Value = obj.InformacionReservas
            End With
            With pLogo
                .ParameterName = "@Logo"
                .DbType = DbType.String
                .Value = obj.Logo
            End With
            'Commando para modificar la fila
            Dim comm As New OleDbCommand
            _Conn.Open()
            With comm
                .Parameters.Add(pDe) : .Parameters.Add(pA)
                .Parameters.Add(pHorario) : .Parameters.Add(pDatosContacto) : .Parameters.Add(pInformacionReservas)
                .Parameters.Add(pLogo)
                .Parameters.Add(pid)
                .Connection = _Conn
                .CommandType = CommandType.Text
                obj.De = obj.De.Replace(Chr(34), " ")
                obj.A = obj.A.Replace(Chr(34), " ")
                obj.Horario = obj.Horario.Replace(Chr(34), " ")
                obj.DatosContacto = obj.DatosContacto.Replace(Chr(34), " ")
                obj.InformacionReservas = obj.InformacionReservas.Replace(Chr(34), " ")

                'sql = "UPDATE Naviera SET " & _
                '      " DE='" & DE & "', " & _
                '      "  A='" & A & "', " & _
                '      " Horario='" & Horario & "', " & _
                '      " DatosContacto='" & DatosContacto & "' " & _
                '      " InformacionReservas='" & InformacionReservas & "' " & _
                '      " WHERE ID=" & ID
                '.CommandText = sql
                .CommandText = "UPDATE Naviera " & _
                               "   SET De=?, " & _
                               "       A=?, " & _
                               "       Horario=?, " & _
                              "       DatosContacto=?, " & _
                               "       InformacionReservas=?, " & _
                               "       Logo=? " & _
                               " WHERE ID=?"
                .ExecuteNonQuery()
            End With
            'Devuelve ID de la fila modificada
            Return obj.ID
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function

    Public Shared Function Add(obj As Naviera) As Long
        Dim id As Long = 0
        Try
            CrearConexion()
            'Parámetros
            'Parámetros
            Dim pid As New OleDbParameter, pDe As New OleDbParameter, pA As New OleDbParameter
            Dim pHorario As New OleDbParameter, pDatosContacto As New OleDbParameter, pInformacionReservas As New OleDbParameter
            Dim pLogo As New OleDbParameter
            With pDe
                .ParameterName = "@De"
                .DbType = DbType.String
                .Value = obj.De
            End With
            With pA
                .ParameterName = "@A"
                .DbType = DbType.String
                .Value = obj.A
            End With
            With pHorario
                .ParameterName = "@Horario"
                .DbType = DbType.String
                .Value = obj.Horario
            End With
            With pDatosContacto
                .ParameterName = "@DatosContacto"
                .DbType = DbType.String
                .Value = obj.DatosContacto
            End With
            With pInformacionReservas
                .ParameterName = "@InformacionReservas"
                .DbType = DbType.String
                .Value = obj.InformacionReservas
            End With
            With pLogo
                .ParameterName = "@Logo"
                .DbType = DbType.String
                .Value = obj.Logo
            End With

            'Commando para modificar la fila
            Dim comm As New OleDbCommand
            _Conn.Open()
            Dim sql As String
            With comm
                .Parameters.Add(pDe) : .Parameters.Add(pA)
                .Parameters.Add(pHorario) : .Parameters.Add(pDatosContacto) : .Parameters.Add(pInformacionReservas)
                .Parameters.Add(pLogo)
                .Connection = _Conn
                .CommandType = CommandType.Text
                sql = "INSERT INTO Naviera (De, A, horario, Datoscontacto, InformacionReservas, Logo)  " & _
                      " VALUES (@De, @A, @Horario, @Datoscontacto, @InformacionReservas, @Logo) " & _
                      " " '" SELECT @@identity"

                .CommandText = sql

                .Connection = _Conn
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
                .CommandText = "SELECT TOP 1 ID FROM Naviera ORDER BY ID DESC"
                'Devuelve la fila insertada
                id = .ExecuteScalar
                '.ExecuteNonQuery()
            End With
            Return id
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Function

    Shared Function GetbyID(ByVal ID As Long) As System.Data.DataRow
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
                               " FROM Naviera " & _
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

    Shared Sub Delete(obj As Naviera)
        Dim ta As New System.Data.DataTable, da As New OleDbDataAdapter
        Dim comm As New System.Data.OleDb.OleDbCommand
        Try
            CrearConexion()
            _Conn.Open()
            Dim p1 As New OleDbParameter
            With p1
                .ParameterName = "@ID"
                .DbType = DbType.Int32
                .Value = obj.ID
            End With
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "DELETE Naviera " & _
                               " WHERE ID=@ID"
                .Parameters.Add(p1)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _Conn.Close()
        End Try
    End Sub

    Shared Function Lista(Optional ByVal where As String = "", Optional ByVal orden As String = "De") As System.Data.DataTable
        Dim ta As New System.Data.DataTable, da As New OleDbDataAdapter
        Dim comm As New OleDbCommand
        Try
            CrearConexion()

            If Not where = String.Empty Then
                where = " WHERE " & where
            End If
            If Not orden = String.Empty Then
                orden = " ORDER BY " & orden
            End If
            With comm
                .Connection = _Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM Naviera " & where & orden
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


    Private Shared Sub CrearConexion()
        _ConnectionString = ConfigurationManager.ConnectionStrings.Item("AccessDatos").ConnectionString
        If _Conn Is Nothing Then
            _Conn = New OleDbConnection(_ConnectionString)
        End If
    End Sub
End Class
