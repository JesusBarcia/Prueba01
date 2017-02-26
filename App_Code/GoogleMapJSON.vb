Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Globalization
Imports System.IO
Public Class GoogleMapJSON


    'Const FindNearbyWeatherUrl As String = "http://ws.geonames.org/findNearByWeatherJSON?lat={0}&lng={1}"
    Const FindNearbyWeatherUrl As String = "http://maps.google.com/maps/api/geocode/json?latlng={0},{1}&region=ES"

    Const RouteUrl As String = "http://maps.google.com/maps/api/directions/json?origin={0}&destination={1}&mode={2}&region=ES"
    Const GeocodeUrl As String = "http://maps.google.com/maps/api/geocode/json?address={0}&region=ES"
    Const DistanciaMatrixUrl As String = "http://maps.googleapis.com/maps/api/distancematrix/json?origins={0}&destinations={1}&mode={2}&region=ES"

    Public Shared Function GetDistanciaMatrix(ByVal Origen As String, ByVal Destino As String) As String
        Dim formattedUri As String = String.Format(CultureInfo.InvariantCulture, DistanciaMatrixUrl, Origen, Destino, "driving")
        Dim webRequest As HttpWebRequest = GetWebRequest(formattedUri)
        Dim response As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
        Dim jsonResponse As String = String.Empty
        Using sr As StreamReader = New StreamReader(response.GetResponseStream())
            jsonResponse = sr.ReadToEnd()
        End Using
        Return jsonResponse
    End Function

    Public Shared Function GetRoute(ByVal Origen As String, ByVal Destino As String) As String
        Dim formattedUri As String = String.Format(CultureInfo.InvariantCulture, RouteUrl, Origen, Destino, "driving")
        Dim webRequest As HttpWebRequest = GetWebRequest(formattedUri)
        Dim response As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
        Dim jsonResponse As String = String.Empty
        Using sr As StreamReader = New StreamReader(response.GetResponseStream())
            jsonResponse = sr.ReadToEnd()
        End Using
        Return jsonResponse
    End Function
    Public Shared Function GetWeatherByLocation(ByVal lat As Double, ByVal lng As Double) As String
        Dim formattedUri As String = String.Format(CultureInfo.InvariantCulture, FindNearbyWeatherUrl, lat, lng)
        Dim webRequest As HttpWebRequest = GetWebRequest(formattedUri)
        Dim response As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
        Dim jsonResponse As String = String.Empty
        Using sr As StreamReader = New StreamReader(response.GetResponseStream())
            jsonResponse = sr.ReadToEnd()
        End Using
        Return jsonResponse
    End Function
    Public Shared Function GetGoogleGeocode(ByVal address As String) As String
        Dim formattedUri As String = String.Format(CultureInfo.InvariantCulture, GeocodeUrl, address)
        Dim webRequest As HttpWebRequest = GetWebRequest(formattedUri)
        Dim response As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
        Dim jsonResponse As String = String.Empty
        Using sr As StreamReader = New StreamReader(response.GetResponseStream())
            jsonResponse = sr.ReadToEnd()
        End Using
        Return jsonResponse
    End Function


    Private Shared Function GetWebRequest(ByVal formattedUri As String) As HttpWebRequest
        '// Create the request’s URI.
        Dim serviceUri As Uri = New Uri(formattedUri, UriKind.Absolute)
        '// Return the HttpWebRequest.
        Return CType(System.Net.WebRequest.Create(serviceUri), HttpWebRequest)
    End Function

End Class
