function attachEvents() {
    let baseUrl = `https://phonebook-nakov.firebaseio.com/phonebook`;
    let phonebook = document.getElementById(`phonebook`);

    function loadContact(){
        phonebook.innerHTML=``;
        let url =baseUrl+`.json`;
        fetch(url)
            .then((responce)=>responce.json())
            .then((data)=>{
                let values =Object.values(data);
                for (let value of values){
                    let person =value.person;
                    let phone=value.phone;
                    let li =document.createElement(`li`);
                    li.textContent=`${person}:${phone}`;

                    let delBtn = document.createElement(`button`);
                    delBtn.textContent=`DELETE`;
                    delBtn.addEventListener(`click`,function (ev) {
                        let currentId=``;
                        let keys=Object.keys(data);
                        for (let key of keys){
                            if(data[key].person===person && data[key].phone===phone){
                                currentId=key;
                            }
                        }
                        ev.target.parentNode.remove();

                        let urlForDel=baseUrl+`/`+currentId+`.json`;
                        fetch(urlForDel,{
                            method: `delete`,
                            body: JSON.stringify(currentId)
                        }).then((responce)=>responce.json());
                    });

                    li.appendChild(delBtn);
                    phonebook.appendChild(li);
                }
            });
    }

    function createContact() {
        let person=document.getElementById(`person`);
        let phone=document.getElementById(`phone`);
        let url =baseUrl+`.json`;
        if(person.value && phone.value){
            let currentPerson={person:person.value,phone:phone.value};
            fetch(url,{
                method: `post`,
                body: JSON.stringify(currentPerson)
            })
                .then(response=>response.json());
        }
        person.value=``;
        phone.value=``;
        loadContact();
    }

    document.getElementById(`btnCreate`).addEventListener(`click`,createContact);
    document.getElementById(`btnLoad`).addEventListener(`click`, loadContact);
}

attachEvents();