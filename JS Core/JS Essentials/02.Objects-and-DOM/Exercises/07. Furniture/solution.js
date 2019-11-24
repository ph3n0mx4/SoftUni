function solve() {
    let furnitureList;
    let generateBtn = document.getElementsByTagName('button')[0];
    let buyBtn = document.getElementsByTagName('button')[1];

    generateBtn.addEventListener('click', function () {
        let textArea = document.getElementsByTagName('textarea')[0].value;
        furnitureList=JSON.parse(textArea);

        let table = document.getElementsByClassName('table')[0];

        for (let furn of furnitureList){
            let row = table.insertRow();
            let cell = row.insertCell();

            let image=document.createElement('img');
            image.setAttribute('src',furn['img']);
            cell.appendChild(image);
            //console.log(furn);

            let name=document.createElement('p');
            name.innerHTML=furn['name'];
            cell= row.insertCell();
            cell.appendChild(name);

            let price=document.createElement('p');
            price.innerHTML=furn['price'];
            cell= row.insertCell();
            cell.appendChild(price);

            let decFactor=document.createElement('p');
            decFactor.innerHTML=furn['decFactor'];
            cell= row.insertCell();
            cell.appendChild(decFactor);

            let checkBox = document.createElement('input');
            checkBox.setAttribute('type','checkbox');
            checkBox.innerText='enable';
            cell=row.insertCell();
            cell.appendChild(checkBox);
        }

    })

    buyBtn.addEventListener('click', function () {
        //console.log('buy');

        let bought =[];
        let totalPrice=0;
        let avgDecFactor=0;
        let count=0;

        let checkBox = Array.from(document.getElementsByTagName('tr'));

        for (let i = 1; i < checkBox.length; i++) {

            if(checkBox[i].children[4].children[0].checked)
            {
                count++;
                //console.log(checkBox[i].children[1].textContent);
                let name = checkBox[i].children[1].textContent;
                bought.push(name);
                let price = Number(checkBox[i].children[2].textContent);
                totalPrice+=price;
                let decFactor = Number(checkBox[i].children[3].textContent);
                avgDecFactor+=decFactor;
            }
        }

        avgDecFactor/=count;

        let textArea=document.getElementsByTagName('textarea')[1];
        textArea.value=`Bought furniture: ${bought.join(', ')}\n`+
            `Total price: ${totalPrice.toFixed(2)}\n`+
            `Average decoration factor: ${avgDecFactor}`

    })

}
