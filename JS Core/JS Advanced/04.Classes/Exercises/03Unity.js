function solve() {
    class Rat{
        constructor(name){
            this.name=name;
            this.otherRats=[];
        }

        unite(otherRat){
            if(otherRat instanceof Rat){
                this.otherRats.push(otherRat);
            }

        }

        getRats(){
            return this.otherRats;
        }

        toString(){
            let result =`${this.name}\n`;
            this.otherRats.forEach(r=>result+=`##${r.name}\n`);
            return result;
        }
    }

    let firstRat = new Rat("Peter");
    //firstRat.name+=`1`;
    //console.log(firstRat instanceof Rat);
    console.log(firstRat.toString()); // Peter

    console.log(firstRat.getRats()); // []

    firstRat.unite(new Rat("George"));
    firstRat.unite(new Rat("Alex"));
    console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

    console.log(firstRat.toString());
// Peter
// ##George
// ##Alex

}

solve();