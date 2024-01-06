user = {'username':"cool", 'email':"test@test", 'bio':"lalalala"};
me = {'username':"coolMe", 'email':"test@test", 'bio':"lalalala"};
//localStorage.setItem('me', JSON.stringify(me));
localStorage.removeItem('me');
//console.log(JSON.parse(localStorage.getItem('me'))["username"]);