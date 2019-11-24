function solve(arr) {
    let objs=[];
    for (let i = 1; i < arr.length; i++) {
        let currentRow = arr[i].split(/\s*\|\s*/).filter(x=>x);

        let obj = {Town: currentRow[0], Latitude:+currentRow[1], Longitude:+currentRow[2]};
        //obj[col1]=currentRow[i].trim();
        objs.push(obj)
    }

    console.log(JSON.stringify(objs));
}
solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
)