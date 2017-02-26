<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PoligonoSimple.aspx.vb" Inherits="PoligonoSimple" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<title>Google Maps JavaScript API v3 Example: Polyline Simple</title>
<link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDl889BWdUIdYfY4FTj2Jty97Xru9_AGEo"></script>
<script type="text/javascript">
     var geocoder = new google.maps.Geocoder();
     var map;
         
    function initialize() {
    var myLatLng = new google.maps.LatLng(40, 0);
    var myOptions = {
      zoom: 7,
      center: myLatLng,
      mapTypeId: google.maps.MapTypeId.TERRAIN
      };
  map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
  document.getElementById("htxtOrigenLat").value=41.387;
  document.getElementById("htxtOrigenLng").value=2.17;
  document.getElementById("htxtDestinoLat").value=42.0911;
  document.getElementById("htxtDestinoLng").value=11.8;

  pintaRuta();
    }

    function pintaRuta() {
        comprobarAddress();
        var latOrigen = document.getElementById("htxtOrigenLat").value;
        var lngOrigen = document.getElementById("htxtOrigenLng").value;
        var latDestino= document.getElementById("htxtDestinoLat").value;
        var lngDestino = document.getElementById("htxtDestinoLng").value;

        var flightPlanCoordinates = [
        new google.maps.LatLng(latOrigen, lngOrigen),
        new google.maps.LatLng(latDestino, lngDestino)
        ];
        var flightPath = new google.maps.Polyline({
            path: flightPlanCoordinates,
            strokeColor: "#FF0000",
            strokeOpacity: 1.0,
            strokeWeight: 4
        });
        flightPath.setMap(map);
    }

   
    function comprobarAddress() {
        // variables
        var addressOrigen = document.getElementById("txtOrigen");
        var addressOrigenLarge = document.getElementById("txtOrigenLarge");
        var haddressOrigen = document.getElementById("htxtOrigen");
        var haddressOrigenLarge = document.getElementById("htxtOrigenLarge");
        var haddressOrigenLat = document.getElementById("htxtOrigenLat");
        var haddressOrigenLng = document.getElementById("htxtOrigenLng");

        var addressOrigenImagenOK = document.getElementById("imgOrigenOK");
        var addressOrigenImagenError = document.getElementById("imgOrigenError");

        var addressDestino = document.getElementById("txtDestino");
        var addressDestinoLarge = document.getElementById("txtDestinoLarge");
        var haddressDestino = document.getElementById("htxtDestino");
        var haddressDestinoLarge = document.getElementById("htxtDestinoLarge");
        var haddressDestinoLat = document.getElementById("htxtDestinoLat");
        var haddressDestinoLng = document.getElementById("htxtDestinoLng");

        var addressDestinoImagenOK = document.getElementById("imgDestinoOK");
        var addressDestinoImagenError = document.getElementById("imgDestinoError");

        var txtRuta = document.getElementById("txtRuta")

        // ocultar imágenes de origen y destino
        addressOrigenImagenOK.style.visibility = "hidden";
        addressOrigenImagenError.style.visibility = "hidden";
        addressDestinoImagenOK.style.visibility = "hidden";
        addressDestinoImagenError.style.visibility = "hidden";

        // Crear objeto geocoder
        if (!geocoder) {
            geocoder = new google.maps.Geocoder();
        }

        // Buscar el origen en Google.Map

        if (!addressOrigen.value == haddressOrigen.value || !haddressOrigen.value == "") {
            var geocoderRequestOrigen = { address: addressOrigen.value };
            geocoder.geocode(geocoderRequestOrigen, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    addressOrigenImagenOK.style.visibility = "visible";
                    addressOrigenLarge.innerHTML = results[0].formatted_address;
                    haddressOrigen.value = addressOrigen.value;
                    haddressOrigenLarge.value = addressOrigenLarge.innerHTML;
                    haddressOrigenLat.value = results[0].geometry.location.lat();
                    haddressOrigenLng.value = results[0].geometry.location.lng();
                }
                if (status == google.maps.GeocoderStatus.ZERO_RESULTS) {
                    addressOrigenImagenError.style.visibility = "visible";
                    addressOrigenLarge.innerHTML = "";
                    haddressOrigen.value = "";
                    haddressOrigenLarge.value = "";
                    haddressOrigenLat.value = 0;
                    haddressOrigenLng.value = 0;

                }
            })
        }


        // Buscar el destino en Google.Map
        if (!addressDestino.value == haddressDestino.value || !haddressDestino.value == "") {
            var geocoderRequestDestino = { address: addressDestino.value };
            geocoder.geocode(geocoderRequestDestino, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    addressDestinoImagenOK.style.visibility = "visible";
                    addressDestinoLarge.innerHTML = results[0].formatted_address;
                    haddressDestino.value = addressDestino.value;
                    haddressDestinoLarge.value = addressDestinoLarge.innerHTML;
                    haddressDestinoLat.value = results[0].geometry.location.lat();
                    haddressDestinoLng.value = results[0].geometry.location.lng();
                }
                if (status == google.maps.GeocoderStatus.ZERO_RESULTS) {
                    addressDestinoImagenError.style.visibility = "visible";
                    addressDestinoLarge.innerHTML = "";
                    haddressDestino.value = "";
                    haddressDestinoLarge.value = "";
                    haddressDestinoLat.value = 0;
                    haddressDestinoLng.value = 0;

                }
            })
        }

    }



