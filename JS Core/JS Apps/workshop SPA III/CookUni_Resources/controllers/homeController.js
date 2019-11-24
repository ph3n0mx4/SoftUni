const homeController= function () {

    const getHome = async function (context) {

        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;


            context.loggedIn = loggedIn;
            context.username = username;
            const firstName = JSON.parse(storage.getData(`userInfo`)).firstName;
            const lastName = JSON.parse(storage.getData(`userInfo`)).lastName;
            context.firstName = firstName;
            context.lastName = lastName;
            try {
                let response = await _Model.getAll();
                context.recipes= await response.json();
            }
            catch (e) {
                console.log(e);
            }
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
            movieView: "./views/_/_ViewPage.hbs"
        }).then(function () {
            this.partial("./views/home/homePage.hbs")
        })
    };

    return{
        getHome
    }
}();