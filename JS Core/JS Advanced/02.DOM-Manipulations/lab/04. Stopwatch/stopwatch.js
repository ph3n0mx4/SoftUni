function stopwatch() {
    const startBtn = document.getElementById('startBtn');
    const stopBtn = document.getElementById('stopBtn');
    const time = document.getElementById('time');
    let counter;

    function start() {
        startBtn.disabled=true;
        stopBtn.disabled=false;
        time.textContent='00:00';
        let second=0;
        let minutes=0;

        counter = setInterval(()=>{
            second++;

            if(second===60){
                second=0;
                minutes++;
            }

            // eslint-disable-next-line multiline-ternary
            let currentTime= minutes<10 ? `0${minutes}:` : `${minutes}`;
            // eslint-disable-next-line multiline-ternary
            currentTime+= second<10 ? `0${second}` : `${second}`;
            time.textContent=currentTime;

        },1000);
    }
    function stop() {
        clearInterval(counter);
        //time.textContent=`00:00`;
        startBtn.disabled=false;
        stopBtn.disabled=true;

    }

    startBtn.addEventListener('click',start);
    stopBtn.addEventListener('click',stop);
    
}
stopwatch();
const a=5;
let b =66;
