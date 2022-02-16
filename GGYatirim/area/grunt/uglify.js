module.exports = function (grunt) {
    
    return {
        js: {
            files: {
                'js-min/min.js': [
                    'js/library/jquery.js',
                    'js/library/bootstrap.js',
                    'js/library/*.js',
                    'js/main.js'
                ]
            }
        }
    };
    
};