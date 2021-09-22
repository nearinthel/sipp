<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuLocal.ascx.cs" Inherits="WebAppEmpp.Script.menuLocal" %>
<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkverPedidos" runat="server" NavigateUrl="~/PedidosPorLocal/verPedidos.aspx">Ver Pedidos en Espera</asp:HyperLink></li>
</ul>
<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkPass" runat="server" NavigateUrl="~/Local/modificarPassLocal.aspx">Cambiar Pass</asp:HyperLink></li>
</ul>
<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkSalir" runat="server" NavigateUrl="~/PedidosPorLocal/LogoutLocal.aspx">Salir</asp:HyperLink></li>
</ul>