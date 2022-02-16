/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

(function ($, ionRangeSlider) {
    "use strict";
    $.fn.rangeslider = function () {

        var $el = $(this);

        var parent = $el.parent();
        console.log(parent);

        if ($el.length === 0) {
            throw new Error('Rangeslider: target element not found');
        }


        $el.on("start", function () {
            console.log("start");
        });

        $el.on("change", function () {
            console.log(parent);
        });
        $el.on("finish", function () {
            console.log("finish");
        });

    };
})(jQuery);
