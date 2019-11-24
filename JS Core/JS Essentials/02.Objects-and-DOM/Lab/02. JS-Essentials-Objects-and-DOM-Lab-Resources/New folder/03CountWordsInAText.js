function solve(arr) {
    let input = arr[0].match(/\w+/g);
    let result={};
    for (let i = 0; i <input.length ; i++) {
        if(!result[input[i]]){
            result[input[i]]=+0;
        }

        result[input[i]]++;
    }

    let myJSON = JSON.stringify(result);
    console.log(myJSON);
}

solve(['JS devs use Node.js for server-side JS.-- JS for devs']);