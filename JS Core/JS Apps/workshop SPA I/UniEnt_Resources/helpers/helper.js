const helper=function () {
    const handler=function (response) {
        if(response.status>=400){
            /*stopNotify();
            notify(`error`,response.statusText);*/
            throw new Error(`Something went wrong ${response.statusText}`)
        }

        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const checkPassword = function (params) {
        return params.password=== params.rePassword;
    };

    /*const notify = function (type,textContent) {
        let element = ``;

        switch (type) {
            case `success`:
                element = document.getElementById(`successBox`);
                element.textContent=textContent;
                break;
            case `error`:
                element = document.getElementById(`errorBox`);
                element.textContent=textContent;
                break;
            case `loadind`:
                element = document.getElementById(`loadingBox`);
                element.textContent=`Loading...`;
                break;
        }


        element.style.display=`block`;
        element.addEventListener(`click`,(ev)=>ev.currentTarget.style.display=`none`);
    };*/

    /*const stopNotify=function () {
        [...document.getElementById(`notifications`).children]
            .forEach(n=>{
                n.style.display=`none`;
            })
    };*/

    return {
        handler,
        checkPassword,
        /*notify,
        stopNotify*/
    }
}();