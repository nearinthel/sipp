<%@ Page Title="" Language="C#" MasterPageFile="~/MPRegistro.master" AutoEventWireup="true" CodeBehind="EliminarLocal.aspx.cs" Inherits="WebAppEmpp.Local.EliminarLocal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div id="centro">
        <TABLE BORDER=1>
            <TR>
                <TD style="WIDTH:100px">
                    <p>Nombre:</p>
                </TD>
                <TD style="WIDTH:100px">
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>

                </TD>
           </TR>
           <TR>
                <TD style="WIDTH:100px">
                    <p>Telefono:</p> 
                </TD>

                <TD style="WIDTH:100px">

                    <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                </TD>
 
            </tr>

            <tr>
                <TD style="WIDTH:100px">
                    <p>Area:</p>
                </TD>

                <TD style="WIDTH:100px">
                    <asp:Label ID="lblArea" runat="server"></asp:Label>
                </TD>

            </tr>  
           <tr>
               <td style="width:100px">
                   Direccion:
               </td>

               <TD style="WIDTH:100px">
    
                    <asp:Label ID="lblDireccion" runat="server"></asp:Label>
               </TD>

           </tr>
           <tr>
               <TD style="WIDTH:100px">
                   <p>Localidad:</p>
                </TD>

                <TD style="WIDTH:100px">
    
                    <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                </TD>
           </tr>
       </TABLE>
       <br />
       <br />
     <table border="1">
         <tr>   
             <td>
                <asp:Label ID="Label1" runat="server" Text="¿Desea eliminar este local?"></asp:Label><br />
                <asp:CheckBox ID="chkAceptar" runat="server" Text="Estoy seguro" ForeColor="Red" />
                <br />
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
              </td>
             </tr>
       </table>
       <br />
       <br />
           
    
    <asp:HyperLink ID="lnkEditar" runat="server" ForeColor="Blue">Ir a Editar Local</asp:HyperLink>
  </div>
       <%-- </form>--%>
</asp:Content>
