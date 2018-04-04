
var person = {

    firstName: "George",
    lastName: "Jones",
    formatName: function() {
        return this.lastName + ", " + this.firstName;
    }

}

var showAlert = function(message) {
    var now = new Date();
    alert(now.toString() + ": " + message);
}

function doSomethingHere(messagePart1, messagePart2, callback) {

    var message = messagePart1 + ", " + messagePart2;

    if(callback != null) {
        callback(message);
    }

}








