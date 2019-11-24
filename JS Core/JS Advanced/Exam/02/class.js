class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory=ramMemory;
        this.cpuGHz=cpuGHz;
        this.hddMemory=hddMemory;
        this.taskManager=[];
        this.installedPrograms=[];

        this.totalRamUsage=0;
        this.totalCPUUsage=0
    }

    installAProgram(name, requiredSpace){
        if(this.hddMemory-requiredSpace<0){
            throw new Error(`There is not enough space on the hard drive`);
        }

        let newProgram = {name,requiredSpace};
        this.installedPrograms.push((newProgram));
        this.hddMemory-=requiredSpace;
        return newProgram;
    }

    uninstallAProgram(name){
        //let currentRoom = this.bookings.filter(x=>x.roomNumber===currentBookingNumber);//ARRAY !!!
        let currentProgram=this.installedPrograms.filter(x=>x.name===name);
        if(currentProgram.length<=0){
            throw new Error(`Control panel is not responding`);
        }

        let hddMemoryPr=currentProgram[0].requiredSpace;
        let index = this.installedPrograms.findIndex(x=>x.name===name);
        this.installedPrograms.splice(index,1);
        this.hddMemory+=hddMemoryPr;

        return this.installedPrograms;
    }

    openAProgram(name){
        let currentProgram=this.installedPrograms.filter(x=>x.name===name);
        if(currentProgram.length<=0){
            throw new Error(`The ${name} is not recognized`);
        }
        let currentOpenProgram=this.taskManager.filter(x=>x.name===name);
        if(currentOpenProgram.length>=1){
            throw new Error(`The ${name} is already open`);
        }
//(programRequiredSpace / totalRamMemory) * 1.5
        //( ( programRequiredSpace / CPU GHz ) / 500) * 1.5

        let ramUsage=(currentProgram[0].requiredSpace/this.ramMemory)*1.5;
        let cpuUsage=((currentProgram[0].requiredSpace/this.cpuGHz)/500)*1.5;

        if(this.totalRamUsage+ramUsage>=100 &&this.totalCPUUsage+cpuUsage>=100){
            throw new Error(`${name} caused out of memory exception`);
        }
        if(this.totalRamUsage+ramUsage>=100){
            throw new Error(`${name} caused out of memory exception`);
        }
        if(this.totalCPUUsage+cpuUsage>=100){
            throw new Error(`${name} caused out of cpu exception`);
        }

        let openedProgram={name, ramUsage, cpuUsage};

        this.taskManager.push(openedProgram);
        return openedProgram;
    }

    taskManagerView(){
        if(this.taskManager.length===0){
            return "All running smooth so far";
        }
        let result=``;
        for (let i = 0; i < this.taskManager.length; i++) {
            let p = this.taskManager[i];
            if(i===this.taskManager.length-1){
                result+=`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%`
            }else {
                result+=`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%\n`
            }

        }
        /*for (let p of this.taskManager){
            result+=`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%\n`
        }*/

        return result;
    }
}

/*let a = new Computer(512,1.2,80);
a.installAProgram(`1`,10);
a.installAProgram(`2`,20);
a.installAProgram(`3`,30);
//a.uninstallAProgram(`1`)
console.log(a.hddMemory);
console.log(a.openAProgram(`2`));
console.log(a.hddMemory);*/

/*let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.uninstallAProgram('Word');
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Excel');
computer.openAProgram('Solitare');*/

/*let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());*/

