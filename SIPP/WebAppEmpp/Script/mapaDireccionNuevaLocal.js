var map;
var marker;
var latlng;



function initialize() {
    var latitud = document.getElementById('contenidoPrincipal_contenidoPrincipal_latbox').value;
    var longitud = document.getElementById('contenidoPrincipal_contenidoPrincipal_longbox').value;
    latlng = new google.maps.LatLng(latitud, longitud)
    var mapOptions = {
        zoom: 9,
        center: latlng
    };

    map = new google.maps.Map(document.getElementById('GMap'),
        mapOptions);

    marker = new google.maps.Marker({
        map: map,
        position: latlng,
        draggable: true,
        

    });


    google.maps.event.addListener(map, 'click', function (e) {
        marker.setPosition(e.latLng);
        


        document.getElementById('contenidoPrincipal_contenidoPrincipal_latboxNuevo').value = marker.getPosition().lat();
        document.getElementById('contenidoPrincipal_contenidoPrincipal_longboxNuevo').value = marker.getPosition().lng();
        codeAddressInverse(new google.maps.LatLng(marker.getPosition().lat(), marker.getPosition().lng()));

    });

    google.maps.event.addListener(marker, 'dragend', function () {
        var lat = marker.getPosition().lat();
        var lng = marker.getPosition().lng();
        document.getElementById('contenidoPrincipal_contenidoPrincipal_latboxNuevo').value = lat;
        document.getElementById('contenidoPrincipal_contenidoPrincipal_longboxNuevo').value = lng;
        codeAddressInverse(new google.maps.LatLng(lat, lng));


    });

}
function addMarker(location, mapa) {
    marker = new google.maps.Marker({
        position: location,
        map: mapa,
       
    });
    markersArray.push(marker);
}

google.maps.event.addDomListener(window, 'load', initialize);