let expect = require(`chai`).expect;
let assert = require(`chai`).assert;
const FilmStudio = require('./filmStudio').FilmStudio;

describe('Test', function () {
    let studio;
    beforeEach(() => {
        studio = new FilmStudio(`Bo`);
    });
    it('should constructor studioName property', function () {
        expect(studio.name).to.be.equal(`Bo`);
    });

    it('should constructor films property', function () {
        expect(studio.films).to.eql([]);
    });

    it('should make movie', function () {
        let actual =studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let expected = { filmName: 'The Avengers',
   filmRoles:
      [ { role: 'Iron-Man', actor: false },
        { role: 'Thor', actor: false },
        { role: 'Hulk', actor: false },
        { role: 'Arrow guy', actor: false } ] };

        let expected2=[ { role: 'Iron-Man', actor: false },
            { role: 'Thor', actor: false },
            { role: 'Hulk', actor: false },
            { role: 'Arrow guy', actor: false } ] ;

        expect(actual).to.eql(expected);
        expect(actual.filmName).to.equal('The Avengers');
        expect(actual.filmRoles).to.eql(expected2);

    });

    it('should make movie with existing name', function () {
        studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let actual=studio.makeMovie('The Avengers',['Iron-Man2', 'Thor2']);
        let expected = { filmName: 'The Avengers 2',
            filmRoles:
                [ { role: 'Iron-Man2', actor: false },
                    { role: 'Thor2', actor: false }]};
        expect(actual).to.eql(expected);
        expect(actual.filmName).to.equal('The Avengers 2');
        expect(actual.filmRoles).to.eql([ { role: 'Iron-Man2', actor: false },
            { role: 'Thor2', actor: false }]);
    });

    it('make movie with one argument', function () {
        expect(()=>studio.makeMovie(['Iron-Man2', 'Thor2'])).to.throw(`Invalid arguments count`);
        expect(()=>studio.makeMovie(`asd`)).to.throw(`Invalid arguments count`);
    });

    it('make movie with wrong arguments', function () {//exception
        expect(()=>studio.makeMovie(1,['Iron-Man2', 'Thor2'])).to.throw(`Invalid arguments`);
        expect(()=>studio.makeMovie(`1`,{'Iron-Man2': 'Thor2'})).to.throw(`Invalid arguments`);
    });

    it('testing casting when actor get role', function () {
        studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let actual=studio.casting(`AZ`,`Iron-Man`);
        let expected = `You got the job! Mr. AZ you are next Iron-Man in the The Avengers. Congratz!`;
        expect(actual).to.be.equal(expected);
    });

    it('testing casting when the role is not existing', function () {
        studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let actual=studio.casting(`AZ`,`to`);
        let expected = `AZ, we cannot find a to role...`;
        expect(actual).to.be.equal(expected);
    });

    it('testing casting when in studio there are no films', function () {
        // studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
        let actual=studio.casting(`AZ`,`to`);
        let expected = `There are no films yet in ${studio.name}.`;
        expect(actual).to.be.equal(expected);
    });

    it('testing lookForProducer throw error', function () {
        expect(()=>{studio.lookForProducer(`Z`)}).to.throw(`Z do not exist yet, but we need the money...`);
    });

    it('testing lookForProducer ', function () {
        studio.makeMovie('The Avengers', ['Iron-Man']);
        let actual = studio.lookForProducer(`The Avengers`);
        let expected = `Film name: The Avengers\nCast:\nfalse as Iron-Man\n`;
        expect(actual).to.be.equal(expected);
    });

});