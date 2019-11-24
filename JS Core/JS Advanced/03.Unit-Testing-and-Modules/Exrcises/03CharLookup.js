let expect = require(`chai`).expect;

describe(`Tests`,function () {
    it('should work correctly', function () {
        let actual = lookupChar(`Asd`,0);
        let expected = `A`;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = lookupChar(`Asd`,2);
        let expected = `d`;
        expect(actual).to.be.equal(expected);
    });

    it('should work correctly', function () {
        let actual = lookupChar(`Asd`,1);
        let expected = `s`;
        expect(actual).to.be.equal(expected);
    });

    it('should return incorrect index when index<0', function () {
        let actual = lookupChar(`Asd`,-1);
        let expected = `Incorrect index`;
        expect(actual).to.be.equal(expected);
    });

    it('should return incorrect index when index>string.length', function () {
        let actual = lookupChar(`Asd`,3);
        let expected = `Incorrect index`;
        expect(actual).to.be.equal(expected);
    });

    it('should return Incorrect index when first parameter is ``', function () {
        let actual = lookupChar(``,0);
        let expected = `Incorrect index`;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined when first parameter is not string', function () {
        let actual = lookupChar({name: `asd`},3);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined when first parameter is not string', function () {
        let actual = lookupChar(3,3);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined when second parameter is not number', function () {
        let actual = lookupChar(`Asd`,3.14);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined when second parameter is not number', function () {
        let actual = lookupChar(`Asd`,`asd`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });

    it('should return undefined when both parameters is not correct type', function () {
        let actual = lookupChar(1,`asd`);
        let expected = undefined;
        expect(actual).to.be.equal(expected);
    });
});
function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}
