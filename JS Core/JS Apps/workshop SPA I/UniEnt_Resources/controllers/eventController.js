const eventController = function () {

    const getCreateEvent = function (context) {
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
                this.partial("./views/event/createEvent.hbs")
            })
    };

    const postCreateEvent = function (context) {
        //console.log(context.params);
        eventModel.createEvent(context.params)
            .then(helper.handler)
            .then(()=>{
                //notify
                homeController.getHome(context);
            });
    };

    const getDetailsEvent = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await eventModel.getEvent(context.params.eventId);
            let event = await response.json();
            Object.keys(event).forEach((key)=>{
                context[key]=event[key];
            });

            context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }


        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/event/detailsEvent.hbs")
        });


    };

    const getEditEvent = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await eventModel.getEvent(context.params.eventId);
            let event = await response.json();
            Object.keys(event).forEach((key)=>{
                context[key]=event[key];
            });

            context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }


        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/event/editEvent.hbs")
        });
    };

    const postEditEvent= function (context) {

        eventModel.editEvent(context.params)
            .then(helper.handler)
            .then(()=>{
                //notify
                homeController.getHome(context);
            });
    };

    const postDeleteEvent=function (context) {
        eventModel.deleteEvent(context.params.eventId)
            .then(helper.handler)
            .then(()=>{
                //notify
                homeController.getHome(context);
            });
    };
    return{
        getCreateEvent,
        postCreateEvent,
        getDetailsEvent,
        getEditEvent,
        postEditEvent,
        postDeleteEvent
    }
}();