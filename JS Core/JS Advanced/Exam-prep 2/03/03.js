class Hotel {
    constructor (name,capacity){
        this.name=name;
        this.capacity=capacity;
        this.bookings=[];
        this.currentBookingNumber=1;

        this.roomsCount={
                single:Math.round(this.capacity*0.5),
                double:Math.round(this.capacity*0.3),
                maisonette:this.capacity-(Math.round(this.capacity*0.5)+Math.round(this.capacity*0.3))
        };
        this.roomsPricing={
            single:50,
            double:90,
            maisonette:135
        };
        this.servicesPricing={
            food:10,
            drink:15,
            housekeeping:25
        };
    }

    rentARoom(clientName,roomType,nights){
        if(this.roomsCount[roomType]>0){
            let client= {
                clientName,
                roomType,
                nights,
                roomNumber:this.currentBookingNumber++
            };
            this.roomsCount[roomType]-=1;
            this.bookings.push(client);
            return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${client.roomNumber}.`
        }
        else {
            let output=[];
            output.push(`No ${roomType} rooms available!`);
            let keys=Object.keys(this.roomsCount).filter(x=>x!==roomType);
            for (const key of keys){
                output.push(`Available ${key} rooms: ${this.roomsCount[key]}.`)
            }
            return output.join(` `);
        }
    }

    roomService(currentBookingNumber,serviceType){
        let currentRoom = this.bookings.filter(x=>x.roomNumber===currentBookingNumber);//ARRAY !!!
        if(currentRoom.length===0){
            return `The booking ${currentBookingNumber} is invalid.`
        }

        if(!this.servicesPricing[serviceType]){
            return `We do not offer ${serviceType} service.`
        }

        if(!currentRoom[0].hasOwnProperty(`services`)){
            currentRoom[0][`services`]=[];
        }
        currentRoom[0][`services`].push(serviceType);
        return `Mr./Mrs. ${currentRoom[0].clientName}, Your order for ${serviceType} service has been successful.`;
    }

    checkOut(currentBookingNumber){
        let currentRoom = this.bookings.filter(x=>x.roomNumber===currentBookingNumber);//ARRAY !!!
        if(currentRoom.length===0){
            return `The booking {currentBookingNumber} is invalid.`
        }
        let nights=+currentRoom[0][`nights`];
        let priceRoom=this.roomsPricing[currentRoom[0].roomType];
        let totalMoney=+nights*+priceRoom;
        //console.log(moneyForRoom);
        let totalServiceMoney=0;
        if(currentRoom[0].hasOwnProperty(`services`)){
            for (let service of currentRoom[0][`services`]) {
                totalServiceMoney+=this.servicesPricing[service]
            }
            return `We hope you enjoyed your time here, Mr./Mrs. ${currentRoom[0].clientName}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing {totalServiceMoney} BGN.`
        }

        return `We hope you enjoyed your time here, Mr./Mrs. ${currentRoom[0].clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`


    }

    report(){

    }

}
/*let hotel = new Hotel(`softuni`,30);
hotel.rentARoom(`Ivan`,`single`,2);
hotel.rentARoom(`Dragan`,`double`,5);
hotel.roomService(1,`food`);
hotel.checkOut(1);*/
/*
console.log(hotel.roomsCount.single);
console.log(hotel.currentBookingNumber);*/
//console.log(hotel.bookings);

/*let hotel = new Hotel('HotUni', 10);
console.log(hotel.rentARoom('Peter', 'single', 4));
console.log(hotel.rentARoom('Robert', 'double', 4));
console.log(hotel.rentARoom('Geroge', 'maisonette', 6));
console.log(hotel.bookings)*/

let hotel = new Hotel('HotUni', 10);
hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);
console.log(hotel.roomService(3, 'housekeeping'));
console.log(hotel.roomService(3, 'drink'));
console.log(hotel.roomService(2, 'room'));
console.log(hotel.bookings);

