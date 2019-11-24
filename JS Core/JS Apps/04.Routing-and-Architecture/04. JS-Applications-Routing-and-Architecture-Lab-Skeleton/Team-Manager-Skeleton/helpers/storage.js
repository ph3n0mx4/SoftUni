const storage = function () {

    const appKey=`kid_Sk_OwiwfB`;
    const appSecret=`8158c3599af84f5499ddc5638aa2f6b7`;

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