<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="WebAppCliente.Pages.Pedido.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link rel="stylesheet" type="text/css" href="/Styles/EstadoPedidos.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/feedback.css" />
        <link href="/Styles/bootstrap.css" rel="stylesheet"/>
    <link href="/Styles/bootstrap-theme.css" rel="stylesheet"/>
        <link href="/Styles/bootstrap-responsive.css" rel="stylesheet"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    
    <div class="capaEstados">

        <div class="contenedor">
            <form id="FrmFeedback" runat="server">
            <img  src="/Images/pizzeria.jpg" class="media-object pull-left" style="width: 128px; height: 128px; margin-right:20px; margin-bottom:10px; margin-top:50px;"/>

            <h2 cssClass="pull-left" style="margin-top:50px;float:left; ">
                <asp:Label ID="tituloEmpresa" runat="server" Text="Pizzeria"></asp:Label>
            </h2>

            <hr style="clear:both;" />
            
       <%-- <img  src="/UploadedImages/" + <%=  %>+ "/Perfil.jpg"" class="media-object pull-left" style="width: 90px; height: 90px; margin-right:10px; margin-bottom:10px;"/>
     --%>  <asp:Image ID="imgPerfil" CssClass=" imgPerfil media-object pull-left"  runat="server" ImageUrl="~/UploadedImages/default-avatar.png" Height="90px" Width="90px" />
                        
            <div class="pull-right ">
            <asp:RadioButton ID="est5" runat="server" cssClass="pull-right" GroupName="estrellas" />
                <%--<label for="CPHcontent_est1">Hombre</label>--%>
                <asp:RadioButton ID="est4" runat="server" cssClass="pull-right" GroupName="estrellas"   />
              <%--  <label for="CPHcontent_est2">Hombre</label>--%>
                <asp:RadioButton ID="est3" runat="server" cssClass="pull-right" GroupName="estrellas" />
               <%-- <label for="CPHcontent_est3">Hombre</label>--%>
                <asp:RadioButton ID="est2" runat="server" cssClass="pull-right" GroupName="estrellas" />
               <%-- <label for="CPHcontent_est4">Hombre</label>--%>
                <asp:RadioButton ID="est1" runat="server" cssClass="pull-right" GroupName="estrellas"  />
                <%--<label for="CPHcontent_est5">Hombre</label>--%>
        </div>

            <textarea id="TextArea1"  cssClass="form-control" style="width:83%;" cols="5" rows="3" runat="server"></textarea>
            <asp:Button ID="BtnComentar" cssClass="btn btn-default pull-right" runat="server" Text="Comentar" OnClick="BtnComentar_Click" />
                </form>
             <hr style="clear:both;" />
        <div id="comentarios" class="comentarios" runat="server">

            
    
    <%--<div class="comentario">

        <img  src="/" class="media-object pull-left" style="width: 64px; height: 64px; margin-right:10px; margin-bottom:10px;"/>

        <div class="arriba">
            <div class="fecha pull-right">
            FECHA
        </div>
            <div class=" ">
            ESTRELLAS
        </div>
            
            
        </div>
        <div class=" " >
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

           
        </div>
         <div class="vUsuariodi">
            usuario
        </div>

    
    </div>--%>

    </div>
</div>
        
</div>
         
</asp:Content>

