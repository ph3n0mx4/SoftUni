function solve() {
    let products=Array.from(document.getElementsByClassName('product'));
    let textArea=document.getElementsByTagName('textarea')[0];
    let checkoutBtn= document.getElementsByClassName('checkout')[0];
    let totalPrice =Number(0);
    let list=[];

    for (let i = 0; i < products.length; i++) {
        let product=products[i];
        let addBtn= product.getElementsByClassName('add-product')[0];
        let name = product.getElementsByClassName('product-title')[0].textContent;
        let price = Number(product.getElementsByClassName('product-line-price')[0].textContent);

        addBtn.addEventListener('click', function () {
            totalPrice+=price;
            if(!list.includes(name)){
                list.push(name.trim());
            }
            textArea.textContent +=`Added ${name} for ${price.toFixed(2)} to the cart.\n`;
        })
    }

    checkoutBtn.addEventListener('click', function () {
        document.getElementsByClassName('checkout')[0].disabled=true;
        for (let i = 0; i < products.length; i++) {
            let product=products[i];
            product.getElementsByClassName('add-product')[0].disabled=true;
        }

        textArea.textContent+=`You bought ${list.join(', ')} for ${totalPrice.toFixed(2)}.`
    })

}