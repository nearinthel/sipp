<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="AltaLocal.aspx.cs" Inherits="WebAppEmpp.Local.AltaLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
      <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="../Script/geocoder.js" type="text/javascript"></script>
        <script src="../Script/mapaAltaLocal.js" type="text/javascript"></script>
    <%--<form id="form1" runat="server">--%>
    <div id="Gmap" style="width: 580px; height: 381px"> </div>
    <div>
        <table border="1" style="width:400px">
            <tr>
                <td style="width:100px">
                    Nombre de Local
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Telefono
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Distancia en km a los que envia
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Direccion
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Localidad
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtLocalidad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                </td>
                <td style="width:100px">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"></asp:Button>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="latbox" runat="server" style="display:none"  ></asp:TextBox>
        <asp:TextBox ID="longbox" runat="server" style="display:none" ></asp:TextBox> 
     <%--<input id="latbox" type="text" />
        <input id="longbox" type="text" />--%>

    </div>
       <%-- </form>--%>
</asp:Content>
