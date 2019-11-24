(function () {
    String.prototype.ensureStart = function(str){
        if(!this.startsWith(str)){
            return str+this;
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function(str){
        if(!this.endsWith(str)){
            return this+str;
        }
        return this.toString();
    };

    String.prototype.isEmpty = function(){
        if(this){
            return true;
        }
        return false;
    };

    String.prototype.truncate = function(n){
        if(this.length<=n){
            return this;
        }
        else if(this.length>n){
            if(this.includes(` `)){
                let currentIndex=this.lastIndexOf(` `);
                return this.slice(0,n-3) + `...`;
            }
            else {
                if(this.length>3){
                    return this.slice(0,n-3) + `...`;
                }else {
                    return `...`.slice(n);
                }
            }
        }
    };

    String.prototype.isEmpty = function(){
        if(this){
            return true;
        }
        return false;
    };
})();
//•	ensureEnd(str)
let str = 'my string';
str = str.ensureStart('my');
str = str.ensureEnd(' strs');
console.log(str);
