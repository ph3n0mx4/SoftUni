const homeController= function () {

    const getHome = async function (context) {

        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;

            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getAllMovies();
                context.movies= await response.json();
            }
            catch (e) {
                console.log(e);
            }
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
            movieView: "./views/movie/movieViewPage.hbs"
        }).then(function () {
            this.partial("./views/home/homePage.hbs")
        })
    };

    return{
        getHome
    }
}();