
const usr = {
    id: 'value1',
    username: 'value2',
    email: 'value3',
    bio: 'value4',
    permissions: ['admin', 'user']
};

function getUser(){
    return localStorage.getItem('user');
}

function setUser(user: any){
    localStorage.setItem('user', JSON.stringify(user));
}

function removeUser(){
    localStorage.removeItem('user');
}

export { getUser, setUser, removeUser, usr };


