//import $ from jQuery


$(function() {

    //1. When a box is clicked, toggle the grow class
    // $(".box").on("click", function() {
    //     $(this).toggleClass("grow");
    // })

    //3. Wire up 1,2,3,4,5,6 to toggle .grow on the divs
    // reference: http://keycode.info/ for keyCodes

    $("body").on("keypress", function(event) {

        if(event.keyCode >= 49 && event.keyCode <= 54) {
            var theSelector = "#box" + (event.keyCode - 48);
            $(theSelector).toggleClass("grow");
        }
        
        // switch(event.keyCode) {

        //     case 49:
        //     $("#box1").toggleClass("grow");
        //     break;
        //     case 50:
        //     $("#box2").toggleClass("grow");
        //     break;
        //     case 51:
        //     $("#box3").toggleClass("grow");
        //     break;
        //     case 52:
        //     $("#box4").toggleClass("grow");
        //     break;
        //     case 53:
        //     $("#box5").toggleClass("grow");
        //     break;
        //     case 54:
        //     $("#box6").toggleClass("grow");
        //     break;
        // }
    })

    //4. Make the textboxes and checkboxes more interactive
    // - Allow the user to press enter in a Task and dynamically add a new checkbox below
    // - Change textbox to a label
    // - Make the label clickable to go back to a textbox
    // - If the checkbox is checked, add strikethrough to the label
    $("#box6 input[type='text']").on("keypress", handleEnter);
    $("#box6 input[type='checkbox']").on("change", handleCheck);


})

function handleCheck(e) {
    
    var id = $(this).attr("data-id");
    var checked = $(this).prop("checked");

    if(checked) {
        $(`label[data-id='${id}'`).addClass("complete");
    } else {
        $(`label[data-id='${id}'`).removeClass("complete");
    }

 
}

function handleEnter(e) {

    if(e.keyCode != 13) {       //13 = Enter Key
        return;
    }


    var id = $(this).attr("data-id");
    var currentValue = $(this).val();

    $(this).hide();
    var label = $(`label[data-id='${id}']`);
    label.text(currentValue);

    label.on("click", function() {
        var id = $(this).attr("data-id");
        $(this).hide();
        $(`input[data-id='${id}']`).show();

    })

    label.show();

    addNewItem();

}
















//1. Write a function that finds box1
//      and adds the class "grow"
function growBox() {
    //var box1 = $("#box1");
    //box1.addClass("grow");
    $("#box1").addClass("grow");

}

//2. Write a function that finds and
//      shrinks the blue box
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
    boxes = $("div").detach();

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
    $("li").text("<b>List Item</b>");
    //$("li").css("font-weight", "bold");
}

//8. Add the .shadow class to the last box
function addShadowToLastBox1() {
    $(".box").last().addClass("shadow");
}

function addShadowToLAstBox2(number) {
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


//11. Change the value of the textbox to "Hello World"
function setTextboxValue() {
    $("input[type='text']").val("Hello World!");
}

//12. Now go back and allow a message to be passed in

//13. Append a new list item
function addNewListItem() {
    //Find out how many li we currently have
    var count = $("#box3 ul").children().length;

    //Create a new list item
    var li = $("<li>").text(`Item ${count + 1}`);

    //Find the list (<ul>) that we will add the list item to
    var ul = $("#box3 ul");

    //Append our new list item
    ul.append(li);
}



//14. Add a new checkbox and textbox
//      - make sure to change the id
function addNewItem() {
    //Find the item we want to copy
    var htmlToCopy = $("#templateItem")[0].innerHTML;

    var newDiv = $(htmlToCopy);

    //Modify the data-id of the child elements
    newDiv.children().attr("data-id", $("#box6").children().length);

    
    //Get the container we want to add to
    var box6 = $("#box6");



    //Append the copied div
    box6.append(newDiv);
    newDiv.find("input[type='checkbox']").on("change", handleCheck);
    newDiv.find("input[type='text']").on("keypress", handleEnter).focus();

}



//15. Now make it possible to switch a textbox to a label

//16. Make all the boxes fade out
function disappear() {
    $(".box").fadeOut(10000);
}
