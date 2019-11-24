let expect = require(`chai`).expect;
//const sum = require('./sum');

it(`should return 3 for [1,2]`, function () {
    let expectedSum =3;
    let actualSum=sum([1,2]);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return 1 for [1]`, function () {
    let expectedSum =1;
    let actualSum=sum([1]);
    expect(actualSum).to.be.equal(expectedSum);
});

it(`should return 0 for []`, function () {
    let expectedSum =0;
    let actualSum=sum([]);
    expect(actualSum).to.be.equal(expectedSum);
});


function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

