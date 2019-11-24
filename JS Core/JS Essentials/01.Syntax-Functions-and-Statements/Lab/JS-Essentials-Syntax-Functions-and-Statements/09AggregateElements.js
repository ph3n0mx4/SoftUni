function aggregateElements(elements) {

    aggregate(elements,0,(a,b)=>a+b);
    aggregate(elements,0,(a,b)=>a+1/b);
    aggregate(elements,'',(a,b)=>a+b);
    function aggregate(arr, accumulator, func) {
        for (let i = 0; i < arr.length; i++) {
            accumulator=func(accumulator,arr[i]);
        }
        return console.log(accumulator);
    }
}

aggregateElements([1,2,3])

