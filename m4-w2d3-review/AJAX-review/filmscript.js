
$(function() {


    $("#searchBtn").on("click", function(event) {

        console.log("Button clicked!");
        //Collect information from the form

        var genre = $("#genre").val();
        var minLength = $("#minLength").val();
        var maxLength = $("#maxLength").val();

        $("#resultsTable").show();
        $("#results").empty();
        $("#results").append($(`<tr><td colspan="3">Loading...</td></tr>`));

        //Use AJAX to get recipies

        $.ajax({
            url: getApiLink(genre, minLength, maxLength),
            method: "GET",
            dataType: "json"
        }).done(function(result) {
            console.log("Result: ", result);
            $("#results").empty();

            var list = result;

            //Display the returned recipies
            for(var i = 0; i < list.length; i++) {

                var r = list[i];

                var html = $(`<tr><td>${r.Title}</td><td>${r.Length}</td><td>${r.Rating}</td>`);

                $("#results").append(html);

            }
            
            $("#resultsTable").show();




        }).fail(function(xhr, status, error) {
            $("#results").empty();
            var html = $(`<tr><td colspan="3" style="text-align: center; font-weight: bold;">No results found</td></tr>`);
            $("#results").append(html);
            $("#resultsTable").show();


        })




    })






})



function getApiLink(genre, min, max) {

    var baseUrl = "http://localhost:51706/api/Review?";

    var url = baseUrl;

    if(genre) {
        url += "genre=" + genre;
    }

    if(min) {
        if(url.length != baseUrl.length) {
            url += "&";
        }
        url += "minLength=" + min;
    }

    if(max) {
        if(url.length != baseUrl.length) {
            url += "&";
        }
        url += "maxLength=" + max;
    }

    return url;

}




