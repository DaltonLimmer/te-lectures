var GOOGLE_API_KEY = "AIzaSyB3HWxzaly0wlMdC6glyJ_lFLSTKedpvc8";

var TE_LOC = { lat: 39.1519511, lng: -84.4673821 };

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
}