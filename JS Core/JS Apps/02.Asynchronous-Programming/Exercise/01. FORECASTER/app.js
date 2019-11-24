function attachEvents() {
    let location=document.getElementById(`location`);
    document.getElementById(`submit`).addEventListener(`click`,getWeather);


   async function getWeather(){
        let code=``;
        let urlLocations =`https://judgetests.firebaseio.com/locations.json`;

        await fetch(urlLocations)
            .then(response=>response.json())
            .then(data=>{
                for (let el of data){
                    if(el.name===location.value){
                        code=el.code;
                    }
                }
                if(code===``){
                     throw new Error(`Error`);
                }
                location.value=``;
            })
            .catch(err=>{
                document.getElementById(`forecast`).style.display=`block`;
                let div = document.getElementById(`forecast`);
                let newDiv =document.createElement(`div`);
                newDiv.textContent=err.message;
                div.appendChild(newDiv);
                return;
            });

       /*if(code===``){
           return ;

       }*/
        let urlCondition=`https://judgetests.firebaseio.com/forecast/today/${code}.json`;
        let name=``;
        let low=``;
        let high=``;
        let condition=``;
        await fetch(urlCondition)
            .then(response=>response.json())
            .then(data=>{
                //console.log(data);
                name=data.name;
                low=data.forecast.low;
                high=data.forecast.high;
                condition=data.forecast.condition;

            });

        let threeDays=``;
        let urlUpcoming=`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
        await fetch(urlUpcoming)
           .then(response=>response.json())
           .then(data=>{
               threeDays=Object.values(data)[0];
           });

       let symbols={Sunny:`&#x2600`};
       symbols[`Partly sunny`]=`&#x26C5`;
       symbols[`Overcast`]=`&#x2601`;
       symbols[`Rain`]=`&#x2614`;
       symbols[`Degrees`]=`&#176`;

       currentWeather();
       threeDaysWeather()

       function currentWeather() {
           document.getElementById(`forecast`).style.display=`block`;
           let generalDiv=document.getElementById(`current`);
           let divForecast=document.createElement(`div`);
           divForecast.classList.add(`forecast`);
           let spanSymbol=document.createElement(`span`);
           spanSymbol.classList.add(`condition`,`symbol`);
           spanSymbol.innerHTML=symbols[condition];

           let generalSpan=document.createElement(`span`);
           generalSpan.classList.add(`condition`);

           let spanName=document.createElement(`span`);
           spanName.classList.add(`forecast-data`);
           spanName.textContent=`${name}`;
           generalSpan.appendChild(spanName);

           let spanT=document.createElement(`span`);
           spanT.classList.add(`forecast-data`);
           spanT.innerHTML=`${low}${symbols.Degrees}/${high}${symbols.Degrees}`;
           generalSpan.appendChild(spanT);

           let spanC=document.createElement(`span`);
           spanC.classList.add(`forecast-data`);
           spanC.textContent=`${condition}`;
           generalSpan.appendChild(spanC);

           divForecast.appendChild(spanSymbol);
           divForecast.appendChild(generalSpan);
           generalDiv.appendChild(divForecast);
       }

       function threeDaysWeather() {
           let divInfo=document.createElement(`div`);
           divInfo.classList.add(`forecast-info`);

           for (let day of threeDays){
               let generalSpan=document.createElement(`span`);
               generalSpan.classList.add(`upcoming`);

               let spanS=document.createElement(`span`);
               spanS.classList.add(`symbol`);
               spanS.innerHTML=`${symbols[day.condition]}`;
               generalSpan.appendChild(spanS);

               let spanT=document.createElement(`span`);
               spanT.innerHTML=`${day.low}${symbols.Degrees}/${day.high}${symbols.Degrees}`;
               spanT.classList.add(`forecast-data`);

               generalSpan.appendChild(spanT);

               let spanC=document.createElement(`span`);
               spanC.textContent=`${day.condition}`;
               spanC.classList.add(`forecast-data`);

               generalSpan.appendChild(spanC);

               divInfo.appendChild(generalSpan);
           }

           let upDiv=document.getElementById(`upcoming`);
           upDiv.appendChild(divInfo);
       }

   }

}

attachEvents();
