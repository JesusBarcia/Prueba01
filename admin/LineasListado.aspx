<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="LineasListado.aspx.vb" Inherits="LineasListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Listado de Lineas
    </h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Filtrar Lineas: " Width="100px"></asp:Label>
        <asp:TextBox ID="txtFiltro" Text="" CssClass="textEntry" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:Button ID="btnBuscar" Text="Buscar" CssClass="submitButton" runat="server" />        
    &nbsp;&nbsp;&nbsp;  <a href="LineasGestion.aspx" target="_self">Nueva línea marítima</a>      
    </p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" Width="804px" AllowPaging="True" AllowSorting="True" 
        DataKeyNames="ID" EmptyDataText="No hay datos" Font-Size="X-Small" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="PuertoOrigen" HeaderText="Puerto Origen" 
                    ItemStyle-Width="200px" SortExpression="PuertoOrigen" >
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="PuertoDestino" HeaderText="Puerto Destino" 
                    ItemStyle-Width="200px" SortExpression="PuertoDestino" >
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Linea" HeaderText="Linea" 
                    ItemStyle-Width="200px" SortExpression="Linea">
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Naviera" HeaderText="Naviera" 
                    ItemStyle-Width="200px" SortExpression="Naviera">
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                
                <asp:BoundField DataField="Fachada" HeaderText="Fachada" 
                    ItemStyle-Width="200px" SortExpression="Fachada">
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>

                
                <asp:BoundField DataField="Visible" HeaderText="Visible" />

                
                <asp:ButtonField CommandName="EDIT" Text="Modif." ButtonType="Image" 
                    HeaderText="Modif." ImageUrl="./Images/icoModificar.png" 
                    ItemStyle-Width="50px"
                    ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:ButtonField>

                <asp:ButtonField CommandName="VER" Text="GPS" ButtonType="Image" 
                    HeaderText="GPS" ImageUrl="./Images/icoOjo.png" 
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