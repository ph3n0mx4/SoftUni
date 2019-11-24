const storage = function () {

    const appKey=`kid_BJjOQ7RGB`;
    const appSecret=`b3fe4c8f31644617a8c7a9239d58b9e7`;

    const getData=function (key) {
        return localStorage.getItem(key + appKey)
    };
    
    const saveData = function (key,value) {
        localStorage.setItem(key + appKey, JSON.stringify(value));
    };

    const saveUser=function (data) {
        saveData(`userInfo`,data);
        saveData(`authToken`,data._kmd.authtoken);
    };

    const deleteUser = function () {
        localStorage.removeItem(`userInfo` + appKey);
        localStorage.removeItem(`authToken` + appKey);
    };

    return{
        getData,
        saveData,
        saveUser,
        deleteUser,
        appKey,
        appSecret
    }
}();