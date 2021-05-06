
var hearAbtUsChecked = false;
var hearAbtUsOtherChecked = false;

var yearsOfExpChecked = false;

validationSuccess = true;





function validateForm() {

    var elems = document.getElementsByTagName("Input");
    var elemsTxtarea = document.getElementsByTagName("textarea");

    for (i = 0; i < elems.length; i++) {
        var e = elems[i];
        if (e.tagName == "INPUT") { //make sure obj is of type input before we send it through the huge loop
            if (e.name == "firstName") { // checks to see if obj is firstname elem
                // \d is the symbol for all numbers 0-9 and g means to search the string globally by pairing these two you can test a string to ensure it has no numbers any where.
                //var numPatt = new RegExp = ("\\d", "g") creation of Regular Expression using the RegExp object
                var numPatt = /\d/g; /* a regular expression of a string must start and end with a foreward slash (/) though some characters like the character for global searching (g) goes after the final slash as it is not a specifier of the search*/
                var result = numPatt.test(e.value); //test for pattern expression contained in numPatt
                if (result == true || e.value == "") {
                    unhideFB("fn"); //shows feedback
                    validationSuccess = false;   
                }
                else {
                    hideFB("fn");   //hides feedback
                }
                continue;
            }
            if (e.name == "lastName") {  // checks to see if obj is lastname elem
                var numPatt = /\d/g;
                var result = numPatt.test(e.value);
                if (result == true || e.value == "") {
                    unhideFB("ln");
                    validationSuccess = false;
                }
                else {
                    hideFB("ln");
                }
                continue;
            }
            if (e.name == "region") { // checks to see if obj is region elem
                var numPatt = /\d/g;
                var result = numPatt.test(e.value);
                if (result == true || e.value == "") {
                    unhideFB("rg");
                    validationSuccess = false;
                }
                else {
                    hideFB("rg");
                }
                continue;
            }
            if (e.name == "discord") {  // checks to see if obj is discord elem
                if (e.value.includes("#") == false || e.value == "") {  //dc usernames must include #s in them
                    unhideFB("dc");
                    validationSuccess = false;
                }
                else {
                    hideFB("dc");
                }
                continue;
            }
            if (e.name == "hearAbtUs") {    // checks to see if obj is hearabtus elem
                if (e.checked == true) {
                    if (e.value == "other") {   // if ther other hearAbtUs box is set we need to validate that before we can validate the section
                        hearAbtUsOtherChecked = true;
                    }
                    else {
                        hideFB("ref");
                        hideFB("otherRef");    //if something aside from the other box is checked we can hide feedback for this section entirely including the other textbox's feedback
                        hearAbtUsChecked = true;
                    }
                }
                else {
                    hideFB("otherRef");  //if other box isnt checked we dont need to show otherRef textarea's feedback.

                    if (hearAbtUsChecked == false) {    //since it is a array of radio buttons we must check to see non of the others were true before unhiding feedback.
                        unhideFB("ref");
                    }
                }
                continue;
            }
            if (e.name == "yearsOfExp") {   // checks to see if obj is yearsofexp elem
                if (e.checked == true) {
                    hideFB("exp");
                    yearsOfExpChecked = true;
                }
                else {
                    if (yearsOfExpChecked == false) { //more radio buttons so we must check to be sure one hasnt been checked yet again.
                        unhideFB("exp");
                    }
                }
                continue;
            }
            if (e.name == "link1") {    // checks to see if obj is link1 elem
                if (e.value.includes("youtube.com") == true || e.value.includes("twitch.tv") == true || e.value == "") { 
                    hideFB("l1");                       //link1 link2 and link3 elems must include the youtube or twitch in them so we know theyre only sending clip.
                }
                else {
                    unhideFB("l1");
                    validationSuccess = false;
                }
                continue;
            }
            if (e.name == "link2") {    // checks to see if obj is link2 elem
                if (e.value.includes("youtube.com") == true || e.value.includes("twitch.tv") == true || e.value == "") {
                    hideFB("l2");
                }
                else {
                    unhideFB("l2");
                    validationSuccess = false;
                }
                continue;
            }
            if (e.name == "link3") {    // checks to see if obj is link3 elem
                if (e.value.includes("youtube.com") == true || e.value.includes("twitch.tv") == true || e.value == "") {
                    hideFB("l3");
                    
                }
                else {
                    unhideFB("l3");
                    validationSuccess = false;
                }
                continue;
            }
        }
        else {
            alert("Issue occured, element was not of type 'input'.");      //if something goes wrong 
            validationSuccess = false;
        }
    }
    for (i = 0; i < elemsTxtarea.length; i++) {
        var e = elemsTxtarea[i];
        if (e.tagName == "TEXTAREA") {
            if (e.name == "whyJoin") {
                if (e.value == "" || e.value == "type here...") {
                    unhideFB("why");
                    validationSuccess = false;
                }
                else {
                    hideFB("why")
                }
                continue;
            }
            if (e.id == "other") {
                if (hearAbtUsChecked == true)
                    hearAbtUsOtherChecked = false;
                if (hearAbtUsOtherChecked == true) {
                    if (e.value == "" || e.value == "type where here...") { //if the box is empty or has default text it hasnt been filled
                        unhideFB("otherRef");                        // so we show feedback but only for the otherRef box not the rest of the section
                        hideFB("ref")                                    
                        hearAbtUsChecked = false;       //if otherRef textarea is empty validation criteria for hearAbtUs section is not met.
                    }
                    else {
                        hideFB("otherRef");             //if it is filled in creteria is met we can hide feedback that was previously shown for this section and set hearAbtUsChecked to true.
                        hearAbtUsChecked = true;
                        hearAbtUsOtherChecked = false; //resets hearAbtUs other box (not needed) not sure if this is good practice or not.
                    }
                }
                continue;
            }
        }
        else {
            alert("Issue occured, element was not of type 'input'.");
            validationSuccess = false;
        }
    }

    if (hearAbtUsChecked == false || yearsOfExpChecked == false) {
        validationSuccess = false;
    }
    if (validationSuccess == true) {
        hideFB("reqFields");
        return true
    }
    else {
        unhideFB("reqFields");
        return false;
    }
}



function unhideFB(id) {
    var feedbackItems = document.getElementsByClassName("feedback");
    for (a = 0; a < feedbackItems.length; a++) {
        if (feedbackItems[a].id == id) {
            feedbackItems[a].style.display = "block";
            return;
        }
    }
}



function hideFB(id) {
    var feedbackItems = document.getElementsByClassName("feedback");
    for (a = 0; a < feedbackItems.length; a++) {
        if (feedbackItems[a].id == id) {
            feedbackItems[a].style.display = "none";
            return;
        }
    }
}