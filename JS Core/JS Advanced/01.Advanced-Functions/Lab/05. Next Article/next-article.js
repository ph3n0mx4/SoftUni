function getArticleGenerator(input) {
    let content = document.getElementById(`content`);

    return function () {
        if(input.length>0){
            let p = document.createElement(`p`);
            p.textContent=input.shift();

            let article = document.createElement(`article`);
            article.appendChild(p);
            content.appendChild(article);
        }
    }
}