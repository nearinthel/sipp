<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="mapalocal.aspx.cs" Inherits="WebAppEmpp.mapalocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
        <script src="Script/mapa.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
       
    <form id="form1" runat="server">
    <div id="Gmap" style="width: 580px; height: 381px"></div>
    <div>
        
            
        <input id="latbox" type="text" />
        <input id="longbox" type="text" />
            
        
    </div>   
</form>

</asp:Content>
