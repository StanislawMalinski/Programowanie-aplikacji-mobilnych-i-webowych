function load(element, content){fetch(content).then(response => response.text()).then(data => {element.innerHTML= data;}).catch(error => {console.error('Error fetching HTML:', error);});};
var mainPageDiv = document.getElementById("main-page-content")

function loadMainPage(){
    load(mainPageDiv, 'pages/main-page.html');
    localStorage.setItem('state', 'main')
}

function loadProfilePage(userId){
    load(mainPageDiv, 'pages/profile-page.html');
    localStorage.setItem('state', 'user' + userId.toString())
    if (userId){
        loadProfile(userId);
    } else {
        loadProfile(JSON.parse(localStorage.getItem('me')));
    }
}

function loadProfile(user){
    document.getElementById("profile-username").innerHTML = user["username"];
    document.getElementById("profile-bio");
}

function loadNewPostPage(){
    load(mainPageDiv, 'pages/new-post-page.html');
    localStorage.setItem('state', 'new-post')
}