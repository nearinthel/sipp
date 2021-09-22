<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="EspecificacionPedido.aspx.cs" Inherits="WebAppEmpp.Local.EspecificacionPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="../Script/mapaDireccionCliente.js" type="text/javascript"></script>
  
        <div id="GMap" style="width: 968px; height: 305px"> </div>
    <div>
    <asp:Label ID="label3" runat="server" Text="Nombre del Cliente"></asp:Label>
        <asp:Label ID="lblNombre" runat="server"></asp:Label>
    <br />
    <asp:Label ID="label4" runat="server" Text="Direccion del cliente"></asp:Label>
    <asp:Label ID="lblDireccion" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="label1" runat="server" Text="Latitud del cliente"></asp:Label>
    <asp:TextBox ID="latbox" runat="server" ReadOnly="true" ></asp:TextBox>
    <br />
    <asp:Label ID="label2" runat="server" Text="Longitud del cliente"></asp:Label>
    <asp:TextBox ID="longbox" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
        </div>
    <div>
   
    <asp:TextBox ID="txtFechas" TextMode="MultiLine" ReadOnly="true" runat="server" Width="287px" Height="68px"></asp:TextBox>
    <br />
    
    <asp:TextBox ID="txtContenido" TextMode="MultiLine" ReadOnly="true" runat="server" Height="89px" Width="286px"></asp:TextBox>
    <br />
    <asp:Label ID="lblEstado" runat="server" ></asp:Label>
    
    <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
    <asp:HyperLink ID="lnkVolver" runat="server" NavigateUrl="~/PedidosPorLocal/verPedidos.aspx">Volver al estado de pedidos</asp:HyperLink>
    </div>
</asp:Content>
