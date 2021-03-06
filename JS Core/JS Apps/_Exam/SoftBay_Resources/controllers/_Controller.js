const _Controller = function () {
    const getCreate = function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            const firstName = JSON.parse(storage.getData(`userInfo`)).firstName;
            const lastName = JSON.parse(storage.getData(`userInfo`)).lastName;
            context.firstName = firstName;
            context.lastName = lastName;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/_/create_.hbs")
            })
    };

    const postCreate = function (context) {
        helper.notify('loading');
        if(helper.checkNonEmptyString(context.params) && helper.checkValidUrl(context.params)){
            _Model.create_(context.params)
                .then(helper.handler)
                .then(()=>{
                    //notify
                    helper.stopNotify();
                    helper.notify('success', 'You just shared your offer!');
                    context.redirect(`#/offers`);
                    //homeController.getHome(context);
                });
        }
        else if(!helper.checkNonEmptyString(context.params)){
            helper.stopNotify();
            helper.notify('error', 'You must fill all fields');
        }
        else {
            helper.stopNotify();
            helper.notify('error', 'You must add valid picture');
        }


    };

    const getDetails = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;
        //console.log(context);
        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await _Model.get_(context.params.Id);
            let thing = await response.json();
            Object.keys(thing).forEach((key)=>{
                context[key]=thing[key];
            });

            //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/_/details_.hbs")
        });
    };

    const getEdit = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if(loggedIn){
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response =await _Model.get_(context.params.Id);
            let thing = await response.json();

            Object.keys(thing).forEach((key)=>{
                context[key]=thing[key];
            });

            //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
        }

        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial("./views/_/edit_.hbs")
        });
    };

    const postEdit= function (context) {
        helper.notify('loading');
        _Model.edit_(context.params)
            .then(helper.handler)
            .then(()=>{
                //notify
                helper.stopNotify();
                helper.notify('success', 'You just edited your offer!');
                //homeController.getHome(context);
                context.redirect(`#/offers`);
            });
    };

    /*const getMyMovies = async function (context) {
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
             this.partial("./views/movie/user_.hbs")
         })
     };*/

     const getDelete = async function (context) {
         const loggedIn = storage.getData(`userInfo`) !== null;

         if(loggedIn){
             const username = JSON.parse(storage.getData(`userInfo`)).username;
             context.loggedIn = loggedIn;
             context.username = username;

             let response =await _Model.get_(context.params.Id);
             let thing = await response.json();
             Object.keys(thing).forEach((key)=>{
                 context[key]=thing[key];
             });

             //context.isCreator=JSON.parse(storage.getData(`userInfo`)).username===event.organizer;
         }

         context.loadPartials({
             footer: "./views/common/footer.hbs",
             header: "./views/common/header.hbs",
         }).then(function () {
             this.partial("./views/_/delete_.hbs")
         });
     };


    const postDelete=function (context) {
         helper.notify('loading');
         _Model.delete_(context.params.Id)
             .then(helper.handler)
             .then(()=>{
                 //notify
                 helper.stopNotify();
                 helper.notify('success', 'You just deleted your offer!');
                 //homeController.getHome(context);
                 context.redirect(`#/offers`);
             });
     };

    const getOffers = async function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData(`userInfo`)).username;
            context.loggedIn = loggedIn;
            context.username = username;

            try {
                let response = await _Model.getAll();
                context.offers = await response.json();
                //console.log(context.offers);
            }
            catch (e) {
                console.log(e);
            }

            context.loadPartials({
                footer: "./views/common/footer.hbs",
                header: "./views/common/header.hbs"
            })
                .then(function () {
                    this.partial("./views/_/_ViewPage.hbs")
                })
        }
        };

        const getProfile = function (context) {
            const loggedIn = storage.getData(`userInfo`) !== null;

            if (loggedIn) {
                const username = JSON.parse(storage.getData(`userInfo`)).username;
                context.loggedIn = loggedIn;
                context.username = username;

                context.loadPartials({
                    footer: "./views/common/footer.hbs",
                    header: "./views/common/header.hbs"
                })
                    .then(function () {
                        this.partial("./views/_/user_.hbs")
                    })
            }
        };

        return{
            getCreate,
            postCreate,
            getDetails,
            getEdit,
            postEdit,
            getDelete,
            postDelete,
            getOffers,
            getProfile
        }
}();
