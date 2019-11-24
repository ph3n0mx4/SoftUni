const PaymentPackage = require('./08PaymentPackage');

let expect = require(`chai`).expect;
let assert = require(`chai`).assert;

describe(`PaymentPackageTests`, function () {
    describe(`constructor`,function () {

        it('c-tor work correctly when initialize', function () {
            paymentPackage = new PaymentPackage(`HR`, 1500);
            let actual = [paymentPackage.name, paymentPackage.value,paymentPackage.active, paymentPackage.VAT];
            let expected=[`HR`,1500,true,20];
            for (let i = 0; i <actual.length ; i++) {
                assert.equal(actual[i],expected[i]);
            }
        });

    });

    describe(`name`,function () {
        let paymentPackage ;
        beforeEach(function () {
            paymentPackage = new PaymentPackage(`HR`, 1500);
        });

        it('should get correct name', function () {
            let actual = paymentPackage.name;
            let expected =`HR`;
            assert.equal(actual,expected);
        });

        it('should set correct name', function () {
            let actual = paymentPackage.name=`Consultation`;
            let expected =`Consultation`;
            assert.equal(actual,expected);
        });

        it('should throw error for incorrect type name', function () {
            assert.throw(() => {
                paymentPackage.name=1;
            },`Name must be a non-empty string`);
        });

        it('should throw error for empty string name', function () {
            assert.throw(() => {
                paymentPackage.name=``;
            },`Name must be a non-empty string`);
        });
    });

    describe(`value`,function () {
        let paymentPackage ;
        beforeEach(function () {
            paymentPackage = new PaymentPackage(`HR`, 1500);
        });

        it('should get correct value', function () {
            let actual = paymentPackage.value;
            let expected =1500;
            assert.equal(actual,expected);
        });

        it('should set correct value', function () {
            let actual = paymentPackage.value=20;
            let expected =20;
            assert.equal(actual,expected);
        });

        it('should set correct value equal to 0', function () {
            let actual = paymentPackage.value=0;
            let expected =0;
            assert.equal(actual,expected);
        });

        it('should throw error for incorrect type value', function () {
            assert.throw(() => {
                paymentPackage.value=``;
            },`Value must be a non-negative number`);
        });

        it('should throw error for negative number value', function () {
            assert.throw(() => {
                paymentPackage.value=-1;
            },`Value must be a non-negative number`);
        });
    });

    describe(`VAT`,function () {
        let paymentPackage ;
        beforeEach(function () {
            paymentPackage = new PaymentPackage(`HR`, 1500);
        });

        it('should get correct VAT', function () {
            let actual = paymentPackage.VAT;
            let expected =20;
            assert.equal(actual,expected);
        });

        it('should set correct VAT', function () {
            let actual = paymentPackage.VAT=21;
            let expected =21;
            assert.equal(actual,expected);
        });

        it('should set correct VAT equal to 0', function () {
            let actual = paymentPackage.VAT=0;
            let expected =0;
            assert.equal(actual,expected);
        });

        it('should throw error for incorrect type VAT', function () {
            assert.throw(() => {
                paymentPackage.VAT=``;
            },`VAT must be a non-negative number`);
        });

        it('should throw error for negative number VAT', function () {
            assert.throw(() => {
                paymentPackage.VAT=-1;
            },`VAT must be a non-negative number`);
        });
    });

    describe(`active`,function () {
        let paymentPackage ;
        beforeEach(function () {
            paymentPackage = new PaymentPackage(`HR`, 1500);
        });

        it('should get correct active', function () {
            let actual = paymentPackage.active;
            let expected =true;
            assert.equal(actual,expected);
        });

        it('should set correct active', function () {
            let actual = paymentPackage.active=false;
            let expected =false;
            assert.equal(actual,expected);
        });

        it('should throw error for incorrect type active', function () {
            assert.throw(() => {
                paymentPackage.active=``;
            },`Active status must be a boolean`);
        });
    });

    it('should correct toString()', function () {
        let paymentPackage = new PaymentPackage(`HR`, 1500);
        let actual = paymentPackage.toString();
        let expected =`Package: HR\n`;
        expected +=`- Value (excl. VAT): 1500\n`;
        expected +=`- Value (VAT 20%): 1800`;
        assert.equal(actual,expected);
    });

    it('should correct toString()', function () {
        let paymentPackage = new PaymentPackage(`HR`, 1500);
        paymentPackage.active=false;
        let actual = paymentPackage.toString();
        let expected =`Package: HR (inactive)\n`;
        expected +=`- Value (excl. VAT): 1500\n`;
        expected +=`- Value (VAT 20%): 1800`;
        assert.equal(actual,expected);
    });

});

//assert.isFunction(StringBuilder.prototype.append);