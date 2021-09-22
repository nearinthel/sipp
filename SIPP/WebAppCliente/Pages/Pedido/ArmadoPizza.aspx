<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArmadoPizza.aspx.cs" Inherits="WebAppCliente.Pages.Pedidos.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/armado-pizza.css" />
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&amp;language=es"></script>
    <script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script type="text/javascript" src="/Scripts/map-pizzeria.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 127px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    <form id="form2" runat="server">
        <div class="Pedido">
            <script type="text/javascript">

                var mapaDiv = "mapArea";
                var latitud = -34.96017596001856;
                var longitud = -54.94185447692871;

                $(document).ready(function () {
                    mapStart();
                });

            </script>
            <div id="divDirecciones" class="editForm">
                <asp:GridView ID="grdDirecciones" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No hay ninguna dirección" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdDirecciones_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Nombre_referencia" HeaderText="Nombre" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:ButtonField ButtonType="Image" CommandName="Seleccionar" HeaderText="Seleccionar" ImageUrl="/Images/selectIcon.png">
                            <HeaderStyle Width="24px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#c30000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <table id="tblMap" style="top: 0;">
                    <tr>
                        <td>
                            <div id="mapArea" class="mapArea"></div>
                        </td>
                        <td style="vertical-align: top;">
                            <%=titulo %>
                            <%=btnArticulo %>
                            <asp:Button CssClass="btn btnPizza" ID="btnPizza" runat="server" OnClick="btnPizzaSelect" CausesValidation="False" BackColor="WhiteSmoke" TabIndex="10" Height="0px" Width="0px" BorderColor="WhiteSmoke" BorderStyle="None" BorderWidth="0px" /><br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
