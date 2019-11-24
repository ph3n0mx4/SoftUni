function solve(name, age, weight, height) {

    let person ={
        name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: 0,
        status: ``
    };

    let bmi =Math.round((weight)/((height/100)**2));
    //bmi=bmi.toFixed(0);
    if(bmi<18.5){
        person[`status`]=`underweight`;
    }
    else if(bmi<25){
        person[`status`]=`normal`;
    }
    else if(bmi<30){
        person[`status`]=`overweight`;
    }
    else if(bmi>=30){
        person[`status`]=`obese`;
        person[`recommendation`]=`admission required`;

    }
    person[`BMI`]=bmi;
    //console.log(person.name);
    //console.log(person);
    //console.log(person.name===name);
    return person;
}

solve(`Peter`, 29, 75, 182);
console.log();
solve(`Honey Boo Boo`, 9, 57, 137);
/*{ name: 'Peter',
    personalInfo: {
    age: 29,
        weight: 75,
        height: 182
}
    BMI: 23
    status: 'normal' }*/
