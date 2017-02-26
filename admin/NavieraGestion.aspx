<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="NavieraGestion.aspx.vb" Inherits="NavieraGestion" ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2>
        Navieras: <asp:label ID="lblAccion" Text="" runat="server"></asp:label>
    </h2>
    <p>
        <asp:label ID="lblLOGO" Text="LOGO:" CssClass="fieldset" runat="server" Width="100px"></asp:label>
        <asp:TextBox ID="txtLOGO" Text="" CssClass="textEntry" runat="server" Width="800px" MaxLength="100"></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblDE" Text="DE:" CssClass="fieldset" runat="server" Width="100px"></asp:label>
        <asp:TextBox ID="txtDE" Text="" CssClass="textEntry" runat="server" Width="800px" MaxLength="100"></asp:TextBox> 
        <br />
        <asp:label ID="lblA" Text="A:" CssClass="fieldset" runat="server" Width="100px"></asp:label>
        <asp:TextBox ID="txtA" Text="" CssClass="textEntry" runat="server" Width="800px" MaxLength="100"></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblHorario" Text="HORARIO:" CssClass="fieldset" runat="server" Width="300px"></asp:label>
        <asp:TextBox ID="txtHorario" Text="" CssClass="textEntry" runat="server" Width="800px" Height="200px" TextMode="MultiLine"></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblDatosContacto" Text="DATOS CONTACTO:" CssClass="fieldset" runat="server" Width="300px"></asp:label>
        <asp:TextBox ID="txtDatosContacto" Text="" CssClass="textEntry" runat="server" Width="800px" Height="200px" TextMode="MultiLine"></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblInformacionReservas" Text="INFORMACIÓN Y RESERVAS:" CssClass="fieldset" runat="server" Width="300px"></asp:label>
        <asp:TextBox ID="txtInformacionReservas" Text="" CssClass="textEntry" runat="server" Width="800px" Height="200px" TextMode="MultiLine"></asp:TextBox> 
    </p>
    
    <p>

        <asp:Button ID="btnEnviar" Text="Grabar" CssClass="submitButton" runat="server" />        
        <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="submitButton" 
        runat="server" CausesValidation="False" />
        <br />
        <asp:HiddenField ID="txtID" runat="server" />
        <asp:HiddenField ID="txtAccion" runat="server" />
    </p>
</asp:Content>