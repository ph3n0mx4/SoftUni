function solve() {

    let selectTo =document.getElementById('selectMenuTo');
    let binary = document.getElementsByTagName('option')[1];

    binary.textContent='Binary';
    binary.value='binary';
    selectTo.appendChild(binary);

    let hexadecimal =document.createElement('option');
    hexadecimal.setAttribute('value','hexadecimal');
    hexadecimal.textContent='Hexadecimal'
    selectTo.appendChild(hexadecimal);

    let convertItBtn = document.getElementsByTagName('button')[0];

    convertItBtn.addEventListener('click', function () {
        //console.log(selectTo.value);
        let set = selectTo.value;
        let number = Number(document.getElementById('input').value);
        let result = document.getElementById('result');
        if(set==='binary'){
            result.value=number.toString(2);
        }

        else {
            result.value=number.toString(16).toUpperCase();
        }

    })


}