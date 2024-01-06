function load(element, content){
    fetch(content)
        .then(response => response.text())
        .then(data => {
            element.innerHTML= data;
        })
        .catch(error => {
            console.error('Error fetching HTML:', error);
        });
};