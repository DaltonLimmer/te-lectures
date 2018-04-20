var GOOGLE_API_KEY = "AIzaSyB3HWxzaly0wlMdC6glyJ_lFLSTKedpvc8";

var TE_LOC = { lat: 39.1519511, lng: -84.4673821 };

$(function () {
    initMap();



})

function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: TE_LOC,
        zoom: 18,
        mapTypeId: 'hybrid'
    })
    var marker = new google.maps.Marker({
        position: TE_LOC,
        map: map
    });

    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng, map);
    });

}

function placeMarker(location, map) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    console.log("Added marker here: ");
    console.log("  Lat: ", location.lat());
    console.log("  Lng: ", location.lng());

}
