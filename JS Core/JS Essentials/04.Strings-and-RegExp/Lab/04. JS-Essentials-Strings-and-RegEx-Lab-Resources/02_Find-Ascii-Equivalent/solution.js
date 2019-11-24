function solve() {
    let textArea = document.getElementById(`text`).value
        .split(` `);
    let resultArea = document.getElementById(`result`);

    let nums=[];
    let words=[];
    let result = [];

    textArea.filter(x=>x!==` `).forEach(x=>{
        if(Number(x)){
            nums.push(x);
        }
        else {
            words.push(x);
        }
    });

    words.forEach(x=>{
        let currentResult=[];
        for (let i = 0; i <x.length ; i++) {
            currentResult.push(x[i].charCodeAt(0));
        }
        result.push(currentResult.join(` `));


    });
    let resultW=[];
    nums.forEach(x=>{
        resultW.push(String.fromCharCode(x));
    });


    //let p = document.createElement(`p`);

    result.push(resultW.join(``));
    result = result.join(`<p>`);
    console.log(result);
    resultArea.innerHTML+=`<p>`+result;

}
