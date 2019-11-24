class Circle {
    constructor(radius){
        this.raduis=radius;
    }

    get radius() {
        return this.raduis;
    }
    get diameter(){
        return 2*this.raduis;
    }

    set diameter(diameter){
        this.raduis=diameter/2;
    }

    get area(){
        return Math.PI*(this.raduis**2);
    }
}

let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
