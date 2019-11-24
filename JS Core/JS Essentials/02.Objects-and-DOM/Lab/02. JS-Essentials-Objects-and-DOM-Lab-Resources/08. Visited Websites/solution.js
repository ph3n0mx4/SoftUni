function solve() {
    let siteElements = document.getElementsByClassName('link-1');

    for (const siteElement of siteElements ){
        siteElement.addEventListener('click', (e)=> {
            let currentTarget =e.currentTarget;
            console.log(currentTarget);
/**
            let paragraphElement =currentTarget.getElementsByTagName('p')[0];
            let text = paragraphElement.textContent;

            let textParts=text.split(' ');
            let click = Number(textParts[1]);
            click++;
            textParts[1]=click;
            paragraphElement.textContent=textParts.join(' ');
            console.log(paragraphElement);**/

        });
    }

}