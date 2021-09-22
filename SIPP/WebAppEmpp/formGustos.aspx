<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="formGustos.aspx.cs" Inherits="WebAppEmpp.formGustos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
   <%-- <form id="form1" runat="server">--%>
    <div id="cont1">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">Seleccione gusto:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="246px">
                    </asp:DropDownList>
                </td>
                <td>Precio</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>Local</td>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Modificar" OnClick="Button2_Click"/>
                    <asp:Button ID="Button3" runat="server" Text="Borrar" OnClick="Button3_Click" />

                </td>
            </tr>
        </table>
        

        <table style="width: 100%;">
            <tr>
                <td>Ver gustos de:</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
                <td><asp:Button ID="Button4" runat="server" Text="Ver" OnClick="Button4_Click" /></td>
                
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" GridLines="None" EmptyDataText="No ah agregado ningun gusto" >
        <Columns> 
            <%--        
            <asp:BoundField DataField="Local" HeaderText="Local" ReadOnly="true"/>
            <asp:BoundField DataField="Gusto" HeaderText="Gusto"/>
            <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="true" />
            --%>
            
        </Columns></asp:GridView>
    </div>
<%--</form>--%>
</asp:Content>
