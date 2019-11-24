function realEstateAgency () {
    let regOffer=document.getElementById(`regOffer`);
    let price = regOffer.getElementsByTagName(`input`)[0];
    let type = regOffer.getElementsByTagName(`input`)[1];
    let rate = regOffer.getElementsByTagName(`input`)[2];
    let regBtn = regOffer.getElementsByTagName(`button`)[0];
    let message= document.getElementById(`message`);
    let building=document.getElementById(`building`);

    let h1 = document.getElementById(`roof`).children[0];

    regBtn.addEventListener(`click`, function () {
        if(Number(price.value)>0
            && Number(rate.value)>=0 && Number(rate.value)<=100
            && isEmpty(type.value) && !type.value.includes(`:`)){
            let div = document.createElement(`div`);
            div.classList.add(`apartment`);
            let p1 = document.createElement(`p`);
            let p2 = document.createElement(`p`);
            let p3 = document.createElement(`p`);

            p1.textContent=`Rent: ${price.value}`;
            p2.textContent=`Type: ${type.value}`;
            p3.textContent=`Commission: ${rate.value}`;

            div.appendChild(p1);
            div.appendChild(p2);
            div.appendChild(p3);
            building.appendChild(div);

            message.textContent=`Your offer was created successfully.`;
        }
        else{
            message.textContent=`Your offer registration went wrong, try again.`;
        }


        clearFieldReg();
    });

    let findOffer=document.getElementById(`findOffer`);
    let budget = findOffer.getElementsByTagName(`input`)[0];
    let typeFind = findOffer.getElementsByTagName(`input`)[1];
    let name = findOffer.getElementsByTagName(`input`)[2];
    let findBtn = findOffer.getElementsByTagName(`button`)[0];

    findBtn.addEventListener(`click`,function () {
        if(Number(budget.value>0) && isEmpty(typeFind.value) && isEmpty(name.value)){
            let apartments = document.getElementsByClassName(`apartment`);
            let isLeased=false;
            for (let ap of apartments){
                let style = ap.getAttribute(`style`);

                let apPrice=Number(ap.children[0].textContent.split(`: `)[1]);
                let apType=ap.children[1].textContent.split(`: `)[1];
                let apCommission=Number(ap.children[2].textContent.split(`: `)[1]);
                let forAgency = (apCommission/100)*2*apPrice;
                let totalPriceAp = (apPrice*(1+apCommission/100));
                if(totalPriceAp<=Number(budget.value)&& typeFind.value===apType
                    /*&& !isLeased*/ && style===null){
                    //isLeased=true;
                    ap.children[0].textContent=name.value;
                    ap.children[1].textContent=`live here now`;
                    let parent = ap.children[2].parentNode;
                    parent.removeChild(ap.children[2]);
                    parent.style=`border: 2px solid red`;

                    let moveOutBtn = document.createElement(`button`);
                    moveOutBtn.textContent=`MoveOut`;
                    moveOutBtn.addEventListener(`click`,function () {

                        let familyName=ap.children[0].textContent;
                        building.removeChild(parent);
                        message.textContent=`They had found cockroaches in ${familyName}'s apartment`;
                    });
                    parent.appendChild(moveOutBtn);

                    message.textContent=`Enjoy your new home! :))`;

                    let agencyProfit = Number(h1.textContent.split(` `)[2]);
                    agencyProfit+=forAgency;
                    h1.textContent = `Agency profit: ${agencyProfit/*.toFixed(2)*/} lv.`;
                    clearFieldFind();
                    return false;
                }else{
                    message.textContent=`We were unable to find you a home, so sorry :(`;
                }
            }
        }
        else {
            message.textContent=`We were unable to find you a home, so sorry :(`;
        }
        clearFieldFind();
    });


    function isEmpty(str) {
        return (str || str.length <=0 ||   str!==``);
    }

    function clearFieldReg() {
        price.value=``;
        type.value=``;
        rate.value=``;
    }

    function clearFieldFind() {
        budget.value=``;
        typeFind.value=``;
        name.value=``;
    }
}

/*console.log(apPrice);
                console.log(typeof apPrice);
                console.log(apType);
                console.log(typeof apType);
                console.log(apCommission);
                console.log(typeof apCommission);*/
