<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="perfilEmpresa.ascx.cs" Inherits="WebAppEmpp.Script.perfilEmpresa" %>

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