let expect = require(`chai`).expect;
let assert = require(`chai`).assert;
//var assert = require('assert');
//https://www.chaijs.com/api/bdd/#method_closeto
//https://www.chaijs.com/api/bdd/

describe(`addFive`,function () {
    it('1should work correctly', function () {
        let actual = mathEnforcer.addFive(1);
        let expected = 6;
        //expect(actual).to.be.equal(expected);
        assert(actual,expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.addFive(1.1);
        let expected = 6.1;
        expect(actual).to.be.equal(expected);
        expect(actual).to.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.addFive(-1);
        let expected = 4;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.addFive(`1`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.addFive({});
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.addFive([1]);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });
});

describe(`subtractTen`,function () {
    it('should work correctly', function () {
        let actual = mathEnforcer.subtractTen(1);
        let expected = -9;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.subtractTen(-1);
        let expected = -11;
        expect(actual).to.be.equal(expected);
    });

    it('2should work correctly', function () {
        let actual = mathEnforcer.subtractTen(10.1);
        let expected = 0.1;
        expect(actual).to.be.closeTo(expected,0.1); //0,1 tochnost
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.subtractTen(`1`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.subtractTen([1]);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.subtractTen({});
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });
});

describe(`sum`,function () {
    it('should work correctly', function () {
        let actual = mathEnforcer.sum(1,2);
        let expected = 3;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.sum(0,0);
        let expected = 0;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.sum(-1,-3);
        let expected = -4;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.sum(-1,5);
        let expected = 4;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.sum(-1.1,5);
        let expected = 3.9;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = mathEnforcer.sum(-1,5.1);
        let expected = 4.1;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.sum(`1`,2);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.sum(1,`2`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined', function () {
        let actual = mathEnforcer.sum(`1`,`2`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });
});

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
