<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DefinirLineaMaritima.aspx.vb" Inherits="DefinirLineaMaritima" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<link href="../Styles/estilosimulador.css" rel="stylesheet" type="text/css" />
<title>Simulador de costes. Resultados en mapa</title>
<link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC8LBFcmQ1Zte3ulax4mds6eRihyIpQhV0"></script>
<script type="text/javascript">
    var map;
    var geocoder = new google.maps.Geocoder();

    var directionsService1 = new google.maps.DirectionsService();
    var directionsDisplay1 = new google.maps.DirectionsRenderer();
    var flightPath = new google.maps.Polyline
    var tbl = document.createElement("table");

    function initialize() {
        var myLatLng = new google.maps.LatLng(42, 4);
        var myOptions = {
            zoom: 5,
            center: myLatLng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

        pintaRutaMaritima();
        //google.maps.event.addListener(map, 'click', function (event) { placeMarker(event.latLng); });

        google.maps.event.addListener(map, 'click', placeMarker2);
        array2txt();

    }

    function placeMarker2(event) {
        //alert(event.latLng.Pa);
        //alert(event.latLng.Qa);
        placeMarker(event.latLng);
    }
     
     function placeMarker(location) {   
     //var clickedLocation = new google.maps.LatLng(location);   
     //var marker = new google.maps.Marker({       position: location,        map: map   });    
         //map.setCenter(location); 
         var orden = document.getElementById("txtOrden");
         var long = arrLineaCoordenadaGPS.length;
         //alert("latitud:" + location.Pa);
         //alert("longitud: "  + location.Qa);
         if (orden.value*2 >= long) {
             arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.Ya; //location.Pa;
             arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.Za; //location.Qa;
         }
         else {
             for (i = long; i > orden.value*2; i -= 2) {
                 arrLineaCoordenadaGPS[i] = arrLineaCoordenadaGPS[i - 2];
                 arrLineaCoordenadaGPS[i + 1] = arrLineaCoordenadaGPS[i - 1];
             }
             //arrLineaCoordenadaGPS[orden.value * 2] = location.Na;
             //arrLineaCoordenadaGPS[orden.value * 2 + 1] = location.Oa;
             arrLineaCoordenadaGPS[orden.value * 2] = location.Ya; //location.Pa;
             arrLineaCoordenadaGPS[orden.value * 2 + 1] = location.Za; //location.Qa;
         }

         pintaRutaMaritima();
         document.getElementById("txtOrden").value = Number(document.getElementById("txtOrden").value) + 1;
         array2txt();
     }

     function pintaRutaMaritima() {
        var contador = 0
        // coordenadas GPS de la ruta
        flightPlanCoordinates = new Array();
        flightPath.setPath(flightPlanCoordinates); // Borrar la ruta anterior
        for (i = 0; i < arrLineaCoordenadaGPS.length; i += 2) {
            flightPlanCoordinates[contador] = new google.maps.LatLng(arrLineaCoordenadaGPS[i], arrLineaCoordenadaGPS[i + 1]);
            contador++;
        }

        // dibujo de la línea
 
        flightPath = new google.maps.Polyline({
            path: flightPlanCoordinates,
            strokeColor: "#6b74ce",
            strokeOpacity: 1.0,
            strokeWeight: 6
        });
        flightPath.setMap(map);
    }


    function borrarCoordenadas() {
        var gps0 = arrLineaCoordenadaGPS[0];
        var gps1 = arrLineaCoordenadaGPS[1];
        var gps2 = arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length - 2];
        var gps3 = arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length - 1];
        //Dejar solo las 4 primeras coordenadas
        arrLineaCoordenadaGPS.splice(4, arrLineaCoordenadaGPS.length - 4);

        arrLineaCoordenadaGPS[0] = gps0;
        arrLineaCoordenadaGPS[1] = gps1;
        arrLineaCoordenadaGPS[2]=gps2;
        arrLineaCoordenadaGPS[3]=gps3;


        pintaRutaMaritima();
        document.getElementById("txtOrden").value = 2;
        array2txt();
        
    }


    function array2txt() {
        var objtxt = document.getElementById("txtDatos")
        var cad = ''
        var contador = 0
        for (i = 0; i < arrLineaCoordenadaGPS.length; i = i + 2) {
            contador++
            cad = cad + contador + " LONG: " + arrLineaCoordenadaGPS[i] + "  ";
            cad = cad + "LAT: " + arrLineaCoordenadaGPS[i + 1];
            if (i!=arrLineaCoordenadaGPS.length-1) {cad=cad  + '\n'};
        }
        objtxt.value = cad;

        var objtxt = document.getElementById("txtRegistro")
        cad = ''
        for (i = 0; i < arrLineaCoordenadaGPS.length; i++) {
            cad = cad + arrLineaCoordenadaGPS[i]
            if (i != arrLineaCoordenadaGPS.length - 1) { cad = cad + '@' };
        }
        objtxt.value = cad;



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
    <form id="form1" runat="server">
        <p><a href="LineasListado.aspx" target="_self">Volver a listado de líneas</a></p>
        <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold"  ForeColor="Red" ></asp:Label>
        <br />
        <asp:Label ID="LineaID" runat="server" width="50px" Text="LineaID: "></asp:Label>
        <asp:TextBox ID="txtLineaID" text="" runat="server" Width="50px" ReadOnly="True"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" width="50px" Text="Orden: "></asp:Label>
        <asp:TextBox ID="txtOrden" text="1" runat="server" Width="50px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtDatos" Width="470px" Height="324px" Text="" 
            runat="server" TextMode="MultiLine" />
        <br />
        <asp:Button ID="btnEnviar" Text = "Enviar" runat="server" />
        &nbsp;&nbsp;&nbsp;
        <input type="button" ID="bntBorrarCoordenadas" value="Borrar Coordenadas"  onclick="javascript: borrarCoordenadas()"/>

        <div id="map_canvas"></div>
        <asp:TextBox ID="txtRegistro" Width="1px" Height="1px" Text="" 
            runat="server" />
    </form>
</body>
</html>
