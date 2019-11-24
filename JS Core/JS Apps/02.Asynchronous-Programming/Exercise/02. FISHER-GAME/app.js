function attachEvents() {
    const elements={
        loadBtn: document.getElementsByClassName(`load`)[0],
        addBtn:document.getElementsByClassName(`add`)[0],
        catches: document.getElementById(`catches`)
    };
    
    elements.loadBtn.addEventListener(`click`,loadAllCatches);
    elements.addBtn.addEventListener(`click`,addCatch);
    elements.catches.children[0].style.display=`none`;
    function loadAllCatches() {
        let url=`https://fisher-game.firebaseio.com/catches.json`;
        fetch(url,{method: `GET`})
            .then(handler)
            .then(showAllCatches)
    }

    function showAllCatches(data) {
        let base=elements.catches.children[0].cloneNode(true);
        elements.catches.textContent=``;
        elements.catches.appendChild(base);
        Object.keys(data).forEach((key)=>{
            let catchEl=elements.catches.children[0].cloneNode(true);
            catchEl.style.display=`inline-block`;
            catchEl.setAttribute(`data-id`,key);
            catchEl.getElementsByClassName(`angler`)[0].value=data[key].angler;
            catchEl.getElementsByClassName(`weight`)[0].value=data[key].weight;
            catchEl.getElementsByClassName(`species`)[0].value=data[key].species;
            catchEl.getElementsByClassName(`location`)[0].value=data[key].location;
            catchEl.getElementsByClassName(`bait`)[0].value=data[key].bait;
            catchEl.getElementsByClassName(`captureTime`)[0].value=data[key].captureTime;
            catchEl.getElementsByClassName(`update`)[0].addEventListener(`click`,updateCatch);
            catchEl.getElementsByClassName(`delete`)[0].addEventListener(`click`,deleteCatch);
            elements.catches.appendChild(catchEl);
        });

    }

    function addCatch() {
        let url=`https://fisher-game.firebaseio.com/catches.json`;
        let addForm=document.getElementById(`addForm`);
        let angler=addForm.getElementsByClassName(`angler`)[0].value;
        let bait=addForm.getElementsByClassName(`bait`)[0].value;
        let captureTime=addForm.getElementsByClassName(`captureTime`)[0].value;
        let location=addForm.getElementsByClassName(`location`)[0].value;
        let species=addForm.getElementsByClassName(`species`)[0].value;
        let weight=addForm.getElementsByClassName(`weight`)[0].value;
        let currentCatch={angler,bait,captureTime,location,species,weight};
        fetch(url,{method:`Post`,body:JSON.stringify(currentCatch)})
            .then(handler)
            .then(loadAllCatches);
    }



    function updateCatch(e) {
        let catchId=e.currentTarget.parentNode.getAttribute(`data-id`);

        let url=`https://fisher-game.firebaseio.com/catches/${catchId}.json`;
        let div = e.currentTarget.parentNode;
        let angler=div.getElementsByClassName(`angler`)[0].value;
        let bait=div.getElementsByClassName(`bait`)[0].value;
        let captureTime=div.getElementsByClassName(`captureTime`)[0].value;
        let location=div.getElementsByClassName(`location`)[0].value;
        let species=div.getElementsByClassName(`species`)[0].value;
        let weight=div.getElementsByClassName(`weight`)[0].value;
        let currentCatch={angler,bait,captureTime,location,species,weight};
        let headers={method:`PUT`, body:JSON.stringify(currentCatch)};

        fetch(url,headers)
            .then(handler)
            .then(loadAllCatches);
    }

    function deleteCatch(e) {
        let catchId=e.currentTarget.parentNode.getAttribute(`data-id`);
        let url=`https://fisher-game.firebaseio.com/catches/${catchId}.json`;
        fetch(url,{method:`DELETE`})
            .then(handler)
            .then(loadAllCatches);
    }
    
    function handler(response) {
        if(response.status>400){
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }
        return response.json();
    }
    
    function createHTMLElement(tagName,className,textContent, attribute) {
        let currentElement=document.createElement(tagName);

        if(typeof className==="string"){
            currentElement.classList.add(className);
        }else if(typeof className==="object"){
            currentElement.classList.add(...className);
        }

        if(textContent){
            currentElement.textContent=textContent;
        }

        if(attribute){
            currentElement.setAttribute(attribute.name,attribute.value);
        }

        return currentElement;
    }
}

attachEvents();

