var map;
var markerCliente;
var geocoder;
var initialLocation;
var mapLocation;

function mapStart() {
    if (typeof mapLocation === 'undefined') {
        mapLocation = new google.maps.LatLng(-34.96854630010426, -54.95133876800537);
    }
    var options = {
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true,
        center: mapLocation
    };

    map = new google.maps.Map(document.getElementById(mapaDiv), options);
    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });

};

function centrarMapa() {
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
            // alert("Falló el servicio de geolocalización");
            mapLocation = defaultLocation;
        } else {
            // alert("Tu navegador no soporta geolocalización");
            mapLocation = defaultLocation;
        }
    }
    map.setCenter(mapLocation);
    window.setTimeout(function () {
        map.panTo(mapLocation);
    }, 1000);
}

function placeMarkerFromDB(location) {
    mapLocation = location;
    mapStart();
    if (!markerCliente) {
        markerCliente = new google.maps.Marker({
            position: location
            , map: map
            , title: 'Aquí estás tu'
            , icon: new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(30, 30))
            , cursor: 'default'
            , draggable: true
        })

        google.maps.event.addListener(markerCliente, 'dragend', function () {
            var lat = markerCliente.getPosition().lat();
            var lng = markerCliente.getPosition().lng();
            document.getElementById(txtLatitud).value = lat;
            document.getElementById(txtLongitud).value = lng;

            codeAddressInverse(new google.maps.LatLng(lat, lng));
        });

        google.maps.event.addDomListener(markerCliente, 'mouseover', function () {
            markerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(114, 114)));
        });

        google.maps.event.addDomListener(markerCliente, 'mouseout', function () {
            markerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(30, 30)));
        });

    }
    else {
        markerCliente.setPosition(location);
    }
}

function placeMarker(location) {
    if (!markerCliente) {
        markerCliente = new google.maps.Marker({
            position: location
            , map: map
            , title: 'Aquí estás tu'
            , icon: new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(30, 30))
            , cursor: 'default'
            , draggable: true
        })
        google.maps.event.addListener(markerCliente, 'dragend', function () {
            var lat = markerCliente.getPosition().lat();
            var lng = markerCliente.getPosition().lng();
            document.getElementById(txtLatitud).value = lat;
            document.getElementById(txtLongitud).value = lng;

            codeAddressInverse(new google.maps.LatLng(lat, lng));
            document.getElementById(txtLatitud).value = lat;
            document.getElementById(txtLongitud).value = lng;
        });

        google.maps.event.addDomListener(markerCliente, 'mouseover', function () {
            markerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(114, 114)));
        });

        google.maps.event.addDomListener(markerCliente, 'mouseout', function () {
            markerCliente.setIcon(new google.maps.MarkerImage('/Images/mapMarker.png', undefined, undefined, undefined, new google.maps.Size(30, 30)));
        });

    }
    else {
        markerCliente.setPosition(location);
    }
    var lat = markerCliente.getPosition().lat();
    var lng = markerCliente.getPosition().lng();
    document.getElementById(txtLatitud).value = lat;
    document.getElementById(txtLongitud).value = lng;

    codeAddressInverse(new google.maps.LatLng(lat, lng));
}

function codeAddress() {
    geocoder = new google.maps.Geocoder();
    var address = document.getElementById(txtDireccion).value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            placeMarker(results[0].geometry.location);
        } /*else {
            alert('Geocode was not successful for the following reason: ' + status);
        }*/
    });
}

function codeAddressInverse(latlng) {
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var address = results[0].formatted_address;
        } else {
            var address = "Direccion no encontrada";
            //alert('Geocode was not successful for the following reason: ' + status);
        }

        document.getElementById(txtDireccion).value = address;
    });
}
