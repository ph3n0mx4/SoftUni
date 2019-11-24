let expect = require(`chai`).expect;
let assert = require(`chai`).assert;
const PizzUni = require('./02. PizzUni_Ресурси').PizzUni;

describe('tests', function () {
    let a;
    beforeEach(() => {
        a = new PizzUni();
    });
    describe('constructor', function () {
        it('constructor registerUsers', function () {
            expect(a.registeredUsers).to.eql([]);
        });

        it('constructor orders', function () {
            expect(a.orders).to.eql([]);
        });

        it('constructor availableProducts[pizzas]', function () {
            expect(a.availableProducts.pizzas).to.eql(['Italian Style', 'Barbeque Classic', 'Classic Margherita']);
        });

        it('constructor availableProducts[drinks]', function () {
            expect(a.availableProducts.drinks).to.eql(['Coca-Cola', 'Fanta', 'Water']);
        });
    });

    describe('registerUser', function () {
        it('should register new user', function () {
            let actual =a.registerUser(`asd`);
            let expected = a.registeredUsers[0];
            expect(actual).to.eql(actual);
        });

        it('should register new user create order history', function () {
            let actual =a.registerUser(`asd`).orderHistory;
            //let expected = a.registeredUsers[0].orderHistory;
            expect(actual).to.eql([]);
        });

        it('should throw error for existing email', function () {
            let actual =a.registerUser(`asd`);
            expect(()=>a.registerUser(`asd`)).to.throw(`This email address (asd) is already being used!`);
        });
    });

    describe('makeAnOrder', function () {
        it('throw error for not registred user', function () {

            expect(()=>a.makeAnOrder(`asd`,`Classic Margherita`)).to.throw(`You must be registered to make orders!`);
        });

        it('throw error for not existing pizza', function () {
            let actual =a.registerUser(`asd`);
            expect(()=>a.makeAnOrder(`asd`,`Classic`)).to.throw(`You must order at least 1 Pizza to finish the order.`);
        });

        it('successful make order ', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            let expected = { orderedPizza: 'Classic Margherita',
                orderedDrink: 'Fanta',
                email: 'asd',
                status: 'pending' };
            expect(a.orders[index]).to.eql(expected);
        });

        it('successful make order ', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`);
            let expected = { orderedPizza: 'Classic Margherita',
                email: 'asd',
                status: 'pending' };
            expect(a.orders[index]).to.eql(expected);
        });

        it('successful make order 2', function () {
            let v =a.registerUser(`asd`);
            let actual = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            let expected = 0;
            expect(actual).to.equal(expected);
        });

        it('successful order in userhistory', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            let expected = { orderedPizza: 'Classic Margherita',
                orderedDrink: 'Fanta'};
            expect(a.registeredUsers[0].orderHistory[0]).to.eql(expected);
        });
    });

    describe('complete order', function () {
        it('should work correctly', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            a.completeOrder();
            let expected = { orderedPizza: 'Classic Margherita',
                orderedDrink: 'Fanta',
                email: 'asd',
                status: 'completed' };
            expect(a.orders[index]).to.eql(expected);
        });
    });

    describe('details order', function () {
        it('order pending', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            let actual = a.detailsAboutMyOrder(index);
            let expected=`Status of your order: pending`
            expect(actual).to.be.equal(expected);
        });

        it('order pending', function () {
            let v =a.registerUser(`asd`);
            let index = a.makeAnOrder(`asd`,`Classic Margherita`,`Fanta`);
            a.completeOrder();
            let actual = a.detailsAboutMyOrder(index);
            let expected=`Status of your order: completed`
            expect(actual).to.be.equal(expected);
        });
    });

    describe('doesTheUserExist', function () {
        it('should ', function () {
            let v =a.registerUser(`asd`); //{ email: 'asd', orderHistory: [] }
            let actual = a.doesTheUserExist(`asd`);
            let expected={ email: 'asd', orderHistory: [] };
            expect(actual).to.eql(expected);
        });

        it('should 2', function () {
            let v =a.registerUser(`asd`); //{ email: 'asd', orderHistory: [] }
            let actual = a.doesTheUserExist(`1`);
            let expected={ email: 'asd', orderHistory: [] };
            expect(actual).to.eql(undefined);
        });
    });
});

