function attachEventsListeners() {
    let divs = document.getElementsByTagName(`div`);

    let daysBtn = document.getElementById(`daysBtn`);
    let hoursBtn = document.getElementById(`hoursBtn`);
    let minutesBtn = document.getElementById(`minutesBtn`);
    let secondsBtn = document.getElementById(`secondsBtn`);

    let buttons = [daysBtn, hoursBtn, minutesBtn, secondsBtn];

    for (let btn of buttons) {
        btn.addEventListener(`click`, function () {
            let currentDiv = btn.parentNode;
            let input = currentDiv.getElementsByTagName(`input`)[0];
            let typeInput = input.id;
            let inputValue = input.value;
            let days = 0, hours = 0, minutes = 0, seconds = 0;

            if (typeInput === `days`) {
                days = Number(inputValue);
                hours = days * 24;
                minutes = hours * 60;
                seconds = minutes * 60;
            } else if (typeInput === `hours`) {
                hours = Number(inputValue);
                minutes = hours * 60;
                seconds = minutes * 60;
                days = (hours / 24).toFixed(1);
            } else if (typeInput === `minutes`) {
                minutes = Number(inputValue);
                hours = (minutes / 60).toFixed(1);
                days = (hours / 24).toFixed(1);
                seconds = minutes * 60;
            } else if (typeInput === `seconds`) {
                seconds = Number(inputValue);
                minutes = (seconds / 60).toFixed(1);
                hours = (minutes / 60).toFixed(1);
                days = (hours / 24).toFixed(1);
            }

            setValue(days, hours, minutes, seconds, currentDiv);
        });
    }

    function setValue(days, hours, minutes, seconds, currentDiv) {
        for (let div of divs) {
            if (currentDiv !== div) {
                let output = div.getElementsByTagName(`input`)[0];
                if (output.id === `days`) {
                    output.value = days;
                } else if (output.id === `hours`) {
                    output.value = hours;
                } else if (output.id === `minutes`) {
                    output.value = minutes;
                } else if (output.id === `seconds`) {
                    output.value = seconds;
                }

            }
        }
    }
}

