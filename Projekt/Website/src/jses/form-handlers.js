var loginFormDiv = document.getElementById("login-modal-anc");
var registerFormDiv = document.getElementById("register-modal-anc");
var logoutFormDiv = document.getElementById("logout-modal-anc");

loginFormDiv.style.display = "none";
registerFormDiv.style.display = "none";

function loginShow(show){
    if(show){
        loginFormDiv.style.display = "block";
        registerFormDiv.style.display = "none";
        logoutFormDiv.style.display = "none";
    }
    else {
        loginFormDiv.style.display = "none";
    }
}

function registerShow(show){
    if (show){
    registerFormDiv.style.display = "block";
    loginFormDiv.style.display = "none";
    logoutFormDiv.style.display = "none";
    }
    else {
    registerFormDiv.style.display = "none";
    }
}

function logoutShow(show){
    if (show){
    logoutFormDiv.style.display = "block";
    loginFormDiv.style.display = "none";
    registerFormDiv.style.display = "none";
    } 
    else {
    logoutFormDiv.style.display = "none";
    }
}

var loginFromSubmit = document.getElementById("login-form");
var registerFromSubmit = document.getElementById("register-form");

loginFromSubmit.addEventListener("submit", function(event){
    event.preventDefault();
    var username = document.getElementById("login-username").value;
    var password = document.getElementById("login-password").value;
    login(username, password);
});

registerFromSubmit.addEventListener("submit", function(event){
    event.preventDefault();
    var username = document.getElementById("register-username").value;
    var email = document.getElementById("register-email").value;
    var password = document.getElementById("register-password").value;
    register(username, email, password);
});
