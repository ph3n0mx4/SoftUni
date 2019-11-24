function solve() {
    let rows =document.getElementsByTagName('li');
    let textArea = document.getElementsByTagName('input')[0];
    let addBtn = document.getElementsByTagName('button')[0];

    addBtn.addEventListener('click',function () {
        let name =textArea.value[0].toUpperCase()+textArea.value.slice(1).toLowerCase();
        let firstLetter = name[0];
        let rowIndex =Number(firstLetter.charCodeAt(0) - 65);
        if(rows[rowIndex].textContent){
            rows[rowIndex].textContent+=', ';
        }
        rows[rowIndex].textContent+=name;
        textArea.value='';
    })

}