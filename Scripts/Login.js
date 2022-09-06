
var MainForm = document.getElementById("MainForm")

function LoginForm() {

    if (MainForm.UserName.value.length == 0) {
        alert("Username cannot be Empty")
        return false;
    }

    if (MainForm.Password.value.length == 0) {
        alert("Password cannot be Empty")
        return false;
    }
    MainForm.Action.value = "Login";
    MainForm.Action.name = "LoginAction";
    MainForm.submit();
}