</script>
    <style type="text/css">
        #map_canvas {
            height: 297px;
        }
    </style>
</head>
<body onload="initialize()">
    <form id="form1" runat="server">

     <div>
        <asp:Label ID="lblOrigen" Width="60px" CssClass="" Text="Origen: " runat="server"/>
        <asp:TextBox ID="txtOrigen" Width="200px" runat="server" onblur="comprobarAddress()"/>
        <img src="./images/check.png" name="imgOrigenOK" id="imgOrigenOK" alt="" style="visibility:hidden"/>
        <img src="./images/cross.png" name="imgOrigenError" id="imgOrigenError" alt="" style="visibility:hidden" />
        <asp:Label name="txtOrigenLarge" ID="txtOrigenLarge" runat="server" text="LabelPrueba1" Widht="300px"/>
     <br />
        <asp:Label ID="lblDestino" Width="60px" Text="Destino: " runat="server"/>
        <asp:TextBox ID="txtDestino" Width="200px" runat="server" onblur="comprobarAddress()"/>
        <img src="./images/check.png" name="imgDestinoOK" id="imgDestinoOK" alt="" style="visibility:hidden"/>
        <img src="./images/cross.png" name="imgDestinoError" id="imgDestinoError" alt="" style="visibility:hidden" />
        <asp:Label name="txtDestinoLarge" ID="txtDestinoLarge" runat="server" text="LabelPrueba2" Widht="300px"/>
     <br />
    <asp:Button ID="btnVerMapa" Text="Ver Mapa"  OnClientClick="javascript:pintaRuta()" runat="server"  />
    <input type="button" id="btVerMapa" value="Ver Mapa" onclick="javascript:pintaRuta()" />
    </div>

     <div id="map_canvas"></div>       
    <asp:HiddenField ID="htxtOrigen" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtOrigenLarge" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtOrigenLat" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtOrigenLng" runat="server" ></asp:HiddenField>

    <asp:HiddenField ID="htxtDestino" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtDestinoLarge" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtDestinoLat" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtDestinoLng" runat="server" ></asp:HiddenField>

    <asp:HiddenField ID="htxtTiempo" runat="server" ></asp:HiddenField>
    <asp:HiddenField ID="htxtDistanciaTotal" runat="server" ></asp:HiddenField>

    </form>
</body>
</html>
