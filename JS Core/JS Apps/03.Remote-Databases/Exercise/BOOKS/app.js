const kinveyUsername=`guest`;
const kinveyPassword=`guest`;
const appKey = `kid_S1lwGJgzr`;
const appSecret = `66019c6a39d5474da5c4a262e3f86be2`;

const baseUrl=`https://baas.kinvey.com/appdata/${appKey}/books`;
const elements ={
    btnSubmit: document.getElementById(`submitBtn`),
    btnLoadBooks: document.getElementById(`loadBooks`),

    inputTitle: document.getElementById(`title`),
    inputAuthor: document.getElementById(`author`),
    inputIsbn: document.getElementById(`isbn`),
    tBodyBooks:document.getElementById(`tbodybooks`)
};

elements.btnSubmit.addEventListener(`click`,addBooks);
elements.btnLoadBooks.addEventListener(`click`,loadBooks);

function addBooks(ev) {
    ev.preventDefault();

    let title = elements.inputTitle.value;
    let author=elements.inputAuthor.value;
    let isbn = elements.inputIsbn.value;

    elements.inputTitle.value=``;
    elements.inputAuthor.value=``;
    elements.inputIsbn.value=``;
    const currentObject={title,author,isbn};

    const headers={
        method:`POST`,
        body: JSON.stringify(currentObject),
        credentials: `include`,
        Authorization: `Basic` + btoa(`${kinveyUsername}:${kinveyPassword}`),
        headers:{
            'Content-type':`application/json`
        }
    };

    fetch(baseUrl,headers)
        .then(handler)
        .then(loadBooks)
        .catch(err=>console.log(err));
}

function deleteBook(bookId) {
    let currentUrl=baseUrl+`/`+bookId;
    const headers={
        method: `DELETE`,
        credentials: `include`,
        Authorization: `Kinvey `+ localStorage.getItem(`authToken`),
        headers: {
            "Content-Type":"application/json"
        }
    };

    fetch(currentUrl,headers)
        .then(handler)
        .then(loadBooks)
        .catch(err=>console.log(err));
}

function loadBooks() {
    const headers ={
        credentials: `include`,
        Authorization: `Kinvey `+ localStorage.getItem(`authToken`)
    };

    fetch(baseUrl,headers)
        .then(handler)
        .then(data=>{
            elements.tBodyBooks.textContent=``;
            data.forEach(book=>{
                let trBook=document.createElement(`tr`);
                trBook.setAttribute(`id`,book._id);

                trBook.innerHTML=`<td>${book.title}</td>
                <td>${book.author}</td>
                <td>${book.isbn}</td>
                <td>
                    <button class=btnEdit value=${book._id}>Edit</button>
                    <button class=btnDelete value=${book._id}>Delete</button>
                </td>`;



                trBook.getElementsByClassName(`btnEdit`)[0]
                    .addEventListener(`click`,() => editBook(book._id));

                trBook.getElementsByClassName(`btnDelete`)[0]
                    .addEventListener(`click`,() => deleteBook(book._id));
                elements.tBodyBooks.appendChild(trBook);
            });


            /*let row = elements.tBodyBooks.children[0].cloneNode(true);
            elements.tBodyBooks.textContent=``;
            for (let obj of data){
                let rowClone=row.cloneNode(true);
                rowClone.children[0].textContent=obj.title;
                rowClone.children[1].textContent=obj.author;
                rowClone.children[2].textContent=obj.isbn;
                elements.tBodyBooks.appendChild(rowClone);
            }*/
        })
        .catch(err=>console.error(err));
}

function editBook(bookId) {
    let currentUrl=baseUrl+`/`+bookId;
    let currentEditBook={
        title: elements.inputTitle.value,
        author: elements.inputAuthor.value,
        isbn: elements.inputIsbn.value,
    };

    clearElementValue(elements.inputTitle,elements.inputAuthor,elements.inputIsbn);

    const headers={
        method: `PUT`,
        body: JSON.stringify(currentEditBook),
        credentials: `include`,
        Authorization: `Kinvey `+ localStorage.getItem(`authToken`),
        headers: {
            "Content-Type":"application/json"
        }
    };

    fetch(currentUrl,headers)
        .then(handler)
        .then(loadBooks)
        .catch(err=>console.log(err));
}

function handler(response) {
    if(response.status>400){
        throw new Error(`Something went wrong. Error: ${response.statusText}`);
    }
    return response.json();
}
function clearElementValue(...arguments) {
    arguments.forEach(el=>{
        el.value=``;
    });
}

