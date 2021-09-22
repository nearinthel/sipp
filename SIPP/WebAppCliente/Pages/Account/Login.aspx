<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppCliente.Pages.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    <div class="LoginForm">
        <form id="FrmLogin" runat="server">
            <table style="width:300px; margin-left:auto; margin-right:auto;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblEstado" runat="server" CssClass="errorLogin"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="lblLogin">Usuario</span><br />
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="inputLogin"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <td>
                    <span class="lblLogin">Contraseña</span><br />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputLogin" TextMode="Password" ></asp:TextBox>
                    <br />
                    <br />
                </td>
                <tr>
                    <td>
                        <asp:Button CssClass="btnLogin" runat="server" Text="Ingresar" ID="btnLogin" OnClick="btnLogin_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="reset" value="Cancelar" class="btnLogin" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:LinkButton ID="lnkOlvide" runat="server">Olvidé mi contraseña</asp:LinkButton>
                        | 
                        <asp:LinkButton ID="lnkRegistrar" runat="server" PostBackUrl="/Pages/Account/Registrarse.aspx">Registrarme</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <br />
        </form>
    </div>
</asp:Content>
