
$(function() {


    $("#searchBtn").on("click", function(event) {

        console.log("Button clicked!");
        //Collect information from the form

        var amiiboName = $("#name").val();
        var characterName = $("#character").val();
        var amiiboType = $("#type").val();
        var series = $("#series").val();


        //Use AJAX to get recipies

        $.ajax({
            url: getApiLink(amiiboType, amiiboName, series, characterName),
            method: "GET",
            dataType: "json"
        }).done(function(result) {
            console.log("Result: ", result);

            $("#results").empty();

            var list = result.amiibo;

            //Display the returned recipies
            for(var i = 0; i < list.length; i++) {

                var r = list[i];
                // var tr = $("<tr>");

                // var td1 = $(`<td><img src="${r.image}"></td>`);
                // var td2 = $(`<td>${r.character}</td>`);
                // var td3 = $(`<td>${r.amiiboSeries}</td>`);

                // tr.append([td1, td2, td3]);

                var html = $(`<tr><td><img class="img-thumbnail" src="${r.image}"></td><td>${r.character}</td><td>${r.amiiboSeries}</td>`);

                $("#results").append(html);

            }
            
            $("#resultsTable").show();




        }).fail(function(xhr, status, error) {
            
            var html = $(`<tr><td colspan="3" style="text-align: center; font-weight: bold;">No results found</td></tr>`);
            $("#results").append(html);
            $("#resultsTable").show();


        })




    })






})



function getApiLink(type, name, series, characterName) {

    var baseUrl = "http://www.amiiboapi.com/api/amiibo?";

    var url = baseUrl;

    if(type) {
        url += "type=" + type;
    }

    if(name) {
        if(url.length != baseUrl.length) {
            url += "&";
        }
        url += "name=" + name;
    }

    if(series) {
        if(url.length != baseUrl.length) {
            url += "&";
        }
        url += "amiiboSeries=" + series;
    }

    if(characterName) {
        if(url.length != baseUrl.length) {
            url += "&";
        }
        url += "character=" + characterName;
    }

    return url;

}




