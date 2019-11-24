function solve() {
    let word = document.getElementById(`word`).value;
    let text=JSON.parse(document.getElementById(`text`).value);
    let result = document.getElementById(`result`);
    let wordToReplace = text[0].split(` `).filter(a=>a!==``)[2];

    let a = new RegExp(wordToReplace, `i`);
    for (let exp of text){
        let currentExp=exp.replace(a,word);
        let p = document.createElement(`p`);
        p.innerHTML=currentExp;
        result.appendChild(p);
    }

}