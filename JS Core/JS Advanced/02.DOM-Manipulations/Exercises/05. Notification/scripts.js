function notify(message) {
    let div = document.getElementById(`notification`);
    let p =document.createElement(`p`);
    p.textContent=message;
    div.appendChild(p);

    div.style.display=`block`;
    setTimeout(()=>{
        div.style.display=`none`;
    },2000);
}