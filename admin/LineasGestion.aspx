<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/Site.master" CodeFile="LineasGestion.aspx.vb" Inherits="LineasGestion" ValidateRequest="false"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        LINEAS: <asp:label ID="lblAccion" Text="" runat="server"></asp:label>
    </h2>
    <p>
        <asp:label ID="lblPuertoOrigen" Text="Puerto Origen:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoOrigen" Text="" CssClass="textEntry" runat="server" Width="600px" MaxLength="100"></asp:TextBox>
        <br />
        <asp:label ID="lblPuertoOrigenMappoint" Text="Puerto Origen (Google):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoOrigenMappoint" Text="" CssClass="textEntry" runat="server" Width="600px" MaxLength="100"></asp:TextBox> 
        <br />
        <asp:label ID="lblPuertoOrigenLongitud" Text="Coordenadas:      Longitud" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoOrigenLongitud" Text="" CssClass="textEntry" runat="server" Width="100px" MaxLength="20"></asp:TextBox> 
        &nbsp &nbsp &nbsp
        <asp:label ID="lblPuertoOrigenLatitud" Text="Latitud" CssClass="fieldset" runat="server" Width="60px"></asp:label>
        <asp:TextBox ID="txtPuertoOrigenLatitud" Text="" CssClass="textEntry" runat="server" Width="100px" MaxLength="20"></asp:TextBox> 

        <br />
        <asp:label ID="lblcbPuertoOrigen" Text="Selecciona el puerto:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbPuertoOrigen" runat="server" Width="400px">

        </asp:DropDownList> 

    </p>
    <p>
        <asp:label ID="lblPuertoDestino" Text="Puerto Destino:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoDestino" Text="" CssClass="textEntry" runat="server" Width="600px" MaxLength="100"></asp:TextBox> 
        <br />
        <asp:label ID="lblPuertoDestinoMappoint" Text="Puerto Destino (Google):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoDestinoMappoint" Text="" CssClass="textEntry" runat="server" Width="600px" MaxLength="100"></asp:TextBox> 
        <br />
        <asp:label ID="lblPuertoDestinoLongitud" Text="Coordenadas:      Longitud" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtPuertoDestinoLongitud" Text="" CssClass="textEntry" runat="server" Width="100px" MaxLength="20"></asp:TextBox> 
        &nbsp &nbsp &nbsp
        <asp:label ID="lblPuertoDestinoLatitud" Text="Latitud" CssClass="fieldset" runat="server" Width="60px"></asp:label>
        <asp:TextBox ID="txtPuertoDestinoLatitud" Text="" CssClass="textEntry" runat="server" Width="100px" MaxLength="20"></asp:TextBox> 
        <br />

        <asp:label ID="lblcbPuertoDestino" Text="Selecciona el puerto:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbPuertoDestino" runat="server" Width="400px">

        </asp:DropDownList> 

    </p>
    <hr />

    <p>
        <asp:label ID="lblLinea" Text="Nombre de la Línea:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtLinea" Text="" CssClass="textEntry" runat="server" Width="600px" ></asp:TextBox> 
    </p>
     <p>
        <asp:label ID="lblNaviera" Text="Naviera Nombre:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtNaviera" Text="" CssClass="textEntry" runat="server" Width="600px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblNavieraFicha" Text="Naviera Ficha:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbNavieraFicha" runat="server" Width="400px">

        </asp:DropDownList> 
    </p> 

     <p>
        <asp:label ID="lblFrecuencia" Text="Frecuencia:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbFrecuencia" runat="server" Width="200px">
            <asp:ListItem id="FrecuenciaDiario" runat="server" Text="Diario" Value="30" />
            <asp:ListItem id="Frecuencia4xSemana" runat="server" Text="4xSemana" Value="16" />                        
            <asp:ListItem id="Frecuencia3xSemana" runat="server" Text="3xSemana" Value="12" />
            <asp:ListItem id="Frecuencia2xSemana" runat="server" Text="2xSemana" Value="8" />
            <asp:ListItem id="FrecuenciaSemanal" runat="server" Text="Semanal" Value="4" />
            <asp:ListItem id="FrecuenciaDecenal" runat="server" Text="Decenal" Value="3" />
            <asp:ListItem id="FrecuenciaQuincenal" runat="server" Text="Quincenal" Value="2" />            
            <asp:ListItem id="Frecuencia2xMes" runat="server" Text="2xMes" Value="2" />
            <asp:ListItem id="FrecuenciaMensual" runat="server" Text="Mensual" Value="1" />
        </asp:DropDownList> 
    </p> 
     <p>
        <asp:label ID="lblTipoTrafico" Text="Tipo Trafico:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbTipoTrafico" runat="server" Width="100px">
            <asp:ListItem runat="server" Text="RO-RO" Value="RO-RO" />
            <asp:ListItem runat="server" Text="RO-PAX" Value="RO-PAX" />
        </asp:DropDownList> 
    </p> 

    <p>
        <asp:label ID="lblDistanciaEnMillas" Text="Distancia en millas:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtDistanciaEnMillas" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblTiempoPuertoOrigen" Text="Tiempo en puerto Origen (horas):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtTiempoPuertoOrigen" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblTiempoTransito" Text="Tiempo en transito (horas):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtTiempoTransito" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblTiempoPuertoDestino" Text="Tiempo en puerto Destino (horas):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtTiempoPuertoDestino" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
    </p>

    <hr />
    <p>
        <asp:label ID="lblFleteMaritimo" Text="Flete Marítimo (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtFleteMaritimo" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblRecargoCabezaTractora" Text="Recargo Cabeza Tractora (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtRecargoCabezaTractora" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblRecargoBAF" Text="Recargo BAF (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtRecargoBAF" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblRecargoMercanciaPeligrosa" Text="Recargo Mercancía Peligrosa (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtRecargoMercanciaPeligrosa" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblRecargoCCRR" Text="Recargo CCRR (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtRecargoCCRR" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblCapPlataformas" Text="Recargo CAP Plataformas (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtCapPlataformas" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblCapPasajeros" Text="CAP Pasajeros (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtCapPasajeros" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
        <asp:label ID="lblCapCoches" Text="CAP Coches (€):" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtCapCoches" Text="" CssClass="textEntry" runat="server" Width="100px" ></asp:TextBox> 
        <br />
    </p>
    <hr />
     <p>
        <asp:label ID="lblFachada" Text="Fachada:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbFachada" runat="server" Width="200px">
            <asp:ListItem runat="server" Text="ATLANTICA" Value="ATLANTICA" />
            <asp:ListItem runat="server" Text="CANTABRICA" Value="CANTABRICA" />
            <asp:ListItem runat="server" Text="MEDITERRANEA" Value="MEDITERRANEA" />
        </asp:DropDownList> 
    </p> 
    <hr />
    <p>
    <asp:label ID="lblVisible" Text="Visible:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
    <asp:CheckBox runat="server" ID="txtVisible" Text="" />
    </p>
    <p>
        <asp:label ID="lblEnlaceComodalWeb" Text="Enlace Comodal Web:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:TextBox ID="txtEnlaceComodalWeb" Text="" CssClass="textEntry" runat="server" Width="600px" ></asp:TextBox> 
    </p>
    <p>
        <asp:label ID="lblFleteMensaje" Text="Flete Mensaje:" CssClass="fieldset" runat="server" Width="200px"></asp:label>
        <asp:DropDownList ID="cbFleteMensaje" runat="server" Width="600px">
            <asp:ListItem runat="server" Text="" Value="1" />
            <asp:ListItem runat="server" Text="El flete marítimo es una estimación de SPC-Spain. Para cotización real, consulte a la naviera" Value="2" />
            <asp:ListItem runat="server" Text="El flete marítimo es orientativo. Para mayor precisión, consulte a la naviera" Value="3" />
        </asp:DropDownList> 
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