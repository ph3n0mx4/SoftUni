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
        if(helper.checkPassword(context.params)){
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
        else {
            helper.stopNotify();
            helper.notify('error', 'Wrong password');
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

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout
    }
}();