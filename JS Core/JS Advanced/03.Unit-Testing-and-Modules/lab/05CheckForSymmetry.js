let expect = require(`chai`).expect;

it(`should return true for [1,2,1]`, function () {
    let expectedSum =true;
    let actualSum=isSymmetric([1,2,1]);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return false for [1,2,3]`, function () {
    let expectedSum =false;
    let actualSum=isSymmetric([1,2,3]);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return false for 1,2,1`, function () {
    let expectedSum =false;
    let actualSum=isSymmetric(1,2,1);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return false for string`, function () {
    let expectedSum =false;
    let actualSum=isSymmetric(`abc`);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return false for {}`, function () {
    let expectedSum =false;
    let actualSum=isSymmetric({});
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return false for 4`, function () {
    let expectedSum =false;
    let actualSum=isSymmetric(4);
    expect(actualSum).to.be.equal(expectedSum);
});

it('should return true when input array has elements of different types', function () {
    const inputArray = [1, 'text', {name: 'John'}, false, {name: 'John'}, 'text', 1];

    const expected = true;
    const actual = isSymmetric(inputArray);
    expect(actual).to.be.equal(expected);

});


function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}
