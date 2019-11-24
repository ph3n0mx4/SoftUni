const homeController= function () {

    const getHome = function (context) {

        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;

            context.loggedIn = loggedIn;
            context.username = username;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        }).then(function () {
            this.partial("./views/home/home.hbs")
        })
    };

    return{
        getHome
    }
}();