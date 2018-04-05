
//Reference Document: https://jqueryvalidation.org/validate/

$(document).ready(function () {

    // var myObj = {
    //     firstProperty: "Value of First Property",
    //     secondProperty: "Value of Second Property",
    //     aMethod: function() {
    //         alert("This is called by aMethod");
    //     }
    // }

    // for(var key in myObj) {
    //     console.log("Key/Value: ", key, myObj[key]);
    // }

    // $("#applicationForm").submit(function(event){
    //     //Check each field for required
    //     //Check for formatting
    //     //If invalid, then prevent form submission
    // })

    // $("#emailAddr").on("blur", function(event) {
    //     //get the value
    //     var value = $(this).val();

    //     if(value.length < 10) {
    //         //Show error
    //     }

    // })

    $("input[name='fName'").on("blur", function() {
        if($(this).val() == "") {
            //Create a new element
            //insert it after the Name field
            //set class of new element to "error"
            //Don't let the for submit
        }
    })

    // Validate takes an object, not a function
    // Objects in javascript use { .. } notation and are the same as key / value pairs
    $("#applicationForm").validate({
        debug: true,
        rules: {
            fName: {
                required: true
            },
            lName: {
                required: true,
                minlength: 2,
                lettersonly: true
            },
            emailAddr: {
                email: true,
                required: {
                    depends: function(element) {
                        return $("#chkEmail").is(":checked");
                    }
                },
                techElevatorEmail: true
            },
            password: {
                required: true,
                minlength: 8,
                strongPassword: true
            },
            verifyPassword: {
                equalTo: "#password"
            },
            favoriteCompanies: {
                minlength: 2
            }
        },
        messages: {
            fName: "First Name is required.",
            lName: {
                required: "Last Name is required.",
                minlength: "Last Name must be at least 2 characters long."
            }
        },
        errorClass: "error",
        validClass: "valid"
    })





});

//Create a custom validation rule that only permits email addresses that end with @techelevator.com
//https://jqueryvalidation.org/jQuery.validator.addMethod

$.validator.addMethod("techElevatorEmail", function(value, element, params) {

    return value.toLowerCase().endsWith("@techelevator.com");

    // var atLoc = value.indexOf("@");
    // var stringEnd = value.substr(atLoc + 1);
    // if(stringEnd.toLowerCase() == "techelevator.com") {
    //     return true;
    // }
}, "Please enter a techelevator.com email address.");

$.validator.addMethod("strongPassword", function(value, element, params) {
    return value.match(/[A-Z]/) && value.match(/[a-z]/) && value.match(/\d/);
}, "Please enter a strong password (one capital, one lower case, and one number");


