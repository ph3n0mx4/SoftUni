function getData() {
    let textArea = JSON.parse(document.getElementsByTagName(`textarea`)[0].value);

    let [peopleIn, blackList, peopleOut] = document.getElementsByTagName(`p`);
    let criteria = textArea.pop();

    let criteriaName = criteria.criteria;
    let criteriaAction = criteria.action;

    let peoplesIN = [];
    let peoplesOUT = [];
    let peoplesBL = [];
    for (let person of textArea) {
        let action = person.action;
        if (action === `peopleIn`) {
            delete person.action;
            //peopleIn.innerHTML+=`{"firstName":"${person.firstName}","lastName":"${person.lastName}"} `;
            if (!peoplesBL.find(x => x.firstName === person.firstName && x.lastName === person.lastName)) {
                peoplesIN.push(person);
            }

        } else if (action === `peopleOut`) {
            delete person.action;
            if (peoplesIN.find(x => x.firstName === person.firstName && x.lastName === person.lastName)) {
                peoplesOUT.push(person);
                peoplesIN = peoplesIN.filter(x => x.firstName !== person.firstName && x.lastName !== person.lastName)
            }


        } else if (action === `blacklist`) {
            if (peoplesIN.find(x => x.firstName === person.firstName && x.lastName === person.lastName)) {
                peoplesOUT.push(person);
                peoplesIN = peoplesIN.filter(x => x.firstName !== person.firstName && x.lastName !== person.lastName)
            }
            /*else if(peoplesOUT.find(x=>x.firstName===person.firstName && x.lastName===person.lastName)){
                peoplesBL.push(person);
                peoplesOUT =peoplesOUT.filter(x=>x.firstName!==person.firstName && x.lastName!==person.lastName)
            }*/

            peoplesBL.push(person);

        }
    }

    if (criteria !== `` && criteriaAction !== `` && criteriaAction === `peopleIn`) {
        peoplesIN = comparef(peoplesIN, criteriaName);
    } else if (criteria !== `` && criteriaAction !== `` && criteriaAction === `peopleOUT`) {
        peoplesOUT = comparef(peoplesOUT, criteriaName);
    } else if (criteria !== `` && criteriaAction !== `` && criteriaAction === `blacklist`) {
        peoplesBL = comparef(peoplesBL, criteriaName);
    }

    peoplesIN.forEach(x => {
        peopleIn.textContent += `{"firstName":"${x.firstName}","lastName":"${x.lastName}"} `;
    })
    peoplesOUT.forEach(x => {
        peopleOut.textContent += `{"firstName":"${x.firstName}","lastName":"${x.lastName}"} `;
    })
    peoplesBL.forEach(x => {
        blackList.textContent += `{"firstName":"${x.firstName}","lastName":"${x.lastName}"} `;
    })


    function comparef(peoples, name) {
        if (name === `lastName`) {
            let arr = peoples.sort((a, b) => a.lastName.localeCompare(b.lastName));
            return arr;
        } else if (name === `firstName`) {
            let arr = peoples.sort((a, b) => a.firstName.localeCompare(b.firstName));
            return arr;
        }

    }


}

