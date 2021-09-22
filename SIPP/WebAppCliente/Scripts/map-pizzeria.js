var map;
var geocoder;
var initialLocation;
var mapLocation;
var makerCliente;

var markersPizzerias = new Array();

function mapStart() {
    if (typeof map === 'undefined') {
        var options = {
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true
        };
        map = new google.maps.Map(document.getElementById(mapaDiv), options);
        if (typeof mapLocation === 'undefined') {
            centrarMapa(true);
        }
        else {
            centrarMapa(false);
        }
    }
};

function centrarMapa(geoLocate) {
    if (geoLocate) {
        defaultLocation = new google.maps.LatLng(-34.96854630010426, -54.95133876800537);
        if (navigator.geolocation) {
            browserSupportFlag = true;
            navigator.geolocation.getCurrentPosition(function (position) {
                mapLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            }, function () {
                handleNoGeolocation(browserSupportFlag);
            });
        } else {
            browserSupportFlag = false;
            handleNoGeolocation(browserSupportFlag);
        }

        function handleNoGeolocation(errorFlag) {
            if (errorFlag == true) {
                //alert("Falló el servicio de geolocalización");
                mapLocation = defaultLocation;
            } else {
                //alert("Tu navegador no soporta geolocalización");
                mapLocation = defaultLocation;
            }
        }
    }
    map.setCenter(mapLocation);
    window.setTimeout(function () {
        map.panTo(mapLocation);
    }, 1000);
}

function placeMarkerPizzeriaFromDB(location, nombrePizzeria) {
    markersPizzerias.push(new google.maps.Marker({
        position: location
            , map: map
            , title: nombrePizzeria
            , icon: new google.maps.MarkerImage('/Images/mapMarkerPizzeria.png', undefined, undefined, undefined, new google.maps.Size(30, 30))
            , cursor: 'default'
            , draggable: false
    }));
    var index = markersPizzerias.length - 1;
    google.maps.event.addDomListener(markersPizzerias[index], 'mouseover', function () {
        markersPizzerias[index].setIcon(new google.maps.MarkerImage('/Images/mapMarkerPizzeria.png', undefined, undefined, undefined, new google.maps.Size(114, 114)));
    });

    google.maps.event.addDomListener(markersPizzerias[index], 'mouseout', function () {
        markersPizzerias[index].setIcon(new google.maps.MarkerImage('/Images/mapMarkerPizzeria.png', undefined, undefined, undefined, new google.maps.Size(30, 30)));
    });
  
    google.maps.event.addDomListener(markersPizzerias[index], 'click', function () {
        __doPostBack('PizzaClick', nombrePizzeria);
        
    });
}

function placeMarkerClientFromDB(location) {
    mapLocation = location;
    mapStart();

    makerCliente = new google.maps.Marker({
        position: location
        , map: map
        , title: 'Aquí estas tu'
        , icon: new google.maps.MarkerImage('/Images/mapMarkerCliente.png', undefined, undefined, undefined, new google.maps.Size(30, 30))
        , cursor: 'default'
        , draggable: false
    })

    google.maps.event.addListener(makerCliente, 'dragend', function () {
        var lat = makerCliente.getPosition().lat();
        var lng = makerCliente.getPosition().lng();
        document.getElementById(txtLatitud).value = lat;
        document.getElementById(txtLongitud).value = lng;

        codeAddressInverse(new google.maps.LatLng(lat, lng));
        document.getElementById(txtLatitud).value = lat;
        document.getElementById(txtLongitud).value = lng;
    });

    google.maps.event.addDomListener(makerCliente, 'mouseover', function () {
        makerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarkerCliente.png', undefined, undefined, undefined, new google.maps.Size(114, 114)));
    });

    google.maps.event.addDomListener(makerCliente, 'mouseout', function () {
        makerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarkerCliente.png', undefined, undefined, undefined, new google.maps.Size(30, 30)));
    });

}
