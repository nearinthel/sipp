<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppEmpp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">

    <ul>
        <li class="nivel1"><a href="Registro/Registro.aspx">Registrar Empresa</a></li>
    </ul>
    <ul>
        <li class="nivel1"><asp:HyperLink ID="lnkLoginEmpresa" runat="server" NavigateUrl="~/Registro/Login.aspx">Ingresar como empresa</asp:HyperLink></li>
    </ul>
    <ul>
        <li class="nivel1"><asp:HyperLink ID="lnkLoginLocal" runat="server" NavigateUrl="~/PedidosPorLocal/LoginLocal.aspx">Ingresar como Local</asp:HyperLink></li>
    </ul>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <div id="centro" style="background-image: url('/Images/Inicio.jpg');"> </div>

</asp:Content>
