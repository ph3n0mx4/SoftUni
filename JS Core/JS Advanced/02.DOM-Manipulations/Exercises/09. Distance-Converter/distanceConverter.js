function attachEventsListeners() {
    let input = document.getElementById(`inputDistance`);
    let output = document.getElementById(`outputDistance`);
    let btn = document.getElementById(`convert`);

    btn.addEventListener(`click`,function () {
        let selectInput = document.getElementById(`inputUnits`).value;
        let selectOutput = document.getElementById(`outputUnits`).value;
        let distance = {km:1000, m:1, cm:0.01, mm:0.001, mi:1609.34, yrd:0.9144, ft:0.3048, in:0.0254};
        let unitIn =distance[selectInput];
        let unitOut = distance[selectOutput];

        output.value=(input.value)*unitIn/unitOut;
    });
}