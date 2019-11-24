let expect = require(`chai`).expect;

describe(`createCalculator Tests`, function () {
    describe(`add Tests`, function () {
        it(`should return 1 when add 1`, function () {
            let calc =createCalculator();
            calc.add(1);
            let actual = calc.get();
            let expected = 1;
            expect(actual).to.be.equal(expected);
        });

        it(`should return 1 when add '1'`, function () {
            let calc =createCalculator();
            calc.add(`1`);
            let actual = calc.get();
            let expected = 1;
            expect(actual).to.be.equal(expected);
        });

        it(`should return NaN when add a`, function () {
            let calc =createCalculator();
            calc.add(`a`);
            let actual = calc.get().toString();
            let expected = `NaN`;
            expect(actual).to.be.equal(expected);
        });
    });

    describe(`subtract Tests`, function () {
        it(`should return 1 when subtract 1`, function () {
            let calc =createCalculator();
            calc.add(2);
            calc.subtract(1);
            let actual = calc.get();
            let expected = 1;
            expect(actual).to.be.equal(expected);
        });

        it(`should return 1 when subtract '1'`, function () {
            let calc =createCalculator();
            calc.add(2);
            calc.subtract(`1`);
            let actual = calc.get();
            let expected = 1;
            expect(actual).to.be.equal(expected);
        });

        it(`should get NaN when add a`, function () {
            let calc =createCalculator();
            calc.subtract(`a`);
            let actual = calc.get().toString();
            let expected = `NaN`;
            expect(actual).to.be.equal(expected);
        });
    });

    describe(`get Tests`, function () {
        it(`should return 0 when don't add or subtract`, function () {
            let calc =createCalculator();
            let actual = calc.get();
            let expected = 0;
            expect(actual).to.be.equal(expected);
        });
    });
});
function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}
