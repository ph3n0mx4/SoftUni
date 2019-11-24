function roadRadar(arr) {
    let speed = arr[0];
    let area = arr[1];

    if(area==='motorway')
    {
        motorway(speed);
    }

    else if(area ==='interstate')
    {
        interstate(speed);
    }

    else if(area ==='city')
    {
        city(speed);
    }

    else if(area ==='residential')
    {
        residential(speed);
    }

    function motorway (speed) {
        determining(speed,130);
    }

    function interstate(speed) {
        determining(speed,90);
    }

    function city(speed) {
        determining(speed,50);
    }

    function residential(speed) {
        determining(speed,20);
    }

    function determining(speed,limit) {

        let result='';
        if(speed>limit && speed-limit<=20)
        {
            result = 'speeding';
        }

        else if(speed-limit<=40 && speed-limit>20)
        {
            result = 'excessive speeding';
        }

        else if(speed>limit)
        {
            result ='reckless driving';
        }

        console.log(result);
    }
}

//roadRadar(['135','motorway'])

