<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMarticulo.aspx.cs" Inherits="WebAppEmpp.Articulos.alta1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 263px;
        }
        .auto-style2 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table style="width:100%;">
            <tr>
                <td class="auto-style2">Seleccione articulo</td>
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
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
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
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
    </form>
</body>
</html>
