<%@ Page Language="C#" Title="" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="WebAppCliente.Pages.Account.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/Registrarse.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    <div class="RegForm">
        <form id="FrmReg" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h1>Registrarse</h1>
            <br />
            <table style="margin-left:auto; margin-right:auto; width:500px;">
                <tr>
                    <td>
                        <span class="lblReg">Nombre</span><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="inputReg"></asp:TextBox>
                    </td>           
                    <td>
                        <asp:RequiredFieldValidator ID="txtNombreValidator" runat="server" ErrorMessage="Debe ingresar el nombre." ControlToValidate="txtNombre" CssClass="errorReg"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    
                    <td>
                        <span class="lblReg">Apellido</span>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="inputReg"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtApellidoValidator" runat="server" ErrorMessage="Debe ingresar el Apellido." ControlToValidate="txtApellido" CssClass="errorReg"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <span class="lblReg">Teléfono</span>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="inputReg"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator
                            ID="RegExpTelefonoValidator"
                            runat="server"
                            ValidationExpression="^[0-9]{2,3}-? ?[0-9]{6,7}$"
                            ControlToValidate="txtTelefono"
                            ErrorMessage="Telefono invalido!"
                            CssClass="errorReg"></asp:RegularExpressionValidator>
                    </td>
                </tr>


                <tr>
                    <td>
                        <span class="lblReg">Celular</span>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="inputReg"></asp:TextBox>
                    </td>
                    <td>

                        <asp:RegularExpressionValidator
                            ID="RegExpCelularValidator"
                            runat="server"
                            ValidationExpression="^[0-9]{2,3}-? ?[0-9]{6,7}$"
                            ControlToValidate="txtCelular"
                            ErrorMessage="Celular invalido!"
                            CssClass="errorReg"></asp:RegularExpressionValidator>


                    </td>

                </tr>

                <tr>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                    <td>
                        <span class="lblReg">Email</span>
                        <asp:TextBox ID="txtEmail" AutoPostBack="true" runat="server" CssClass="inputReg" ></asp:TextBox>
                    </td>
                    <td>
                  
                          <asp:Label  ID="Label1" runat="server" Text="" CssClass="errorReg" ></asp:Label>
                         <asp:Label  ID="lblComprobarEmail" runat="server" Text="" CssClass="errorReg" ></asp:Label>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                       

                        <asp:RequiredFieldValidator ID="txtEmailRequiredValidator" runat="server" ErrorMessage="Debe ingresar el Email." ControlToValidate="txtEmail" CssClass="errorReg"></asp:RequiredFieldValidator>
                        

                        <asp:RegularExpressionValidator
                            ID="RegExpEmailValidator"
                            runat="server"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Email invalido!"
                            CssClass="errorReg"></asp:RegularExpressionValidator>


                    </td>
                </tr>

                <tr>
                    <td>
                        <span class="lblReg">Contraseña</span>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="inputReg" TextMode="Password"></asp:TextBox>
                    </td>


                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar la Contraseña." ControlToValidate="txtPassword" CssClass="errorReg"></asp:RequiredFieldValidator>


                        <asp:RegularExpressionValidator
                            ID="RegrExpPasswordValidator"
                            runat="server"
                            ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,})$*"
                            ControlToValidate="txtPassword"
                            ErrorMessage="Debe tener al menos 8 caracteres, 1 minuscula, 1 mayuscula y sin espacios. "
                            CssClass="errorReg"></asp:RegularExpressionValidator>


                    </td>

                </tr>

                <tr>
                    <td>
                        <span class="lblReg">Confirme Contraseña</span>
                        <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="inputReg" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtConfirmarPasswordValidator" runat="server" ErrorMessage="Debe Confirmar la Contraseña." ControlToValidate="txtConfirmarPassword" CssClass="errorReg"></asp:RequiredFieldValidator>


                        <asp:CompareValidator ID="txtConfirmarPasswordCompareValidator" runat="server" ErrorMessage="Las Contraseñas no coinciden." ControlToValidate="txtPassword" ControlToCompare="txtConfirmarPassword" Operator="Equal" Type="String" CssClass="errorReg"></asp:CompareValidator>


                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button CssClass="btnReg" runat="server" Text="Registrame" OnClick="btnRegistrar_Click" ID="Button1" />
                        <input type="reset" value="Cancelar" class="btnReg" />
                    </td>
                </tr>
            </table>

            <br />
        </form>
    </div>
</asp:Content>

