/* ##################################################
Attaching Event Handlers via Javascript (The Old Way)
################################################## */


//Blur
var fNameField = document.getElementById("fname");
fNameField.addEventListener("blur", function() {
    this.value = this.value.toUpperCase();
});

//Change
var activityField = document.getElementById("activity");
activityField.addEventListener("change", function() {
    this.value = this.value.toUpperCase();
});

//Change
var programmingLanguageField = document.getElementById("programmingLanguage");
programmingLanguageField.addEventListener("change", function() {
    if(this.value != "Select one") {
        message = "You selected " + this.value;
    } else {
        message = "Please select a language.";
    }

    document.getElementById("languageMessage").innerHTML = message;
})

//Focus
var usernameField = document.getElementById("username");

usernameField.addEventListener("focus", function(){
    this.style.background = "blue";
    this.style.color = "white";
})
usernameField.addEventListener("blur", function() {
    this.style.background = null;
    this.style.color = null;
})

// var allInputs = document.getElementsByTagName("input");
// for(var i = 0; i < allInputs.length; i++) {
//     allInputs[i].addEventListener("focus", function(){
//         this.style.background = "green";
//         this.style.color = "white";
//     })
//     allInputs[i].addEventListener("blur", function() {
//         this.style.background = null;
//         this.style.color = null;
//     })
// }

//Select
var messageField = document.getElementById("message");
messageField.addEventListener("select", function() {
    document.getElementById("selectedMessage").innerHTML = "You selected inside the textbox.";
})

//keyup
var birthDateField = document.getElementById("birthDate");
birthDateField.addEventListener("keyup", function(event) {
    document.getElementById("lastkey").innerHTML = "The last key was " + event.key;
    document.getElementById("birthdateMessage").innerHTML = this.value;
});

//MouseOver & MouseOut
var mouseOverBox = document.getElementById("mouseover");
mouseOverBox.addEventListener("mouseover", function() {
    this.style.background = "#860036";
})
mouseOverBox.addEventListener("mouseout", function() {
    this.style.background = null;
})

//Click
var clickBox = document.getElementById("click");
clickBox.addEventListener("click", function() {

    var colors = ["red", "white", "blue", "orange", "purple", "#ff00ff"];

    var colorSet = false;
    for(var i = 0; i < colors.length; i++) {
        if(this.style.background == colors[i]) {
            var nextColor = i + 1;
            if(nextColor > colors.length - 1) {
                nextColor = 0;
            }
            this.style.background = colors[nextColor];
            colorSet = true;
            break;
        }
    }

    if(!colorSet) {
        this.style.background = colors[0];
    }
})

//Double Click
var dblclickBox = document.getElementById("dblclick");
dblclickBox.addEventListener("dblclick", function() {
    if(this.style.background != "green") {
        this.style.background = "green";
    } else {
        this.style.background = null;
    }
})

//Context Menu
var rightclickBox = document.getElementById("rightclick");
rightclickBox.addEventListener("contextmenu", function(event) {
    event.preventDefault();
    if(this.style.background != "violet") {
        this.style.background = "violet";
    } else {
        this.style.background = null;
    }
    return false;
})