function getInfo() {
    let stop = document.getElementById(`stopId`).value;
    let url = `https://judgetests.firebaseio.com/businfo/${stop}.json`;

    fetch(url)
        .then((responce)=>responce.json())
        .then((data)=>{
            document.getElementById(`stopName`).textContent=data.name;
            document.getElementById(`buses`).innerHTML=``;
            let arrBuses=Object.entries(data.buses);

            for (let [busNUmber, busTime] of arrBuses){
                let listItem = document.createElement(`li`);
                listItem.textContent=`Bus ${busNUmber} arrives in ${busTime}`;
                document.getElementById(`buses`).appendChild(listItem);
            }

            document.getElementById(`stopId`).value=``;
        })
        .catch(error=>{
            document.getElementById(`stopName`).textContent=`Error`;
        });
}