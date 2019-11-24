function solve() {
    let textArea = document.getElementById(`text`).value;
    let currentCase = document.getElementById(`naming-convention`).value;
    let resultArea = document.getElementById(`result`);

    let arr=[];
    textArea.split(` `).forEach(x=>{
        arr.push(x[0].toUpperCase()+x.substr(1).toLowerCase());
    });
    let result = arr.join(``);
    if(currentCase===`Camel Case`){
        result=result[0].toLowerCase()+result.substr(1);
        resultArea.textContent=result;
    }
    else if(currentCase===`Pascal Case`){
        resultArea.textContent=result;
    }
    else {
        resultArea.textContent=`Error!`;
    }

}