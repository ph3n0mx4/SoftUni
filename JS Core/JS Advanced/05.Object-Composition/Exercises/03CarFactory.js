function solve(obj) {
    let engines =[
            { power: 90, volume: 1800,},
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 }
];

    let carriages =[
            { type: 'hatchback', color:obj.color },
            { type: 'coupe', color:obj.color }
    ];

    let inches=obj.wheelsize%2!==0? obj.wheelsize : obj.wheelsize-1;
    let wheels=[];
    for (let i = 0; i < 4; i++) {
        wheels.push(inches);
    }
    return{
        model: obj.model,
        engine: engines.filter((e)=>e.power>=obj.power)[0],
        carriage: carriages.filter((c)=>c.type===obj.carriage)[0],
        wheels: wheels
    }
}

console.log(
solve({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }));
/*{ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }*/


/*{ model: 'VW Golf II',
    engine: { power: 90,
    volume: 1800 },
    carriage: { type: 'hatchback',
        color: 'blue' },
    wheels: [13, 13, 13, 13] }*/
