class Vacation {
    constructor(organizer, destination, budget){
        this.organizer=organizer;
        this.destination=destination;
        this.budget=budget;
        this.kids={};

    }

    registerChild(name, grade, budget){
        if(budget>=this.budget ){
            if(!this.kids.hasOwnProperty(grade)){
                this.kids[grade]=[];
                this.kids[grade].push(`${name}-${budget}`);
                return this.kids[grade];
            }
            else if(this.kids[grade].find(x=>x.includes(name))){
                return `${name} is already in the list for this ${this.destination} vacation.`;
            }
            this.kids[grade].push(`${name}-${budget}`);
            return this.kids[grade];
        }
        return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
    }

    removeChild(name, grade){
        if(this.kids.hasOwnProperty(grade)){
            if(this.kids[grade].find(x=>x.includes(name))){
                let child = this.kids[grade].find(x=>x.includes(name));
                let index = this.kids[grade].indexOf(child);
                if(index>-1){
                    this.kids[grade].splice(index,1);
                    return this.kids[grade];
                }

            }
        }
        return `We couldn't find ${name} in ${grade} grade.`;
    }

    get numberOfChildren(){
        this._numberOfChildren = 0;

        for (const grade in this.kids) {
            this._numberOfChildren += this.kids[grade].length;
        }

        return this._numberOfChildren;
        //return Object.entries(this.kids).reduce((a,b)=>a[1].length+b[1].length);
    }

    toString(){
        let result=``;
        if(this.numberOfChildren>0){
            result +=`${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

            for (let grade of Object.entries(this.kids).sort((a,b)=>a[0]-b[0])) {
                result+=`Grade: ${grade[0]}\n`;
                let count=1;
                for (let kid of grade[1]){
                    result+=`${count++}. ${kid}\n`;
                }
            }
        }
        else {
            result +=`No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        }
        return result;
    }
}

let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
console.log(vacation.registerChild('Gosho', 5, 2000));
console.log(vacation.registerChild('posho', 5, 2000));
//console.log(vacation.removeChild('posho', 5, 2000));
console.log(vacation.registerChild('Mosho', 5, 2000));
console.log(vacation.registerChild('Ivan', 6, 2000));
console.log(vacation.registerChild('AZZ', 6, 2000));
console.log(vacation.numberOfChildren);
console.log(vacation.toString());
