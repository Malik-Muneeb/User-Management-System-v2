
window.onload = function () {
    var btn = document.getElementById('btnCreate');
    btn.onclick = validations;

}

function validations() {

    if ($("txtName").val() == "") {
        alert("First Enter Name!");
        return false;
    }
    if ($("txtLogin").val() == "") {
        alert("First Enter Login!");
        return false;
    }
    if ($("txtPassword").val() == "" || $("txtPassword").length < 8) {
        alert("First Enter Password and password greater than 8!");
        return false;
    }
    if ($("txtEmail").val() == "") {
        alert("First Enter Email!");
        return false;
    }
    if ($("txtAddress").val() == "") {
        alert("First Enter Address!");
        return false;
    }
    if ($("txtAge").val() == 0) {
        alert("First Enter Age!");
        return false;
    }
    if ($("txtCnic").val() == "") {
        alert("First Enter CNIC");
        return false;
    }
    if ($("userImage").val == "") {
        alert("First Select Image!");
        return false;
    }
}