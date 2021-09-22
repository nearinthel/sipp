function distancia(lat1, lon1, lat2, lon2) {
    var R = 6371; // Radio de la tierra
    var dLat = (lat2 - lat1) * Math.PI / 180;  // Delta Latitud * Pi/180
    var dLon = (lon2 - lon1) * Math.PI / 180;
    var a =
       0.5 - Math.cos(dLat) / 2 +
       Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
       (1 - Math.cos(dLon)) / 2;//formula magica

    return Math.round(R * 2 * Math.asin(Math.sqrt(a))); //retornando sin decimales (string)


}

//Hacer esto en donde queramos meter el valor de la distancia para cargarlo en un txtbox
//<script>
//window.onload = function(){
//    document.getElementById('distancia2').value=" "+distance(lat1, lon1, lat2, lon2);
//};
//</script>
