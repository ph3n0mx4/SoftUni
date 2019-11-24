const storage = function () {

    const appKey=`kid_BJjOQ7RGB`;
    const appSecret=`b3fe4c8f31644617a8c7a9239d58b9e7`;

    const getData=function (key) {
        return sessionStorage.getItem(key + appKey)
    };
    
    const saveData = function (key,value) {
        sessionStorage.setItem(key + appKey, JSON.stringify(value));
    };

    const saveUser=function (data) {
        saveData(`userInfo`,data);
        saveData(`authToken`,data._kmd.authtoken);
        saveData(`userId`,data._id);
    };

    const deleteUser = function () {
        sessionStorage.removeItem(`userInfo` + appKey);
        sessionStorage.removeItem(`authToken` + appKey);
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