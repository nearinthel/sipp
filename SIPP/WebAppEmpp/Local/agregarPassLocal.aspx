<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="agregarPassLocal.aspx.cs" Inherits="WebAppEmpp.Local.agregarPassLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
   <%-- <form id="form1" runat="server">--%>
        <div>
        <table style="border:double" border="1">
     
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label1" Text="Nombre del Local" runat="server"></asp:Label>

            </td>

            <td style="width:100px">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>

            </td>

        </tr>
            
        <tr>
            <td style="width:100px">
                <asp:Label ID="lblPass" Text="Contraseña" runat="server"></asp:Label>

            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

            </td>


        </tr>

            
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label3" Text="Confirme Contraseña" runat="server"></asp:Label>

            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtConPass" runat="server" TextMode="Password"></asp:TextBox>

            </td>

        </tr>
        <tr>
            <td style="width:100px">
                <asp:Button ID="btnConfirmar" Text="Confirmar" runat="server" OnClick="btnConfirmar_Click"></asp:Button>

            </td>

            <td style="width:100px">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>

            </td>

        </tr>
            
        <tr>
            <td style="width:100px">
                <asp:CompareValidator ID="cvPass" runat="server" ErrorMessage="Las Contraseñas no son iguales" ControlToValidate="txtConPass" ControlToCompare="txtPass" ForeColor="Red"></asp:CompareValidator>

            </td>



        </tr>


        </table>
            <asp:TextBox ID="txtHiddenRut" runat="server" style="display:none"></asp:TextBox>
    </div>
      <%--  </form>--%>
</asp:Content>
