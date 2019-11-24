function solve() {

    let table = document.getElementsByTagName('tbody')[0]
        .getElementsByTagName('tr');
    let searchField = document.getElementById('searchField');
    let searchBtn = document.getElementById('searchBtn');

    searchBtn.addEventListener('click', function () {
        let text = searchField.value;
        searchField.value='';
        for (let row of table)
        {
            row.removeAttribute('class');
            if(row.textContent.includes(text)){
                row.classList.add('select');
            }
        }

    })

}