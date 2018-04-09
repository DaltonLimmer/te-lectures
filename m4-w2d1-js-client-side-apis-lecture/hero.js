// http://api.icndb.com/jokes/random?exclude=explicit
// http://api.icndb.com/jokes/random?exclude=explicit&limitTo=nerdy



$(document).ready(function () {

    $("#randomButton").on("click", function (event) {

        requestFact(false);

    });

    $("#nerdButton").on("click", function (event) {

        requestFact(true);

    });

});

function requestFact(isNerdy) {

    var theUrl = "http://api.icndb.com/jokes/random?exclude=explicit";
    if(isNerdy) {
        theUrl += "&limitTo=nerdy";
    }

    $.ajax({
        url: theUrl,
        type: "GET",
        dataType: "json"
    })
    .done(function( data ) {
        $("#message").text(data.value.joke);
    });


}


