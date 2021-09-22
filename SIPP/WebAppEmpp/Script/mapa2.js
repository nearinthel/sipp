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
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("dvMap"),mapOptions);

    cliente = new google.maps.Marker({
        position: map.getCenter(),
        draggable: true,
    });

/*-----------------------Agregar todos los marcadores de la base de datos-------------------*/
    for (i = 0; i < markers.length; i++) {
                data = markers[i]
                myLatlng = new google.maps.LatLng(data.lat, data.lng);
                addMarker(myLatlng, data.title, map);
    };//fin del for
/*-----------------------------------------------------------------------------------------*/

/*------------------------Evento Click mostrar marcadores cercanos -------------------------*/
    google.maps.event.addListener(map, 'click', function (e) {
        cliente.setPosition(e.latLng);
        cliente.setMap(map);
        ocultarMarkers();
        mostrarMarkerscercanos();
    });//fin del evento
/*-----------------------------------------------------------------------------------------*/

}//Fin function()

//Agregar marcador
function addMarker(location, titulo, mapa) {
    marker = new google.maps.Marker({
        position: location,
        map: mapa,
        title: titulo
    });
    markersArray.push(marker);
}

//Ocultar todos los marcadores (menos cliente)
function ocultarMarkers() {
    if (markersArray) {
        for (i in markersArray) {
            markersArray[i].setMap(null);
        }
    }
}

//Mostrar los marcadores
function mostrarMarkers() {
    if (markersArray) {
        for (i in markersArray) {
            markersArray[i].setMap(map);
        }
    }
}

//Mostrar los marcadores cercanos (distancia en KILOMETROS)
function mostrarMarkerscercanos() {
    var kilometros = 3;
    if (markersArray) {

        for (i in markersArray) {
            if (distancia(cliente.getPosition().lat(), cliente.getPosition().lng(), markersArray[i].getPosition().lat(), markersArray[i].getPosition().lng()) <= kilometros) {
            markersArray[i].setMap(map);
            }
        }
    }
}


google.maps.event.addDomListener(window, 'load', initialize);






