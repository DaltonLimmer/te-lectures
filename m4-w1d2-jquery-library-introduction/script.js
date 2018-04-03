//import $ from 'jquery';

//1. Write a function that finds element with ID = box1 
//      and adds the class "grow"
function growBox1() {
    $("#box1").addClass("grow");
}

//2. Write a function that finds all blue boxes and
//      shrinks them
function shrinkBlueBox() {
    $(".blue").addClass("shrink");
}

//3. Remove all of the elements inside of a div on the page
function removeAllStuffs() {
    $("div").empty();
}

//4. Detach all of the divs on the page
var boxes;
function detachDivs() {
    boxes = $(".content>div").detach();
}

//5. Reattach the divs on the page
function reattachDivs() {
    $("section").append(boxes);
}

//6. Change the text for all of the <p> tags inside boxes
//      to say a message
function changeText(message) {
    $(".box p").text(message);
}

//7. Change the li to have <b>List Item</b> as their text
function makeBold() {
    //$("li").html("<b>List Item</b>");
    // $("li").text("List Item")
    $("li").css("font-weight", "bold");
}

//8. Add the .shadow class to the last box
function addShadowToLastBox1() {
    $(".box").last().addClass("shadow");
}

function addShadowToLastBox2(number) {
    $(`.box:nth-last-of-type(${number})`).addClass("shadow");
}

//9. Toggle the .shadow class on any box passed in
function toggleShadow(selector) {
    $(selector).toggleClass("shadow");
}

//10. Make any input textbox have the .yellow class
//      to give it a yellow background
function makeYellowTextboxes() {
    $("input[type='text']").addClass("yellow");
}

//11. Change the value of the textboxes to "Hello World"
function setTextboxValue() {
    $("input[type='text']").val("Hello World!");
}

//12. Now go back and allow a message to be passed in
function setTextboxValueWithMessage(message) {
    $("input[type='text']").val(message);
}

//13. Append a new list item
function addNewListItem() {

    //Find out how many LIs we have
    var count = $("#box3 li").length;
    //var count = $("#box3 ul").children().length;

    //Create a new list item
    var li = $("<li>").text(`Item ${count + 1}`);

    //Find the list (<ul>) that we need to add the item to
    var ul = $("#box3 ul");

    //Append the new List Item
    ul.append(li);    
}


//14. Add a new checkbox and textbox by copying the existing ones.
//      - make sure to change the id
function addNewItem() {

    //Find the item to copy
    var htmlToCopy = $("#templateItem")[0].innerHTML;
    // console.log(htmlToCopy);

    //Create a new item
    var newDiv = $(htmlToCopy);

    //Get the container we want to add to
    var box6 = $("#box6");

    //Append the copied div
    box6.append(newDiv);

}

//15. Make all the boxes fade out
function fadeout() {
    $(".box").fadeOut(1000);
}

function disappear() {
    //$(".box").hide();
    $(".box").css("visibility", "hidden");
}

function fadein() {
    $(".box").fadeIn(1000);
}

function reappear() {
    //$(".box").show();
    $(".box").css("visibility", "visible");
}

$(function() {
    
    $("#disappearButton").click(function() {
        disappear();
    })

    $("#reappearButton").click(function() {
        reappear();
    })

    $("#disappearButton").click();

})



//console.log("Has red class?", $("#box1").hasClass("red"));



// var items = $("div");

// for(var i = 0; i < items.length; i++) {
    
//     var item = $(items[i]);
    
//     if(item.hasClass("red")) {
//         console.log("Item has Red class.");
//     } else {
//         console.log("Item does NOT have Red class.");
//     }
// }


//$(".red, .yellow, .green").removeClass(["red", "yellow", "green"]).addClass("blue");
//console.log("Text: ", );
