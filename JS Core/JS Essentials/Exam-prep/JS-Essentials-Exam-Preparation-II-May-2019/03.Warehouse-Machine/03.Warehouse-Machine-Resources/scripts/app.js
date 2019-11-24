function coffeeStorage() {
    let textArea = JSON.parse(document.getElementsByTagName(`textarea`)[0].value);
    let input = textArea;

    let [report, inspection] = document.getElementsByTagName(`p`);
    textArea.value = '';

    let brands = {};
    for (let token of input) {
        let a = token.split(`, `);
        let type = a[0];
        let brand = a[1];
        let subBrand = a[2];
        let date = a[3];
        let quantity =Number(a[4]);

        if (type === 'IN') {
            if (!brands[brand]) {
                brands[brand] = {};
            }
            if (!brands[brand][subBrand]) {
                brands[brand][subBrand] = {date: date, quantity: quantity};

            } else if (brands[brand][subBrand]) {
                let currentDate = brands[brand][subBrand].date;
                let a = date.localeCompare(currentDate);

                if (a > 0) {
                    brands[brand][subBrand].date = date;
                    brands[brand][subBrand].quantity = quantity;
                } else if (a === 0) {
                    brands[brand][subBrand].quantity += quantity;
                }
            }

        } else if (type === `OUT`) {
            if (brands[brand] && brands[brand][subBrand]) {
                let currentDate = brands[brand][subBrand].date;
                let a = date.localeCompare(currentDate);
                if(a < 0 && brands[brand][subBrand].quantity >= quantity){
                    brands[brand][subBrand].quantity -= quantity
                    //delete brands[brand][subBrand];
                }
                if(brands[brand][subBrand].quantity===0){
                    delete brands[brand][subBrand];
                }

            }
        } else if (type === `REPORT`) {
            Object.entries(brands).forEach(([brand,subBrand])=>{
                let arr=[];
                Object.entries(subBrand).map(([name,information])=>{
                    arr.push(` ${name} - ${information.date} - ${information.quantity}.`)
                })
                report.innerHTML+= `${brand}:${arr.join(``)}` + `<br/>`;

            })
        } else if(type===`INSPECTION`) {
            Object.entries(brands)
                .sort((a,b=>a[0]-b[0]))
                .forEach(([brand, subBrand]) => {
                let arr = [];
                Object.entries(subBrand)
                    .sort((a,b)=>b[1].quantity-a[1].quantity)
                    .map(([name, information]) => {
                    arr.push(` ${name} - ${information.date} - ${information.quantity}.`)
                })
                inspection.innerHTML += `${brand}:${arr.join(``)}` + `<br/>`;


            })
        }

    }
    //console.log(input);
    //console.log(load);
    //console.log(unload);

}