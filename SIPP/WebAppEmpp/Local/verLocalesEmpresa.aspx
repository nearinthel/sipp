<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="verLocalesEmpresa.aspx.cs" Inherits="WebAppEmpp.Local.verLocalesEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%@ Register TagPrefix="uc" TagName="repetidor" Src="~/Script/repetidor.ascx"%>
        <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
        <script src="../Script/geocoder.js" type="text/javascript"></script>
    <uc:repetidor id="repetidor" runat="server"></uc:repetidor>

    <script src="../Script/mapaPerfilesLocales.js"></script>
    <%--<form id="form1" runat="server">--%>
    <div id="GMap" style="width: 580px; height: 381px"> </div>

    <asp:GridView ID="grdPizzerias" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
        AllowPaging="true" PageSize="4" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" 
        EmptyDataText="No hay locales todavia" OnPageIndexChanging="grdPizzerias_PageIndexChanging" 
        OnRowEditing="grdPizzerias_RowEditing" OnRowDeleting="grdPizzerias_RowDeleting" 
        OnRowCancelingEdit="grdPizzerias_RowCancelingEdit" OnRowUpdated="grdPizzerias_RowUpdated" 
        OnRowUpdating="grdPizzerias_RowUpdating" EnableViewState="false">

        <AlternatingRowStyle BackColor="White" />
        <Columns>

                <%--<asp:BoundField DataField="id" HeaderText="Id" />--%>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="true" />
                <%--<asp:BoundField DataField="Descripcion" HeaderText="Costo" />--%>
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" ReadOnly="true" />
            <asp:BoundField DataField="localidad" HeaderText="Localidad" Readonly="true"/>
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="area" HeaderText="Area" />
             <asp:HyperLinkField DataNavigateUrlFormatString="~/Local/CambiarDireccionLocal.aspx?Local={0}" DataNavigateUrlFields="nombre" Text="Cambiar Direccion" />
            <asp:HyperLinkField DataNavigateUrlFormatString="~/Local/agregarPassLocal.aspx?Local={0}" DataNavigateUrlFields="nombre" Text="Modificar Pass" />
         <%--   <asp:HyperLinkField DataNavigateUrlFormatString="~/Local/EditarLocal.aspx?Local={0}" DataNavigateUrlFields="nombre" Text="Editar Local" />

            <asp:HyperLinkField DataNavigateUrlFormatString="~/Local/EliminarLocal.aspx?Local={0}" DataNavigateUrlFields="nombre" Text="Eliminar Local" />--%>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
           
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
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Local/AltaLocal.aspx">Agregar mas locales</asp:HyperLink>
<%--    <asp:HyperLink ID="lnkPassLocal" runat="server" NavigateUrl="~/Local/agregarPassLocal.aspx">Agregar Contraseña a un Local para ver pedidos</asp:HyperLink>--%>

       <%--</form> --%>
</asp:Content>
