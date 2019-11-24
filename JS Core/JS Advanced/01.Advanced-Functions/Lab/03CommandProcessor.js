function solve() {
    let str = ``;

    function append(string) {
        str +=string;
        //console.log(str);
    }
    function removeStart(n) {
        str=str.substring(n);
        //console.log(str);
    }
    function removeEnd(n) {
        str=str.substring(0,str.length-n);
        //console.log(str);
    }
    function print() {
        console.log(str);
    }

    return{
        append,
        removeStart,
        removeEnd,
        print
    };
};

let secondZeroTest = solve();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();


