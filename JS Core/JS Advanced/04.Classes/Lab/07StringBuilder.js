class StringBuilder {
    constructor(string) {
        if (string !== undefined) {
            StringBuilder._vrfyParam(string);
            this._stringArray = Array.from(string);
        } else {
            this._stringArray = [];
        }
    }

    append(string) {
        StringBuilder._vrfyParam(string);
        for(let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }

    prepend(string) {
        StringBuilder._vrfyParam(string);
        for(let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }

    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }

    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }

    toString() {
        return this._stringArray.join('');
    }
}

let expect = require(`chai`).expect;
let assert = require(`chai`).assert;

describe(`StringBuilder`,function () {

    let stringBuilder ;

    beforeEach(function () {
        stringBuilder = new StringBuilder();
    });



    it('should work correctly without passed parameter', function () {
        const expected = '';
        const actual = stringBuilder.toString();

        assert.equal(actual, expected);
    });

    it('should throw error when append array', function () {
        assert.throw(() => {
            stringBuilder.append([]);
        },`Argument must be string`);
    });

    it('should throw error when append array', function () {
        //let sb=new StringBuilder([]);
        assert.throw(() => {
            new StringBuilder([]);
        },`Argument must be string`);
    });

    it(`should append string`, function () {
        stringBuilder.append(`aa`);
        let actual = stringBuilder.toString();
        let expexted=`aa`;

        expect(actual).to.be.equal(expexted);
    });


    it(`should add string when create new StringBuilder`, function () {
        let sb=new StringBuilder(`aa`);
        let expexted=`aa`;

        expect(sb.toString()).to.be.equal(expexted);
    });

    it(`create new StringBuilder without add string`, function () {
        let sb=new StringBuilder();
        let expexted=``;

        expect(sb.toString()).to.be.equal(expexted);
    });


    it(`should add string beginning of the storage - 1`, function () {
        stringBuilder.append(`aa`);
        stringBuilder.prepend(`bb`);
        let actual = stringBuilder.toString();
        let expexted=`bbaa`;

        expect(actual).to.be.equal(expexted);
    });


    it('should throw error when prepend array', function () {
        stringBuilder.append(`aa`);
        assert.throw(() => {
            stringBuilder.prepend([]);
        },`Argument must be string`);
    });


    it(`should insert string at the given index`, function () {
        stringBuilder.append(`aa`);
        stringBuilder.insertAt(`bb`,1);
        let actual = stringBuilder.toString();
        let expexted=`abba`;

        expect(actual).to.be.equal(expexted);
    });

    it('should throw error when insert array at the given index', function () {
        stringBuilder.append(`aa`);
        assert.throw(() => {
            stringBuilder.insertAt([],1);
        },`Argument must be string`);
    });

    it(`should remove string at the given index and length`, function () {
        stringBuilder.append(`javascript`);
        stringBuilder.remove(4,6);
        let actual = stringBuilder.toString();
        let expexted=`java`;

        expect(actual).to.be.equal(expexted);
    });

    it('should throw error when use remove operation', function () {
        stringBuilder.append(`aaaaa`);
        stringBuilder.remove(2,6);
        let actual = stringBuilder.toString();
        let expexted=`aa`;

        expect(actual).to.be.equal(expexted);
    });

    it(`should test all functionality`, function () {
        stringBuilder.append(`zxc`);
        stringBuilder.prepend(`qwe`);
        stringBuilder.insertAt(`asd`,3);
        stringBuilder.remove(0,3);
        let actual = stringBuilder.toString();
        let expexted=`asdzxc`;
        //qwe asd zxc
        expect(actual).to.be.equal(expexted);
    });

    it('should have the correct function properties', function () {
        assert.isFunction(StringBuilder.prototype.append);
        assert.isFunction(StringBuilder.prototype.prepend);
        assert.isFunction(StringBuilder.prototype.insertAt);
        assert.isFunction(StringBuilder.prototype.remove);
        assert.isFunction(StringBuilder.prototype.toString);
    });
});

