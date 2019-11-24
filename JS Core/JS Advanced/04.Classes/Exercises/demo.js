const Extendable  = (function() {
    class extend {
        constructor() {
            this.id=0;
            this.id++;
        }
    }
    return function() {
        this.id++;
    }
})();

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);

