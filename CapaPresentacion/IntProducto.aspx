<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IntProducto.aspx.cs" Inherits="CapaPresentacion.IntProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <h2>&nbsp;&nbsp; - PRODUCTOS -</h2>
    </div><br />
        <div class="Componentes">
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Tipo: "></asp:Label>
            <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="160px" Height="30px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Marca: "></asp:Label>
            <asp:TextBox ID="txtMarca" runat="server" Height="30px" Width="185px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="130px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Precio Venta: "></asp:Label>
            <asp:TextBox ID="txtPrecioVenta" runat="server" Height="30px" Width="75px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="Precio Compra: "></asp:Label>
            <asp:TextBox ID="txtPrecioCompra" runat="server" Height="30px" Width="75px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Proveedor: "></asp:Label>
            <asp:DropDownList ID="ddlProveedor" runat="server" Width="130px" Height="30px">
            </asp:DropDownList>
            <br /><br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" Height="30px" Width="600px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNuevo" runat="server" Height="30px" Text="Nuevo" Width="100px" OnClick="Button1_Click" />
            <br />
        </div><br /><br />
        <div class="Width100">

            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
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

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
</asp:Content>
