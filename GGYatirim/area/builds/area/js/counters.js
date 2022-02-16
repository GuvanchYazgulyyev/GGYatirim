/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.counters = function (time, wrapper) {


        var counter = function counterFunction() {
            var i = 0,
                $element = $(this).find('.number'),
                $number = $($element).attr('data-number'),
                number = parseInt($number, 10),
                step = Math.ceil(time / number);


            var interval = setInterval(function () {
                if (i <= number) {
                    $element.html(i + '');
                }
                else {
                    clearInterval(interval);
                }
                i = i + 1;
            }, step);


        };
        var that = this;
        var counted = false;

        $(wrapper).on('visible', function visibleCounters() {
            if (counted === false) {
                counted = true;
                $(that).each(function () {
                    counter.call(this);
                });
            }
        });

        $(wrapper).on('no-visible', function () {
            
        });

    };
})(jQuery);