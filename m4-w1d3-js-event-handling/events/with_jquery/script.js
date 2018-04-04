/* ##################################################
Attaching Event Handlers via jQuery
################################################## */


//Blur
$("#fname").on("blur", function() {
    var name = $(this).val();
    name = name.toUpperCase();
    $(this).val(name);
});

//Change
$("#activity").on("change", function() {
    $(this).val($(this).val().toUpperCase());
})



//Change
$("#programmingLanguage").on("change", function() {
    if($(this).val() != "Select one") {
        message = "You selected " + $(this).val();
    } else {
        message = "Please select a language.";
    }

    $("#languageMessage").text(message);
})


//keyup
$("#birthDate").on("keyup", function(event) {
    $("#lastkey").text("The last key was " + event.key);
    $("#birthdateMessage").text = $(this).val();
})


//MouseOver & MouseOut
var mouseOverBox = document.getElementById("mouseover");
mouseOverBox.addEventListener("mouseover", function() {
    this.style.background = "#860036";
})
mouseOverBox.addEventListener("mouseout", function() {
    this.style.background = null;
})


//Context Menu
$("#rightclick").on("contextmenu", function(event) {
    event.preventDefault();
    console.log("color: ", $(this).css("background-color"));
    if($(this).css("background-color") != "rgb(238, 130, 238)") {
        $(this).css("background-color", "violet");
    } else {
        $(this).css("background", "");
    }
    return false;
})