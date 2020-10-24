<%@ Page Title="REPORTE CLIENTES" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteClientes.aspx.cs" Inherits="CapaPresentacion.ReporteClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>&nbsp; - REPORTE DE CLIENTES -</h2>
    </div><br />
    <div class="Componentes">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnGenerarReporte" runat="server" Height="30px" Text="Generar Reporte" Width="150px" OnClick="btnGenerarReporte_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
</asp:Content>
