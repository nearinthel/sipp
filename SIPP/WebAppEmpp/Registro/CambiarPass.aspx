<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="CambiarPass.aspx.cs" Inherits="WebAppEmpp.Registro.CambiarPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
   <%--<form id="form1" runat="server">--%>
    <div>
        <table border="0" style="width:400px">
            <tr>
                <td style="width:100px">
                    Pass Actual
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtPassActual" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width:100px">
                    <asp:RequiredFieldValidator ID="rfvPassActual" runat="server" ControlToValidate="txtPassActual" ErrorMessage="Ponga la Contraseña Actual" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Pass Nueva
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtPassNueva" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width:100px">
                    <asp:RequiredFieldValidator ID="rfvPassNueva" runat="server" ErrorMessage="Ingrese nueva contraseña" ControlToValidate="txtPassNueva" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Confirme Pass Nueva
                </td>
                <td style="width:100px">
                    <asp:TextBox ID="TxtConfirmePass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width:100px">
                    <asp:RequiredFieldValidator ID="rfvConfirmePass" runat="server" ErrorMessage="Ingrese la confirmacion" ForeColor="Red" ControlToValidate="txtConfirmePass"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="cvPass" runat="server" ErrorMessage="Las contraseñas no son iguales" ControlToValidate="txtConfirmePass" ControlToCompare="txtPassNueva" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                </td>
                <td style="width:100px">
                    <asp:Button ID="btnVolver" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </div>
       <%--</form>--%>
</asp:Content>
