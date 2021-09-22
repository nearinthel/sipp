<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="ModificarLocal.aspx.cs" Inherits="WebAppEmpp.Local.ModificarLocal" %>
<%@ Register TagPrefix="uc" TagName="repetidor" Src="~/Script/repetidor.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="../Script/geocoder.js" type="text/javascript"></script>

    <uc:repetidor id="repetidor" runat="server"></uc:repetidor>
    <script src="../Script/mapaModificacionLocal.js"></script>
    <%--<form id="form1" runat="server">   --%>
    <div id="GMap" style="width: 1080px; height: 307px"> </div>
    <table border="1" style="width:400px">

        <tr>
            <td>

            </td>
            <td style="width:100px">
              Datos Actuales
            </td>

            <td style="width:100px">
                Datos Nuevos

            </td>

        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label3" Text="Nombre del Local" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="lblNombre" runat="server" ReadOnly="true" ></asp:TextBox>
            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

            </td>

        </tr>
        <tr>
             <td style="width:100px">
                <asp:Label ID="Label4" Text="Telefono" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="lblTelefono" runat="server" ReadOnly="true"></asp:TextBox>
            </td>

            <td style="width:100px">
                
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>

            
        <tr>
             <td style="width:100px">
                <asp:Label ID="Label1" Text="Area en km" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ReadOnly="true" ID="lblArea" runat="server"></asp:TextBox>
            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click"/>

            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkPass" runat="server" OnClick="lnkPass_Click">Modificar Pass del Local</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkCambiarDireccion" runat="server" OnClick="lnkCambiarDireccion_Click" >Cambiar direccion del Local seleccionado</asp:LinkButton>

                
            </td>
            <td>
                <asp:LinkButton ID="lnkEliminar" runat="server" OnClick="lnkEliminar_Click">Eliminar Local</asp:LinkButton>

            </td>

        </tr>

    </table>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Local/AltaLocal.aspx">Agregar mas locales</asp:HyperLink>
    <asp:TextBox ID="latbox" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="longbox" runat="server" style="display:none"></asp:TextBox>
  <%--  <asp:TextBox ID="latboxNuevo" runat="server" style="display:none"></asp:TextBox>
    <asp:TextBox ID="longboxnuevo" runat="server" style="display:none"></asp:TextBox>--%>
    <%--<asp:TextBox ID="txtHiddenNombre" runat="server" style="display:none"></asp:TextBox>--%>
       <%-- </form>--%>
</asp:Content>
