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
        //helper.notify(`loading`);
        userModel.register(context.params)
            .then(helper.handler)
            .then(data=>{
                //helper.stopNotify();
                //helper.notify(`success`,`You just logged-in`);
                storage.saveUser(data);
                //notify
                //homeController.getHome(context);
                context.redirect("#/home");
            })
    };

    const postLogin=function (context) {
        //helper.notify(`loading`);
        userModel.login(context.params).then(helper.handler)
            .then(data=>{
                /*helper.stopNotify();
                helper.notify(`success`,`You was registred successfully`);*/
                storage.saveUser(data);
                //notify
                //homeController.getHome(context);
                context.redirect("#/home");
            });
    };

    const logout =function (context) {

        userModel.logout()
            .then(helper.handler)
            .then(() => {
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