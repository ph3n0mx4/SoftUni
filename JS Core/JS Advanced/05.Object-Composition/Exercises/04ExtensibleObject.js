function solve(){
    let obj ={
        //__proto__:{},
        extend: function (template) {
            for (let propertyName of Object.getOwnPropertyNames(template)){
                if(typeof(template[propertyName])===`function`){
                    Object.setPrototypeOf(obj, template);
                }
                else {
                    obj[propertyName]=template[propertyName];
                }
            }
        }
    };


    return obj;
}
let template= {
    extensionMethod: function () {},
    extensionProperty: 'someString'
}

let a =solve();

a.extend(template);
console.log(
    a.extend(template));