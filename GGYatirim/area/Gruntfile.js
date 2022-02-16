module.exports = function(grunt) {
    
    grunt.option('scheme', 'area');
    
    var path = require('path');
    global.color_schemes_path = path.join(process.cwd(), 'less-color-schemes');
    
    require('time-grunt')(grunt);
    
    require('load-grunt-config')(grunt, {
        jitGrunt: true
    });
    
};