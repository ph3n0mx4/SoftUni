function attachEvents() {
    document.getElementById(`refresh`).addEventListener(`click`,refresh);
    document.getElementById(`submit`).addEventListener(`click`,submit);

    function refresh(){
        document.getElementById(`messages`).textContent=``;
        let url =`https://rest-messanger.firebaseio.com/messanger.json`;
        fetch(url)
            .then(response=>response.json())
            .then(data=>{
                document.getElementById(`messages`);
                let messages=Object.values(data);
                for (let message of messages){
                    document.getElementById(`messages`).textContent+=`${message.author}: ${message.content}\n`
                }
            });
    }

    function submit() {
        let author=document.getElementById(`author`).value;
        let content=document.getElementById(`content`).value;

        document.getElementById(`author`).value=``;
        document.getElementById(`content`).value=``;

        let currentMessage={author,content};

        let url =`https://rest-messanger.firebaseio.com/messanger.json`;
        fetch(url,{
            method:`post`,
            body:JSON.stringify(currentMessage)
        })
            .then(response=>response.json())
            /*.then(()=>{refresh()})*/;
    }


}

attachEvents();