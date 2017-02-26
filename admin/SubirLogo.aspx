<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="SubirLogo.aspx.vb" Inherits="admin_SubirLogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Subir Logo
    </h2>

    <div>
     <p>
        <asp:label ID="lblFileUpload" Text="Logo (Solo jpg, gif, png):" CssClass="fieldset" runat="server" Width="150px" ></asp:label>
        <asp:FileUpload ID="FileUpload" runat="server" Width="700px" />
    </p>
   <p>
        <asp:label ID="lblError" Text="" CssClass="failureNotification" runat="server" ></asp:label>
    </p>
    <p>
        <asp:Button ID="btnEnviar" Text="Grabar" CssClass="submitButton" runat="server" />        
        <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="submitButton" 
        runat="server" CausesValidation="False" />
        <br />
    </p>
    </div>
</asp:Content> 