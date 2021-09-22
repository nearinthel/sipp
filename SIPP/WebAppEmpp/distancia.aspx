<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distancia.aspx.cs" Inherits="WebAppEmpp.distancia" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script src="https://maps.googleapis.com/maps/api/js?v=3&libraries=geometry&sensor=false"></script>

    <script>
        var markers=[<asp:Repeater ID="rptMarkers" runat="server">
                        <ItemTemplate>
                            {
                                "title": '<%# Eval("Nombre") %>',
                                "lat": '<%# Eval("Latitud") %>',
                                "lng": '<%# Eval("Longitud") %>'
                            }
                        </ItemTemplate>
                        <SeparatorTemplate>
                            ,
                        </SeparatorTemplate>
                    </asp:Repeater>
        ];
    </script>
    <script src="Script/mapa2.js"></script>
    <script src="Script/calculardistancia.js"></script>

        <script>
            window.onload = function(){
                document.getElementById('distancia2').value=" "+distancia(35.5656, 54.5151, 34.999, 54.1212);
            };
        </script>

    
    <title></title>
</head>
<body>

    
        <div id="dvMap" style="width: 580px; height: 381px"></div>
    <div>
        
            
<form>
    <input type="text" id="distancia2" />
</form>
        
    </div>   
    



</body>
</html>