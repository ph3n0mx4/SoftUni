function f(input = 5) {
    for (let i = 1; i <=input ; i++) {
        console.log('*'.repeat(input).split('').join(' '));
    }
}

f();