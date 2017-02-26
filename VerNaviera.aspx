<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VerNaviera.aspx.vb" Inherits="VerNaviera" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ver ficha Naviera</title>
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
    
        <table id="Table1" class="txtnormalazul" cellspacing="20px" width="620px">
        <tr>
        <td style="width:300px">
            <asp:image id="imgNavieraFicha_Logo" runat="server"  alt="Naviera Logo" width="200px" height="100px" />
        </td>


        <td style="width:300px">
            <center>
                <asp:label id="lblDatosContacto" text="Datos de contacto" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblNavieraFicha_DatosContacto" Text="" runat="server" />
        </td>
        </tr>
        <tr>
        <td style="width:300px">
            <asp:label id="lblDe" text="De " runat="server" />
            <asp:Label ID="lblNavieraFicha_De" Text="" runat="server" CssClass="titularazul" />

            <asp:image ID="Image1" src=".\images\dobleFlecha.jpg" alt="doble flecha" runat="server" width="20px" Height="10px"/>
            <asp:label id="lblA" text=" a " runat="server" />
            <asp:Label ID="lblNavieraFicha_A" Text="" runat="server" CssClass="titularazul" />
            <br />
            <br />
            <center>
                <asp:label id="lblHorario" text="Horario" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblNavieraFicha_Horario" Text="" runat="server" />
            <br />
            <br />
        </td>
        <td style="width:300px">
            <center>
                <asp:label id="lblInformacionReservas" text="Información y reservas" runat="server" CssClass="titularazul"/>
            </center><br />
            <asp:Label ID="lblNavieraFicha_InformacionReservas" Text="" runat="server" />
        </td>
        </tr>
        
        </table>
    </div>
    </form>
</body>
</html>
