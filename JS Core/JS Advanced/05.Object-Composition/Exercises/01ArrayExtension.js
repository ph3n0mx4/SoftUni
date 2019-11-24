function solve(arr) {
    const arrExt=(function () {
        return {
            last: ()=>{
                return arr[arr.length-1];
            },
            skip: (n)=>{
                return arr.slice(n);
            },
            take: (n)=>{
                return arr.slice(0,n);
            },
            sum: ()=>{
                return arr.reduce((a,b)=>a+b);
            },
            average: ()=>{
                return (this.sum())/arr.length;
            }
        }
    })();
}

(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        return this.slice(n);
    };

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    };

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    };

    Array.prototype.average = function () {
        return this.sum() / this.length;
    };
})();

let arr = [1,2,3];

console.log(arr.sum());

solve()