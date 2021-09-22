<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EstadoPedidos.aspx.cs" Inherits="WebAppCliente.Pages.Pedido.PantallaEstados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <link rel="stylesheet" type="text/css" href="/Styles/EstadoPedidos.css" />
        <link href="/Styles/bootstrap.css" rel="stylesheet"/>
        <link href="/Styles/bootstrap-responsive.css" rel="stylesheet"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.js"></script>

     <style type="text/css">
         .auto-style1 {
             margin-left: 2px;
         }
     </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
<link href="/Styles/bootstrap.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="/Styles/bootstrap-theme.css" />
    <form id="form1" runat="server" class="auto-style1">
    <div class="capaEstados">
            
        
     
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
         <ContentTemplate>
             
            
        <div class="panel panel-default">
  <!-- Default panel contents -->
            
  <div class="panel-heading"><h3> Mis Pedidos</h3></div>
  <div class="panel-body">
     
        <asp:GridView ID="tablaEstados" runat="server" CellPadding="10" GridLines="None" OnSelectedIndexChanged="tablaEstados_SelectedIndexChanged" OnRowDataBound="tablaEstados_RowDataBound" AutoGenerateColumns="False" CssClass="table table-hover" EmptyDataText="No has hecho ningun pedido." Height="24px" ShowHeaderWhenEmpty="True" Width="100%" >
            <AlternatingRowStyle CssClass="table table-hover" />
            <Columns>
                
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Nombre_Local" HeaderText="Local" />
                <asp:BoundField DataField="Costo" HeaderText="Costo" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="" HeaderText="" />
            </Columns>
            <EmptyDataRowStyle BackColor="White" />
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="White" Font-Bold="True" />
            <PagerStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
            
        </asp:GridView>
             <br>
            <asp:Button ID="Button1" runat="server" Text="Actualizar" CssClass="btn btn-danger" OnClick="Actualizar_Click" style="margin-left: 21px; margin-bottom:20px;"  Width="199px" />
             <div></div>
      </div>
</div>
            
             </ContentTemplate>
             </asp:UpdatePanel>
    </div>
    </form>

</asp:Content>