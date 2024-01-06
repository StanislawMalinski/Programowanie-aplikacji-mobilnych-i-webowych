function send(request) {
    return fetch(request)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            return data;
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

function URL() {
    filePath = "../../static/appsettings.json"
    fetch(filePath)
        .then(data => {
            data.json().then(js => {
                                return js["URL"]
            })
        })
        .catch(error => {
            console.error('Error:', error);
        });
    return ""
}
