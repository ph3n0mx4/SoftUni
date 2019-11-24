function solve(input) {
    let ATM =[];

    for (let i = 0; i < input.length; i++) {
        let cmd = input[i];

        if(cmd.length>2){
            cmd.forEach(x=>ATM.push(x));
            let insertedCash = cmd.reduce((a,b)=>a+b,0);
            let totalCashInATM = ATM.reduce((a,b)=>a+b,0);

            console.log(`Service Report: ${insertedCash}$ inserted. Current balance: ${totalCashInATM}$.`);
        }

        else if(cmd.length===2){

            let currentBalance =cmd[0];
            let forWithdraw =cmd[1];
            let totalCashInATM = ATM.reduce((a,b)=>a+b,0);

            if(currentBalance<forWithdraw){
                console.log(`Not enough money in your account. Account balance: ${currentBalance}$.`);
            }
            else if(forWithdraw>totalCashInATM){
                console.log(`ATM machine is out of order!`);
            }
            else {
                ATM.sort((a,b)=>b-a)
                let difference = currentBalance-forWithdraw;
                for (let j = 0; j < ATM.length; j++) {
                    if(ATM[j]<=forWithdraw && currentBalance>difference){
                        currentBalance-=ATM[j];
                        forWithdraw-=ATM[j];
                        ATM[j]=0;
                    }
                    if(currentBalance===difference){
                        j=ATM.length-1;
                    }
                }
                ATM.sort((a,b)=>b-a);
                let index =ATM.indexOf(0);
                ATM=ATM.slice(0,index+1);
                console.log(`You get ${cmd[1]}$. Account balance: ${currentBalance}$. Thank you!`)
            }
        }

        else {
            let banknote=cmd[0];
            let banknoteCount=0;
            ATM.forEach((x)=>{
                if(x===banknote){
                    banknoteCount++;
                }
            })
            console.log(`Service Report: Banknotes from ${banknote}$: ${banknoteCount}.`)
        }
    }
}

solve([[20, 5, 100, 20, 1],
        [457, 25],
        [1],
        [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
        [20, 85],
        [5000, 4500],
    ]
);