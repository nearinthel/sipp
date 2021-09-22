//funcion que traduce la direccion en coordenadas
function codeAddress() {

    //obtengo la direccion del formulario
    var address = document.getElementById('contenidoPrincipal_contenidoPrincipal_txtDireccion').value;
    //hago la llamada al geodecoder
    geocoder.geocode({ 'address': address }, function (results, status) {

        //si el estado de la llamado es OK
        if (status == google.maps.GeocoderStatus.OK) {
            //centro el mapa en las coordenadas obtenidas
            map.setCenter(results[0].geometry.location);
            //coloco el marcador en dichas coordenadas
            marker.setPosition(results[0].geometry.location);

        } else {
            //si no es OK devuelvo error
            alert("No podemos encontrar la direcci&oacute;n, error: " + status);
        }
    });
}
function codeAddressInverse(latlng) {
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var address = results[0].formatted_address;
            var address2 = results[1].formatted_address;
        } else {
            var address = "Direccion no encontrada";
            var address2 = "Direccion no encontrada";
            //alert('Geocode was not successful for the following reason: ' + status);
        }
        //console.log(address);
        console.log(address2);
        document.getElementById('contenidoPrincipal_contenidoPrincipal_txtDireccion').value = address;
        var str = new String();
        //str = document.getElementById('contenidoPrincipal_contenidoPrincipal_txtDireccion').valueOf;

        var localidad = "";
        var caracter;
        //console.log(address2);
        //console.log(address2.IndexOf(","));
        console.log(String.prototype.contains(address2, ","));
        for (var i = 0; i < String.prototype.contains(address2, ",") ; i++) {
            caracter = address2.charAt(i);
            //console.log(caracter);
            localidad = localidad + caracter;
        }
        console.log(localidad);
        document.getElementById('contenidoPrincipal_contenidoPrincipal_txtLocalidad').value = localidad;
        //console.log(address2);
    });
}
String.prototype.contains = function (has, it) {
    return has.indexOf(it);
}