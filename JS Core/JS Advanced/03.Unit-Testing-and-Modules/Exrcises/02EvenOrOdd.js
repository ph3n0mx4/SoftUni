let expect = require(`chai`).expect;

describe(`Tests`,function () {
    it('should return undefined', function () {
        let actual=isOddOrEven(1);
        let expected = undefined;
        expect(actual).to.be.equal(expected);

    });

    it('should return odd', function () {
        let actual=isOddOrEven(`a`);
        let expected = "odd";
        expect(actual).to.be.equal(expected);
    });

    it('should return even', function () {
        let actual=isOddOrEven(`aa`);
        let expected = "even";
        expect(actual).to.be.equal(expected);
    });
});

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}
