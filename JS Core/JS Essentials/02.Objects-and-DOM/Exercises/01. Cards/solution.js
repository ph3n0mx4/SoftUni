function solve() {
    let player1Div =Array.from(document.getElementById('player1Div'));
    let player2Div =Array.from(document.getElementById('player2Div'));

    let currentFirst=document.getElementsByTagName('span')[0];
    let currentSecond=document.getElementsByTagName('span')[2];
    function addEvent(collection) {
       for (let i = 0; i <collection.length ; i++) {
           let card=collection[i];
           card.addEventListener('click', clickEvent ());
    }

    addEvent(player1Div);
    addEvent(player2Div);

    function clickEvent() {

        this.src='images/whiteCard.jpg';
        console.log(this.name);
        //card.setAttribute('src','images/whiteCard.jpg');
        //card.style.border='2px solid red';
    }
}