function loadCommits() {
    let username=document.getElementById(`username`).value;
    let repository=document.getElementById(`repo`).value;
    let url =`https://api.github.com/repos/${username}/${repository}/commits`;
    document.getElementById(`commits`).textContent=``;
    fetch(url)
        .then(response=>{
            if(response.status>300){
                throw new Error(`Error: ${response.status} (${response.statusText})`)
            }
            return response;
        })
        .then(response=>response.json())
        .then(data=>{

           for (let currentDate of data){
               let li = document.createElement(`li`);
               li.textContent=`${currentDate.commit.author.name}: ${currentDate.commit.message}`;
               document.getElementById(`commits`).appendChild(li);
           }
        }).catch(err=>{
        let li = document.createElement(`li`);
        li.textContent=err.message;
        document.getElementById(`commits`).appendChild(li);
    });

}