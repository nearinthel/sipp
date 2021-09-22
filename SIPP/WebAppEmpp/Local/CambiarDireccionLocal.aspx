<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="CambiarDireccionLocal.aspx.cs" Inherits="WebAppEmpp.Local.CambiarDireccionLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="../Script/geocoder.js" type="text/javascript"></script>
    <script src="../Script/mapaDireccionNuevaLocal.js" type="text/javascript"></script>
    <div id="GMap" style="width: 580px; height: 381px"> </div>
    <%--<form id="form1" runat="server">--%>
    <table border="1" style="width:400px">
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Local"></asp:Label>
                <asp:Label ID="lblNombre" runat="server" ></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Label ID="label2" runat="server" Text="Datos Actuales"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Label ID="Textbox1" runat="server" Text="Datos Nuevos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="label1" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDireccion" runat="server"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:Textbox ID="txtDireccion" runat="server" ></asp:Textbox>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="label3" runat="server" Text="Localidad"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:TextBox ID="txtLocalidad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click"></asp:Button>
            </td>
            <td style="width:100px">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
            </td>
        </tr>
    </table>
    <asp:TextBox ID="latbox" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="longbox" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="latboxNuevo" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="longboxNuevo" runat="server" style="display:none"></asp:TextBox>
      <%--  </form>--%>
</asp:Content>
