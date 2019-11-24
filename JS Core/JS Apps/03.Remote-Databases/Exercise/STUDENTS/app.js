window.addEventListener(`load`,loading);

const kinveyUsername=`guest`;
const kinveyPassword=`guest`;
const appKey = `kid_S1lwGJgzr`;
const appSecret = `66019c6a39d5474da5c4a262e3f86be2`;

const baseUrl=`https://baas.kinvey.com/appdata/${appKey}/students`;

function loading() {
    const headers ={
        credentials: `include`,
        Authorization: `Kinvey `+ localStorage.getItem(`authToken`)
    };

    fetch(baseUrl,headers)
        .then(handler)
        .then(data=>{
            data.sort((a,b)=>a.ID-b.ID);

            data.forEach(student=>{
                let trStudent=document.createElement(`tr`);
                trStudent.innerHTML=`<td>${student.ID}</td>
                <td>${student.FirstName}</td>
                <td>${student.LastName}</td>
                <td>${student.FacultyNumber}</td>
                <td>${student.Grade}</td>`;

                document.getElementsByTagName(`tbody`)[0].appendChild(trStudent);
            });

        })
        .catch(err=>console.error(err));

}

function handler(response) {
    if(response.status>400){
        throw new Error(`Something went wrong. Error: ${response.statusText}`);
    }
    return response.json();
}
