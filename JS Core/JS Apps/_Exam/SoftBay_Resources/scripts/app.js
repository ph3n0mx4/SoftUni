const app = Sammy("#container", function () {
    this.use(`Handlebars`,`hbs`);
    //Home
    this.get(`#/home`,homeController.getHome);

    //User
    this.get(`#/register`,userController.getRegister);
    this.get(`#/login`, userController.getLogin);

    this.get(`#/logout`,userController.logout);

    this.get(`#/profile`,userController.getProfile);

    this.post(`#/register`,userController.postRegister);
    this.post(`#/login`,userController.postLogin);

    //_
    this.get(`#/create`,_Controller.getCreate);
    this.get(`#/offers`,_Controller.getOffers);
    this.get(`#/profile`,_Controller.getProfile);
    this.get(`#/details/:Id`,_Controller.getDetails);
    this.get(`#/edit/:Id`,_Controller.getEdit);
    this.get(`#/delete/:Id`,_Controller.getDelete);

    this.post(`#/create`,_Controller.postCreate);
    this.post(`#/edit/:Id`,_Controller.postEdit);
    this.post(`#/delete/:Id`,_Controller.postDelete);

});

(()=>{
app.run(`#/home`);
})();

Handlebars.registerHelper('if_eq', function(a, b, opts) {
    if (a == b) {
        return opts.fn(this);
    } else {
        return opts.inverse(this);
    }
});

