function addItem() {
    let items = document.getElementById(`items`);
    let text = document.getElementById(`newItemText`).value;

    let li = document.createElement(`li`);
    li.textContent=text;
    items.appendChild(li);
}