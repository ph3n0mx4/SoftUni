function solve(obj) {
    let methodP=[`GET`, `POST`, `DELETE`, `CONNECT`];
    let regexUri = RegExp(/^([0-9a-zA-Z.]+)$/g);
    let versionP =[`HTTP/0.9`, `HTTP/1.0`, `HTTP/1.1`, `HTTP/2.0`];
    let regexMsg=RegExp(/^[^<>\\\&\'\"]+$/);

//let a = obj.method;
    if(obj.method && methodP.includes(obj.method)){
        if(obj.uri && (regexUri.test(obj.uri) || obj.uri===`*` )){
            if(obj.version && versionP.includes(obj.version)){
                if((obj.message && regexMsg.test(obj.message)) || obj.message===`` || obj.message===null){
                    return obj;
                }

                throw new Error(`Invalid request header: Invalid Message`);
            }
            throw new Error(`Invalid request header: Invalid Version`);
        }
        throw new Error(`Invalid request header: Invalid URI`);
    }
    throw new Error(`Invalid request header: Invalid Method`);


    /**let regex = RegExp(/[0-9a-zA-Z.:\/ \-\%\*]+/);
    console.log(regexUri.test(str));**/
}
console.log(solve({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: 'asl<pls'
    }

));

