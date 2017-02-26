Imports Microsoft.VisualBasic
Imports System.Web.Script.Serialization
Public Structure CoordenadaGPS
    Dim Longitud As Double
    Dim Latitud As Double
End Structure
Public Class Funciones

    Shared Function Distancia(ByVal Origen As String, ByVal Destino As String) As Single
        'Se comprueba si está en la base de datos el origen y destino
        Dim respuesta As String
        Dim nDistanciaTotal As Double = 0, nTiempoTotal As Double = 0
        Dim dr As System.Data.DataRow = Datos.ArchivoJSonGet(Origen, Destino)
        If Not IsDBNull(dr.Item("ID")) Then
            nDistanciaTotal = Funciones.Coma2Punto(dr.Item("DistanciaTotal"))
            nTiempoTotal = Funciones.Coma2Punto(dr.Item("TiempoTotal"))
        Else
            respuesta = GoogleMapJSON.GetDistanciaMatrix(Origen, Destino)
            Dim obj2 As Object
            Dim js2 As JavaScriptSerializer = New JavaScriptSerializer()
            obj2 = js2.Deserialize(Of Object)(respuesta)
            If obj2("status") = "OK" Then
                nDistanciaTotal = obj2("rows")(0)("elements")(0)("distance")("value")
                nTiempoTotal = obj2("rows")(0)("elements")(0)("duration")("value")
            ElseIf obj2("status").ToString.StartsWith("OVER_QUERY_LIMIT") Then
                Throw New Exception("Error. Se ha rebasado el máximo de consultas a Google Maps")
            ElseIf obj2("status").ToString.StartsWith("ZERO_RESULTS") Then
                Throw New Exception("Error. No se ha encontrado ruta terrestre entre " & Origen & " y " & Destino)
            ElseIf obj2("status").ToString.StartsWith("NOT_FOUND") Then
                Throw New Exception("Error. No se ha encontrado " & Origen & " o " & Destino)
            Else
                nDistanciaTotal = 1000
                nTiempoTotal = 1000
            End If
            Datos.ArchivoJSonSave(Origen, Destino, nDistanciaTotal, nTiempoTotal)
        End If
        Return nDistanciaTotal / 1000
    End Function


    Shared Function TiempoHoras(ByVal Origen As String, ByVal Destino As String) As Single
        'Se comprueba si está en la base de datos el origen y destino
        'Devuelve el tiempo en horas
        Dim respuesta As String
        Dim nDistanciaTotal As Double = 0, nTiempoTotal As Double = 0
        Dim dr As System.Data.DataRow = Datos.ArchivoJSonGet(Origen, Destino)
        If Not IsDBNull(dr.Item("ID")) Then
            nDistanciaTotal = Funciones.Coma2Punto(dr.Item("DistanciaTotal"))
            nTiempoTotal = Funciones.Coma2Punto(dr.Item("TiempoTotal"))
        Else
            respuesta = GoogleMapJSON.GetRoute(Origen, Destino)
            Dim obj2 As Object
            Dim js2 As JavaScriptSerializer = New JavaScriptSerializer()
            obj2 = js2.Deserialize(Of Object)(respuesta)
            If obj2("status") = "OK" Then
                nDistanciaTotal = obj2("routes")(0)("legs")(0)("distance")("value")
                nTiempoTotal = obj2("routes")(0)("legs")(0)("duration")("value")
            Else
                nDistanciaTotal = 1000
                nTiempoTotal = 1000
            End If
            Datos.ArchivoJSonSave(Origen, Destino, nDistanciaTotal, nTiempoTotal)
        End If
        Return nTiempoTotal / 3600
    End Function

    Shared Function GetCoordenadaGPS(ByVal address As String) As CoordenadaGPS
        'Se comprueba si está en la base de datos el origen y destino
        Dim respuesta As String
        Dim retorno As CoordenadaGPS
        With retorno
            .Longitud = 0
            .Latitud = 0
        End With
        respuesta = GoogleMapJSON.GetGoogleGeocode(address)
        Dim obj2 As Object
        Dim js2 As JavaScriptSerializer = New JavaScriptSerializer()
        obj2 = js2.Deserialize(Of Object)(respuesta)
        If obj2("status") = "OK" Then
            retorno.Longitud = obj2("results")(0)("geometry")("location")("lng")
            retorno.Latitud = obj2("results")(0)("geometry")("location")("lat")
        ElseIf obj2("status").ToString.StartsWith("OVER_QUERY_LIMIT") Then
            Throw New Exception("Error. Se ha rebasado el máximo de consultas a Google Maps")
        ElseIf obj2("status").ToString.StartsWith("ZERO_RESULTS") Then
            Throw New Exception("Error. No se ha encontrado las coordenadas de " & address)
        ElseIf obj2("status").ToString.StartsWith("NOT_FOUND") Then
            Throw New Exception("Error. No se ha encontrado " & address)
        End If
        Return retorno
    End Function


    Shared Function LineaGetCoordenadaGPS(ByVal LineaID As Integer) As String
        'Devuelve un array de string con las coordenadas GPS de la ruta marítima
        Dim dt As System.Data.DataTable = Datos.LineaGPSGetCoordenadasByLineaID(LineaID)
        Dim retorno(dt.Rows.Count - 1, 1) As String
        For x As Integer = 0 To dt.Rows.Count - 1
            retorno(x, 0) = dt.Rows(x).Item("Latitud")
            retorno(x, 1) = dt.Rows(x).Item("Longitud")
        Next
        Return ArrayToString(retorno)
    End Function

    Shared Function ArrayToString(ByVal arr(,) As String) As String
        Dim retorno As New StringBuilder
        'retorno.Append(Chr(34))
        For x As Integer = 0 To arr.GetLength(0) - 1
            retorno.Append(Chr(34) & arr(x, 0).Replace(",", ".") & Chr(34) & ",")
            retorno.Append(Chr(34) & arr(x, 1).Replace(",", ".") & Chr(34))
            If x <> arr.GetLength(0) - 1 Then
                retorno.Append(",")
            End If
        Next
        'retorno.Append(Chr(34))
        Return retorno.ToString
    End Function

    Shared Function Coma2Punto(ByVal c As Object) As String
        Dim retorno As String = ""
        If Not IsDBNull(c) Then
            Dim entrada As String = CType(c, String)
            If entrada.IndexOf(".") <> 0 Then
                retorno = entrada
            Else
                retorno = entrada.Replace(",", ".")
            End If
        End If
        Return retorno
    End Function
    Shared Function Punto2Coma(ByVal c As Object) As String
        Dim retorno As String = ""
        If Not IsDBNull(c) Then
            Dim entrada As String = CType(c, String)
            If entrada.IndexOf(",") <> 0 Then
                retorno = entrada
            Else
                retorno = entrada.Replace(".", ",")
            End If
        End If
        Return retorno
    End Function



    Shared Function StringNormalizar(ByVal c As String) As String
        Dim x As Integer, retorno As String = ""
        Dim index As Integer = 0
        Dim juegoChar As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-;,:._-/()ÁÉÍÓÚÇabcdefghijklmnñopqrstuvwxyzáéíóú "
        For x = 0 To c.Length - 1
            index = juegoChar.IndexOf(c.Substring(x, 1))
            If index <> -1 Then
                retorno = retorno & c.Substring(x, 1)
            End If
        Next
        Return retorno
    End Function
End Class
