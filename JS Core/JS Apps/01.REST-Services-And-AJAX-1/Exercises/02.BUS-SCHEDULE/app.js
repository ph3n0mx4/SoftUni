function solve() {
    let departBtn = document.getElementById(`depart`);
    let arriveBtn = document.getElementById(`arrive`);
    let currentId=`depot`;

    let currentStop=``;

    function depart() {
        let url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;
        departBtn.disabled=true;
        arriveBtn.disabled=false;
        fetch(url)
            .then((info)=>info.json())
            .then((data)=>{
                currentStop=data;
                document.getElementsByTagName(`span`)[0].textContent=`Next stop ${data.name}`;
                currentId=data.next;
            })
            .catch(()=>{
                document.getElementsByTagName(`span`)[0].textContent=`Error`;
                departBtn.disabled=false;
                arriveBtn.disabled=false;
            });

    }

    function arrive() {
        departBtn.disabled=false;
        arriveBtn.disabled=true;
        document.getElementsByTagName(`span`)[0].textContent=`Arriving at ${currentStop.name}`;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();