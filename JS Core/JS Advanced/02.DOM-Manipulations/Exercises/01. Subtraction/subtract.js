function subtract() {
    let firstInput = document.getElementById(`firstNumber`).value;
    let secondInput = document.getElementById(`secondNumber`).value;
    let result = document.getElementById(`result`);
    result.textContent=(Number(firstInput)-Number(secondInput));
}