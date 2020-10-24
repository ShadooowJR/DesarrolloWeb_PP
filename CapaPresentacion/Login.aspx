<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LOGIN</title>
    <link rel="stylesheet" type="text/css" href="Styles/StylesLogin.css" />
    </head>
<body class="LoginBody" style="height: 523px">
    <form id="form1" runat="server">
        <div class="LoginComponentes">

            <br />
            <br />
            <h2>LOGIN</h2>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" Height="30px" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Contraseña: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtPass" runat="server" Height="30px" Width="200px" TextMode="Password"></asp:TextBox>

            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Height="35px" Text="Ingresar" Width="100px" OnClick="btnLogin_Click" />
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
