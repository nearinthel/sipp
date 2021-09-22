var marker;
var markersArray = [];
var cliente;

function initialize() {
    var popup;

	var mapOptions = {
		center: new google.maps.LatLng(-34.466412581936105, -54.85935363769533),
		zoom: 8,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	};
	map = new google.maps.Map(document.getElementById("GMap"), mapOptions);



	/*-----------------------Agregar todos los marcadores de la base de datos-------------------*/
	for (i = 0; i < markers.length; i++) {
		data = markers[i]
		myLatlng = new google.maps.LatLng(data.lat, data.lng);

		addMarker(myLatlng, data.title, map);

		google.maps.event.addListener(marker, "click", function (e) {
		    if (!popup) {

		        popup = new google.maps.InfoWindow();
		    }
		    map.setCenter(this.getPosition());
		    var note = this.title;
		    popup.setContent(note);
		    popup.open(map, this);

		    
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
			localidad: data.localidad
			//dragable:true


		});
		markersArray.push(marker);
	}



}



google.maps.event.addDomListener(window, 'load', initialize);