import pl from '../assets/pl-flag.png';
import en from '../assets/en-flag.png';
import './LanguageSelector.css';



const dic = {
  "login": {"en": "Login", "pl": "Zaloguj się"},
  "logout": {"en": "Logout", "pl": "Wyloguj się"},
  "register": {"en": "Register", "pl": "Zarejestruj się"},
  "username": {"en": "Username", "pl": "Nazwa użytkownika"},
  "password": {"en": "Password", "pl": "Hasło"},
  "email": {"en": "Email", "pl": "Email"},
  "repeatPassword": {"en": "Repeat password", "pl": "Powtórz hasło"},
  "loginError": {"en": "Login error", "pl": "Błąd logowania"},
  "loginErrorDescription": {"en": "Invalid username or password", "pl": "Nieprawidłowa nazwa użytkownika lub hasło"},
  "post": {"en": "Post", "pl": "Post"},
  "posts": {"en": "Posts", "pl": "Posty"},
  "postTitle": {"en": "Title", "pl": "Tytuł"},
  "mainPage": {"en": "Home", "pl": "Strona główna"},
  "myProfile": {"en": "My profile", "pl": "Mój profil"},
  "delete": {"en": "Delete", "pl": "Usuń"},
  "edit": {"en": "Edit", "pl": "Edytuj"},
  "save": {"en": "Save", "pl": "Zapisz"},
  "cancel": {"en": "Cancel", "pl": "Anuluj"},
  "newPost": {"en": "New post", "pl": "Nowy post"},
  "comments": {"en": "Comments", "pl": "Komentarze"},
  "next": {"en": "Next", "pl": "Następny"},
  "previous": {"en": "Previous", "pl": "Poprzedni"},
  "userProfile": {"en": "User profile", "pl": "Profil użytkownika"},
  "noPost": {"en": "No post", "pl": "Brak postów"},
  "loadingAnimation": {"en": "Loading animation", "pl": "Animacja ładowania"},
  "helloOnForface": {"en": "Hello on ForFace", "pl": "Witaj na ForFace"},
  "forFace": {"en": "ForFace", "pl": "ForFace"},
  "createdAt": {"en": "Created at", "pl": "Utworzono"},
  "user": {"en": "User", "pl": "Użytkownik"},
  "publish":  {"en": "Publish", "pl": "Opublikuj"},
  "comment": {"en": "Comment", "pl": "Komentarz"},
  "postContent": {"en": "Post content", "pl": "Treść posta"},
  "deletionPostConfirmationMessage": {"en": "Are you sure you want to delete this post?", "pl": "Czy na pewno chcesz usunąć ten post?"},
  "accessDeniedMessage": {"en": "Access denied", "pl": "Brak dostępu"},
  "postNotExist": {"en": "Post not exist", "pl": "Post nie istnieje"},
  "hi": {"en": "Hi", "pl": "Cześć"},
  "error-massage": {"en": "Error", "pl": "Błąd"},
  "login-with-google": {"en": "Login with Google", "pl": "Zaloguj się przez Google"},
  "your-mail": {"en": "Your mail", "pl": "Twój email"},
  "your-username": {"en": "Your username", "pl": "Twoja nazwa użytkownika"},
  "repeate-password": {"en": "Repeat password", "pl": "Powtórz hasło"},
  "register-with-google": {"en": "Register with Google", "pl": "Zarejestruj się przez Google"},
  "" : {"en": "", "pl": ""},
  "main-page": {"en": "Home", "pl": "Strona główna"},
  "forface": {"en": "ForFace", "pl": "ForFace"},
  "my-profile": {"en": "My profile", "pl": "Mój profil"},
  "new-post": {"en": "New post", "pl": "Nowy post"},
  "cancle": {"en": "Cancle", "pl": "Anuluj"},
  "title" : {"en": "Title", "pl": "Tytuł"},
  "content" : {"en": "Content", "pl": "Treść"},
  "User already exists." : {"en": "User already exists.", "pl": "Użytkownik już istnieje."},
  "logout-message": {"en": "Are you sure you want to logout?", "pl": "Czy na pewno chcesz się wylogować?"},
}
function LanguageSelector() {
  function setLanguage(lang: string) {
    localStorage.setItem('lang', lang);
    window.location.reload();
  }

  // console.log(getPhrase('test'));

  return (
    <div className='flag-selector'>
    <img className='flag' src={en} onClick={() => setLanguage('en')} alt='en' />
    <img className='flag' src={pl} onClick={() => setLanguage('pl')} alt='pl' />
    </div>
  );
}

