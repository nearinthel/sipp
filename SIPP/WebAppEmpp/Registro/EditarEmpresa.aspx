<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MPRegistro.master" CodeBehind="EditarEmpresa.aspx.cs" Inherits="WebAppEmpp.Registro.EditarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div class="centro">
       <div class="centro">

           
<TABLE BORDER=1>

<TR>
    <TD style="WIDTH:100px">
   <p>Razon Social:</p> 
</TD>

<TD style="WIDTH:100px">
    <asp:TextBox ID="txtRSocial" runat="server"></asp:TextBox>

</TD>
 
</tr>

<TR>
    <TD style="WIDTH:100px">
   <p>Logo:</p> 
</TD>

<TD style="WIDTH:100px">
    
    
    <asp:FileUpload ID="fuLogo" runat="server" />
</TD>

   

</TR>


<tr>
        <TD style="WIDTH:100px">
 <p>Telefono:</p>
</TD>

<TD style="WIDTH:100px">
    
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
</TD>
   

</tr> 

<tr>
       <TD style="WIDTH:100px">
<p>Cambiar Password:</p>
</TD>

<TD style="WIDTH:100px">
 
    <asp:LinkButton ID="lnkPass" runat="server" PostBackUrl="~/Registro/CambiarPass.aspx">ir a cambiar contraseña</asp:LinkButton>
</TD>
   

</tr>

<tr>

<TD style="WIDTH:100px">
<asp:button id="btnConfirmar" runat="server"  text="Confirmar" OnClick="btnConfirmar_Click" />
</TD>

<TD style="WIDTH:100px">
<asp:button ID="btnCancelar" runat="server" Text="Volver" />
</TD>

</tr>    
</table>
       </div>
    </div>

<%--</form>--%>

</asp:Content>