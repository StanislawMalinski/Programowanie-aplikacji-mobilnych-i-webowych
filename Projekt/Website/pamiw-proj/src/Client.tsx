import './appsettings.json';

const baseUrl = 'https://localhost:7061/forum/';

async function curl(url: string, method: string, data: any) {
    try {
        const response = await fetch(url, {
            method: method,
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            },
            body: data ? JSON.stringify(data) : null,
        });
        return await response.json();  
    } catch (error) {
        console.error('Client Error:', error);
        throw error;
    }
}

export function GetPosts(page: number) {
    return curl(baseUrl + 'Post/page=' + page, 'GET', null);
}

export function GetMaxPosts() {
    return curl(baseUrl + 'Post/maxpage', 'GET', null);
}

export function GetPost(id: number) {
    return curl(baseUrl + 'Post/' + id, 'GET', null);
}

export function GetPostsForUser(id: number, page: number) {
    return curl(baseUrl + 'Post/' + id + '/page=' + page, 'GET', null);
}

export function GetMaxPostsForUser(id: number) {
    return curl(baseUrl + 'Post/' + id + '/maxpage', 'GET', null);
}

export function DeletePost(id: number) {
    return curl(baseUrl + 'Post/' + id, 'DELETE', null);
}

export function PostPost(postJson: any) {
    return curl(baseUrl + 'Post', 'POST', postJson);
}

export function PutPost(postJson: any) {
    return curl(baseUrl + 'Post', 'PUT', postJson);
}

export function GetUser(id: number) {
    return curl(baseUrl + 'UserProfile/' + id, 'GET', null);
}

export function DeleteUser(id: number) {
    return curl(baseUrl + 'UserProfile/' + id, 'DELETE', null);
}

export function PostUser(userJson: any) {
    return curl(baseUrl + 'UserProfile', 'POST', userJson);
}

export function PutUser(userJson: any) {
    return curl(baseUrl + 'UserProfile', 'PUT', userJson);
}

export function Login(loginJson: any) {
    return curl(baseUrl + 'Jwt/login', 'POST', loginJson);
}

export function Register(registerJson: any) {
    return curl(baseUrl + 'Jwt/register', 'POST', registerJson);
}
