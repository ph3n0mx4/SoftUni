const userController = function () {

    const getRegister=function (context) {
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/user/registerPage.hbs")
            })
    };

    const getLogin=function (context) {
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/user/loginPage.hbs")
            })
    };

    const postRegister=function (context) {

        helper.notify('loading');
        if(helper.checkPassword(context.params) &&  helper.checkNonEmpty(context.params)){
            userModel.register(context.params)
                .then(helper.handler)
                .then(data=>{
                    storage.saveUser(data);
                    //notify
                    helper.stopNotify();
                    helper.notify('success', 'You just registered!');
                    //homeController.getHome(context);
                    context.redirect("#/home");
                })
        }
        else if(!helper.checkPassword(context.params)){
            helper.stopNotify();
            helper.notify('error', 'Wrong password');
        }
        else {
            helper.stopNotify();
            helper.notify('error', 'You must fill all fields');
        }

    };

    const postLogin=function (context) {
        helper.notify('loading');
        userModel.login(context.params).then(helper.handler)
            .then(data=>{
                storage.saveUser(data);
                //notify
                helper.stopNotify();
                helper.notify('success', 'You just logged in!');
                //homeController.getHome(context);
                context.redirect("#/home");
            });
    };

    const logout =function (context) {
        helper.notify('loading');
        userModel.logout()
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify('success', 'You just logged out!');
                storage.deleteUser();
                //homeController.getHome(context);
                context.redirect("#/home");
            })
    };

    const getProfile=function (context) {
        const loggedIn = storage.getData(`userInfo`) !== null;
        if (loggedIn) {
            context.username = JSON.parse(storage.getData(`userInfo`)).username;
        }
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/_/user_.hbs")
            })
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
        getProfile
    }
}();