function sovle(input) {
    let step =Number(input.pop());
    let result=[];
    for (let i = 0; i < input.length; i+=step) {
        result.push(input[i]);
    }
    result.forEach(x=>console.log(`${x}`))
}
sovle(['dsa',
    'asd',
    'test',
    'tset',
    '2']
)