function solve() {
    let textElement = document.getElementById('input');
    let textContent =textElement.textContent;
    let output = document.getElementById('output');

    let sentences = textContent.split(/\.\s*/);
    while (sentences.length!==0){

        let currentParagraph=[];
        for (let i = 0; i <3 ; i++) {
            currentParagraph.push(sentences.shift());
            if(sentences.length===0){
                break;
            }
        }

        let p =document.createElement('p');
        p.textContent=currentParagraph.join(". ");
        output.appendChild(p);
    }

}

