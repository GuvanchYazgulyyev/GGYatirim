module.exports = function (grunt) {

    var files = {};

    files['css-min/' + grunt.option('scheme') + '.min.css'] = [

        /**
         * This is sequential including for creating /min-css/*.min.css files.
         * You can add other libraries if you need!
         */
        'css/library/bootstrap.css',
        'css/library/font-awesome.min.css',
        'css/library/font-awesome-animation.min.css',
        'css/library/normalize.css',
        'css/library/ion.rangeSlider.css',
        'css/library/ion.rangeSlider.skinHTML5.css',
        'css/library/sumoselect.css',
        'css/library/materialdesignicons.min.css',
        'css/library/owl.carousel.min.css',
        'css/library/selectize.css',
        'css/library/owl.theme.default.min.css',
        'css/library/chartist.min.css',
        'css/library/simditor.css',

                'css/' + grunt.option('scheme') + '.css'
    ];

    return {
        css: {
            files: files
        }
    };

};