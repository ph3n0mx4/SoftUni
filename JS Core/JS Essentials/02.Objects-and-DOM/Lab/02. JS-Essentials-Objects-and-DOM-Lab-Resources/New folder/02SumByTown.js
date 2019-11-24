function solve(arr) {
    let obj = {};
    for (let i = 0; i < arr.length; i+=2) {
        if(!obj[arr[i]]){
            obj[arr[i]]=+0;
        }
        obj[arr[i]]+=Number(arr[i+1]);
    }

    let myJSON = JSON.stringify(obj);
    console.log(myJSON);
}
solve(['Sofia','20','Varna','3','Sofia','5','Varna','4'])