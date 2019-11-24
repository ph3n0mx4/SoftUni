class Stringer {
    constructor(string,length){
        this.innerString=string;
        this.innerLength=length;
    }

    get innerString(){
        return this._string;
    }

    set innerString(string){
            this._string=string;

    }

    get innerLength(){
        return this._length;
    }

    set innerLength(length){
        if(length<0){
            this._length=0;
        }
        else {
            this._length=length;
        }

    }

    increase(length){
        this.innerLength+=length;
    }

    decrease(length){
        if(this.innerLength-length<0){
            this.innerLength=0;
        }
        else {
            this.innerLength-=length;
        }

    }

    toString(){
        let result;
        if(this.innerLength<=0) {
            result = `...`;
        }
        else  if(this.innerLength<this.innerString.length){
                let currentString = this.innerString.slice(0,this.innerLength)
                result = `${currentString}...`
        }
        else if(this.innerLength>=this.innerString.length){
            return`${this.innerString}`;
        }

        return result;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
