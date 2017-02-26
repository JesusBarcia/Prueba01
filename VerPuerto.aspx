<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VerPuerto.aspx.vb" Inherits="VerPuerto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ver ficha Puerto</title>
    <link href="Styles/estilosimulador.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="header">
		<div id="header_r">
				<div id="logo"><img src="http://www.shortsea.es/templates/shortsea/images/shortsea.png" alt="logo_shortsea" /></div>
		</div>
    </div>
    <form id="form1" runat="server">
    <div>
    
        <table id="Table1"  width="620px" class="txtnormalazul" cellspacing="20px">
        <tr>
        <td style="width:300px">
            <center>
                <asp:label id="lblTerminal" text="TERMINAL" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblPuertoFicha_Terminal" Text="" runat="server" />
        </td>
        <td style="width:300px">
            <center>
                <asp:label id="lblDatosContacto" text="DATOS DE CONTACTO" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblPuertoFicha_DatosContacto" Text="" runat="server" />
            <br />
            <center>
                <asp:image id="imgPuertoFicha_Logo" runat="server"  alt="Puerto Logo" width="200px"  />
            </center>
        </td>
        </tr>

        <tr>
        <td style="width:300px">
            <asp:Label ID="lblPuertoFicha_ServiciosComplementarios" Text="" runat="server" />
        </td>
        <td style="width:300px">
            <center>
                <asp:label id="lblInformacionReservas" text="INFORMACIÓN Y RESERVAS" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblPuertoFicha_InformacionReservas" Text="" runat="server" />
        </td>
        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
