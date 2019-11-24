function encodeAndDecodeMessages() {
    let input = document.getElementsByTagName(`textarea`)[0];
    let output = document.getElementsByTagName(`textarea`)[1];

    let encodeAndSendIt = document.getElementsByTagName(`button`)[0];
    let decodeAndReadIt = document.getElementsByTagName(`button`)[1];

    encodeAndSendIt.addEventListener(`click`,function () {
        let inputValue = input.value;
        input.value=``;
        let result = ``;
        for (let i = 0; i < inputValue.length; i++) {
            let num = inputValue.charCodeAt(i)+1;
            result+=String.fromCharCode(num);
        }
        output.value=result;
    });

    decodeAndReadIt.addEventListener(`click`,function () {
        let outputValue = output.value;
        let result = ``;
        for (let i = 0; i < outputValue.length; i++) {
            let num = outputValue.charCodeAt(i)-1;
            result+=String.fromCharCode(num);
        }
        output.value=result;
    });
}