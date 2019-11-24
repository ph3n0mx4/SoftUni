const homeController= function () {

    const getHome = async function (context) {

        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;

            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await eventModel.getAllEvents();
                context.events= await response.json();
            }
            catch (e) {
                console.log(e);
            }
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
            eventView: "./views/event/eventViewPage.hbs"
        }).then(function () {
            this.partial("./views/home/homePage.hbs")
        })
    };

    return{
        getHome
    }
}();