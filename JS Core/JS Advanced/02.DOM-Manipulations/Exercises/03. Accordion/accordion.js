function toggle() {
    let div = document.getElementById(`extra`);
    let btn = document.getElementsByClassName(`button`)[0];
    //console.log(div.style.display);
    btn.addEventListener(`click`, onClick());
    function onClick(){
        if(btn.textContent===`More`){
            div.style.display=`block`;
            btn.textContent=`Less`;
        }else {
            div.style.display=`none`;
            btn.textContent=`More`;
        }
    }
}