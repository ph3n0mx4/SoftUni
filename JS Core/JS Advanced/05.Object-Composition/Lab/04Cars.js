function solve(arr) {
    const car=(function () {
        let cars={};
        return{
            create:(name)=>{
                cars[name]={};
            },
            createInherits:(name,inheritsName)=>{
                cars[name]={};
                Object.setPrototypeOf(cars[name],cars[inheritsName]);
            },
            set: (name,key,value)=>{
                cars[name][key]=value;
            },
            print: (name) =>{
                let result=[];
                for (let a in cars[name]){
                    result.push(`${a}:${cars[name][a]}`);
                }
                //return console.log(result.join(`, `));
                return console.log(cars[name]);

            }
        }
    })();

    for (let cmd of arr){
        let currentCmd=cmd.split(` `);
        if(currentCmd[0]===`create`){
            if(currentCmd[2]===`inherit`){
                car.createInherits(currentCmd[1],currentCmd[3]);
            }else {
                car.create(currentCmd[1]);
            }
        }
        else if(currentCmd[0]===`set`){
            car.set(currentCmd[1],currentCmd[2],currentCmd[3]);
        }
        else if(currentCmd[0]===`print`){
            car.print(currentCmd[1]);
        }
    }

}
solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']);

/*['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']*/








