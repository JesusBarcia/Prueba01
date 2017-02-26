<%@ Page Language="VB" AutoEventWireup="false" CodeFile="simuladorOLD.aspx.vb" Inherits="SimuladorOLD" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="es-es" lang="es-es" >
<head>
  <link href="Styles/estilosimulador.css" rel="stylesheet" type="text/css" />
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta name="robots" content="index, follow" />
  <meta name="keywords" content="Transporte marítimo de corta distancia, short sea shipping, transporte marítimo, transporte por carretera, política de transporte, medioambiente, intermodalidad, comodalidad, multimodalidad, ro-ro" />
  <meta name="description" content="Shortsea España. Asociación Española de Promoción del Transporte Marítimo de Corta Distancia" />
  <meta name="generator" content="Joomla! 1.5 - Open Source Content Management" />
  <title>Simulador de Cadenas de Transporte</title>
  <link href="http://simulador.shortsea.es/simulador.aspx?format=feed&amp;type=rss" rel="alternate" type="application/rss+xml" title="RSS 2.0" />
  <link href="http://simulador.shortsea.es/simulador.aspx??format=feed&amp;type=atom" rel="alternate" type="application/atom+xml" title="Atom 1.0" />
  <link rel="stylesheet" href="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/mod_sbd_rollmenu.css" type="text/css" />
  <script type="text/javascript" src="http://www.shortsea.es/media/system/js/mootools.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es/media/system/js/caption.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/yahoo_2.0.0-b2.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/event_2.0.0-b2.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/dom_2.0.2-b3.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/animation_2.0.0-b3.js"></script>
  <script type="text/javascript" src="http://www.shortsea.es//modules/mod_sbd_rollmenu/mod_sbdrollmenu/mod_sbd_roll_compressed.js"></script>
  <script type="text/javascript">
<!--
      function runOver(id) {
          if (runOk == 1 && currentId != id) {
              runOk = 0;
              window.setTimeout('switchRun()', ('time_delay'));
              currentId = id;
              window.setTimeout('AccordionMenu.openDtById(\'' + id + '\')', ('menu_delay'));
              //alert( id );
          }
      }
      function runOut(id) {
          AccordionMenu.openDtById(id, 0);
          runOk = 1;
          currentId = 0;
      }
//-->

  </script>

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


<link rel="stylesheet" href="http://www.shortsea.es/templates/system/css/system.css" type="text/css" />
<link rel="stylesheet" href="http://www.shortsea.es/templates/system/css/general.css" type="text/css" />


<link rel="stylesheet" href="http://www.shortsea.es/templates/shortsea/css/template.css" type="text/css" />
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
<body id="page_bg">
<div id="centrador">
<a name="up" id="up"></a>
<div class="center" align="center">	
			
<div id="wrapper">
	<div id="wrapper_r">
	
		<div id="whitebox">
			<div id="whitebox_t">
				<div id="whitebox_tl">
				<div id="whitebox_tr"></div>
			</div>
		</div>

		<div id="header">
			<div id="header_r">
				<div id="logo"><img src="http://www.shortsea.es/templates/shortsea/images/shortsea.png" alt="logo_shortsea" /></div>
			</div>
		</div>

		<div id="tabarea">
			<table cellpadding="0" cellspacing="0" class="pill">
				<tr>
					<td class="pill_l"></td>
					<td class="pill_m">
					<div id="pillmenu">
						<ul class="menu"><li class="item1"><a href="http://www.shortsea.es/"><span>Inicio</span></a></li><li class="item61"><a href="/buscar"><span>Buscar</span></a></li><li class="item10"><a href="/contacto"><span>Contacto</span></a></li><li class="item62"><a href="/enlaces"><span>Enlaces</span></a></li><li class="item63"><a href="/mapa-web"><span>Mapa Web</span></a></li><li class="item21"><a href="/english"><span>Summary in English</span></a></li></ul>