function getPhrase(phrase: string) {
  var lang = localStorage.getItem('lang');
  var res = {"en": phrase + "-en", "pl": phrase + "-pl"};
  if (phrase === "login") 
    res = dic[phrase];
  else if (phrase === "logout")
  res = dic[phrase];
  else if (phrase === "register")
    res = dic.register;
  else if (phrase === "username")
    res = dic.username;
  else if (phrase === "password")
    res = dic.password;
  else if (phrase === "email")
    res = dic.email;
  else if (phrase === "repeatPassword")
    res = dic.repeatPassword;
  else if (phrase === "loginError")
    res = dic.loginError;
  else if (phrase === "loginErrorDescription")
    res = dic.loginErrorDescription;
  else if (phrase === "post")
  res = dic[phrase];

  else if (phrase === "posts")
    res = dic.posts;
  else if (phrase === "postTitle")
    res = dic.postTitle;
  else if (phrase === "mainPage")
    res = dic.mainPage;
  else if (phrase === "myProfile")
    res = dic.myProfile;
  else if (phrase === "delete")
    res = dic.delete;
  else if (phrase === "edit")
    res = dic.edit;
  else if (phrase === "save")
    res = dic.save;
  else if (phrase === "cancel")
    res = dic.cancel;
  else if (phrase === "newPost")
    res = dic.newPost;
  else if (phrase === "comments")
    res = dic.comments;
  else if (phrase === "next")
    res = dic.next;
  else if (phrase === "previous")
    res = dic.previous;
  else if (phrase === "userProfile")
    res = dic.userProfile;
  else if (phrase === "noPost")
    res = dic.noPost;
  else if (phrase === "loadingAnimation")
    res = dic.loadingAnimation;
  else if (phrase === "helloOnForface")
    res = dic.helloOnForface;
  else if (phrase === "forFace")
    res = dic.forFace;
  else if (phrase === "createdAt")
    res = dic.createdAt;
  else if (phrase === "user")
    res = dic.user;
  else if (phrase === "publish")
    res = dic.publish;
  else if (phrase === "comment")
    res = dic.comment;
  else if (phrase === "postContent")
    res = dic.postContent;
  else if (phrase === "deletionPostConfirmationMessage")
    res = dic.deletionPostConfirmationMessage;
  else if (phrase === "accessDeniedMessage")
    res = dic.accessDeniedMessage;
  else if (phrase === "hi"){
    res = dic.hi;
    
  }else if (phrase === "error-massage")
    res = dic["error-massage"];
  else if (phrase === "login-with-google")
    res = dic["login-with-google"];
  else if (phrase === "your-mail")
    res = dic["your-mail"];
  else if (phrase === "your-username")
    res = dic["your-username"];
  else if (phrase === "repeate-password")
    res = dic["repeate-password"];
  else if (phrase === "register-with-google")
    res = dic["register-with-google"];
  else if (phrase === "postNotExist")
    res = dic.postNotExist;
  else if (phrase === "")
    return "";
  else if (phrase === "main-page")
    res = dic["main-page"];
  else if (phrase === "forface")
    res = dic.forface;
  else if (phrase === "my-profile")
    res = dic[phrase];
  else if (phrase === "new-post")
    res = dic[phrase];
  else if (phrase === "title")
    res = dic[phrase];
  else if (phrase === "content")
    res = dic[phrase];
  else if (phrase === "User already exists.")
    res = dic["User already exists."];
  else if (phrase === "logout-message")
    res = dic["logout-message"];

  if (lang === 'en')
    return res.en;
  else if (lang === 'pl')
    return res.pl;
  else
    return res.en;
}

export default LanguageSelector;
export {getPhrase};