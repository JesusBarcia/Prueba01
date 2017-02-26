<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="NavieraListado.aspx.vb" Inherits="NavieraListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Listado de Navieras
    </h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Filtrar Navieras: " Width="100px"></asp:Label>
        <asp:TextBox ID="txtFiltro" Text="" CssClass="textEntry" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:Button ID="btnBuscar" Text="Buscar" CssClass="submitButton" runat="server" />        
        &nbsp;&nbsp;&nbsp;  <a href="NavieraGestion.aspx" target="_self">Nueva Naviera</a>
    </p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" Width="804px" AllowPaging="True" AllowSorting="True" 
        DataKeyNames="ID" EmptyDataText="No hay datos" Font-Size="X-Small">
            <Columns>
                <asp:BoundField DataField="De" HeaderText="De" 
                    ItemStyle-Width="300px" SortExpression="De" >
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="A" HeaderText="A" 
                    ItemStyle-Width="100px" SortExpression="A" >
<ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Horario" HeaderText="Horario" 
                    ItemStyle-Width="300px" SortExpression="Horario">
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DatosContacto" HeaderText="Contacto" 
                    ItemStyle-Width="300px" 
                    SortExpression="DatosContacto">
<ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="InformacionReservas" HeaderText="Informacion y Reservas" 
                    ItemStyle-Width="300px" 
                    SortExpression="InformacionReservas">
<ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                
                <asp:ButtonField CommandName="EDIT" Text="Modif." ButtonType="Image" 
                    HeaderText="Modif." ImageUrl="./Images/icoModificar.png" 
                    ItemStyle-Width="50px"
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:ButtonField>

                <asp:ButtonField CommandName="VER" Text="Ver" ButtonType="Image" 
                    HeaderText="Ver" ImageUrl="./Images/icoOjo.png" 
                    ItemStyle-Width="50px"
                    ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:ButtonField>

                <asp:BoundField DataField="ID" HeaderText="ID" 
                    ItemStyle-Width="50px" 
                    SortExpression="ID">
                    <ItemStyle Width="50px"></ItemStyle>
                </asp:BoundField>
                
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>


</asp:Content>