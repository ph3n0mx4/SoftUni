function calc(inSteps, inLength,inSpeed) {
    let speed = inSpeed*(1000/3600);
    let totalLength = inSteps*inLength;
    let breaks = (Math.floor(totalLength/500))*60;

    let totalSecond = breaks + totalLength/speed;

    let hours = Math.floor(totalSecond/3600);
    if(hours===0)
    {
        hours='00';
    }
    else if(hours<10)
    {
        hours='0'+hours;
    }

    let seconds = Math.round( totalSecond%60);

    let minutes = Math.floor(totalSecond/60);
    if(minutes===0)
    {
        hours='00';
    }
    else if(minutes<10)
    {
        minutes='0'+minutes;
    }

    let result = `${hours}:${minutes}:${seconds}`;
    console.log(result);
}

calc(4000, 0.60, 5);
calc(2564, 0.70, 5.5);