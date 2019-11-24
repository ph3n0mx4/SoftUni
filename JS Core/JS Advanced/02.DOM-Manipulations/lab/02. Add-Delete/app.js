function addItem() {
    let items = document.getElementById(`items`);
    let text = document.getElementById(`newText`);
    let element = createElement(`li`,text.value);

    let aEleAttribute = {name: `href`, value: `#`};
    let aEleEventListener = {type: `click`, func: deleteItem};
    let deleteLink = createElement(`a`, `[Delete]`,aEleAttribute,aEleEventListener);

    appendChilds(element,[deleteLink]);
    appendChilds(items,[element]);

    clearText();

    
    function deleteItem() {items.removeChild(this.parentNode)};

    function createElement(tag,text,attribute, eventListner) {
        let el=document.createElement(tag);
        el.textContent=text;

        if(attribute){
            el.setAttribute(attribute.name,attribute.value);
        }
        if(eventListner){
            el.addEventListener(eventListner.type, eventListner.func);
        }

        return el;
    }
    
    function clearText() {text.value=``};
    
    function appendChilds(parent,childs) {
        childs.forEach((child)=>parent.appendChild(child));
    }
}

