//

//Get your own API key here: http://www.omdbapi.com/apikey.aspx

const OMDB_API_KEY = "59d10480";

$(document).ready(function () {

    $("#btnSearch").on("click", function (event) {

        var movie = $("#movie").val();


        var service = new MovieService();
        service.search(movie, refreshMovieTable);
        


    });

});

function refreshMovieTable(searchResults) {

    console.log("Search Results: ", searchResults);

    for(var i = 0; i < searchResults.Search.length; i++) {

        var result = searchResults.Search[i];

        var tr = $("<tr>");
        var posterCell = $("<td>").addClass("col-sm-2");

        if(result.Poster.toLowerCase() != "n/a") {
            var posterImage = $("<img>").prop("src", result.Poster).addClass("img-responsive").addClass("img-thumbnail");
            posterCell.append(posterImage);
        } else {
            posterCell.text("No image");
        }

        tr.append(posterCell);

        var imdbCell = $("<td>").text(result.imdbID);
        var nameCell = $("<td>").text(result.Title);
        var yearCell = $("<td>").text(result.Year);

        tr.append(imdbCell);
        tr.append(nameCell);
        tr.append(yearCell);
        

        $("#movieData").append(tr);
    }
}

function MovieService() {

    const url = `http://www.omdbapi.com/?apikey=${OMDB_API_KEY}&`;

    this.search = function(movieTitle, successCallback) {
        $.ajax({
            url: url + "s=" + movieTitle,
            method: "GET",
            dataType: "json"
        }).done(function(data) {
            successCallback(data);
        }).fail(function(xhr, status, error) {
                console.error("Error occurred while trying to get movie list: ", error);
            }
        )
    }


}

