function solve() {
    let typeCounter = {};

    for (let arg of arguments){
        let type = typeof arg;

        console.log(`${type}: ${arg}`);
        if(typeCounter[type]){
            typeCounter[type]++;
        }else {
            typeCounter[type]=1;
        }
    }

    Object.entries(typeCounter)
        .sort((a,b)=>{
            return b[1]-a[1];
        }).forEach(el=>console.log(`${el[0]} = ${el[1]}`));

}

solve('cat', 42, function () {
    console.log('Hello world!');
});