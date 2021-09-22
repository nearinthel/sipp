<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConfirmarPedido.aspx.cs" Inherits="WebAppCliente.Pages.Pedido.ConfirmarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/ConfirmarPedido.css" />
    <link href='http://fonts.googleapis.com/css?family=La+Belle+Aurore' rel='stylesheet' type='text/css'>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">

    <form id="form1" runat="server">
        <div class="capaConfirmarPedido">
            <center>
                <h1>Confirme su pedido</h1>
                <p>
                    <b>Local: </b><br />
                    <%=local %><br /><br />

                    <b>Dirección de Entrega: </b><br />
                    <%=direccion%><br /><br />
                </p>
                <h3>Resumen del Pedido</h3>
            </center>
            <%=resumen%>
            <br />
            <br />
            <center><table>
                <tr>
                    <td>
                        <asp:Button ID="btnConfirmar" CssClass="btnConfirmacion" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnEditar" CssClass="btnConfirmacion" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" CssClass="btnConfirmacion" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
                </center>
            <br />
            <br />
            <br />
        </div>
    </form>

</asp:Content>
