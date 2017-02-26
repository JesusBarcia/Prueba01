<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VerMapa.aspx.vb" Inherits="VerMapa" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<link href="Styles/estilosimulador.css" rel="stylesheet" type="text/css" />
<title>Google Maps JavaScript API v3 Example: Polyline Simple</title>
<link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDl889BWdUIdYfY4FTj2Jty97Xru9_AGEo"></script>
<script type="text/javascript">
    var map;
    var geocoder = new google.maps.Geocoder();

    var directionsService1 = new google.maps.DirectionsService();
    var directionsDisplay1 = new google.maps.DirectionsRenderer();

    var directionsService2 = new google.maps.DirectionsService();
    var directionsDisplay2 = new google.maps.DirectionsRenderer();

    var directionsService3 = new google.maps.DirectionsService();
    var directionsDisplay3 = new google.maps.DirectionsRenderer();


    function initialize() {
    var myLatLng = new google.maps.LatLng(40, 0);
    var myOptions = {
      zoom: 4,
      center: myLatLng,
      mapTypeId: google.maps.MapTypeId.ROADMAP
      };
  map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

  //document.getElementById("htxtPuertoOrigenLat").value = 41.387;
  //document.getElementById("htxtPuertoOrigenLng").value = 2.17;
  //document.getElementById("htxtPuertoDestinoLat").value = 42.0911;
  //document.getElementById("htxtPuertoDestinoLng").value = 11.8;


      pintaRutaMaritima();
      pintaRutaTerrestre();
      map.setCenter(new google.maps.LatLng(40, 0));
    }    

    function pintaRutaTerrestre() {
        var start = arrTrayecto[0] //document.getElementById("htxtOrigenLarge").value;
        var end = arrTrayecto[1] // document.getElementById("htxtDestinoLarge").value;
        var puertoOrigen = arrTrayecto[2] //document.getElementById("htxtPuertoOrigenLarge").value;
        var puertoDestino = arrTrayecto[3] //document.getElementById("htxtPuertoDestinoLarge").value;


        var request1 = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        var request2 = {
            origin: start,
            destination: puertoOrigen,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        var request3 = {
            origin: puertoDestino,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };

        directionsService1.route(request1, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                var route = response.routes[0];
                directionsDisplay1.setDirections(response);
            }
        });

        directionsService2.route(request2, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                var route = response.routes[0];
                directionsDisplay2.setDirections(response);
            }
        });

        directionsService3.route(request3, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                var route = response.routes[0];
                directionsDisplay3.setDirections(response);
            }
        });

        directionsDisplay1.setMap(map);
        directionsDisplay2.setMap(map);
        directionsDisplay3.setMap(map);

    }

    function pintaRutaMaritima() {
        var contador = 0

        flightPlanCoordinates = new Array()
        for (i = 0; i < arrLineaCoordenadaGPS.length; i += 2) {
            flightPlanCoordinates[contador] = new google.maps.LatLng(arrLineaCoordenadaGPS[i], arrLineaCoordenadaGPS[i + 1]);
            contador++;
        }

        var flightPath = new google.maps.Polyline({
            path: flightPlanCoordinates,
            strokeColor: "#6b74ce",
            strokeOpacity: 1.0,
            strokeWeight: 6
        });
        flightPath.setMap(map);
    }


</script>
    <style type="text/css">
        #map_canvas
        {
            z-index: 1;
            left: 510px;
            top: 80px;
            position: absolute;
            height: 600px;
            width: 800px;
        }
    </style>
</head>

<body onload="initialize()">  
    <div id="header">
		<div id="header_r">
				<div id="logo"><img src="http://www.shortsea.es/templates/shortsea/images/shortsea.png" alt="logo_shortsea" /></div>
		</div>
    </div>
    <form id="form1" runat="server">
        <em>
            <asp:Label ID="LabelTituloTerrestre" runat="server" CssClass="titularazulgrande" Text="Transporte por carretera"></asp:Label>
        </em>  
        <asp:Panel ID="PanelResumenTerrestre" runat="server" Height="50px" Width="500px">
                <asp:Table ID="TablaResultadosTerrestre" runat="server" Height="40px" 
                           Width="500px" CssClass="blue" BorderColor="#E0E0E0" BorderStyle="Solid"> 
                </asp:Table> 
        </asp:Panel>   
        <em>
            <asp:Label ID="Label2" runat="server" CssClass="titularazulgrande" Text="Transporte marítimo"></asp:Label>
        </em>  
        <asp:Panel ID="PanelResumenMaritimos" runat="server" Height="100px" Width="500px">
                <asp:Table ID="TableResultadosMaritimos" runat="server" Height="40px" 
                           Width="500px" CssClass="blue" BorderColor="#E0E0E0" BorderStyle="Solid"> 
                </asp:Table> 
        </asp:Panel>           

    <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold"  ForeColor="Red" ></asp:Label>
    <br />
    <asp:Label ID="Label1" Text="Selecciona la línea marítima: " runat="server" CssClass="txtverdanasmall" />
    <br />
        <asp:HyperLink runat="server" ID="hypEnlaceComodalWeb"  Target="_blank" 
                ImageUrl="~/images/comodalwebico.png"></asp:HyperLink>

    <br />
    <asp:DropDownList ID="cmbLineas"  Width="500px" cssClass="blue" runat="server" AutoPostBack="True" />
   
    <br />

    <div id="map_canvas"></div>     
    </form>
</body>
</html>