<div id="lk"><a href="http://www.linkedin.com/groups?home=&gid=4260743&trk=anet_ug_hm" target="_blank"><img src="http://www.shortsea.es/templates/shortsea/images/linkedIn.png" alt="linkedIn" border="0"/></a></div>
					</div>

					</td>
				</tr>
			</table>
		</div>			
			
			
			<div id="whitebox_m">
				<div id="area">
													<div id="leftcolumn" class="izquierda" style="float:left;">
												<div class="moduletable">
					<h3> </h3>
					<script type="text/javascript">					    runOver('sbd1');</script><dl class="accordion-menu"><dt class="a-m-t" id="sbd2" onclick="javascript:void( runOver( 'sbd2' ) );">¿Quienes Somos?</dt><dd class="a-m-d sbdItemId2"><div class="bd"><dl class="rollmenu_2_0"><dd ><a href="/iquienes-somos/iquienes-somos" class="rollsublevel_2_1"  >¿Quienes Somos?</a></dd><dd ><a href="/iquienes-somos/definicion-sss" class="rollsublevel_2_1"  >Definición SSS</a></dd><dd ><a href="/iquienes-somos/european-sss-network-" class="rollsublevel_2_1"  >European SSS Network</a></dd><dd ><a href="/iquienes-somos/icomo-asociarse" class="rollsublevel_2_1"  >¿Cómo Asociarse?</a></dd><dd ><a href="/iquienes-somos/miembros" class="rollsublevel_2_1"  >Miembros</a></dd></dl></div></dd><dt class="a-m-t" id="sbd16" onclick="javascript:void( runOver( 'sbd16' ) );">Documentacion</dt><dd class="a-m-d sbdItemId16"><div class="bd"><dl class="rollmenu_16_0"><dd ><a href="/documentacion/normativa-ue" class="rollsublevel_16_1"  >UE. Normativa y Planificación</a></dd><dd ><a href="/documentacion/normativa-espanola" class="rollsublevel_16_1"  >Nacional. Normativa y Planificación</a></dd><dd ><a href="/documentacion/-memorias-corporativas" class="rollsublevel_16_1"  >Memorias Corporativas</a></dd><dd ><a href="/documentacion/programas-id" class="rollsublevel_16_1"  >Programas I+D</a></dd><dd ><a href="/documentacion/formacion" class="rollsublevel_16_1"  >Jornadas, seminarios & formación</a></dd><dd ><a href="/documentacion/estudios-y-proyectos" class="rollsublevel_16_1"  >Estudios y Proyectos de la Asociación</a></dd><dd ><a href="/documentacion/otros" class="rollsublevel_16_1"  >Otros Estudios y Proyectos</a></dd></dl></div></dd><dt class="a-m-t" id="sbd19" onclick="javascript:void( runOver( 'sbd19' ) );">Prensa</dt><dd class="a-m-d sbdItemId19"><div class="bd"><dl class="rollmenu_19_0"><dd ><a href="/prensa/noticias" class="rollsublevel_19_1"  >Noticias</a></dd><dd ><a href="/prensa/notas-de-prensa" class="rollsublevel_19_1"  >Notas de Prensa</a></dd><dd ><a href="/prensa/dossier-de-prensa" class="rollsublevel_19_1"  >Dossier de Prensa</a></dd><dd ><a href="/component/acajoom/Itemid-14" class="rollsublevel_19_1"  >Newsletter</a></dd></dl></div></dd><dt class="a-m-t-n" id="sbd78"  onclick="javascript:void( window.location = '/observatorio-estadistico'  );">Observatorio</dt><dt class="a-m-t" id="sbd8" onclick="javascript:void( runOver( 'sbd8' ) );">Servicios</dt><dd class="a-m-d sbdItemId8"><div class="bd"><dl class="rollmenu_8_0"><dd ><a href="http://simulador.shortsea.es/simulador.aspx" class="rollsublevel_8_1"  >Simulador de Cadenas de Transporte</a></dd></dl></div></dd><dt class="a-m-t" id="sbd33" onclick="javascript:void( runOver( 'sbd33' ) );">Grupos de Trabajo</dt><dd class="a-m-d sbdItemId33"><div class="bd"><dl class="rollmenu_33_0"><dd ><a href="/grupos-de-trabajo/estadisticas" class="rollsublevel_33_1"  >Estadísticas</a></dd><dd ><a href="/grupos-de-trabajo/procedimientos-administrativos" class="rollsublevel_33_1"  >Procedimientos administrativos</a></dd><dd ><a href="/grupos-de-trabajo/autopistas-del-mar" class="rollsublevel_33_1"  >Autopistas del mar</a></dd><dd ><a href="/grupos-de-trabajo/spc-spain" class="rollsublevel_33_1"  >Short Sea Promotion Centre SPAIN</a></dd></dl></div></dd><dt class="a-m-t sbdhidden" >&nbsp;</dt><dd class="a-m-d"><div class="bd"><dl class="rollmenu_0"><dd>&nbsp;</dd></dl></div></dd></dl>		</div>
	
										
							<div id="galeria"><iframe src="http://w3.shortsea.es/gestor/index.php?option=com_oziogallery2&view=05imagerotator&Itemid=15&amp;tmpl=component" width="189" marginwidth="0px" allowtransparency="true" frameborder="0" scrolling="no" class="autoHeight"></iframe></div><h3>&nbsp;</h3>
