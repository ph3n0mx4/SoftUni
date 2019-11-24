let expect = require(`chai`).expect;

describe(`TestFunc`,function () {
    it('should return true when input is a integers in range', function () {
        let actual =rgbToHexColor(0,255,123);
        let expected = `#00FF7B`;
        expect(actual).to.be.equal(expected);
    });

    describe(`Test red`,function () {
        it('should return undefined when input-red is not in range', function () {
            let actual =rgbToHexColor(-1,255,123);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });

        it('should return undefined when input-red is not in range', function () {
            let actual =rgbToHexColor(256,255,123);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });

        it('should return undefined when input-red is not a integer', function () {
            let actual =rgbToHexColor(`a`,255,123);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });
    });

    describe(`Test blue`,function () {
        it('should return undefined when input-red is not in range', function () {
            let actual =rgbToHexColor(0,255,-1);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });

        it('should return undefined when input-red is not in range', function () {
            let actual =rgbToHexColor(0,255,256);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });

        it('should return undefined when input-red is not a integer', function () {
            let actual =rgbToHexColor(0,255,`a`);
            let expected = undefined;
            expect(actual).to.be.equal(expected);
        });
    });


});
function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}
