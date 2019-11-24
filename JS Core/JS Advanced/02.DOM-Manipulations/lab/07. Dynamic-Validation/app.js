function validate() {
    let input = document.getElementById(`email`);
    input.addEventListener(`change`,checkInput);

    function checkInput(){
        let pattern = (/[a-z]+@[a-z]+.[a-z]+/g);
        let match = pattern.test(input.value);

        if(!match){
            input.classList.add(`error`);
        }else {
            input.classList.remove(`error`);
        }


    }

}