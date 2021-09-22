<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="BorrarEmpresa.aspx.cs" Inherits="WebAppEmpp.Registro.BorrarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server" >
    <%--<form id="form1" runat="server">--%>
    <div class="centro">
       <div class="centro">
           <asp:Image ID="imgLogo" runat="server" Height="63px" Width="72px" /><br />
           
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
    <tr>
        <td style="width:100px">
            <asp:Button ID="btnConfirmar" runat="server" Text="Borrar Empresa" OnClick="btnConfirmar_Click" />
        </td>
        <td style="width:100px">
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

        </td>
        
    </tr>
</table>
           <br />
           Eliminar esta Empresa es irreversible
           
       </div>
    </div>
<%--</form>--%>
</asp:Content>
