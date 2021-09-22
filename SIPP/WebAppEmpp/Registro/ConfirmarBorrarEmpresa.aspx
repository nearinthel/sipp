<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConfirmarBorrarEmpresa.aspx.cs" Inherits="WebAppEmpp.Registro.ConfirmarBorrarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div id="centro">
        <table border="1" style="width:400px">
            <tr>
                <td style="width:100px">
                    Ingrese Contraseña para borrar Empresa

                </td>
                <td style="width:100px">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirme borrar" OnClick="btnConfirmar_Click" />
                </td>
                <td style="width:100px">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass" ForeColor="Red" ErrorMessage="Debe Poner Contraseña"></asp:RequiredFieldValidator>
        Borrar la Empresa es irreversible
    </div>
       <%-- </form>--%>
</asp:Content>
