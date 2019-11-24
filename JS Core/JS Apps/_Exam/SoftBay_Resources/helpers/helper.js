const helper=function () {
    const handler=function (response) {

        if(response.status>=400){
            stopNotify();
            notify(`error`,response.statusText);
            throw new Error(`Something went wrong ${response.statusText}`)
        }

        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const checkPassword = function (params) {
        return params.password === params.rePassword;
    };

    const checkNonEmpty = function (params) {
        if(params.password && params.rePassword && params.username){
            return true
        }
        else {
            return false
        }
    };

    const checkNonEmptyString = function (params) {
        if(params.product && params.description && params.price){
            return true
        }
        else {
            return false
        }
    };
    
    const checkValidUrl = function (params) {
        if(params.pictureUrl.startsWith(`https://`)){
            return true;
        }
        else {
            return false;
        }
    };

    const notify = function (type, textContent) {
        let element = '';

        switch (type) {
            case "success":
                element = document.getElementById('successBox');
                element.textContent = textContent;
                element.addEventListener('click', (event) => event.currentTarget.style.display = 'none');
                break;
            case "error":
                element = document.getElementById('errorBox');
                element.textContent = textContent;
                element.addEventListener('click', (event) => event.currentTarget.style.display = 'none');
                break;
            case "loading":
                element = document.getElementById('loadingBox');
                element.textContent = 'Loading...';
                element.addEventListener('click', (event) => event.currentTarget.style.display = 'none');
                break;
        }

        element.style.display = 'block';
    };

    const stopNotify = function () {
        Array.from(document.getElementById('notifications').children).forEach(child => child.style.display = 'none');
    };

    return {
        handler,
        checkPassword,
        checkNonEmpty,
        notify,
        stopNotify,
        checkNonEmptyString,
        checkValidUrl
    }
}();