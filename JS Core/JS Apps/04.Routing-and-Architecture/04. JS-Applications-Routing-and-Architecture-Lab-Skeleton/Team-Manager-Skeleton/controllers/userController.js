const userController = function () {

    const getRegister=function (context) {
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/register/registerPage.hbs")
            })
    };

    const getLogin=function (context) {
        context.loadPartials({
            footer: "./views/common/footer.hbs",
            header: "./views/common/header.hbs"
        })
            .then(function () {
                this.partial("./views/login/loginPage.hbs")
            })
    };

    const postRegister=function (context) {
        userModel.register(context.params)
            .then(helper.handler)
            .then(data=>{
                storage.saveUser(data);
                //notify
                homeController.getHome(context);
            })
    };

    const postLogin=function (context) {
        userModel.login(context.params).then(helper.handler)
            .then(data=>{
                storage.saveUser(data);
                //notify
                homeController.getHome(context);
            });
    };

    const logout =function (context) {

        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                homeController.getHome(context);
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