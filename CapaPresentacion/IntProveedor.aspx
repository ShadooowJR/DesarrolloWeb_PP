<%@ Page Title="PROVEEDORES" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IntProveedor.aspx.cs" Inherits="CapaPresentacion.IntProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
        <div>
            <h2>&nbsp;- PROVEEDORES -</h2>
        </div><br />
        <div class="Componentes">
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" Height="30px" Width="330px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="205px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="30px" Text="Nuevo" Width="100px" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
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
