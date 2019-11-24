(function () {

    let loginBtn =document.getElementById(`loginBtn`);

    loginBtn.addEventListener(`click`,function () {
        if(loginBtn.textContent===`Login`){
            loginBtn.textContent=`Logout`;
        }
        else {
            loginBtn.textContent=`Login`;
        }

    });

    /*let inputUsername=document.getElementById(`username`);
    inputUsername.classList.add(`border-0`);
    inputUsername.classList.add(`bg-light`);

    inputUsername.value=`IVAN`;
    inputUsername.setAttribute(`disable`,`disable`);

    let createOffers = document.getElementById(`create-offers`);
    createOffers.style.display=`none`;*/
//inputUsername.disabled=`disabled`;
})();