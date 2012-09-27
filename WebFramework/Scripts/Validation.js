/*Login page---------------------------------------------------------------------------------------------*/

function validateUser() {

    var x = document.forms["login"]["Username"].value;
    var y = document.forms["login"]["Password"].value;
    var count = 0;

    if (x == null || x == "") {

        $("#username").css('border-color', '#FF0000');
        count++;        
    }

    if (y == null || y == "") {

        $("#password").css('border-color', '#FF0000');
        count++;
    }
    if (count > 0) {
        return false;
    }
}

function noBorderUsername() {
    $("#username").css('border-color', 'transparent');
}
function noBorderPassword() {
    $("#password").css('border-color', 'transparent');
}


/*Add content page-----------------------------------------------------------------------------------------*/

function validateContent() {

    var x = document.forms["addContent"]["Title"].value;
    var y = document.forms["addContent"]["Group"].value;
    var z = document.forms["addContent"]["Content"].value;    

    count = 0;

    if (x == null || x == "") {

        $("#title").css('border-color', '#FF0000');
        count++;
    }

    if (y == null || y == "") {

        $("#group").css('border-color', '#FF0000');
        count++;
    }

    if (z == null || z == "") {

        $("#content").css('border-color', '#FF0000');
        count++;
    }

    if (count > 0) {
        return false;
    }
}

function noBorderTitle() {
    $("#title").css('border-color', 'transparent');
}
function noBorderGroup() {
    $("#group").css('border-color', 'transparent');
}
function noBorderContent() {
    $("#content").css('border-color', 'transparent');
}
