module.exports = function (grunt) {
    
    return {
        
        js: {
            options: {
                strict: true,
                browser: true,
                globals: {
                    jQuery: true,
                    Backbone: true
                }
            },
            files: {
                src: ['js/*.js']
            } 
        }
        
    };
    
};


