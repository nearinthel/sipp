var map;
var data;
var myLatlng;
var marker;
var markersArray = [];
var cliente;

function initialize() {

    var mapOptions = {
        center: new google.maps.LatLng(-34.466412581936105, -54.85935363769533),
        zoom: 8,
        //mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("GMap"), mapOptions);



    /*-----------------------Agregar todos los marcadores de la base de datos-------------------*/
    for (i = 0; i < markers.length; i++) {
        data = markers[i]
        myLatlng = new google.maps.LatLng(data.lat, data.lng);
     
        addMarker(myLatlng, data.title, map);
        //var marker = new google.maps.marker({
        //    position: myLatlng,
        //    map: map,
        //    title:data.title
        //});

        //addMarker(myLatlng, data.title, map);
        //(function (marker, data) {
            google.maps.event.addListener(marker, 'click', function (e) {

                
                map.setCenter(this.getPosition());

                document.getElementById('contenidoPrincipal_contenidoPrincipal_latbox').value = this.getPosition().lat();
                document.getElementById('contenidoPrincipal_contenidoPrincipal_longbox').value = this.getPosition().lng();
                document.getElementById('contenidoPrincipal_contenidoPrincipal_lblNombre').value = this.title;
                
                document.getElementById('contenidoPrincipal_contenidoPrincipal_lblTelefono').value = this.telefono;
                document.getElementById('contenidoPrincipal_contenidoPrincipal_lblArea').value = this.area ;
            
            });

    };//fin del for
    function addMarker(location, titulo, mapa) {
        marker = new google.maps.Marker({
            position: location,
            map: mapa,
            title: titulo,
            telefono: data.telefono,
            area: data.area,
            direccion: data.direccion,
            localidad:data.localidad
            //dragable:true


        });
        markersArray.push(marker);
    }



}//Fin function()



google.maps.event.addDomListener(window, 'load', initialize);