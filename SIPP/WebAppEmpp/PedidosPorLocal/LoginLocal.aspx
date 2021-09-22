<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="LoginLocal.aspx.cs" Inherits="WebAppEmpp.Local.LoginLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
   <%-- <form id="form1" runat="server">--%>
        <div id="centro">
        <div>
        
            <table style="width:400px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server">Nombre de la empresa</asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtLocal" runat="server"></asp:TextBox>  
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocal" runat="server" ForeColor="Red" ControlToValidate="txtLocal" ErrorMessage="Ingrese el Nombre del Local"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CustomValidator ID="cvLocal" runat="server" ErrorMessage="El Local no existe" ForeColor="Red" OnServerValidate="cvLocal_ServerValidate" ControlToValidate="txtLocal"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server">Contraseña</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass" ForeColor="Red" ErrorMessage="Ingrese Contraseña"></asp:RequiredFieldValidator>
             
                    </td>
                       </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnConfirmar" Text="Confirmar" runat="server" OnClick="btnConfirmar_Click" />

                    </td>
                    <td>
                        <input id="Reset" type="reset" value="reset" />
                    </td>
                   
                        
                    
                </tr>
            </table>
        
        </div>
    </div>
        <%--</form>--%>
</asp:Content>
