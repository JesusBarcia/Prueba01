<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DefinirRutaMaritima.aspx.vb" Inherits="DefinirRutaMaritima" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<link href="Styles/estilosimulador.css" rel="stylesheet" type="text/css" />
<title>Simulador de costes. Resultados en mapa</title>
<link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDl889BWdUIdYfY4FTj2Jty97Xru9_AGEo"></script>
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
        pintarCoordenadas();

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
             //arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.lat;
             //arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.lng;
             arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.Pa;
             arrLineaCoordenadaGPS[arrLineaCoordenadaGPS.length] = location.Qa;
         }
         else {
             for (i = long; i > orden.value*2; i -= 2) {
                 arrLineaCoordenadaGPS[i] = arrLineaCoordenadaGPS[i - 2];
                 arrLineaCoordenadaGPS[i + 1] = arrLineaCoordenadaGPS[i - 1];
             }
             //arrLineaCoordenadaGPS[orden.value * 2] = location.Na;
             //arrLineaCoordenadaGPS[orden.value * 2 + 1] = location.Oa;
             arrLineaCoordenadaGPS[orden.value * 2] = location.Pa;
             arrLineaCoordenadaGPS[orden.value * 2 + 1] = location.Qa;
         }

         pintarCoordenadas();
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

    function pintarCoordenadas() {
        // creates a <table> element and a <tbody> element
        var body = document.getElementsByTagName("body")[0];
        var tblBody = document.createElement("tbody");
        
        // creating all cells
        for (var j = 0; j < arrLineaCoordenadaGPS.length; j+=2) {
            // creates a table row

            var row = document.createElement("tr");
                var cell1 = document.createElement("td");
                var cellText1 = document.createTextNode(arrLineaCoordenadaGPS[j]);
                cell1.appendChild(cellText1);
                row.appendChild(cell1);

                var cell2 = document.createElement("td");
                var cellText2 = document.createTextNode(arrLineaCoordenadaGPS[j+1]);
                cell2.appendChild(cellText2);
                row.appendChild(cell2);

            // add the row to the end of the table body
            tblBody.appendChild(row);
        }

        // put the <tbody> in the <table>
        tbl.appendChild(tblBody);
        // appends <table> into <body>
        body.appendChild(tbl);
        // sets the border attribute of tbl to 2;
        tbl.setAttribute("border", "2");
    }


    function array2txt() {
        var objtxt = document.getElementById("txtDatos")
        var cad = ''
        for (i = 0; i < arrLineaCoordenadaGPS.length; i++) {
            cad = cad + arrLineaCoordenadaGPS[i];
            if (i!=arrLineaCoordenadaGPS.length-1) {cad=cad  + '@'};
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
        <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold"  ForeColor="Red" ></asp:Label>
        <br />
        <asp:Label ID="Label1" Text="Selecciona la línea marítima: " CssClass="titularazulgrande" runat="server" />
        <br />
        <asp:DropDownList ID="cmbLineas"  Width="500px" cssClass="blue" runat="server" AutoPostBack="True" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Orden: "></asp:Label>
        <asp:TextBox ID="txtOrden" text="1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtDatos" Width="415px" Height="324px" Text="" 
            runat="server" />
        <br />
        <asp:Button ID="btnEnviar" Text = "Enviar" runat="server" />
        <div id="map_canvas"></div>
    </form>
</body>
</html>
