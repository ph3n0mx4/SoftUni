(() => {
    // TODO
    //console.log(monkeys);
    renderMonkeyTemplate();
    function renderMonkeyTemplate() {
        let template=document.getElementById(`monkey-template`).innerHTML;
        let compiled = Handlebars.compile(template);
        let rendered =compiled({monkeys});
        document.getElementsByTagName(`section`)[0].innerHTML+=rendered;
    }

    [...document.getElementsByTagName(`section`)[0]
        .getElementsByTagName(`button`)]
        .forEach(btn=>{
            btn.addEventListener(`click`,function ({target}) {
                let card = target.parentNode;
                console.log(card);
                let p = card.getElementsByTagName(`p`)[0];
                console.log(p);
                if(p.style.display===`none`){
                    p.style.display=`block`;
                }
                else {
                    p.style.display=`none`;
                }

            })
        });
})();