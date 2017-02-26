<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Velocidad" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtVelocidad" runat="server"></asp:TextBox><br />
        <asp:Label ID="Distancia" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtDistancia" runat="server"></asp:TextBox><br />

        <asp:Button ID="Calcular" Text="Calcular" runat="server" />
        <br />
        <asp:Label ID="Resultado" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
