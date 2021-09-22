<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppEmpp.Registro.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
 
    <div id="centro">
        <div>
        
            <table style="width:400px">
                <tr>
                    <td>
                        <asp:Label runat="server">Nombre de la empresa</asp:Label>
                    </td>
                    <td>
                      <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>  
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ForeColor="Red" ControlToValidate="txtEmpresa" ErrorMessage="Ingrese su Razon Social"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CustomValidator ID="cvEmpresa" runat="server" ErrorMessage="La Empresa no existe" ForeColor="Red" OnServerValidate="cvEmpresa_ServerValidate" ControlToValidate="txtEmpresa"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server">Contraseña</asp:Label>
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
   
</asp:Content>
