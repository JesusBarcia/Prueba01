<%@ Page Language="VB" AutoEventWireup="false" CodeFile="simuladorNEW.aspx.vb" Inherits="SimuladorNEW" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Simulador Shortsea Spain</title>
<link type="text/css" href="css/simulador.css" rel="stylesheet"/>

<!---------------------------------------------------------------->
<!------------inicio javascript simulador------------------------->
<!---------------------------------------------------------------->

<script type="text/javascript" src="http://maps.google.com/maps/api/js"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDl889BWdUIdYfY4FTj2Jty97Xru9_AGEo"></script>
<script type="text/javascript">
    var geocoder = new google.maps.Geocoder();
    google.maps.event.addDomListener(window, 'load', initialize);

    function quitarsetTimeout() {
        window.clearTimeout;
    }

    function verAyuda() {
        window.open('ayuda.pdf', 'cal', 'width=400,height=250,left=270,top=180', toolbar = no)
    }

    function initialize() {
        //var inputOrigen = document.getElementById('txtOrigen');
        //var inputDestino = document.getElementById('txtDestino');
        //var autocompleteOrigen = new google.maps.places.Autocomplete(inputOrigen);
        //var autocompleteDestino = new google.maps.places.Autocomplete(inputDestino);
        //var infowindowOrigen = new google.maps.InfoWindow();
        //var infowindowDestino = new google.maps.InfoWindow();

        //google.maps.event.addListener(autocompleteOrigen, 'place_changed', function () {
        //    infowindowOrigen.close();
        //    var placeOrigen = autocompleteOrigen.getPlace();
        //    var addressOrigen = '';
        //    if (placeOrigen.address_components) {
        //        addressOrigen = [(placeOrigen.address_components[0] &&
        //                placeOrigen.address_components[0].short_name || ''),
        //               (placeOrigen.address_components[1] &&
        //                placeOrigen.address_components[1].short_name || ''),
         //              (placeOrigen.address_components[2] &&
        //                placeOrigen.address_components[2].short_name || '')
        //              ].join(' ');
        //    }

//            infowindowOrigen.setContent('<div><strong>' + placeOrigen.name + '</strong><br>' + addressOrigen)
        //        });


        //google.maps.event.addListener(autocompleteDestino, 'place_changed', function () {
        //    infowindowDestino.close();
        //    var placeDestino = autocompleteDestino.getPlace();
        //    var addressDestino = '';
        //    if (placeDestino.address_components) {
        //        addressDestino = [(placeDestino.address_components[0] &&
        //                placeDestino.address_components[0].short_name || ''),
        //               (placeDestino.address_components[1] &&
        //                placeDestino.address_components[1].short_name || ''),
        //               (placeDestino.address_components[2] &&
        //                placeDestino.address_components[2].short_name || '')
        //              ].join(' ');
        //    }

            //infowindowDestino.setContent('<div><strong>' + placeDestino.name + '</strong><br>' + addressDestino)
        //});
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
            var geocoderRequestOrigen = { address: addressOrigen.value, language: 'ES', region: 'ES' };
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
            var geocoderRequestDestino = { address: addressDestino.value, language: 'ES', region: 'ES' };
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



    function nuevaConsulta() {
        document.getElementById("map_canvas").style.visibility = "hidden";
        document.getElementById("txtOrigen").value = "";
        document.getElementById("txtOrigenLarge").innerHTML = "";
        document.getElementById("htxtOrigen").value = "";
        document.getElementById("htxtOrigenLarge").value = "";
        document.getElementById("htxtOrigenLat").value = "";
        document.getElementById("htxtOrigenLng").value = "";

        document.getElementById("txtDestino").value = "";
        document.getElementById("txtDestinoLarge").innerHTML = "";
        document.getElementById("htxtDestino").value = "";
        document.getElementById("htxtDestinoLarge").value = "";
        document.getElementById("htxtDestinoLat").value = "";
        document.getElementById("htxtDestinoLng").value = "";

        //document.getElementById("txtDistanciaTotal").innerHTML = "";
        //document.getElementById("txtTiempo").innerHTML = "";
        document.getElementById("htxtDistanciaTotal").value = "";
        document.getElementById("htxtTiempo").value = "";

    }
</script>
<!-------------------------------------------------------------    --->
<!------------fin javascript simulador-------------------------    --->
<!-------------------------------------------------------------    --->


  <!-- JoomlaWorks "Ultimate PNG Fix" (v2.0) starts here -->
	<!--[if lt IE 7]>
	<script defer type="text/javascript" src="http://www.shortsea.es/plugins/system/jwupf/ultimatepngfix_inline.js"></script>
	<![endif]-->
	<!-- JoomlaWorks "Ultimate PNG Fix" (v2.0) ends here -->
  <!--Simple By Design: SBD Accordion Menu for Joomla (v0.9.83a.J15N) - http://www.simplebydesign.co.uk/joomla/modules/sbd-accordian-menu.html-->
  <!--Yahoo! User Interface Library : http://developer.yahoo.com/yui/index.html-->


<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-28712740-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
</head>
<body>

  <div class="header"></div>
  <div class="container">
<div class="content">
  <h3>SIMULADOR DE CADENAS DE TRANSPORTE | TRANSPORT CHAINS SIMULATOR</h3>

<!-------------------------------------------------------------    --->
<!--------------------------inicio simulador-------------------    --->
<!-------------------------------------------------------------    --->
<a id="simuladorcostes" name="simuladorcostes"> </a>
<form id="form1" runat="server" class="blue">								


<table style="height:3000px" width="900px">
<tr style="height:3000px">
<td valign="top" colspan="2">
        <asp:Panel ID="PanelSimulador" runat="server" Width="680px" >
        <!-- **************************************************PANEL ORIGEN INICIO *********************************************** -->
             <asp:Panel ID="PanelParametros" runat="server" Width="650px">
                  <table style="height:50px">
                  <tr style="height:20px; vertical-align:top"><!-- Fila 1 -->
                    <td align="left" style="width:70px"><!-- Celda 1 -->
                        <a href="#" onclick="window.open('ayuda.pdf','Ayuda/Help','width =800,height=600');"> 
                        Ayuda/Help                   
                        </a>
                    </td>
                    <td align="left" style="width:200px"><!-- Celda 2 -->
                        <a href="#" onclick="window.open('ayuda.pdf','Ayuda/Help','width =800,height=600');"> 
                        <img src="images/ayuda.jpg" alt="ayuda" align="middle"/>
                        </a>
                    </td>
                    <td align="left" style="width:50px"><!-- Celda 3 -->
                        &nbsp
                    </td>

                    <td rowspan="5" style="width:265px; text-align:left; vertical-align:top"><!-- Celda 4 -->
                        <object data="http://www.shortsea.es/banner_simulador/banner.swf" style="height: 133px; width: 265px" 
                            type="application/x-shockwave-flash">
                            <param name="movie" value="http://www.shortsea.es/banner_simulador/banner.swf" />
                            <param name="scale" value="exactfit" />
                        </object>
                    </td>
                    <td align="left" style="width:65px"><!-- Celda 5 -->
                        &nbsp
                    </td>

                  </tr>

                  <tr style="height:10px; vertical-align:top"><!-- Fila 2 -->
                    <td align="left" style="width:100px"><!-- Celda 1 -->
                        <asp:Label ID="lblOrigen" runat="server" Text="Origen/From:" CssClass="txtsmallazul" ></asp:Label>
                    </td>
                    <td align="left" style="width:140px"><!-- Celda 2 -->
                        <asp:TextBox ID="txtOrigen" runat="server" CssClass="txtverdanasmall" onblur="comprobarAddress()" Width="130px" />
                    </td>
                    <td align="left" style="width:80px"><!-- Celda 3 -->
                        <img src="./images/check1.png" name="imgOrigenOK" id="imgOrigenOK" alt="" style="visibility:hidden"/>
                        <img src="./images/cross1.png" name="imgOrigenError" id="imgOrigenError" alt="" style="visibility:hidden" />
                    </td>
                    <td align="left" style="width:35px"><!-- Celda 5 -->
                        &nbsp
                    </td>
                  </tr>

                  <tr style="height:10px; vertical-align:top"><!-- Fila 3 -->
                    <td align="right" style="width:70px"><!-- Celda 1 -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtOrigen" ErrorMessage="RequiredFieldValidator"  
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" align="left" style="width:220px"><!-- Celda 2 -->
                        <asp:Label ID="txtOrigenLarge" runat="server" CssClass="txtverdanasmall" name="txtOrigenLarge" text="" Widht="280px" />
                    </td>
                    <td align="left" style="width:65px"><!-- Celda 5 -->
                        &nbsp
                    </td>
                  </tr>



                  <tr style="height:10px; vertical-align:top"><!-- Fila 4 -->
                    <td align="left" style="width:100px"><!-- Celda 1 -->
                        <asp:Label ID="lblDestino" runat="server" CssClass="txtsmallazul" Text="Destino/To: " />
                    </td>
                    <td align="left" style="width:140px"><!-- Celda 2 -->
                        <asp:TextBox ID="txtDestino" runat="server" CssClass="txtverdanasmall" onblur="comprobarAddress()" Width="130px" />
                  </td>
                  <td align="left" style="width:80px"><!-- Celda 3 -->
                        <img src="./images/check1.png" name="imgDestinoOK" id="imgDestinoOK" alt="" style="visibility:hidden"/>
                        <img src="./images/cross1.png" name="imgDestinoError" id="imgDestinoError" alt="" style="visibility:hidden" />
                  </td>
                    <td align="left" style="width:35px"><!-- Celda 5 -->
                        &nbsp
                    </td>
                  </tr> 

                  <tr style="height:10px; vertical-align:top"><!-- Fila 5 -->
                    <td align="right" style="width:70px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDestino" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" align="left" style="width:250px">
                        <asp:Label ID="txtDestinoLarge" runat="server" CssClass="txtverdanasmall" name="txtDestinoLarge" text="" Widht="280px" />
                    </td>
                    <td align="left" style="width:65px"><!-- Celda 5 -->
                        &nbsp
                    </td>
                  </tr> 

                  </table>
                  <asp:Label ID="lblToneladas" runat="server" CssClass="txtsmallazul" Text="Toneladas netas de carga/Net tons of cargo: " />
                  <asp:TextBox ID="txtToneladasTransportadas" runat="server" CssClass="txtverdanasmall" Width="50px" />
                  <br />
                  <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold" ForeColor="Red"></asp:Label>
                  <br />
                  <em>
                  <asp:Label ID="Label11" runat="server" CssClass="titularazulgrande" Text="Parámetros a definir para la cadena de Transporte sólo por carretera"></asp:Label><br />
                  </em>
                  <asp:Label ID="Label11ENG" runat="server" CssClass="titularazulgrande_EN" Text="Parameters to be set for the 'only road' transport chain"></asp:Label>

                  <br />
                  &nbsp;&nbsp;
                  <asp:Label ID="Label4" runat="server" CssClass="txtsmallazul" Text="Euros/Km: " Width="100px"></asp:Label>
                  <asp:TextBox ID="txtCosteKm" runat="server" CssClass="txtverdanasmallderecha" text-align="right" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                  <asp:Label ID="Label5" runat="server" CssClass="txtsmallazul" Text="Vel. Media Km/h /Average speed: "></asp:Label>
            <asp:TextBox ID="txtVelocidad" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br />
                  &nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" Text="Peajes/Tools €: " CssClass="txtsmallazul"  Width="100px"></asp:Label>
            <asp:TextBox ID="txtPeajes" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br /><br />
            <em>
                <asp:Label ID="Label17" runat="server" CssClass="titularazulgrande" Text="Parámetros a definir para el tramo terrestre en las cadenas que usan el TMCD" /><br />
            </em>
            <asp:Label ID="Label17ENG" runat="server" CssClass="titularazulgrande_EN" Text="Parameters to be set for the road leg of SSS chains" />
            <br />
            &nbsp;&nbsp;
            <asp:Label ID="Label15" runat="server" Text="Euros/Km Acarreo Origen/Origin hauling"  Width="200px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox  text-align="right" ID="txtCosteKmAcarreoOrigen" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label20" runat="server" Text="Vel. Km/h Acarreo Origen/Origin hauling: "   Width="200px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox ID="txtVelocidadAcarreoOrigen" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;
            <asp:Label ID="Label16" runat="server" Text="Euros/Km Acarreo Destino/Destination hauling:" Width="200px" CssClass="txtsmallazul" />
            <asp:TextBox text-align="right" ID="txtCosteKmAcarreoDestino" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label21" runat="server" Text="Vel. Km/h Acarreo Destino/Destination hauling: "   Width="200px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox ID="txtVelocidadAcarreoDestino" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>

            <br /><br />           

            <em>
                <asp:Label ID="Label10" runat="server" CssClass="titularazulgrande" Text="Opciones adicionales para el tramo marítimo en las cadenas que usan el TMCD" /><br />
            </em>
            <asp:Label ID="Label22" runat="server" CssClass="titularazulgrande_EN" Text="Additional options for the maritime leg of SSS chains" />
            <br />
            <asp:Label ID="Label14" runat="server" CssClass="titular" Font-Size="XX-Small" Text="(Si no marca ninguna opción, se considera el embarque de semirremolque de carga general)" /><br />
            <asp:Label ID="Label14ENG" runat="server" CssClass="titular_EN" Font-Size="XX-Small" Text="(If no choise is marked, general cargo semi-trailer will be considered for the shipment)" />
            <br /> 
                  &nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="Mercancías Peligrosas/Dangerous Goods" CssClass="txtsmallazul" Width="180px"></asp:Label>
            <asp:CheckBox  ID="txtRecargoMercanciaPeligrosa" runat="server" CssClass="blue" />
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="¿Acompañado?/Accompanied?" CssClass="txtsmallazul" Width="140px"></asp:Label>
            <asp:CheckBox ID="txtRecargoCabezaTractora" runat="server" CssClass="blue" />
            <br />
                  &nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Carga refrigerada/Refrigerated cargo" CssClass="txtsmallazul" Width="180px"></asp:Label>
            <asp:CheckBox ID="txtRecargoRefrigerado" runat="server" CssClass="blue" />
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label7" runat="server" Text="Animales Vivos/Live animals" CssClass="txtsmallazul" Width="140px"></asp:Label>
            <asp:CheckBox ID="txtRecargoAnimalesVivos" runat="server" CssClass="blue" />
            <br /> 
            <br />
            
            <em>
                <asp:Label ID="Label13" runat="server" CssClass="titular" Text="Seleccione qué líneas quiere consultar (Pulse CTRL para marcar más de una línea)" /><br />
                <asp:Label ID="Label13ENG" runat="server" CssClass="titular_EN" Text="Select which lines you want to consult (Press CTRL key to selecte more than one line)" />

            </em>
                  &nbsp;<br /> &nbsp;&nbsp;
            <asp:ListBox ID="txtListBoxLineas" runat="server" CssClass="txtverdanasmall" Height="88px" Rows="8" SelectionMode="Multiple" Width="455px" BackColor="#E8F0F5" ></asp:ListBox>
            <br />
            
                  &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Alta Frecuencia/High Frequency" CssClass="txtsmallazul" Width="180px"></asp:Label>
            <asp:CheckBox  ID="txtAltaFrecuencia" runat="server" CssClass="blue" />
                  &nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="Fachada Cantábrica/Cantabrian Seaboard" CssClass="txtsmallazul" Width="200px"></asp:Label>
            <asp:CheckBox ID="txtFachadaCantabrica" runat="server" Checked="false" CssClass="blue" />
            <br />
                  &nbsp;&nbsp;
            <asp:Label ID="Label18" runat="server" Text="Fachada Atlántica/Atlantic Seaboard" CssClass="txtsmallazul" Width="180px"></asp:Label>
            <asp:CheckBox  ID="txtFachadaAtlantica" runat="server"  Checked="false" CssClass="blue" />
                  &nbsp;&nbsp;
            <asp:Label ID="Label19" runat="server" Text="Fachada Mediterránea/Mediterranean Seaboard" CssClass="txtsmallazul" Width="200px"></asp:Label>
            <asp:CheckBox ID="txtFachadaMediterranea" runat="server" Checked="false" CssClass="blue" />
            <br />
            <br />
                  &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" CssClass="txtsmallazul" Text="Resultados ordenados por/Results ordered by:" />
                  &nbsp; &nbsp;
            <asp:RadioButton ID="RBCoste" GroupName="optimizado" runat="server" CssClass="txtsmallazul" Text="Coste/Cost" Checked="True" />
                  &nbsp;&nbsp;
            <asp:RadioButton ID="RBTiempo" GroupName="optimizado" runat="server" CssClass="txtsmallazul" Text="Tiempo/Time" />
                  &nbsp; &nbsp;
            <asp:RadioButton ID="rbDistancia"  GroupName="optimizado" runat="server" CssClass="txtsmallazul"  Text="Distancia/Distance"/>
        </asp:Panel> <!-- Fin asp:PanelParametros -->
        <!-- **************************************************PANEL PARAMETROS FIN *********************************************** -->
                    
        <!-- **************************************************PANEL BOTONES INICIO *********************************************** -->
        <asp:Panel ID="PanelBotones"   runat="server" Height="60px" Width="650px" BorderColor="Beige">
                  
                  <asp:Button ID="btnCalcular" runat="server" CssClass="blue" Text="Calcular/Calculate"  Width="196px" OnClientClick="javascript:comprobarAddress()" />
                  &nbsp; &nbsp;
                  <asp:Button ID="btnCalcularMapa" runat="server" CssClass="blue" Text="Ver Mapa Resultados/View Results Map "  Width="196px" />
                  <br />
                  <asp:Button ID="btnNuevaSimulacion" runat="server" CssClass="blue" Text="Nueva Simulación/New Simulation" Width="196px" />
                  &nbsp; &nbsp;                  
                 
                  <a  href="http://www.comodalweb.org" target="_blank">
                      <img alt="Comodalweb" class="logocomodalweb" longdesc="Acceso a Comodalweb 2.0" src="images/comodalwebico.png" /> </a>
                  <br />
        </asp:Panel>
        <!-- **************************************************PANEL BOTONES FIN *********************************************** -->

        <!-- **************************************************PANEL RESUMEN INICIO *********************************************** -->
          
        <asp:Panel ID="PanelResumen" runat="server" Height="120px" Width="650px" Visible="false">
        <em>
            <asp:Label ID="LabelTituloTerrestre" runat="server" CssClass="titularazulgrande" Text="Transporte por carretera"></asp:Label>
        </em> 
        <asp:Label ID="Label23" runat="server" CssClass="titularazulgrande_EN" Text="/Transport by 'only road'"></asp:Label>

             <asp:Table ID="TablaResultadosTerrestre" runat="server" Height="40px" Width="660px" CssClass="blue" 
                 BorderColor="#E0E0E0" BorderStyle="Solid"> 
             </asp:Table> 
        </asp:Panel>    
        <!-- **************************************************PANEL RESUMEN INICIO *********************************************** -->        


       
        <!-- **************************************************PANEL RESULTADOS INICIO *********************************************** -->        
        <br />
        <asp:Panel ID="PanelResultados" runat="server" Height="480px" Width="660px" ScrollBars="Vertical" Visible="false">
        <em>
            <asp:Label ID="LabelTituloTotales" runat="server" CssClass="titularazulgrande" Text="Transporte Intermodal con líneas marítimas existentes."></asp:Label><br />
        </em>
        <asp:Label ID="LabelTituloTotales_EN" runat="server" CssClass="titularazulgrande_EN" Text="Existing maritime intermodal transport lines."></asp:Label><br />

             <asp:Label ID="LabelErrorDataList" runat="server" CssClass="txtsmallbold" ForeColor="Red" Width="581px" Visible="False"></asp:Label>
              &nbsp;&nbsp;
             <asp:DataList  ID="DataList1"   OnItemCommand="seleccionar" runat="server" Visible="False" CellPadding="0" Width="575px" >
                    <HeaderTemplate>
                    <table width="635px" cellspacing="0" border="0" cellpadding="0" style="background-color:White">
                        <tr style="background-color:White">
                            <td width="35px" align="center"></td>
                            <td  width="200" colspan="2" align="center" class="titularazul"> Origen-Destino/From-To</td>
                            <td  width="80px" align="right" class="titularazulderecha" >Cost(Eur)</td>
                            <td width="80px" align="right" class="titularazulderecha" >Tiempo (Hor)</td>
                            <td  width="80px" align="right" class="titularazulderecha" >Dist. (Km)</td>
                            <td  width="80px" align="right" class="titularverdederecha" >Cost Ext.(Eur)</td>
                            <td  width="80px" align="right" class="titularverdederecha" >Emis. CO2(Kg)</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr  style="background-color:#F0F0F0">
                            <td width="35px" align="center">
                            <asp:Button ID="Button1" runat="server"  CommandArgument="+" Text="+" /></td>
                            <td width="200px" align="left" colspan="2" class="txtverdanasmall"><%# container.dataitem("Linea") %></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("costeTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("tiempoTotal"), Single).ToString("F1")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("distanciaTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderechaverde"><%# CType(Container.DataItem("costesExternosTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderechaverde"><%# CType(Container.DataItem("costeEmisionCO2Total"), Single).ToString("N0")%></td>
                           </tr> 
                    </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr  style="background-color:#E8F0F5">
                            <td width="35px" align="center">
                            <asp:Button ID="Button1" runat="server"  CommandArgument="+" Text="+" /></td>
                            <td width="200px" colspan="2" align="left" class="txtverdanasmall"><%# container.dataitem("Linea") %></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("costeTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("tiempoTotal"), Single).ToString("F1")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderecha"><%# CType(Container.DataItem("distanciaTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderechaverde"><%# CType(Container.DataItem("costesExternosTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtverdanasmallderechaverde"><%# CType(Container.DataItem("costeEmisionCO2Total"), Single).ToString("N0")%></td>
                           </tr> 
                        </AlternatingItemTemplate>
                        <SelectedItemTemplate>
                            <tr style="background-color:#FFFFC0">
                            <td width="35px" align="center">
                            <asp:Button ID="ButtonMenos" runat="server"  CommandArgument="-" Text="-" /></td>
                            <td width="100px" align="left" class="txtsmallazul"><%#Container.dataitem("Origen")%></td>
                            <td width="100px" align="left"  class="txtsmallazul"><%#Container.DataItem("PuertoOrigen")%></td>                            
                            <td width="80px" align="right" class="txtsmallazul"><%# CType(Container.DataItem("costeOrigenPuerto"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallazul"><%# CType(Container.DataItem("tiempoOrigenPuerto"), Single).ToString("F1")%></td>
                            <td width="80px" align="right" class="txtsmallazul"><%# CType(Container.DataItem("distanciaOrigenPuerto"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallverde"><%# CType(Container.DataItem("costesExternosOrigenPuerto"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallverde"><%# CType(Container.DataItem("costeEmisionCO2OrigenPuerto"), Single).ToString("N0")%></td>
                           </tr> 
                            <tr style="background-color:#FFFFC0">
                            <td width="35px" align="center"></td>
                            <td width="100px" align="left"  class="txtsmallazul"><b><%#Container.dataitem("PuertoOrigen")%></b></td>
                            <td width="100px" align="left"  class="txtsmallazul"><b><%#Container.DataItem("PuertoDestino")%></b></td>                            
                            <td width="80px" align="right" class="txtsmallazul"><b><%# CType(Container.DataItem("costePuertoPuertoconRecargos"), Single).ToString("N0")%></b></td>
                            <td width="80px" align="right" class="txtsmallazul"><b><%# CType(Container.DataItem("tiempoPuertoPuerto"), Single).ToString("F1")%></b></td>
                            <td width="80px" align="right" class="txtsmallazul"><b><%# CType(Container.DataItem("distanciaPuertoPuerto"), Single).ToString("N0")%></b></td>
                            <td width="80px" align="right" class="txtsmallverde"><b><%# CType(Container.DataItem("costesExternosPuertoPuerto"), Single).ToString("N0")%></b></td>
                            <td width="80px" align="right" class="txtsmallverde"><b><%# CType(Container.DataItem("costeEmisionCO2PuertoPuerto"), Single).ToString("N0")%></b></td>

                           </tr> 
                           <tr style="background-color:#FFFFC0">
                           <td width="35px" align="center"></td>
                            <td width="100px" align="left" class="txtsmallazul"><%#Container.DataItem("PuertoDestino")%></td>
                            <td width="100px" align="left" class="txtsmallazul"><%#Container.DataItem("Destino")%></td>                            
                            <td width="80px" align="right" class="txtsmallazul"><%# CType(Container.DataItem("costePuertoDestino"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallazul"><%# CType(Container.DataItem("tiempoPuertoDestino"), Single).ToString("F1")%></td>
                            <td width="80px" align="right" class="txtsmallazul"><%#CType(Container.DataItem("distanciaPuertoDestino"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallverde"><%# CType(Container.DataItem("costesExternosPuertoDestino"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallverde"><%# CType(Container.DataItem("costeEmisionCO2PuertoDestino"), Single).ToString("N0")%></td>
                           </tr> 
                           <tr style="background-color:White">
                            <td width="35px" align="center"></td>
                            <td width="200px" align="left" class="txtsmallboldnegro" colspan="2">Total: <%# container.dataitem("Origen") %> 
                                *** <%# container.dataitem("Destino") %> </td>
                            <td width="80px" align="right" class="txtsmallboldnegro"><%# CType(Container.DataItem("costeTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallboldnegro"><%# CType(Container.DataItem("tiempoTotal"), Single).ToString("F1")%></td>
                            <td width="80px" align="right" class="txtsmallboldnegro"><%# CType(Container.DataItem("distanciaTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallboldnegroverde"><%# CType(Container.DataItem("costesExternosTotal"), Single).ToString("N0")%></td>
                            <td width="80px" align="right" class="txtsmallboldnegroverde"><%# CType(Container.DataItem("costeEmisionCO2Total"), Single).ToString("N0")%></td>
                           </tr> 
                           <tr style="background-color:White">
                            <td width="35px" align="center"></td>
                            <td width="540px" align="left" class="titularnegro" colspan="6">
                            <%#Container.DataItem("FleteMensaje")%>
                            
                            </td>
                           </tr> 
                           
                           <tr></tr>
                           <tr>
                            <td width="35px" align="center"></td>
                            <td id="Td1" colspan="7" align="left" class="txtsmallboldnegro">
                                <%#CType(Container.DataItem("PuertoOrigenIDEnlace"), String).ToString%>                               
                            </td>
                           </tr>
                           <tr>
                            <td width="35px" align="center"></td>
                            <td colspan="7" align="left" class="txtsmallboldnegro">
                                <%#CType(Container.DataItem("NavieraIDEnlace"), String).ToString%>
                            </td>
                           </tr>
                           
                           <tr>
                            <td width="35px" align="center"></td>
                            <td colspan="7" align="left" class="txtsmallboldnegro">
                                <%#CType(Container.DataItem("PuertoDestinoIDEnlace"), String).ToString%>                               
                            </td>
                           </tr>
                            <br />
                            
                        </SelectedItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                        
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />                        
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
        </asp:Panel>
        <!-- **************************************************PANEL RESULTADOS FIN *********************************************** -->                
       
       <asp:Panel runat="server" ID="panelLogoFomento" Height="90px">
       <br />
        <img src="images/LogoFomento.jpg" /><br />

        <p class="titular">
            COMODALWEB 2.0: Proyecto financiado por el Plan Nacional I+D+i 2008-2011.    
        </p>
       </asp:Panel>
       
        </asp:Panel>
        <!-- **************************************************PANEL SIMULADOR FIN *********************************************** -->                   


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



      <!-- SIMULADOR: FINAL	  -->








</td>
</tr>


</table>

</form>

<!-------------------------------------------------------------    --->
<!--------------------------fin simulador----------------------    --->
<!-------------------------------------------------------------    --->

</div>
</div>
 <div class="footer"><div class="footer-container">
    <p>SPC-Spain - Calle Cronos, 63, 3ª pl, Of. 6-28037-MADRID<br />
      Tel: 91 304 13 59/91 304 13 59 - Fax: 91 327 41 99 <br />
    <a href="mailto:info@shortsea.es">info@shortsea.es - </a><a href="http://shortsea.es/images/politicadeprivacidad.pdf">Política de privacidad</a></p></div>
   </div>
</body>
</html>
