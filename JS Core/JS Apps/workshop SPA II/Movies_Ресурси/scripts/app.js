const app = Sammy("#container", function () {
    this.use(`Handlebars`,`hbs`);
    //Home
    this.get(`#/home`,homeController.getHome);

    //User
    this.get(`#/register`,userController.getRegister);
    this.get(`#/login`, userController.getLogin);

    this.get(`#/logout`,userController.logout);

    this.post(`#/register`,userController.postRegister);
    this.post(`#/login`,userController.postLogin);

    //Movies
    this.get(`#/createMovie`,movieController.getCreateMovie);
    this.get(`#/myMovies`,movieController.getMyMovies);
    this.get(`#/detailsEvent/:movieId`,movieController.getDetailsMovie);
    this.get(`#/editMovie/:movieId`,movieController.getEditMovie);
    this.get(`#/deleteMovie/:movieId`,movieController.getDeleteMovie);


    this.post(`#/createMovie`,movieController.postCreateMovie);
    this.post(`#/editMovie/:movieId`,movieController.postEditMovie);
    this.post(`#/deleteMovie/:movieId`,movieController.postDeleteMovie);
});

(()=>{
app.run(`#/home`);
})();