<form action="/index.php" method="post" name="login" id="form-login" >
		<fieldset class="input">
	<p id="form-login-username">
		<label for="modlgn_username">Nombre de usuario</label><br />
		<input id="modlgn_username" type="text" name="username" class="inputbox" alt="username" size="18" />
	</p>
	<p id="form-login-password">
		<label for="modlgn_passwd">Contraseña</label><br />
		<input id="modlgn_passwd" type="password" name="passwd" class="inputbox" size="18" alt="password" />
	</p>
		<p id="form-login-remember">
		<label for="modlgn_remember">Recordarme</label>
		<input id="modlgn_remember" type="checkbox" name="remember" class="inputbox" value="yes" alt="Remember Me" />
	</p>
		<input type="submit" name="Submit" class="button" value="Iniciar sesión" />
	</fieldset>
	<ul>
		<li>
			<a href="/component/user/reset">
			¿Recordar contraseña?</a>
		</li>
		<li>
			<a href="/component/user/remind">
			¿Recordar usuario?</a>
		</li>
			</ul>
	
	<input type="hidden" name="option" value="com_user" />
	<input type="hidden" name="task" value="login" />
	<input type="hidden" name="return" value="Lw==" />
	<input type="hidden" name="bcc97725dc1aa70d78f6520ea67c8450" value="1" /></form>
<div id="european">SPC Spain es miembro de la Red Europea de Shortsea Shipping <a href="http://www.shortsea.info" target="_blank"> <img src="http://www.shortsea.es/templates/shortsea/images/european.jpg" alt="european_shortsea" /></a></div>
</div>
												
												<div id="maincolumn_full">

													<div class="nopad">
<div id="portada">

</div>






<!-------------------------------------------------------------    --->
<!--------------------------inicio simulador-------------------    --->
<!-------------------------------------------------------------    --->
<a id="simuladorcostes" name="simuladorcostes"> </a>
<form id="form1" runat="server" class="blue">								
<div class="componentheading-servicios">
	Simulador de Cadenas de Transporte
    
</div>
<table class="blog-servicios" cellpadding="0" cellspacing="0">
<tr>
	<td valign="top">
		<table width="100%"  cellpadding="0" cellspacing="0">
		<tr>
			<td valign="top" width="100%" class="article_column">

            </td>
        </tr>
        </table>
    </td>
</tr>
</table>

<table class="contentpaneopen-servicios">




