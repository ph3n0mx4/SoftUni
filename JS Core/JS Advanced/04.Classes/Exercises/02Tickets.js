function solve(input,sort) {
    class Ticket {
        constructor(destination,price,status){
            this.destination=destination;
            this.price=price;
            this.status=status;
        }

        toString(){
            return `Ticket { destination: ${this.destination},price: ${this.price},status: ${this.status} }`;
        }
    }

    let tickets=[];
    for (let token of input){
        let arr = token.split(`|`);
        let destination = arr[0];
        let price = Number(arr[1]);
        let status=arr[2];
        let ticket = new Ticket(destination,price,status);
        tickets.push(ticket);
    }

    if(sort===`destination`){
        return tickets.sort((a,b)=>a.destination.localeCompare(b.destination));
    }
    else if(sort===`price`){
        return tickets.sort((a,b)=>a.price-b.price);
    }
    else if(sort===`status`){
        return tickets.sort((a,b)=>a.status.localeCompare(b.status));
    }

    console.log(tickets.join(`\n`).toString());
}




solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
);
console.log();
solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
)