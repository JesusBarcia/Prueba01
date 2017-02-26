<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="PuertoListado.aspx.vb" Inherits="PuertoListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Listado de Puertos
    </h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Filtrar Puertos: " Width="100px"></asp:Label>
        <asp:TextBox ID="txtFiltro" Text="" CssClass="textEntry" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:Button ID="btnBuscar" Text="Buscar" CssClass="submitButton" runat="server" />        
        &nbsp;&nbsp;&nbsp;  <a href="PuertoGestion.aspx" target="_self">Nueva Puerto</a>
    </p>
    <asp:Panel ID="Panel1" runat="server" Width="800px">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" Width="800px" AllowPaging="True" AllowSorting="True" 
        DataKeyNames="ID" EmptyDataText="No hay datos" Font-Size="X-Small">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Puerto" 
                    ItemStyle-Width="150px" SortExpression="Nombre" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Terminal" HeaderText="Terminal" 
                    ItemStyle-Width="150px" SortExpression="Terminal" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ServiciosComplementarios" HeaderText="Servicios Complementarios" 
                    ItemStyle-Width="150px" SortExpression="ServiciosComplementarios" >
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DatosContacto" HeaderText="Contacto" 
                    ItemStyle-Width="150px" 
                    SortExpression="DatosContacto">
<ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="InformacionReservas" HeaderText="Informacion y Reservas" 
                    ItemStyle-Width="150px" 
                    SortExpression="InformacionReservas">
<ItemStyle Width="150px"></ItemStyle>
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
    </asp:Panel>
 
 </asp:Content>