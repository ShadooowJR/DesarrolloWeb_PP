<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioCaja.aspx.cs" Inherits="CapaPresentacion.InicioCaja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>INICIO CAJA</title>
    <link rel="stylesheet" type="text/css" href="Styles/StylesLogin.css" />
</head>
<body class="LoginBody" style="height: 523px">
    <form id="form1" runat="server">
        <div class="LoginComponentes">

            <br />
            <br />
            <br />
            <br />
            <h2>INICIO DE CAJA</h2>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Efectivo Q. "></asp:Label>
            <asp:TextBox ID="txtInicioCaja" runat="server" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<br />
            <asp:Button ID="btnLogin" runat="server" Height="35px" Text="Aceptar" Width="100px" OnClick="btnLogin_Click" />
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
