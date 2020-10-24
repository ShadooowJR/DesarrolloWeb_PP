<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CierreCaja.aspx.cs" Inherits="CapaPresentacion.CierreCaja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CIERRE DE CAJA</title>
    <link rel="stylesheet" type="text/css" href="Styles/StylesLogin.css" />
</head>
<body class="LoginBody" style="height: 523px">
    <form id="form1" runat="server">
        <div class="LoginComponentes">

            <br />
            <br />
            <h2>CIERRE DE CAJA</h2>
            <br />
            <br />
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Inicio Caja Q. "></asp:Label>
            <asp:TextBox ID="txtInicioCaja" runat="server" Height="30px" Width="200px" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Cierre Caja Q. "></asp:Label>
            &nbsp;<asp:TextBox ID="txtCierreCaja" runat="server" Height="30px" Width="200px" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Height="30px" Text="Continuar Operaciones" Width="150px" OnClick="btnLogin_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCerrarSesión" runat="server" Height="30px" OnClick="btnCerrarSesión_Click" Text="Cerrar Sesión" Width="150px" />
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <br />
            <br />

            <br />

        </div>
    </form>
</body>
</html>
