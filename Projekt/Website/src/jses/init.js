var upperBarDiv = document.getElementById("upper-menu-navigation-bar-anc");
var sideBarDiv = document.getElementById("side-menu-navigation-bar-anc");
var loginFormDiv = document.getElementById("login-modal-anc");
var registerFormDiv = document.getElementById("register-modal-anc");
var logoutFormDiv = document.getElementById("logout-modal-anc");

function load(element, content){fetch(content).then(response => response.text()).then(data => {element.innerHTML= data;}).catch(error => {console.error('Error fetching HTML:', error);});};
/*
switch (localStorage.getItem('state')){
    case 'main':
        loadMainPage();
        break;
    case 'new-post':
        loadNewPostPage();
        break;
    case 'user':
        loadProfilePage(JSON.parse(localStorage.getItem('me')));
        break;
    default:
        console.log("No state found");
        break;
}
*/
load(sideBarDiv, 'componnents/menus/side-menu-navigation-bar.html');
var source = !localStorage.getItem('user') ? 
'componnents/menus/upper-menu-navigation-bar-logged-in.html' :
    'componnents/menus/upper-menu-navigation-bar-logged-out.html';
load(upperBarDiv, source);

load(loginFormDiv, 'componnents/auths/login-modal.html');
loginFormDiv.style.display = "none";
load(registerFormDiv, 'componnents/auths/register-modal.html');
registerFormDiv.style.display = "none";
load(logoutFormDiv, 'componnents/auths/logout-modal.html');
logoutFormDiv.style.display = "none";
