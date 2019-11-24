
function solve(arr) {

    const module = (function () {
        let storage=[];
        return{
            add: (input)=>{
                storage.push(input);
            },
            remove: (input)=>{
                storage=storage.filter(x=>x!==input);
            },
            print: ()=>{
                console.log(storage.join(`,`));
            }
        }
    })();

    for (let a of arr){
        let b = a.split(` `);
        if(b[0]===`add`){
            module.add(b[1]);
        }
        else if(b[0]===`remove`){
            module.remove(b[1]);
        }
        else if(b[0]===`print`){
            module.print();
        }
    }
};

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
