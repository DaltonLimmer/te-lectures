var root = 'https://jsonplaceholder.typicode.com';

$(function () { 

    loadUsers();
    $("#save").on("click", onSaveButtonClick);

});


function onRowClick(event) {

    var id = $(this).children().eq(0).text();
    var name = $(this).children().eq(1).text();
    var username = $(this).children().eq(2).text();
    var email = $(this).children().eq(3).text();

    
    $("#id").val(id);
    $("#name").val(name);
    $("#username").val(username);
    $("#email").val(email);

    $("#myModal").modal();


}


function onSaveButtonClick(event) {

    var id = $("#id").val();
    var name = $("#name").val();
    var username = $("#username").val();
    var email = $("#email").val();

    $.ajax({
        url: root + "/users/" + id,
        method: "PUT",
        data: {
            name: name,
            username: username,
            email: email
        }
    }).done(function(data) {
        $("#myModal").modal('hide');
        loadUsers();
    })


}




function loadUsers() {



    $.ajax({
        url: root + "/users",
        method: "GET"
    }).done(function(data) {

        //Clear the User Table
        $("#userData").empty();

        //Add results to the table

        for(var i = 0; i < data.length; i++) {

            var tr = $("<tr>");
            tr.append($(`<td>${data[i].id}</td>`))
            tr.append($(`<td>${data[i].name}</td>`))
            tr.append($(`<td>${data[i].username}</td>`))
            tr.append($(`<td>${data[i].email}</td>`))

            tr.on("click", onRowClick);


            $("#userData").append(tr);
        }


    })

}




