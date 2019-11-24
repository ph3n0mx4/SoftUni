
function deleteByEmail() {
    let input = document.getElementsByName(`email`)[0];
    let result = document.getElementById(`result`);

    let rows =document.querySelectorAll(`#customers tr td:last-child`);
    //console.log(rows.length);
    let rowToDelete = Array.from(rows).find((row)=>row.textContent===input.value);
    input.value=``;

    if(rowToDelete){
        let row = rowToDelete.parentNode;
        row.parentNode.removeChild(row);
        result.textContent="Deleted.";
    }else {
        result.textContent="Not found.";
    }
}
/*
function deleteByEmail() {
    const SELECTORS = {
        TABLE_ROWS: '#customers tr td:last-child',
        MESSAGE: 'result',
        EMAIL: 'email',
    };

    const message = document.getElementById(SELECTORS.MESSAGE);
    deleteByEmail1();

    function getEmail() {
        return document.getElementsByName(SELECTORS.EMAIL)[0].value;
    }
    function deleteByEmail1() {
        const rows = document.querySelectorAll(SELECTORS.TABLE_ROWS);
        const email = getEmail();
        const rowToDelete = Array.from(rows).find(row => row.textContent == email);

        if (rowToDelete) {
            let row = rows[0].parentNode;
            row.parentNode.removeChild(row);
            message.textContent = "Deleted.";
        } else {Not found
            message.textContent = ".";
        }
    }
}
*/