function solve() {
    let rightAnsCount=Number(3);
    let questionCount =1;
    let rightAns=['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

    function result() {
        let h1Result=document.getElementsByTagName('h1')[1];

        if(rightAnsCount===3){
            h1Result.textContent='You are recognized as top JavaScript fan!';
        }

        else {
            h1Result.textContent=`You have ${rightAnsCount} right answers`;
        }
    }

    let answers = Array.from(document.getElementsByClassName('answer-text'));
    for (let i = 0; i <answers.length; i++) {
        let ans=answers[i];
        ans.addEventListener('click', function event(){

            if(rightAns[questionCount-1]!==ans.textContent){
                rightAnsCount--;
            }

            let section1 = document.getElementById('quizzie').children[questionCount];
            section1.style.display='none';
            let section2 = document.getElementById('quizzie').children[questionCount+1];
            section2.style.display='block';

            questionCount++;

            if (questionCount>3){
                result();

            }
        });
    }
}
