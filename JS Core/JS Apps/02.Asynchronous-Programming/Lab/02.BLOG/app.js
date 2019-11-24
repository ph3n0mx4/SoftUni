function attachEvents() {
    let baseUrl = `https://blog-apps-c12bf.firebaseio.com/`;
    let baseData=``;

    document.getElementById(`btnLoadPosts`).addEventListener(`click`,function () {
        let postsUrl = baseUrl+`/posts.json`;
        fetch(postsUrl)
            .then(response=>response.json())
            .then(data=>{
                baseData=data;
                for(let currentData in data){
                    let id = currentData;
                    let title = data[currentData].title;
                    let option =document.createElement(`option`);
                    option.value=id;
                    option.textContent=title;
                    document.getElementById(`posts`).appendChild(option);

                }
            })
    });

    document.getElementById(`btnViewPost`).addEventListener(`click`,function () {
        document.getElementById(`post-comments`).textContent=``;
        document.getElementById(`post-body`).textContent=``;
        let currentKey =document.getElementById(`posts`).value;
        document.getElementById(`post-title`).textContent=baseData[currentKey].title;
        document.getElementById(`post-body`).textContent=baseData[currentKey].body;
        let id = baseData[currentKey].id;

        let commentsUrl=baseUrl+`/comments.json`;
        fetch(commentsUrl)

            .then(response=>response.json())
            .then(data=>{
                let values = Object.values(data);
                for (let value of values){
                    if(id===value.postId){
                        let li =document.createElement(`li`);
                        li.textContent=value.text;
                        //console.log(value.text)
                        document.getElementById(`post-comments`).appendChild(li);
                    }
                }
            })
    });

}

attachEvents();