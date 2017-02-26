<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master"  CodeFile="Mensaje.aspx.vb" Inherits="admin_Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        <h2>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </h2>
    <br />
    <p>        
        Pulse <a href="<%=url%>" > aquí </a> para continuar
    </p>

    </div>
</asp:Content> 