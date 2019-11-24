class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory=ramMemory;
        this.cpuGHz=cpuGHz;
        this.hddMemory=hddMemory;
        this.taskManager=[];
        this.installedPrograms=[];
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
        if(currentProgram.length===0){
            throw new Error(`Control panel is not responding`);
        }

        let hddMemoryPr=currentProgram[0].requiredSpace;
        let index=this.installedPrograms.indexOf(currentProgram);
        this.installedPrograms.splice(index,1);
        this.hddMemory+=hddMemoryPr;

        return this.installedPrograms;
    }
}

let a = new Computer(512,1.2,80);
a.installAProgram(`1`,10);
a.installAProgram(`2`,20);
a.installAProgram(`3`,30);
//a.uninstallAProgram(`1`)
console.log(a.hddMemory);
console.log(a.uninstallAProgram(`1`));
console.log(a.hddMemory);
