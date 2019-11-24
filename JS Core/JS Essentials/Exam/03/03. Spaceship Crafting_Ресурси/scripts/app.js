function spaceshipCrafting() {
    let titaniumCore = Number(document.getElementById(`titaniumCoreFound`).value);
    let aluminiumCore = Number(document.getElementById(`aluminiumCoreFound`).value);
    let magnesiumCore = Number(document.getElementById(`magnesiumCoreFound`).value);
    let carbonCore = Number(document.getElementById(`carbonCoreFound`).value);
    let losses = Number(document.getElementById(`lossesPercent`).value);

    let [availableBars, builtSpaceships] = document.getElementsByTagName(`p`);

    titaniumCore -= titaniumCore * (losses / 400);
    aluminiumCore -= aluminiumCore * (losses / 400);
    magnesiumCore -= magnesiumCore * (losses / 400);
    carbonCore -= carbonCore * (losses / 400);

    let titaniumBar = Math.round(Math.floor(titaniumCore) / 25);
    let aluminiumBar = Math.round(Math.floor(aluminiumCore) / 50);
    let magnesiumBar = Math.round(Math.floor(magnesiumCore) / 75);
    let carbonBar = Math.round(Math.floor(carbonCore) / 100);

    let theUndefinedShip = 0;
    let nullMaster = 0;
    let JSONCrew = 0;
    let falseFleet = 0;

    while (titaniumBar >= 1.9 && aluminiumBar >= 1.9 && magnesiumBar >= 2.9 && carbonBar >= 0.9) {
        //theUndefinedShip	while (7 titanium bars, 9 aluminum bars, 7 magnesium bars, 7 carbon bars)
        if (titaniumBar >= 7 && aluminiumBar >= 9 && magnesiumBar >= 7 && carbonBar >= 7) {
            titaniumBar -= 7;
            aluminiumBar -= 9;
            magnesiumBar -= 7;
            carbonBar -= 7;
            theUndefinedShip++;
        }
        //nullMaster  5 titanium bars, 7 aluminum bars, 7 magnesium bars, 5 carbon bars
        if (titaniumBar >= 5 && aluminiumBar >= 7 && magnesiumBar >= 7 && carbonBar >= 5) {
            titaniumBar -= 5;
            aluminiumBar -= 7;
            magnesiumBar -= 7;
            carbonBar -= 5;
            nullMaster++;
        }

        //JSONCrew 3 titanium bars, 5 aluminum bars, 5 magnesium bars, 2 carbon bars
        if (titaniumBar >= 3 && aluminiumBar >= 5 && magnesiumBar >= 5 && carbonBar >= 2) {
            titaniumBar -= 3;
            aluminiumBar -= 5;
            magnesiumBar -= 5;
            carbonBar -= 2;
            JSONCrew++;
        }

        // falseFleet 2 titanium bars, 2 aluminum bars, 3 magnesium bars, 1 carbon bar
        if (titaniumBar >= 2 && aluminiumBar >= 2 && magnesiumBar >= 3 && carbonBar >= 1) {
            titaniumBar -= 2;
            aluminiumBar -= 2;
            magnesiumBar -= 3;
            carbonBar -= 1;
            falseFleet++;
        }
    }
    let arrBuilt = [];
    availableBars.innerHTML += `${titaniumBar} titanium bars, ${aluminiumBar} aluminum bars, ${magnesiumBar} magnesium bars, ${carbonBar} carbon bars`;

    if (theUndefinedShip > 0) {
        arrBuilt.push(`${theUndefinedShip} THE-UNDEFINED-SHIP`);
    }

    if (nullMaster > 0) {
        arrBuilt.push(`${nullMaster} NULL-MASTER`);
    }

    if (JSONCrew > 0) {
        arrBuilt.push(`${JSONCrew} JSON-CREW`);
    }

    if (falseFleet > 0) {
        arrBuilt.push(`${falseFleet} FALSE-FLEET`);
    }
    builtSpaceships.innerHTML = arrBuilt.join(`, `);
}