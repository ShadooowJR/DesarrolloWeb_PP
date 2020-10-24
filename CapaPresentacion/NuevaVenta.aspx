<%@ Page Title="Nueva Venta" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="CapaPresentacion.NuevaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <div>
        <h2>&nbsp;- NUEVA VENTA -</h2><br />
    </div>
    <div class="Componentes">
    &nbsp;
        <asp:Label ID="Label1" runat="server" Text="NIT: "></asp:Label>


        <asp:TextBox ID="txtNIT" runat="server" Height="30px" Width="150px" AutoPostBack="True" OnTextChanged="txtNIT_TextChanged"></asp:TextBox>


    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Cliente: "></asp:Label>


        <asp:TextBox ID="txtNombreCliente" runat="server" Height="30px" Width="365px" Enabled="False"></asp:TextBox>


    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblErrorNIT" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAuditoria" runat="server" BackColor="Yellow" BorderColor="Black" BorderWidth="5px" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="360px"></asp:TextBox>

        <br />
&nbsp;<br />
&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Tipo de Pago: "></asp:Label>
        <asp:DropDownList ID="ddlTipoPago" runat="server" Height="30px" Width="150px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCrearFactura" runat="server" Height="30px" OnClick="btnCrearFactura_Click" Text="Crear Factura" Width="150px" />
        <br /><br />
    </div>
    <div class ="Componentes">

    &nbsp;&nbsp;
        <asp:Label ID="lblSeleccioneProductos" runat="server" Text="- Seleccione Sus Productos -" Visible="False" BackColor="Yellow"></asp:Label>

        <br />
        <br />
&nbsp;&nbsp;
        <asp:Label ID="lblBuscar" runat="server" Text="Buscar: " Visible="False"></asp:Label>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Width="200px" Visible="False" AutoPostBack="True" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>

    </div><br />
    <div class="Width100">
        <asp:GridView ID="gvProductos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Visible="False" Width="100%">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>        
    </div><br />
    <div class="Componentes">
    &nbsp;&nbsp;
        <asp:Label ID="lblCuanto" runat="server" Text="¿Cuantas Unidades?" Visible="False"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;
        <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="150px" Visible="False"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Button ID="btnAgregarCarrito" runat="server" Height="30px" Text="Agregar Al Carrito" Visible="False" Width="200px" OnClick="btnAgregarCarrito_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelarVenta" runat="server" Height="30px" Text="Cancelar Venta" Visible="False" Width="200px" OnClick="btnCancelarVenta_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Visible="False"></asp:Label>
    </div><br />
    <div class="Componentes">
        
    &nbsp;&nbsp;
        <asp:Label ID="lblComprado" runat="server" Text="USTED HA ESCOGIDO: " Visible="False"></asp:Label>
        
    </div><br />
    <div class="Width100">

        <asp:GridView ID="gvCarrito" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </div><br />
    <div class="Componentes">

    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Total Q. " Visible="False"></asp:Label>
        <asp:TextBox ID="txtTotal" runat="server" Enabled="False" Height="30px" Visible="False" Width="100px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEfectivo" runat="server" Text="Efectivo Q. " Visible="False"></asp:Label>
        <asp:TextBox ID="txtEfectivo" runat="server" AutoPostBack="True" Height="30px" OnTextChanged="txtEfectivo_TextChanged" Visible="False" Width="100px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCambio" runat="server" Text="Cambio Q. " Visible="False"></asp:Label>
        <asp:TextBox ID="txtCambio" runat="server" Enabled="False" Height="30px" Visible="False" Width="100px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Label ID="lblTerminoCompra" runat="server" Text="¿Terminó Su Compra?" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFacturar" runat="server" Height="30px" OnClick="btnFacturar_Click" Text="Facturar" Visible="False" Width="150px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDineroInsuficiente" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
</asp:Content>
