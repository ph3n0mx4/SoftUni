function solve() {
    let expressionArea=document.getElementById('expressionOutput');
    let resultArea = document.getElementById('resultOutput');
    let temp=['',''];
    let counter=0;
    let operator='';
    let cBtn=document.getElementsByClassName('clear')[0];
    cBtn.addEventListener('click',function () {
        expressionArea.textContent='';
        resultArea.textContent='';
        operator='';
    })

    let btns = document.getElementsByClassName('keys')[0].getElementsByTagName('button');

    for (let btn of btns){
        btn.addEventListener('click',function () {
            if(btn.textContent==='='){
                resultArea.textContent= temp[1]!=='' ? `${equal(operator,temp)}` : 'NaN';
            }

            else if(btn.textContent==='/'||btn.value==='*'
                ||btn.textContent==='+'||btn.textContent==='-'){

                expressionArea.textContent+=' ';
                expressionArea.textContent+=btn.textContent.toString();
                expressionArea.textContent+=' ';
                operator+=btn.value.toString();
                counter++;
            }

            else {
                expressionArea.textContent+=btn.textContent;
                temp[counter]+=btn.value;
            }
        })
    }

    function equal(operator,temp) {
        let firstNumber=temp[0];
        let secondNumber=temp[1];

        let result=0;

        switch (operator) {
            case "+": result =Number(firstNumber)+Number(secondNumber);break;
            case "-": result =Number(firstNumber)-Number(secondNumber);break;
            case "*": result =Number(firstNumber)*Number(secondNumber);break;
            case "/": result =Number(firstNumber)/Number(secondNumber);break;
        }

        return result;
    }

}