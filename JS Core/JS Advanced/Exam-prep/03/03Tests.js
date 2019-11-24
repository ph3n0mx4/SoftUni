let expect = require(`chai`).expect;
let assert = require(`chai`).assert;
const SoftUniFy = require('./03. Softunify').SoftUniFy;

describe(`Tests`,function () {
    describe(`constructor`,function () {
        it('should work correctly', function () {
            let actual = new SoftUniFy().songsList;
            let expected = 'Your song list is empty';
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });
    });

    describe(`downloadSong`,function () {
        it('should work correctly when artist not exist', function () {
            let action = new SoftUniFy();
            action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...')
            let actual = action.songsList;
            let expected = 'Venom - Knock, Knock let the devil in...';
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });

        it('should work correctly when artist exist', function () {
            let action = new SoftUniFy();
            action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            action.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            let actual = action.songsList;
            let expected = 'Venom - Knock, Knock let the devil in...\n';
            expected += 'Phenomenal - IM PHENOMENAL...';
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });
    });

    describe(`playSong`,function () {
        it('should work correctly when song exist', function () {
            let action = new SoftUniFy();
            action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            //action.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            let actual = action.playSong('Venom');
            let expected = 'Eminem:\n';
            expected += 'Venom - Knock, Knock let the devil in...\n';
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });

        it('should work correctly when song not exist', function () {
            let action = new SoftUniFy();
            action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            let actual = action.playSong('Phenomenal');
            let expected = `You have not downloaded a Phenomenal song yet. Use SoftUniFy's function downloadSong() to change that!`;
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });
    });

    describe(`rateArtist`,function () {
        it('should work correctly when set rate', function () {
            let action = new SoftUniFy();
            action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...')
            action.rateArtist('Eminem',50);
            let actual = action.allSongs[`Eminem`].rate;
            let expected = 50;
            expect(actual).to.be.equal(expected);
            //assert(actual, expected);
        });

        it('should work correctly when artist not exist', function () {
            let action = new SoftUniFy();
            //action.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...')

            let actual = action.rateArtist('Eminem',50);
            let expected = `The Eminem is not on your artist list.`;
            expect(actual).to.be.equal(expected);
        });
    });
});
