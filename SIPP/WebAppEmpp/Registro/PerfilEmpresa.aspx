<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="PerfilEmpresa.aspx.cs" Inherits="WebAppEmpp.Registro.PerfilEmpresa" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div id="centro">
    <div id="centro">

           <asp:Image ID="imgLogo" runat="server" Height="179px" Width="198px" />
           
<TABLE BORDER=1>

<TR>
<TD style="WIDTH:100px">
    <p>Rut:</p>
</TD>

<TD style="WIDTH:100px">
    
    <asp:label ID="lblRut" runat="server"></asp:label>

</TD>
    

</TR>
<TR>
    <TD style="WIDTH:100px">
   <p>Razon Social:</p> 
</TD>

<TD style="WIDTH:100px">

    <asp:Label ID="lblRSocial" runat="server"></asp:Label>
</TD>
 
</tr>





<tr>
        <TD style="WIDTH:100px">
 <p>Telefono:</p>
</TD>

<TD style="WIDTH:100px">
    
    <asp:Label ID="lblTelefono" runat="server"></asp:Label>
</TD>
   





</tr>    
</table>
           <asp:LinkButton ID="lnkModificacionEmpresa" runat="server" PostBackUrl="~/Registro/EditarEmpresa.aspx">Modificar Empresa</asp:LinkButton>
       </div>
    </div>
<%--</form>--%>

</asp:Content>
