class List {
    constructor(){
        this.arrayList=[];
        this.size=this.arrayList.length;
    }

    add(num){
        this.arrayList.push(Number(num));
        this._sort();
    }

    remove(index){
        if(index>=0 && index<this.size){
            this.arrayList.splice(index,1);
            this._sort();
        }
    }

    get(index){
        if(index>=0 && index<this.size) {
            return this.arrayList[index];
        }
    }

    _sort(){
        this.arrayList.sort((a,b)=>a-b);
        this.size=this.arrayList.length;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);

console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
