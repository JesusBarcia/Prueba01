<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Navegador.aspx.vb" Inherits="Navegador" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<!-- <link href="Styles/estilosimulador.css" rel="stylesheet" type="text/css" />-->
<link type="text/css" href="css/simulador.css" rel="stylesheet"/>
<title>Simulador de Cadenas de Transporte. Resultados en mapa</title>
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
        var myLatLng = new google.maps.LatLng(42, 4);
        var myOptions = {
            zoom: 5,
            center: myLatLng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        
        pintaRutaTerrestre();
        setTimeout("pintaRutaMaritima()", 1500);
        setTimeout("vistaInicial()", 1800);
        //pintaRutaMaritima();

    }

    function pintaRutaTerrestre() {
        var origen = arrTrayecto[0]
        var destino = arrTrayecto[1]
        var puertoOrigen = arrTrayecto[2]
        var puertoDestino = arrTrayecto[3]
        var puertoOrigenID = arrTrayecto[4]
        var puertoDestinoID = arrTrayecto[5]
        var naviera = arrTrayecto[6]
        var navieraID = arrTrayecto[7]

        var request1 = {
            origin: origen,
            destination: destino,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        var request2 = {
            origin: origen,
            destination: puertoOrigen,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        var request3 = {
            origin: puertoDestino,
            destination: destino,
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
        var origen = arrTrayecto[0] 
        var destino = arrTrayecto[1] 
        var puertoOrigen = arrTrayecto[2] 
        var puertoDestino = arrTrayecto[3]
        var puertoOrigenID = arrTrayecto[4]
        var puertoDestinoID = arrTrayecto[5]
        var naviera = arrTrayecto[6]
        var navieraID = arrTrayecto[7]
        var infoWindowNavieraGPS

        // coordenadas GPS de la ruta
        flightPlanCoordinates = new Array()
        for (i = 0; i < arrLineaCoordenadaGPS.length; i += 2) {
            flightPlanCoordinates[contador] = new google.maps.LatLng(arrLineaCoordenadaGPS[i], arrLineaCoordenadaGPS[i + 1]);
            contador++;
            if (i < 3) {
                infoWindowNavieraGPS = new google.maps.LatLng(arrLineaCoordenadaGPS[i], arrLineaCoordenadaGPS[i + 1]);
            }
        }

        // dibujo de la línea
        var flightPath = new google.maps.Polyline({
            path: flightPlanCoordinates,
            strokeColor: "#000000", //rojo "#FF0000", // verde "#00cc00", //azul original"#6b74ce",
            strokeOpacity: 1.0,
            strokeWeight: 3
        });
        flightPath.setMap(map);

        // iconos de puerto de origen y destino y naviera
        var markerPuertoOrigen = new google.maps.Marker({
                position:new google.maps.LatLng(arrLineaCoordenadaGPS[0]+2, arrLineaCoordenadaGPS[1]),
                map: map, 
                title: 'Puerto: ' + puertoOrigen });
        var long = arrLineaCoordenadaGPS.length;
        var markerPuertoDestino = new google.maps.Marker({
                position:new google.maps.LatLng(arrLineaCoordenadaGPS[long-2]+2, arrLineaCoordenadaGPS[long-1]),
                map: map,
                title: 'Puerto: ' + puertoDestino
            });

         var markerNaviera = new google.maps.Marker({
                position: infoWindowNavieraGPS,
                map: map,
                icon: './images/bandera-roja.png',
                title: 'Linea: ' + naviera
            });


        // infowindow de puertos de origen y destino
            var contentStringOrigen = '<div id="div_infowindow">' + '<p>Puerto: <b>' + puertoOrigen + '</b><br/> '
            if (puertoOrigenID!=0){
            contentStringOrigen = contentStringOrigen + 
                                '<a href="./verPuerto.aspx?ID=' + puertoOrigenID + '" target="_blank">Información sobre el puerto de origen/Information about the port of origin </a> </div>';
            }
            var infowindowOrigen = new google.maps.InfoWindow({ content: contentStringOrigen });
            google.maps.event.addListener(markerPuertoOrigen, 'click', function () {
                infowindowOrigen.open(map, markerPuertoOrigen);
            });

            var contentStringDestino = '<div id="div_infowindow">' + 'Puerto: <b>' + puertoDestino + '</b><br/> ' 
            if (puertoDestinoID!=0){
                contentStringDestino = contentStringDestino + 
                                '<a href="./verPuerto.aspx?ID=' + puertoDestinoID + '" target="_blank">Información sobre el puerto de destino//Information about the port of destination </a> </div>';
            }
            var infowindowDestino = new google.maps.InfoWindow({ content: contentStringDestino });
            google.maps.event.addListener(markerPuertoDestino, 'click', function () {
                infowindowDestino.open(map, markerPuertoDestino);
            });

            var contentStringNaviera = '<div id="div_infowindow">' + 'Linea: <b>' + naviera + '</b><br/> '
            if (navieraID != 0) {
                contentStringNaviera = contentStringNaviera +
                                '<a href="./verNaviera.aspx?ID=' + navieraID + '" target="_blank">Enlace Servicio TMCD</a> </div>';
            }
            var infowindowNaviera = new google.maps.InfoWindow({ content: contentStringNaviera });
            google.maps.event.addListener(markerNaviera, 'click', function () {
                infowindowNaviera.open(map, markerNaviera);
            });

            google.maps.event.addListener(flightPath, 'click', function (evt) {
                //alert('encontrado');
                infowindowNaviera.open(map, markerNaviera);
            });
    }   

    function vistaInicial() {
        map.setCenter(new google.maps.LatLng(42, 4));
        map.setZoom(5);
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
        #div_infowindow
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 10px;
	        font-weight: normal;
	        color: #006699;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
        <asp:Label ID="LabelTituloTerrestre" runat="server" CssClass="titularazulgrande" Text="Cadena de Transporte sólo por carretera"></asp:Label>
        <asp:Label ID="LabelTituloTerrestre_EN" runat="server" CssClass="titularazulgrande_EN" Text="/'Only Road' transport Chain"></asp:Label>

        <asp:Panel ID="PanelResumenTerrestre" runat="server" Height="80px" Width="500px">
                <asp:Table ID="TablaResultadosTerrestre" runat="server" Height="60px" 
                           Width="500px" CssClass="blue" BorderColor="#E0E0E0" BorderStyle="Solid"> 
                </asp:Table> 
        </asp:Panel>   
        <asp:Label ID="Label2" runat="server" CssClass="titularazulgrande" Text="Cadena Tte Marítimo Corta Dist.(TMCD)"></asp:Label>
        <asp:Label ID="Label3" runat="server" CssClass="titularazulgrande_EN" Text="/Short Sea Shipping(SSS) Chain"></asp:Label>

        <asp:Panel ID="PanelResumenMaritimos" runat="server" Height="200px" Width="500px">
                <asp:Table ID="TableResultadosMaritimos" runat="server" Height="40px" 
                           Width="500px" CssClass="blue" BorderColor="#E0E0E0" BorderStyle="Solid"> 
                </asp:Table> 
        </asp:Panel>           
        <br />
        <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold"  ForeColor="Red" ></asp:Label>
        <br />

        <asp:Label ID="Label1" Text="Selecciona la línea marítima " CssClass="titularazulgrande" runat="server" />
        <asp:Label ID="Label4" Text="/Select a SSS line: " CssClass="titularazulgrande_EN" runat="server" />
        <br />
        <asp:DropDownList ID="cmbLineas"  Width="500px" cssClass="blue" runat="server" AutoPostBack="True" />
        <br />
        <br />
        <asp:Button ID="btnNuevaSimulacion" runat="server" CssClass="blue" Text="Nueva Simulación/New simulation " Width="250px" />
        <br /><br />
        <b><u>
        <asp:HyperLink runat="server" ID="hypEnlaceComodalWeb2"  Target="_blank" 
                BorderStyle="None"  
                CssClass="titularnegro"
                Text="Deja tus comentarios y observaciones sobre la ruta <br>elegida en la plataforma COMODALWEB 2.0"
                ToolTip="Deja tus comentarios y observaciones sobre la ruta elegida en la plataforma COMODALWEB 2.0"
                BorderWidth="0px" ></asp:HyperLink>
        </u></b><br />
        <b><u>
        <asp:HyperLink runat="server" ID="hypEnlaceComodalWeb3"  Target="_blank" 
                BorderStyle="None"  
                CssClass="titularnegro_EN"
                Text="Leave your comments and observations about the selected <br>route at the COMODALWEB 2.0 platform"
                ToolTip="Leave your comments and observations about the selected route at the COMODALWEB 2.0 platform"
                BorderWidth="0px" ></asp:HyperLink>
        </u></b>&nbsp;
        <br />
        <asp:HyperLink runat="server" ID="hypEnlaceComodalWeb"  Target="_blank" 
                ImageUrl="~/images/comodalwebico.png" BorderStyle="None"  
                ToolTip="Deja tus comentarios y observaciones sobre la ruta elegida en la plataforma COMODALWEB 2.0/Leave your comments and observations about the selected route at the COMODALWEB 2.0 platform"
                BorderWidth="0px" CssClass="txtverdanasmall" ></asp:HyperLink>


        <div id="map_canvas"></div>     
<br />

    </form>
</body>
</html>
