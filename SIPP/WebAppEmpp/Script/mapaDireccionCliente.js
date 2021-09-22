var map;
var marker;
var latlng;



function initialize() {
    var latitud = document.getElementById('contenidoPrincipal_contenidoPrincipal_latbox').value;
    var longitud = document.getElementById('contenidoPrincipal_contenidoPrincipal_longbox').value;
    var note = document.getElementById('contenidoPrincipal_contenidoPrincipal_lblNombre').value;
    latlng = new google.maps.LatLng(latitud, longitud)
    var mapOptions = {
        zoom: 8,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById('GMap'), mapOptions);

    marker = new google.maps.Marker({
        map: map,
        position: latlng,
        draggable: false,


    });

    //var popup = new google.maps.InfoWindow();
    //popup.setContent(note);
    //popup.open(map, marker);
}
google.maps.event.addDomListener(window, 'load', initialize);