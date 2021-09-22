<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebAppEmpp.Registro.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
   <%-- <form id="form1" runat="server">--%>
<div id="centro">
<div>

<TABLE BORDER=1 style="WIDTH:400px">

<TR>
<TD style="WIDTH:100px">
    <p>Rut:</p>
</TD>

<TD style="WIDTH:100px">
    
    <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>

</TD>
    <TD style="WIDTH:100px">
        <asp:RequiredFieldValidator ID="valRut" runat="server" ErrorMessage="Es obligatorio el rut" ControlToValidate="txtRut" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CustomValidator ID="cvRut" runat="server" ErrorMessage="El Rut ya esta usado" ControlToValidate="txtRut" ForeColor="Red" OnServerValidate="cvRut_ServerValidate"></asp:CustomValidator>
    </td>

</TR>
<TR>
    <TD style="WIDTH:100px">
   <p>Razon Social:</p> 
</TD>

<TD style="WIDTH:100px">
    <asp:TextBox ID="txtRSocial" runat="server"></asp:TextBox>
    
</TD>
    <TD style="WIDTH:100px">
        <asp:RequiredFieldValidator ID="valRSocial" runat="server" ErrorMessage="Es obligatorio la Razon social" ControlToValidate="txtRSocial" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>
</tr>

<tr>
        <TD style="WIDTH:100px">
 <p>Telefono:</p>
</TD>

<TD style="WIDTH:100px">
    
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
</TD>
    <TD style="WIDTH:100px">
        <asp:RequiredFieldValidator ID="valTelefono" runat="server" ErrorMessage="Es obligatorio el telefono" ControlToValidate="txtTelefono" ForeColor="Red"></asp:RequiredFieldValidator>
    </td>

</tr> 

<tr>
        <TD style="WIDTH:100px">
<p>Password:</p>
</TD>

<TD style="WIDTH:100px">
 
    <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
</TD>
    <TD style="WIDTH:100px">
        <asp:RequiredFieldValidator ID="valPass" runat="server" ErrorMessage="Es obligatoria la contraseña" ControlToValidate="txtContrasenia" ForeColor="Red"></asp:RequiredFieldValidator><br />

    </td>

</tr>
 <tr>    
  <td>
    <p>Confirme Password:</p>
</TD>


<TD style="WIDTH:100px">
 
    <asp:TextBox ID="txtContraseniaConfirmar" runat="server" TextMode="Password"></asp:TextBox>
</TD>
     <TD style="WIDTH:100px">
         
        <asp:RequiredFieldValidator ID="valPassConfirm" runat="server" ErrorMessage="Debe confirmar la contraseña" ControlToValidate="txtContraseniaConfirmar" ForeColor="Red"></asp:RequiredFieldValidator><br />
    
         <asp:CompareValidator ID="valComparePass" runat="server" ErrorMessage="las contraseñas no son iguales" ControlToValidate="txtContraseniaConfirmar" ControlToCompare="txtContrasenia" ForeColor="Red"></asp:CompareValidator>
       </td>

</tr>   
<tr>

<TD style="WIDTH:100px">
<asp:button id="btnConfirmar" runat="server"  text="Confirmar" OnClick="btnConfirmar_Click" />
</TD>

<TD style="WIDTH:100px">
<input type="reset" value="Cancelar">
</TD>

</tr>    
</table>
</div>
</div>
<%--</form>--%>
</asp:Content>
