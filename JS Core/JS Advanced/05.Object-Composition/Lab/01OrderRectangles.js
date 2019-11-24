function buildRect(width,height) {
    return {
        width,
        height,
        area(){
            return(()=> {this.width*this.height})();
        },
        DcompareTo(rect){
            return rect.area()-this.area() || rect.width-this.width;
        }
    };
}


function solve(input) {
    let rects = [];
    for (let [width, height] of input) {
        let rect = comparator(width, height);
        rects.push(rect);
    }
    rects.sort((a, b) => a.compareTo(b));
    return rects;


    function comparator(w, h) {
        let rect = {
            width: w,
            height: h,
            area: () => rect.width * rect.height,
            compareTo(other) {
                let result = other.area() - rect.area();
                return result || (other.width - rect.width);    }  };  return rect;}

}
console.log(solve([[1,5],[5,12]]));