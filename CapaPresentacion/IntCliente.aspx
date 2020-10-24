<%@ Page Title="CLIENTES" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IntCliente.aspx.cs" Inherits="CapaPresentacion.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
        <div>
            <h2>&nbsp;- CLIENTES -</h2>
        </div><br />
        <div class="Componentes">
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" Height="30px" Width="330px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="DPI: "></asp:Label>
            <asp:TextBox ID="txtDPI" runat="server" Height="30px" Width="205px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="NIT: "></asp:Label>
            <asp:TextBox ID="txtNIT" runat="server" Height="30px"></asp:TextBox>
            <br /><br />
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Teléfono: "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" Height="30px" Width="100px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="Dirección: "></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" Height="30px" Width="330px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="País: "></asp:Label>
            <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" Height="30px" Width="200px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Departamento: "></asp:Label>
            <asp:DropDownList ID="ddlDepa" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepa_SelectedIndexChanged" Height="30px" Width="200px">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="Municipio: "></asp:Label>
            <asp:DropDownList ID="ddlMunicipio" runat="server" Height="30px" Width="200px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="30px" Text="Nuevo" Width="100px" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div><br /><br />
        <div class="Width100">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
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
        </div>
</asp:Content>
