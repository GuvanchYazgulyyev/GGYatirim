module.exports = function (grunt) {

    return {
        extract: {
            options: {
                packageSpecific: {
                    'jquery': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/jquery.js'
                        ]
                    },
                    'font-awesome': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'css/font-awesome.min.css',
                            'fonts/*'
                        ]
                    },
                    'bootstrap': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/js/bootstrap.js',
                            'dist/css/bootstrap.css',
                            'dist/fonts/*'
                        ]
                    },
                    'animate.css': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'animate.css'
                        ]
                    },
                    'font-awesome-animation': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/font-awesome-animation.min.css'
                        ]

                    },
                    'ion.rangeSlider': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'js/ion.rangeSlider.min.js',
                            'css/normalize.css',
                            'css/ion.rangeSlider.css',
                            'css/ion.rangeSlider.skinHTML5.css'
                        ]
                    },
                    'mdi': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'css/materialdesignicons.min.css',
                            'fonts/*'
                        ]
                    },
                    'owl.carousel': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/owl.carousel.js',
                            'dist/assets/owl.carousel.min.css',
                            'dist/assets/owl.theme.default.min.css'
                        ]
                    },
                    'selectize': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/js/standalone/selectize.js',
                            'dist/css/selectize.css'
                        ]
                    },
                    'microplugin': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'src/microplugin.js'
                        ]
                    },
                    'chartist': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/chartist.min.js',
                            'dist/chartist.min.css'
                        ]
                    },
                    'js-marker-clusterer': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'src/markerclusterer.js'
                        ]
                    },
                    'jquery-mousewheel': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'jquery.mousewheel.js'
                        ]
                    },
                    'progressbar.js': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'dist/progressbar.js'
                        ]
                    },
                    'simple-hotkeys': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'lib/hotkeys.js'
                        ]
                    },
                    'simple-module': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'lib/module.js'
                        ]
                    },
                    'simple-uploader': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'lib/uploader.js'
                        ]
                    },
                    'simditor': {
                        keepExpandedHierarchy: false,
                        stripGlobBase: true,
                        files: [
                            'lib/simditor.js',
                            'styles/simditor.css'
                        ]
                    }

                }

            },
            dest: 'js/library',
            js_dest: 'js/library',
            css_dest: 'css/library',
            fonts_dest: 'fonts'
        }
    };

};