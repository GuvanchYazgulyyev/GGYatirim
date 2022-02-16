module.exports = function (grunt) {
    
    var _ = require('underscore');
    
    var style_file = 'css/' + grunt.option('scheme') + '.css';
    var files = {};
    files[style_file] = 'less/concat.less';
    
    return {
        compele: {
            options: {
                modifyVars: {
                    'scheme-name': grunt.option('scheme')
                }
            },
            files: files
        }
    };
    
};