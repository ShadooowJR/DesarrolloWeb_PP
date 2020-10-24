<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoPedido.aspx.cs" Inherits="CapaPresentacion.NuevoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MÓDULO DE PEDIDOS</title>
    <link href="Styles/Styles.css" rel="stylesheet" type="text/css" />    
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=txtFechaEntrega.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                yearRange: '2019:2050'
            });
        });
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h2>&nbsp; - NUEVO PEDIDO -</h2>
        </div>
        <div class="Componentes">

            <br />
&nbsp;&nbsp;

            <asp:Label ID="Label1" runat="server" Text="Proveedor: "></asp:Label>

            <asp:DropDownList ID="ddlProveedor" runat="server" AutoPostBack="true" Height="30px" Width="200px" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged">
            </asp:DropDownList>

            &nbsp;&nbsp;

            <asp:Label ID="Label2" runat="server" Text="Fecha Pedido: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtFechaPedido" runat="server" Height="30px" Width="95px" Visible="False" Enabled="False"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Fecha Entrega: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtFechaEntrega" runat="server" Height="30px" Width="95px" Visible="False"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAuditoria" runat="server" BackColor="Yellow" BorderColor="Black" BorderWidth="5px" Height="100px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="360px"></asp:TextBox>

        </div><br />
        <div class="Width100">

            <asp:GridView ID="gvProductos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" GridLines="Vertical" Visible="False" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div><br />
        <div class="Componentes">

            &nbsp;

            &nbsp;&nbsp;

            <br />

            &nbsp;&nbsp;

            <asp:Label ID="Label7" runat="server" Text="Cantidad: " Visible="False"></asp:Label>

            <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="100px" Visible="False"></asp:TextBox>

            &nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Solicitado por: " Visible="False"></asp:Label>
            <asp:TextBox ID="txtCajero" runat="server" Height="30px" Width="270px" Visible="False" Enabled="False"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAceptar" runat="server" Height="35px" Text="Aceptar" Visible="False" Width="150px" OnClick="btnAceptar_Click"/>
            <br />
            <br />
            <br />
        </div>
        <div>
            <h2>&nbsp; - PEDIDOS REALIZADOS -</h2>
        </div><br />
        <div class="Width100">
            <asp:GridView ID="gvPedidos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" GridLines="Vertical" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div><br /><br />
        <div class="Componentes">

        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="¿Pedido Recibido? - Seleccionelo Y Click En Aceptar"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPedidoRecibido" runat="server" Height="30px" OnClick="btnPedidoRecibido_Click" Text="Aceptar" Width="150px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
</asp:Content>
