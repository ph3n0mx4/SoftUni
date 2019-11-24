function attachEvents() {
    let towns=document.getElementById(`towns`);
    let btn = document.getElementById(`btnLoadTowns`);
    btn.addEventListener(`click`,loadTonws);
    let ul = document.getElementById(`root`).children[0];
    ul.textContent=``;
    function loadTonws() {
        towns=towns.value
            .split(`,`)
            .map(el=>({name:`${el}`}));
        renderTowns(towns);

    }
    function renderTowns(towns) {
        let template=document.getElementById(`town-template`).innerHTML;
        let compiled = Handlebars.compile(template);
        let rendered =compiled({towns});
        document.getElementById(`root`).innerHTML=rendered;
        document.getElementById(`towns`).value=``;
    }
}
attachEvents();