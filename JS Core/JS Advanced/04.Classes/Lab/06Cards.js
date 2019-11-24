let result = (function () {
    let suits = {
        SPADES: `\u2660`,
        HEARTS: `\u2665`,
        DIAMONDS: `\u2666`,
        CLUBS: `\u2663`
    };

    let faces=["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card{
        //_face;
        //_suit;
        constructor(face,suit){
            this.face=face;
            this.suit=suit;
        }

        get face(){
            return this._face;
        }

        set face(face){
            if(!faces.includes(face)){
                throw new Error(`Wrong face!`);
            }
            this._face=face;
        }

        get suit(){
            return this._suit;
        }

        set suit(suit){
            if(!Object.values(suits).some(s => s === suit)){
                throw new Error(`Wrong suit!`);
            }
            this._suit=suit;
        }
    }

    return{
        Suits:suits,
        Card: Card
    }
}());

let Card = result.CARD;
let Suits = result.Suits;

let card1 = new Card(`Q`, Suits.CLUBS);
let card2 = new Card(`2`, Suits.SPADES);

