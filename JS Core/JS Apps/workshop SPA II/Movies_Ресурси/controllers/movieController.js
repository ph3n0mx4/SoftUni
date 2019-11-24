
const movieController = function () {
    const getCreateMovie = function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/movie/createMovie.hbs")
            })
    };

    const postCreateMovie = function (context) {
        movieModel.createMovie(context.params)
            .then(helper.handler)
            .then(()=>{
                //notify
                context.redirect(`#/home`);
                //homeController.getHome(context);
            });
    };

    const getDetailsMovie = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;
        //console.log(context);
        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;
            
            let response =await movieModel.getMovie(context.params.movieId);
            let movie = await response.json();
            Object.keys(movie).forEach((key)=>{
                context[key]=movie[key];
            });

            //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/movie/detailsMovie.hbs")
        });
    };

    const getMyMovies = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;
        const username = JSON.parse(storage.getData(`userInfo`)).username;
        const userId = JSON.parse(storage.getData(`userInfo`))._id;

        context.myMovies =``;
        if(loggedIn){

            //let creator =
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getMyMovies(userId);
                context.myMovies = await response.json();
            }
            catch (e) {
                console.log(e);
            }
        }
        //console.log(context.myMovies);
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/movie/userMovies.hbs")
        })
    };

    const getEditMovie = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await movieModel.getMovie(context.params.movieId);
            let movie = await response.json();
            Object.keys(movie).forEach((key)=>{
                context[key]=movie[key];
            });

            //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/movie/editMovie.hbs")
        });
    };

    const postEditMovie= function (context) {

        movieModel.editMovie(context.params)
            .then(helper.handler)
            .then(()=>{
                //notify
                //homeController.getHome(context);
                context.redirect(`#/home`);
            });
    };

    const getDeleteMovie = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await movieModel.getMovie(context.params.movieId);
            let movie = await response.json();
            Object.keys(movie).forEach((key)=>{
                context[key]=movie[key];
            });

            //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/movie/deleteMovie.hbs")
        });
    };

    const postDeleteMovie=function (context) {
        movieModel.deleteMovie(context.params.movieId)
            .then(helper.handler)
            .then(()=>{
                //notify
                //homeController.getHome(context);
                context.redirect(`#/home`);
            });
    };
    return{
        getCreateMovie,
        postCreateMovie,
        getDetailsMovie,
        getEditMovie,
        postEditMovie,
        getDeleteMovie,
        postDeleteMovie,
        getMyMovies
    }
}();
