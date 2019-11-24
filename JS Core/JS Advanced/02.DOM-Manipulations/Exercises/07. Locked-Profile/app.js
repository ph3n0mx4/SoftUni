function lockedProfile() {
    let buttons=document.getElementsByTagName(`button`);
    for (let button of buttons){
        let div = button.parentNode;
        let unlock = div.getElementsByTagName(`input`)[1];
        let hiddenDiv = div.getElementsByTagName(`div`)[0];
        button.addEventListener(`click`,function () {
            if(unlock.checked && button.textContent===`Show more`){
                hiddenDiv.style.display=`block`;
                button.textContent=`Hide it`;
            }else if(unlock.checked){
                //let hiddenDiv = document.getElementById(`user1HiddenFields`);
                hiddenDiv.style.display=`none`;
                button.textContent=`Show more`;
            }
        });
    };
}