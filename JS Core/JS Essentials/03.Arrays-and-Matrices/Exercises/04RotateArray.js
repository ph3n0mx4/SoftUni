function solve(input) {
    let amount = Number(input.pop());
    //amount = input.length===1 ? 0 : amount;
    for (let i = 0; i < amount%input.length; i++) {

        input.unshift(input.pop());
    }

    console.log(input.join(' '));
}

solve(['1',
    '2',
    '3',
    '4',
    '2']
)