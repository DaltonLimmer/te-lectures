const GOOGLE_API_KEY = "AIzaSyB3HWxzaly0wlMdC6glyJ_lFLSTKedpvc8";
const WEBAPI_BASE_URL = "http://localhost:61393/api/";

var TE_LOC = { lat: 39.1519511, lng: -84.4673821 };
var AllMarkers = [];
var MainMap;

$(function () {
    initMap();

    $("#clearMarkers").click(function(){

        $.ajax({
            url: WEBAPI_BASE_URL + "Marker/deleteAll",
            method: "POST"
        }).done(function () {
            loadAllMarkers();
        }).fail(function (xhr, error) {
            console.log("Error saving data!", error);
        })
    })


})

function initMap() {
    MainMap = new google.maps.Map(document.getElementById('map'), {
        center: TE_LOC,
        zoom: 18,
        mapTypeId: 'hybrid'
    })

    google.maps.event.addListener(MainMap, 'click', function (event) {
        placeMarker(event.latLng, MainMap, true);
    });

    loadAllMarkers();

}

function loadAllMarkers() {

    console.log("Clearing all markers...")

    clearAllMarkers();

    console.log("Adding TE marker...")
    placeMarker(TE_LOC);

    $.ajax({
        url: WEBAPI_BASE_URL + "Marker",
        method: "GET",
        dataType: "json"
    }).done(function (data) {
        //console.log("Data:", data);

        for (var i = 0; i < data.length; i++) {
            if (data[i]) {
                var loc = new google.maps.LatLng(data[i].Latitude, data[i].Longitude);
                placeMarker(loc);
            }
        }


    }).fail(function (xhr, error) {
        console.log("Error retrieving data!", error);
    })

}

function clearAllMarkers() {

    for(var i = 0; i < AllMarkers.length; i++) {
        console.log("Clearing marker...");
        AllMarkers[i].setMap(null);
        //AllMarkers[i] = null;
    }

    AllMarkers = [];

}


function placeMarker(location, saveToServer) {
    AllMarkers.push(new google.maps.Marker({
        position: location,
        map: MainMap
    }));

    // console.log("Added marker here: ");
    // console.log("  Lat: ", typeof location.lat == 'function' ? location.lat() : location.lat);
    // console.log("  Lng: ", typeof location.lng == 'function' ? location.lng() : location.lng);

    if (saveToServer) {
        //Post to WebAPI

        var latLngData = {
            latitude: location.lat(),
            longitude: location.lng()
        }
        $.ajax({
            url: WEBAPI_BASE_URL + "Marker/add",
            method: "POST",
            data: latLngData
        }).done(function (data) {
            console.log("Data:", data);
        }).fail(function (xhr, error) {
            console.log("Error saving data!", error);
        })
    }

}
