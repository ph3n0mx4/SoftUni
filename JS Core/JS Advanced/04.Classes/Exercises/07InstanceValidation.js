class CheckingAccount {
    constructor(clientId, email, firstName, lastName){
        this.clientId=clientId;
        this.email=email;
        this.firstName=firstName;
        this.lastName=lastName;
    }

    get clientId(){
        return this._clientId;
    }

    set clientId(clientId){
        let valid=true;
        let type = typeof clientId;
        for (let i = 0; i <clientId.length; i++) {
            if(!Number(clientId[i])){
                valid=false;
            }
        }
        if(valid && clientId.length===6 && type===`string` ){
            this._clientId=clientId;
        }
        else {
            throw new TypeError(`Client ID must be a 6-digit number`);
        }
    }

    get email(){
        return this._email;
    }

    set email(email){
        let pattern = /[A-Za-z0-9]+@[a-z.]+/gm;
        let match = pattern.test(email);
        if(match){
            this._email=email;
        }
        else {
            throw new TypeError(`Invalid e-mail`);
        }

    }

    get firstName(){
        return this._firstName;
    }

    set firstName(firstName){
        let pattern = /[A-Z][a-z]+/gm;
        let match = pattern.test(firstName);
        if(firstName.length>=3 && firstName.length<=20){
            if(match){
                this._firstName=firstName;
            }
            else {
                throw new TypeError(`First name must contain only Latin characters`);
            }

        }
        else {
            throw new TypeError(`First name must be between 3 and 20 characters long`);
        }

    }

    get lastName(){
        return this._lastName;
    }

    set lastName(lastName){
        let pattern = /[A-Z][a-z]+/gm;
        let match = pattern.test(lastName);
        if(lastName.length>=3 && lastName.length<=20){
            if(match){
                this._firstName=lastName;
            }
            else {
                throw new TypeError(`Last name must contain only Latin characters`);
            }

        }
        else {
            throw new TypeError(`Last name must be between 3 and 20 characters long`);
        }
    }
}

let acc = new CheckingAccount('131455', 'ivan@sad.', 'Iaa', 'P')