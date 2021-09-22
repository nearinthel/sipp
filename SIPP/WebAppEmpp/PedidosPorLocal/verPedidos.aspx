<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="verPedidos.aspx.cs" Inherits="WebAppEmpp.PedidosPorLocal.verPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <asp:GridView ID="grdPedidos" runat="server" EmptyDataText="No hay pedidos en el momento" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
         AllowPaging="true" PageSize="7" OnPageIndexChanging="grdPedidos_PageIndexChanged" AllowSorting="true">
        <AlternatingRowStyle BackColor="White" />
        <Columns> 
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Costo" HeaderText="Costo" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="FechaPedido" HeaderText="Pedido año/mes/dia min:hora" />   
            <asp:HyperLinkField DataNavigateUrlFormatString="~/PedidosPorLocal/EspecificacionPedido.aspx?Pedido={0}&Usuario={1}" 
                DataNavigateUrlFields="Id,Usuario"  Text="Ver Especificaciones" ></asp:HyperLinkField>
        </Columns>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />

    </asp:GridView>
       <%-- </form>--%>
   
</asp:Content>
