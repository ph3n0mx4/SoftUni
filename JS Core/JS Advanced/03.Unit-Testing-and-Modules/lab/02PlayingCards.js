function solve(face, suit) {
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

console.log(solve(1, 'A'));

module.export = solve();