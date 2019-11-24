function addProduct() {
    let product = document.getElementsByTagName(`input`)[0];
    let price = document.getElementsByTagName(`input`)[1];
    let products=document.getElementById(`product-list`);
    let total=document.getElementsByTagName(`tfoot`)[0]
        .getElementsByTagName(`td`)[1];
    console.log(total);

    if(product.value && price.value && price.value>0){
        let tr=document.createElement(`tr`);
        let td1=document.createElement(`td`);
        let td2=document.createElement(`td`);
        td1.textContent=product.value;
        td2.textContent=price.value;
        tr.appendChild(td1);
        tr.appendChild(td2);
        products.appendChild(tr);
        total.textContent =+price.value+Number(total.textContent);
    }

    product.value=``;
    price.value=``;
}