<tr>
<td valign="top" colspan="2">
        <asp:Panel ID="PanelSimulador" runat="server" Height="1550px" Width="680px" >
        <!-- **************************************************PANEL ORIGEN INICIO *********************************************** -->
             <asp:Panel ID="PanelParametros" runat="server" Height="830px" Width="670px">
                  <table style="height:50px">
                  <tr style="height:20px; vertical-align:top"><!-- Fila 1 -->
                    <td align="left" style="width:70px"><!-- Celda 1 -->
                        <a href="#" onclick="window.open('ayuda.pdf','Ayuda','width =800,height=600');"> 
                        Ayuda                   
                        </a>
                    </td>
                    <td align="left" style="width:200px"><!-- Celda 2 -->
                        <a href="#" onclick="window.open('ayuda.pdf','Ayuda','width =800,height=600');"> 
                        <img src="images/ayuda.jpg" alt="ayuda" align="middle"/>
                        </a>
                    </td>
                    <td align="left" style="width:50px"><!-- Celda 3 -->
                        &nbsp
                    </td>

                    <td rowspan="5" style="width:400px; vertical-align:top"><!-- Celda 4 -->
                        <object data="images/banner.swf" style="height: 125px; width: 100%" 
                            type="application/x-shockwave-flash">
                            <param name="movie" value="images/banner.swf" />
                            <param name="scale" value="exactfit" />
                        </object>
                    </td>
                  </tr>

                  <tr style="height:10px; vertical-align:top"><!-- Fila 2 -->
                    <td align="left" style="width:70px"><!-- Celda 1 -->
                        <asp:Label ID="lblOrigen" runat="server" Text="Origen: " CssClass="txtsmallazul" Width="60px"></asp:Label>
                    </td>
                    <td align="left" style="width:220px"><!-- Celda 2 -->
                        <asp:TextBox ID="txtOrigen" runat="server" CssClass="txtverdanasmall" onblur="comprobarAddress()" Width="200px" />
                    </td>
                    <td align="left" style="width:80px"><!-- Celda 3 -->
                        <img src="./images/check.png" name="imgOrigenOK" id="imgOrigenOK" alt="" style="visibility:hidden"/>
                        <img src="./images/cross.png" name="imgOrigenError" id="imgOrigenError" alt="" style="visibility:hidden" />
                    </td>
                  </tr>

                  <tr style="height:10px; vertical-align:top"><!-- Fila 3 -->
                    <td align="right" style="width:70px"><!-- Celda 1 -->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtOrigen" ErrorMessage="RequiredFieldValidator"  
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" align="left" style="width:300px"><!-- Celda 2 -->
                        <asp:Label ID="txtOrigenLarge" runat="server" CssClass="txtverdanasmall" name="txtOrigenLarge" text="" Widht="300px" />
                    </td>
                  </tr>



                  <tr style="height:10px; vertical-align:top"><!-- Fila 4 -->
                    <td align="left" style="width:70px"><!-- Celda 1 -->
                        <asp:Label ID="lblDestino" runat="server" CssClass="txtsmallazul" Text="Destino: " Width="60px" />
                    </td>
                    <td align="left" style="width:220px"><!-- Celda 2 -->
                        <asp:TextBox ID="txtDestino" runat="server" CssClass="txtverdanasmall" onblur="comprobarAddress()" Width="200px" />
                  </td>
                  <td align="left" style="width:80px"><!-- Celda 3 -->
                        <img src="./images/check.png" name="imgDestinoOK" id="imgDestinoOK" alt="" style="visibility:hidden"/>
                        <img src="./images/cross.png" name="imgDestinoError" id="imgDestinoError" alt="" style="visibility:hidden" />
                  </td>
                  </tr> 

                  <tr style="height:10px; vertical-align:top"><!-- Fila 5 -->
                    <td align="right" style="width:70px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDestino" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2" align="left" style="width:300px">
                        <asp:Label ID="txtDestinoLarge" runat="server" CssClass="txtverdanasmall" name="txtDestinoLarge" text="" Widht="300px" />
                    </td>
                  </tr> 
                  </table>
                  <br />
                  <asp:Label ID="lblToneladas" runat="server" CssClass="txtsmallazul" Text="Toneladas netas de carga: " />
                  <asp:TextBox ID="txtToneladasTransportadas" runat="server" CssClass="txtverdanasmall" Width="50px" />
                  <br />
                  <asp:Label ID="LabelError" runat="server" CssClass="txtsmallbold" ForeColor="Red"></asp:Label>
                  <br />
                  <em>
                  <asp:Label ID="Label11" runat="server" CssClass="titularazulgrande" Text="Parámetros a definir para la cadena de Transporte sólo por carretera"></asp:Label>
                  </em>
                  <br />
                  <asp:Label ID="Label4" runat="server" CssClass="txtsmallazul" Text="Euros/Km: " Width="60px"></asp:Label>
                  <asp:TextBox ID="txtCosteKm" runat="server" CssClass="txtverdanasmallderecha" text-align="right" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                  <asp:Label ID="Label5" runat="server" CssClass="txtsmallazul" Text="Vel. Media Km/h: "></asp:Label>
            <asp:TextBox ID="txtVelocidad" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" Width="60px" runat="server" Text="Peajes €: " CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox ID="txtPeajes" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br /><br />
            <em>
                <asp:Label ID="Label17" runat="server" CssClass="titularazulgrande" Text="Parámetros a definir para el tramo terrestre en las cadenas que usan el TMCD" />
            </em>
            <br />
            <asp:Label ID="Label15" runat="server" Text="Euros/Km Acarreo Origen"  Width="150px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox  text-align="right" ID="txtCosteKmAcarreoOrigen" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label20" runat="server" Text="Vel. Km/h Acarreo Origen: "   Width="150px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox ID="txtVelocidadAcarreoOrigen" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Euros/Km Acarreo Destino" Width="150px" CssClass="txtsmallazul" />
            <asp:TextBox text-align="right" ID="txtCosteKmAcarreoDestino" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label21" runat="server" Text="Vel. Km/h Acarreo Destino: "   Width="150px" CssClass="txtsmallazul"></asp:Label>
            <asp:TextBox ID="txtVelocidadAcarreoDestino" runat="server" CssClass="txtverdanasmallderecha" Width="59px"></asp:TextBox>

            <br /> <br />                        
            

            <em>
                <asp:Label ID="Label10" runat="server" CssClass="titularazulgrande" 
                Text="Opciones adicionales para el tramo marítimo en las cadenas que usan el TMCD" />
            </em>
            <br />
            <asp:Label ID="Label14" runat="server" CssClass="titular" Font-Size="XX-Small" Text="(Si no marca ninguna opción, se considera el embarque de semirremolque de carga general)" />
            <br /> 
            <asp:Label ID="Label9" runat="server" Text="Mercancías Peligrosas" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox  ID="txtRecargoMercanciaPeligrosa" runat="server" CssClass="blue" />
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="¿Acompañado?" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox ID="txtRecargoCabezaTractora" runat="server" CssClass="blue" />
            <br />

            <asp:Label ID="Label8" runat="server" Text="Carga refrigerada" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox ID="txtRecargoRefrigerado" runat="server" CssClass="blue" />
                  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label7" runat="server" Text="Animales Vivos" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox ID="txtRecargoAnimalesVivos" runat="server" CssClass="blue" />
            <br /> 
            <br />
            
            <em>
                <asp:Label ID="Label13" runat="server" CssClass="titular" 
                Text="Seleccione qué líneas quiere consultar (Puede marcar más de una línea pulsando la tecla control)" />
            </em>
                  &nbsp;<br /> &nbsp;&nbsp;
            <asp:ListBox ID="txtListBoxLineas" runat="server" CssClass="txtverdanasmall" Height="88px" Rows="8" SelectionMode="Multiple" Width="455px" BackColor="#E8F0F5" ></asp:ListBox>
            <br />
            
                  &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Alta Frecuencia" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox  ID="txtAltaFrecuencia" runat="server" CssClass="blue" />
                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="Fachada Cantábrica" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox ID="txtFachadaCantabrica" runat="server" Checked="false" CssClass="blue" />
            <br />

                  &nbsp;&nbsp;
            <asp:Label ID="Label18" runat="server" Text="Fachada Atlántica" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox  ID="txtFachadaAtlantica" runat="server"  Checked="false" CssClass="blue" />
            
                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Label ID="Label19" runat="server" Text="Fachada Mediterránea" CssClass="txtsmallazul" Width="150px"></asp:Label>
            <asp:CheckBox ID="txtFachadaMediterranea" runat="server" Checked="false" CssClass="blue" />
            <br />
            <br />

                  &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" CssClass="txtsmallazul" Text="Resultados ordenados por:" />
                  &nbsp; &nbsp;&nbsp;
            <asp:RadioButton ID="RBCoste" GroupName="optimizado" runat="server" CssClass="blue" Text="Coste" Checked="True" />
                  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:RadioButton ID="RBTiempo" GroupName="optimizado" runat="server" CssClass="blue" Text="Tiempo" />
                  &nbsp; &nbsp; &nbsp;
            <asp:RadioButton ID="rbDistancia"  GroupName="optimizado" runat="server" CssClass="blue"  Text="Distancia"/>
        </asp:Panel> <!-- Fin asp:PanelParametros -->
        <!-- **************************************************PANEL PARAMETROS FIN *********************************************** -->
                    
        <!-- **************************************************PANEL BOTONES INICIO *********************************************** -->
        <asp:Panel ID="PanelBotones" runat="server" CssClass="pnlBotones"   Height="60px" Width="670px" BorderColor="Beige">
                  
                  <asp:Button ID="btnCalcular" runat="server" CssClass="blue" Text="Calcular"  Width="196px" OnClientClick="javascript:comprobarAddress()" />
                  &nbsp; &nbsp;
                  <asp:Button ID="btnCalcularMapa" runat="server" CssClass="blue" Text="Ver Mapa Resultados"  Width="196px" />
                  <br />
                  <asp:Button ID="btnNuevaSimulacion" runat="server" CssClass="blue" Text="Nueva Simulación" Width="196px" />
                  &nbsp; &nbsp;                  
                 
                  <a  href="http://www.comodalweb.org" target="_blank">
                      <img alt="Comodalweb" class="logocomodalweb" longdesc="Acceso a Comodalweb 2.0" src="images/comodalwebico.png" /> </a>
                  <br />
        </asp:Panel>
        <!-- **************************************************PANEL BOTONES FIN *********************************************** -->

        <!-- **************************************************PANEL RESUMEN INICIO *********************************************** -->
          
        <asp:Panel ID="PanelResumen" runat="server" Height="90px" Width="650px" Visible="false">
        <em>
            <asp:Label ID="LabelTituloTerrestre" runat="server" CssClass="titularazulgrande" Text="Transporte por carretera"></asp:Label>
        </em> 
             <asp:Table ID="TablaResultadosTerrestre" runat="server" Height="40px" Width="660px" CssClass="blue" 
                 BorderColor="#E0E0E0" BorderStyle="Solid"> 
             </asp:Table> 

        </asp:Panel>    
        <!-- **************************************************PANEL RESUMEN INICIO *********************************************** -->        


       
        <!-- **************************************************PANEL RESULTADOS INICIO *********************************************** -->        
        <asp:Panel ID="PanelResultados" runat="server" Height="480px" Width="660px" ScrollBars="Vertical" Visible="false">
        <em>
            <asp:Label ID="LabelTituloTotales" runat="server" CssClass="titularazulgrande" Text="Transporte Intermodal con líneas marítimas existentes."></asp:Label><br />
        </em>
             <asp:Label ID="LabelErrorDataList" runat="server" CssClass="txtsmallbold" ForeColor="Red" Width="581px" Visible="False"></asp:Label>
              &nbsp;&nbsp;
             <asp:DataList  ID="DataList1"   OnItemCommand="seleccionar" runat="server" Visible="False" CellPadding="0" Width="575px" >
                    <HeaderTemplate>
                    <table width="635px" cellspacing="0" border="0" cellpadding="0" style="background-color:White">
                        <tr style="background-color:White">
                            <td width="35px" align="center"></td>
                            <td  width="200" colspan="2" align="center" class="titularazul"> ORIGEN - DESTINO</td>
                            <td  width="80px" align="right" class="titularazulderecha" >Coste (Eur)</td>
                            <td width="80px" align="right" class="titularazulderecha" >Tiempo (Horas)</td>
                            <td  width="80px" align="right" class="titularazulderecha" >Distancia (Km)</td>
                            <td  width="80px" align="right" class="titularverdederecha" >Costes Ext(Eur)</td>
                            <td  width="80px" align="right" class="titularverdederecha" >Emisiones CO2 (Kg)</td>
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


