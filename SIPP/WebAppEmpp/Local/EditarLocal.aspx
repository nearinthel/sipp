<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="EditarLocal.aspx.cs" Inherits="WebAppEmpp.Local.EditarLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div id="centro">
       <TABLE BORDER=1>

        <tr>
            <td>

            </td>
            <td style="width:100px">
              Datos Actuales
            </td>

            <td style="width:100px">
                Datos Nuevos

            </td>

        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label3" Text="Nombre del Local" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="lblNombre" runat="server" ReadOnly="true" ></asp:TextBox>
            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

            </td>

        </tr>
        <tr>
             <td style="width:100px">
                <asp:Label ID="Label4" Text="Telefono" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="lblTelefono" runat="server" ReadOnly="true"></asp:TextBox>
            </td>

            <td style="width:100px">
                
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>

            
        <tr>
             <td style="width:100px">
                <asp:Label ID="Label1" Text="Area en km" runat="server"></asp:Label>

            </td>
            <td>
                <asp:TextBox ReadOnly="true" ID="lblArea" runat="server"></asp:TextBox>
            </td>

            <td style="width:100px">
                <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>

            </td>
        </tr>
       <tr>
            <td>
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click"/>

            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </td>
        </tr>
           <tr>
               <td>

                   <asp:LinkButton ID="lnkPass" runat="server" OnClick="lnkPass_Click">Cambiar la contraseña del Local</asp:LinkButton>

               </td>
               <td>
                   <asp:LinkButton ID="lnkCambiarDireccion" runat="server" OnClick="lnkCambiarDireccion_Click" >Cambiar direccion del Local seleccionado</asp:LinkButton>
               </td>
           </tr> 
</table>
       
    </div>
       <%-- </form>--%>
</asp:Content>
