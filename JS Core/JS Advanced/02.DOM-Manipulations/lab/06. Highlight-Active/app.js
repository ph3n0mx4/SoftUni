function focus() {
    let inputs = Array.from(document.getElementsByTagName(`input`));

    //divs.forEach(d=>console.log(d));
    function onFocus(event) {
        console.log(event.target);
        let input = event.target.parentNode;
        input.setAttribute(`class`,`focused`);
    }

    function onBlur(event) {
        let input = event.target.parentNode;
        input.removeAttribute(`class`);
    }

    inputs.forEach(d=>{
        d.addEventListener(`focus`,onFocus);
        d.addEventListener(`blur`,onBlur);
    });

}