<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="WebAppCliente.Pages.Account.EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/editarPerfil.css" />
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&amp;language=es"></script>
    <script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script type="text/javascript" src="/Scripts/map.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" runat="server">
    <form id="form1" runat="server">
        <div class="perfilNav">
            <script type="text/javascript">
                var mapaDiv = "mapArea";
                var txtDireccion = "<%=txtDireccion.ClientID%>";
                var txtLatitud = "<%=txtLatitud.ClientID%>";
                var txtLongitud = "<%=txtLongitud.ClientID%>";
                $(document).ready(function () {

                    //Centramos el mapa

                    if (typeof markerCliente === 'undefined') {
                        mapStart();
                        centrarMapa();
                    }

                    if (typeof fromBehind === 'undefined') {
                        $("#tblMap").toggle("slide");
                        $("#divDatos").slideUp("slow", function () {
                            $("#divDirecciones").slideUp("slow", function () {
                                $("#divPerfil").slideDown();
                            });
                        });
                    }
                    $("#btnNavPerfil").click(function () {
                        $("#divDatos").slideUp("slow", function () {
                            $("#divDirecciones").slideUp("slow", function () {
                                $("#divPerfil").slideDown();
                            });
                        });
                    });

                    $("#btnNavDatos").click(function () {
                        $("#divPerfil").slideUp("slow", function () {
                            $("#divDirecciones").slideUp("slow", function () {
                                $("#divDatos").slideDown();
                            });
                        });
                    });

                    $("#btnNavDirecciones").click(function () {
                        $("#divPerfil").slideUp("slow", function () {
                            $("#divDatos").slideUp("slow", function () {
                                $("#divDirecciones").slideDown();
                            });
                        });
                    });

                    $("#btnNew").click(function () {
                        $("#tblMap").toggle("slide");
                    });

                    $("#<%=imgPerfil.ClientID%>").click(function () {
                        document.getElementById('<%=imgUpload.ClientID %>').click();
                    });

                    $("#<%=imgUpload.ClientID%>").change(function () {
                        var input = document.getElementById('<%=imgUpload.ClientID %>');
                        if (input.files && input.files[0]) {
                            var reader = new FileReader();

                            reader.onload = function (e) {
                                $('#<%=imgPerfil.ClientID%>')
                                    .attr('src', e.target.result)
                                    .width(150)
                                    .height(150);
                            };

                            reader.readAsDataURL(input.files[0]);
                            }
                    });

                    $("#<%=txtEmail.ClientID%>").change(function () {
                        var regex = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
                        var emailField = document.getElementById("<%=txtEmail.ClientID%>");
                        var valid = regex.test(emailField.value);
                        $('#errorMessage').fadeIn("slow");
                    });

                });

            </script>
            <!--<div id="btnNavPerfil" class="btnNavPerfil">Datos Personales</div>
            <div id="btnNavDatos" class="btnNavPerfil">Perfil</div>
            <div id="btnNavDirecciones" class="btnNavPerfil">Direcciones</div>-->
            <input type="button" id="btnNavPerfil" class="btnNavPerfil" value="Perfil">
            <input type="button" id="btnNavDatos" class="btnNavPerfil" value="Datos Personales">
            <input type="button" id="btnNavDirecciones" class="btnNavPerfil" value="Direcciones">
        </div>
        <div id="errorMessage" class="errorMessage">
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        </div>
        <div id="divPerfil" class="editForm">
            <table style="margin-left: auto; margin-right: auto; width: 500px;">
                <tr>
                    <td>
                        <asp:Image ID="imgPerfil" CssClass="imgPerfil" runat="server" ImageUrl="~/UploadedImages/default-avatar.png" Height="150px" Width="150px" /><asp:FileUpload ID="imgUpload" runat="server" CssClass="fileEdit" />
                        <p class="imgText" id="imgText">Cambiar Imagen</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="lblEdit">Email</span><br />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputEdit"></asp:TextBox>
                    </td>
                    <td>


                        <br />


                    </td>
                </tr>

                <tr>
                    <td>
                        <span class="lblEdit">Contraseña</span><br />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="inputEdit" TextMode="Password"></asp:TextBox>
                    </td>


                    <td>&nbsp;</td>

                </tr>

                <tr>
                    <td>
                        <span class="lblEdit">Confirme Contraseña</span><br />
                        <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="inputEdit" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <div id="divDatos" class="editForm">
            <table style="margin-left: auto; margin-right: auto; width: 500px;">
                <tr>
                    <td>
                        <span class="lblEdit">Nombre</span><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="inputEdit"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <span class="lblEdit">Apellido</span><br />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="inputEdit"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span class="lblEdit">Teléfono</span><br />
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="inputEdit"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>


                <tr>
                    <td>
                        <span class="lblEdit">Celular</span><br />
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="inputEdit"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>

                </tr>

            </table>
        </div>
        <div id="divDirecciones" class="editForm">
            <asp:GridView ID="grdDirecciones" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No hay ninguna dirección" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdDirecciones_RowCommand" OnRowDeleting="grdDirecciones_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Nombre_referencia" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar" ImageUrl="/Images/editIcon.png" CausesValidation="false">
                        <HeaderStyle Width="24px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:TemplateField ShowHeader="True" HeaderText="Borrar" HeaderStyle-Width="24px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="/Images/deleteIcon.png" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar la ubicación seleccionada?');" AlternateText="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField DeleteImageUrl="/Images/deleteIcon.png" />
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#c30000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:Label CssClass="alertEdit" ID="lblAlertDirecciones" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <div class="btn btnNew" id="btnNew" title="Agregar nueva direccion"><span>Nueva Dirección</span></div>
            <table id="tblMap" style="top: 0;">
                <tr>
                    <td>
                        <div id="mapArea" class="mapArea"></div>
                    </td>
                    <td style="vertical-align: top;">
                        <span class="titleDireccion">Agregar nueva dirección:</span><br />
                        <br />
                        <span class="lblEdit">Nombre</span><br />
                        <asp:TextBox ID="txtNombreDireccion" CssClass="inputEdit" runat="server" ToolTip="Ingrese un nombre para identificar esta dirección"></asp:TextBox><br />
                        <span class="lblEdit">Dirección</span><br />
                        <asp:TextBox ID="txtDireccion" CssClass="inputEdit" runat="server" TextMode="MultiLine" Height="80px" ToolTip="Complete la dirección con los datos que considere necesarios"></asp:TextBox><br />
                        <asp:TextBox ID="txtLatitud" runat="server" CssClass="inputHidden"></asp:TextBox><asp:TextBox ID="txtLongitud" runat="server" CssClass="inputHidden"></asp:TextBox>
                        <asp:HiddenField ID="hiddEdit" runat="server" Value="Add" />
                        <br />
                        <asp:Button CssClass="btn btnSave" ID="btnSave" runat="server" Text="Guardar" ToolTip="Guardar Direccion" OnClick="btnSave_Click" CausesValidation="False" /><br />
                        <asp:Label CssClass="errorEdit" ID="lblDireccionStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="btnDiv">
            <table style="width: 200px; margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        <asp:Button CssClass="btnEdit" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ID="btnGuardar" />
                        <input type="reset" value="Cancelar" class="btnEdit" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
