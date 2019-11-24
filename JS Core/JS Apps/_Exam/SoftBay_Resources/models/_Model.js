const _Model=function () {
    const create_ = function (params) {

        let data={
            ...params,
            creator: JSON.parse(storage.getData(`userInfo`)).username,
            //peopleInterestedIn: 0,
            //organizer: JSON.parse(storage.getData(`userInfo`)).username
        };

        let url =`/appdata/${storage.appKey}/offers`;

        let headers={
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url,headers);
    };

    const getAll=function () {
        let url =`/appdata/${storage.appKey}/offers`;
        let headers = {
            headers:{}
        };

        return requester.get(url,headers);
    };

    const get_=function (id) {///appdata/app_id/events?query={"_acl.creator":"${user_id}"}
        let url =`/appdata/${storage.appKey}/offers/${id}`;
        let headers = {
            headers:{}
        };

        return requester.get(url,headers);
    };

    const edit_=function (params) {

        let data={
            ...params,
            creator: JSON.parse(storage.getData(`userInfo`)).username
        };
        let url =`/appdata/${storage.appKey}/offers/${params.Id}`;
        delete params.Id;

        let headers = {
            body: JSON.stringify(data),
            headers:{}
        };
        return requester.put(url,headers);
    };

    const delete_ = function (Id) {
        let url =`/appdata/${storage.appKey}/offers/${Id}`;
        let headers = {
            headers:{}
        };
        return requester.del(url,headers);
    };

    /*const getMyMovies = function (userId) {
        let url =`/appdata/${storage.appKey}/movies?query={"_acl.creator":"${userId}"}`;
        let headers = {
            headers:{}
        };
        return requester.get(url,headers);
    };*/

    return{
        create_,
        getAll,
        get_,
        edit_,
        delete_,
        //getMyMovies
    }
}();