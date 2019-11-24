function calculate(a, b, operator) {
    let calc = function (a, b, operator) {
        return operator(a,b);
    }

    let add = function (a,b) {
        return a+b;
    }
    let subtract = function (a,b) {
        return a-b;
    }
    let multiply = function (a,b) {
        return a*b;
    }
    let divide = function (a,b) {
        return a/b;
    }

    let result;

    switch (operator) {
        case '+': result = calc(a,b, add); break;
        case '-': result = calc(a,b,subtract); break;
        case '*': result = calc(a,b,multiply); break;
        case '/': result = calc(a,b,divide); break;
    }

    console.log(result);
}

(calculate(2,-1,'*'));