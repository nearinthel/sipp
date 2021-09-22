<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ArmarPedido.aspx.cs" Inherits="WebAppCliente.Pages.Pedido.ArmarPizza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/jquery.js"></script>
    <script src="/Scripts/jquery-ui.min.js"></script>
    <script src="/Scripts/jquery.ui.touch-punch.min.js"></script>
    <script src="/Scripts/<%=Session["Producto"]%>.js"></script>
    <link rel="stylesheet" type="text/css" href="/Styles/<%=Session["Producto"]%>.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/ArmarPedido.css" />
    <link href='http://fonts.googleapis.com/css?family=La+Belle+Aurore' rel='stylesheet' type='text/css'>
    <script type="text/javascript">
        function enviarPedido() {
            $('#<%=hiddenEstructuraPizza.ClientID%>').val($('#pizzaArea').html());
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    <form id="FrmPedido" runat="server">
        <table id="desplegarResumen" class="resumenIngredientes">
            <tr id="rowTotalPreview">
                <th style="text-align: right">Total:</th>
                <th id="totalPreview">50</th>
            </tr>
        </table>
        <div id='modal'>
            <div class="ayuda">
                <h2>Arrastre los elementos para quitarlos</h2>
                <h3 style="cursor: pointer">Click aquí para cerrar</h3>
            </div>
            <div id='detallesArea' class='detallesArea'>
                <table cellspacing="0" style="margin-left: auto; margin-right: auto; left: -50%">
                    <tr>
                        <td>
                            <div class="detallesLeftScroll" onclick="scrollIngredientes('left',570)"></div>
                        </td>
                        <td>
                            <div id='detalles' class='detalles'>
                                <table cellspacing="0">
                                    <tr id='detallesRow'></tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div class="detallesRightScroll" onclick="scrollIngredientes('right',570)"></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="editor">
            <div id="resumenArea" class="resumenArea">
                <h2>Resumen de ingredientes</h2>
                <table id="resumenIngredientes" class="resumenIngredientes">
                </table>
            </div>
            <div class="controlesArea">
                <div id="addPizza" class="controlIcon" title="Agregar Pizza" precio="<%=precioPorcion.ToString().Replace(",",".")%>"></div>
                <div id="deletePizza" class="controlIcon" title="Quitar Pizza"></div>
                <div id="nextPizza" class="controlIcon" title="Pizza Siguiente"></div>
                <div id="beforePizza" class="controlIcon" title="Pizza Anterior"></div>
            </div>
            <div id="pizzaArea" class="pizzaArea">
                <%=editor%>
            </div>
            <div class="ingredientsArea">
                <div class="scrollUp" onclick="scrollIngredientes('up',570)"></div>
                <div class="ingredients">
                    <%=ingredientes%>
                </div>
                <div class="scrollDown" onclick="scrollIngredientes('down',570)"></div>
            </div>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnPedido" CssClass="btnPedido" runat="server" Text="Realizar Pedido" OnClientClick="return enviarPedido();" OnClick="btnPedido_Click" />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="btnCancelar" OnClientClick="return confirm('¿Desea cancelar este pedido?');" CssClass="btnPedido" runat="server" Text="Cancelar Pedido" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hiddenEstructuraPizza" runat="server" />
    </form>
</asp:Content>
