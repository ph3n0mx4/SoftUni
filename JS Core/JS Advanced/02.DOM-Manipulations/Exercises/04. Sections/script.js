function create(words) {
    let content = document.getElementById(`content`);

    for (let word of words) {
        let p = document.createElement(`p`);
        p.textContent = word;
        p.style.display = `none`;

        let div = document.createElement(`div`);
        div.addEventListener(`click`, function () {
            p.style.display = `block`;
        });
        div.appendChild(p);
        content.appendChild(div);
    }
}