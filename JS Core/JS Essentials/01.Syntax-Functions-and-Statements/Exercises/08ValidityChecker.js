function solve(arr) {
    let x1 = arr[0];
    let y1 = arr[1];
    let x2 = arr[2];
    let y2 = arr[3];

    function check(x1,y1,x2,y2)
    {
        let dist=Math.sqrt(Math.pow(x1-x2,2)+Math.pow(y1-y2,2));
        let result;
        if(Number.isInteger(dist))
        {
            result=`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`;
        }

        else
        {
            result=`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`;
        }
        console.log(result);
    }

    check(x1,y1,0,0);
    check(x2,y2,0,0);
    check(x1,y1,x2,y2);

}

solve([3, 0, 0, 4]);