
module.exports = {
    
    image_min : {
        
        options: {                       
            optimizationLevel: 3,
            progressive: true
        },
        
        files: [{
            expand: true,                  
            cwd: 'images-source/',    
            src: ['**/*.{png,jpg,gif,ico,jpeg}'],   
            dest: 'images/'
        }]
        
    }
    
};