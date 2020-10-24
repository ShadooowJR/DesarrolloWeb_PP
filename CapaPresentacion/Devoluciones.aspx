<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Devoluciones.aspx.cs" Inherits="CapaPresentacion.Devoluciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>&nbsp; - NUEVA DEVOLUCION -</h2>
    </div><br />
    <div class="Componentes">

    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="No. de Factura: "></asp:Label>
        <asp:TextBox ID="txt_idFactura" runat="server" Height="30px" Width="100px" OnTextChanged="txt_idFactura_TextChanged" AutoPostBack="True"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp   ;
        <asp:TextBox ID="txtAuditoria" runat="server" BackColor="Yellow" BorderColor="Black" BorderWidth="5px" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="360px"></asp:TextBox>

        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="NIT Cliente: "></asp:Label>
        <asp:TextBox ID="txtNit" runat="server" Height="30px" Width="150px" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Cliente: "></asp:Label>
        <asp:TextBox ID="txtNombreCliente" runat="server" Height="30px" Width="300px" Enabled="False"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Cajero: "></asp:Label>
        <asp:TextBox ID="txtCajero" runat="server" Height="30px" Width="300px" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Tipo de Pago: "></asp:Label>
        <asp:TextBox ID="txtTipoPago" runat="server" Height="30px" Width="130px" Enabled="False"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Fecha Venta: "></asp:Label>
&nbsp;<asp:TextBox ID="txtFecha" runat="server" Height="30px" Width="100px" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Hora Venta: "></asp:Label>
        <asp:TextBox ID="txtHora" runat="server" Height="30px" Width="100px" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Total: "></asp:Label>
        <asp:TextBox ID="txtTotal" runat="server" Height="30px" Width="100px" Enabled="False"></asp:TextBox>

    </div><br />
    <div class="Width100">

        <asp:GridView ID="gvDetalleFactura" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
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

    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCuantosDevolver" runat="server" Text="¿Cuántos Devolverá?: " Enabled="False"></asp:Label>
        <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="100px" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCantidadDevolver" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server" Text="¿Motivo?: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False" Height="100px" Width="212px" TextMode="MultiLine"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDevolver" runat="server" Height="30px" OnClick="btnDevolver_Click" Text="Devolver" Width="150px" Enabled="False" />
    </div><br />
    <div class="Componentes">

    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Text="- DEVOLUCIONES PARA ESTA FACTURA -"></asp:Label>

    </div><br />
    <div class="Width100">

        <asp:GridView ID="gvDevoluciones" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
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
        <asp:Button ID="btnFacturar" runat="server" Height="30px" Text="Generar Factura" Width="200px" Enabled="False" OnClick="btnFacturar_Click" />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        
    </div>
</asp:Content>
