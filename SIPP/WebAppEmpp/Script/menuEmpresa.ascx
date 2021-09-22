<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuEmpresa.ascx.cs" Inherits="WebAppEmpp.Script.menuEmpresa" %>


<ul>
    <li class="nivel1"><a href="#">Empresa</a>
        <ul>
            <li><asp:HyperLink ID="lnkPerfil" runat="server" NavigateUrl="~/Registro/PerfilEmpresa.aspx">Perfil Empresa</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkEditarPerfil" runat="server" NavigateUrl="~/Registro/EditarEmpresa.aspx">Editar Perfil de Empresa</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkPass" runat="server" NavigateUrl="~/Registro/CambiarPass.aspx">Cambiar Password</asp:HyperLink></li>
            <li><asp:HyperLink ID="lnkBorrar" runat="server" NavigateUrl="~/Registro/BorrarEmpresa.aspx">Borrar esta Empresa</asp:HyperLink></li>
        
        </ul>
    </li>
</ul>

<ul>
    <li class="nivel1"><a href="#">Locales</a>
        <ul>
            <li><asp:HyperLink ID="lnkAltaLocal" runat="server" NavigateUrl="~/Local/AltaLocal.aspx">Agregar locales</asp:HyperLink></li>
            <li class="nivel1"><asp:HyperLink ID="lnkVerLocalesEmpresa" runat="server" NavigateUrl="~/Local/verLocalesEmpresa.aspx">Ver  locales por grilla</asp:HyperLink></li>
            <li class="nivel1"><asp:HyperLink ID="lnkLocalesMapa" runat="server" NavigateUrl="~/Local/ModificarLocal.aspx">Ver locales por mapa</asp:HyperLink></li>
        </ul>
    </li>

</ul>

<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkArticulos" runat="server" NavigateUrl="~/Articulos/ABMarticulo.aspx">ABM articulos</asp:HyperLink></li>
</ul>

<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkEspecificacion" runat="server" NavigateUrl="~/formGustos.aspx">ABM gustos</asp:HyperLink></li>
</ul>

<ul>
    <li class="nivel1"><asp:HyperLink ID="lnkSalir" runat="server" NavigateUrl="~/Registro/Logout.aspx">Salir</asp:HyperLink></li>
</ul>