const kinveyUsername=`guest`;
const kinveyPassword=`pass`;

let elements={
    getVenuesBtn: document.getElementById(`getVenues`),
    venueDate: document.getElementById(`venueDate`),
    venueInfo: document.getElementById(`venue-info`)
};
elements.getVenuesBtn.addEventListener(`click`,load);
let baseUrl=`https://baas.kinvey.com/`;

function load() {
    let date=elements.venueDate.value;
    elements.venueDate.value=``;
    elements.venueInfo.innerHTML=``;


    const headersPost={
        method:`POST`,
        credentials: `include`,
        Authorization: `Basic` + btoa(`${kinveyUsername}:${kinveyPassword}`),
        headers:{
            'Content-type':`application/json`
        }
    };

    let postUrl = baseUrl+`rpc/kid_BJ_Ke8hZg/custom/calendar?query=${date}`;
    fetch(postUrl,headersPost)
        .then(handler)
        .then(data=>{
            getVenue(data);
        })
        .catch(err=>console.log(err));

    function getVenue(ids){
        ids.forEach(id=>{
            let getUrl=baseUrl+`appdata/kid_BJ_Ke8hZg/venues/${id}`;
            const headersGet ={
                credentials: `include`,
                Authorization: `Kinvey `+ localStorage.getItem(`authToken`)
            };

            fetch(getUrl,headersGet)
                .then(handler)
                .then(data=>{
                    composeVenue(data);
                    console.log(data);
                    //data.forEach(venue=>composeVenue(venue));
                })
                .catch(err=>console.log(err));
        });
    }


}

function handler(response) {
    if(response.status>400){
        throw new Error(`Something went wrong. Error: ${response.statusText}`);
    }
    return response.json();
}

function composeVenue(venue) {
    let div = document.createElement(`div`);
    div.classList.add(`venue`);
    div.setAttribute(`id`,`${venue._id}`);

    div.innerHTML=`<span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
    <div class="venue-details" style="display:none">
        <table>
            <tr>
                <th>Ticket Price</th>
                <th>Quantity</th>
                <th></th>
            </tr>
            <tr>
                <td class="venue-price">${venue.price} lv</td>
                <td><select class="quantity">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                    </select></td>
                <td><input class="purchase" type="button" value="Purchase"></td>
            </tr>
        </table>
        <span class="head">Venue description:</span>
        <p class="description">${venue.description}</p>
        <p class="description">Starting time: ${venue.startingHour}</p>
    </div>`;

    let btnMoreInfo=div.getElementsByClassName(`info`)[0];
    let btnPurchase=div.getElementsByClassName(`purchase`)[0];

    btnMoreInfo.addEventListener(`click`,moreInfo);
    btnPurchase.addEventListener(`click`,purchase);

    function moreInfo() {
        let a =div.getElementsByClassName(`venue-details`)[0];
        if(a.style.display===`block`){
            a.style.display=`none`;
        }
        else {
            a.style.display=`block`;
        }
    }
    function purchase(){
        let qty=Number(div.getElementsByClassName(`quantity`)[0].value);
        let price=Number(`${venue.price}`);

        div.parentNode.innerHTML=`<span class="head">Confirm purchase</span>
        <div class="purchase-info">
            <span>${venue.name}</span>
            <span>${qty} x ${price}</span>
            <span>Total: ${qty * price} lv</span>
            <input type="button" value="Confirm">
        </div>`;

        let btnConfirm=document.getElementsByClassName(`purchase-info`)[0].children[3];
        btnConfirm.addEventListener(`click`,confirmFunc);

        function confirmFunc() {

            let url=baseUrl+`rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${venue._id}&qty=${qty}`;
            const headersPost={
                method:`POST`,
                credentials: `include`,
                Authorization: `Basic` + btoa(`${kinveyUsername}:${kinveyPassword}`),
                headers:{
                    'Content-type':`application/json`
                }
            };

            fetch(url,headersPost)
                .then(handler)
                .then(data=>{
                    elements.venueInfo.textContent=`You may print this page as your ticket`;
                    elements.venueInfo.innerHTML+=data.html;
                })
                .catch(err=>console.log(err))
        }
    }
    elements.venueInfo.appendChild(div);
}