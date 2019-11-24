function printDeckOfCards(cards) {
    function createCard (face,suit) {
        let faces = [`2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `J`, `Q`, `K`, `A`];
        let suits = {S:`\u2660`,H:`\u2665`,D:`\u2666`,C:`\u2663`};

        if(!faces.includes(face)){
            throw new Error();
        }

        if(!suits[suit]){
            throw new Error();
        }

        let card= {
            face,
            suit:suits[suit],
            toString: function () {
                return this.face+this.suit
            }
        }

        return card;
        //console.log(`\u2663`);
        //console.log(`A`);

    }
    let result=[];
    for (let card of cards) {
        try {
            let face = card.length===3 ? card[0]+card[1] : card[0];
            let suit = card.length===3 ? card[2] : card[1];
            result.push(createCard(face,suit));
        }
        catch (e) {
            return console.log(`Invalid card: ${card}`);
        }
    }
    console.log(result.join(` `));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);