<span class="article_separator">&nbsp;</span>
				</td>
		 
		</tr>
		</table>
	</td>
</tr>
<tr>
	<td valign="top" align="center">
				<br /><br />
	</td>
</tr>
<tr>
	<td valign="top" align="center">
			</td>
</tr>

</form>

<!-------------------------------------------------------------    --->
<!--------------------------fin simulador----------------------    --->
<!-------------------------------------------------------------    --->

 	
																	</div>
						</div>
						<div class="clr"></div>
				</div>
			</div>

	</div>
	<div id="footer">
		<div id="footer_l">
			<div id="footer_r">
				<p style="float:left;">
					 


<table class="contentpaneopen">
	<tr>
		<td valign="top" ><p class="MsoNormal">SPC-Spain   -   Calle Cronos, 63, 3ª pl, Of. 6   -   28037-MADRID    Tel: 91 304 13 59    Fax: 91 327 41 99   <a href="mailto:info@shortsea.es"><span style="text-decoration: underline;"><span style="color: #0000ff;">info@shortsea.es</span></span></a><strong></strong></p>
<p> </p></td>
	</tr>
	<tr>
        <td valign="top" >

       		</td>
     </tr>
</table>

				</p>
				<p style="float:right">	 			 	
					
				</p>
			</div>
		</div>
	</div>			
		</div>
	</div>
	
</div>
</div>
</body>
</html>