const movieModel=function () {
    const createMovie = function (params) {

        let data={
            ...params,
            creator: JSON.parse(storage.getData(`userInfo`)).username
            /*peopleInterestedIn: 0,
            organizer: JSON.parse(storage.getData(`userInfo`)).username*/
        };

        let url =`/appdata/${storage.appKey}/movies`;

        let headers={
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url,headers);
    };

    const getAllMovies=function () {
        let url =`/appdata/${storage.appKey}/movies`;
        let headers = {
            headers:{}
        };

        return requester.get(url,headers);
    };

    const getMovie=function (id) {///appdata/app_id/events?query={"_acl.creator":"${user_id}"}
        let url =`/appdata/${storage.appKey}/movies/${id}`;
        let headers = {
            headers:{}
        };

        return requester.get(url,headers);
    };

    const editMovie=function (params) {

        let url =`/appdata/${storage.appKey}/movies/${params.movieId}`;

        //delete params.movieId;

        let headers = {
            body: JSON.stringify({...params}),
            headers:{}
        };
        return requester.put(url,headers);
    };

    const deleteMovie = function (movieId) {
        let url =`/appdata/${storage.appKey}/movies/${movieId}`;
        let headers = {
            headers:{}
        };
        return requester.del(url,headers);
    };

    const getMyMovies = function (userId) {
        let url =`/appdata/${storage.appKey}/movies?query={"_acl.creator":"${userId}"}`;
        let headers = {
            headers:{}
        };
        return requester.get(url,headers);
    };

    return{
        createMovie,
        getAllMovies,
        getMovie,
        editMovie,
        deleteMovie,
        getMyMovies
    }
}();