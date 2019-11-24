function solve() {
    let textArea = document.getElementById(`text`).value;
    let num = document.getElementById(`number`).value;
    let result = document.getElementById(`result`);

    if(num>textArea.length){
        let diff = num-textArea.length;
        let temp = textArea.substring(0,diff);
        result.innerHTML=textArea+temp;
    }
    else if(num<textArea.length){
        let arr=[];
        let diff =textArea.length%num;

        if(diff!==0){
            diff=num-diff;
            textArea=textArea+textArea.substr(0,diff);
        }

        while (textArea.length>0){
            arr.push(textArea.substring(0,num));
            textArea=textArea.substring(num,textArea.length);
        }

        result.innerHTML=arr.join(` `);
    }
    else {
        result.innerHTML=textArea;
    }

}