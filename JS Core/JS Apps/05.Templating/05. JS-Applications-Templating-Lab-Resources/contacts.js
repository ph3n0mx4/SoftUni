(async ()=>{
    const contacts = [
        {
            id: 1,
            name: "John",
            phoneNumber: "0847759632",
            email: "john@john.com"
        },
        {
            id: 2,
            name: "Merrie",
            phoneNumber: "0845996111",
            email: "merrie@merrie.com"
        },
        {
            id: 3,
            name: "Adam",
            phoneNumber: "0866592475",
            email: "adam@stamat.com"
        },
        {
            id: 4,
            name: "Peter",
            phoneNumber: "0866592475",
            email: "peter@peter.com"
        },
        {
            id: 5,
            name: "Max",
            phoneNumber: "0866592475",
            email: "max@max.com"
        },
        {
            id: 6,
            name: "David",
            phoneNumber: "0866592475",
            email: "david@david.com"
        }
    ];
    try {
        let response = await fetch(`./template.html`,{'Content-Type':`html/text`});
        let src = await  response.text();

        let template = Handlebars.compile(src);
        const html = template({contacts});

        document.getElementById(`contacts`).innerHTML=html;

        [...document.getElementsByClassName(`detailsBtn`)]
            .forEach(button=>{
                button.addEventListener(`click`,function ({target}) {
                    let card = target.parentNode;
                    let details = card.getElementsByClassName(`details`)[0];
                    details.style.display=details.style.display
                    ?``
                    :`none`;
                })
            })
    }
    catch (e) {
        console.log(e);
    }
})();


