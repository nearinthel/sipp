<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="repetidor.ascx.cs" Inherits="WebAppEmpp.Script.repetidor" %>
        <script>
            var markers=[<asp:Repeater ID="rptMarkers" runat="server">
                            <ItemTemplate>
                                {
                                    "title": '<%# Eval("Nombre") %>',
                                    "lat": '<%# Eval("Latitud") %>',
                                    "lng": '<%# Eval("Longitud") %>',
                                    "telefono":'<%#Eval("Telefono")%>',
                                    "direccion":'<%#Eval("Direccion")%>',
                                    "area":'<%#Eval("Area")%>',
                                    "localidad":'<%#Eval("Localidad")%>'
                                }
                        </ItemTemplate>
                        <SeparatorTemplate>
                            ,
                        </SeparatorTemplate>
                    </asp:Repeater>
            ];
    </script>