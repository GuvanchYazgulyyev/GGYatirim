/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";

    $.fn.setSize = function () {
        var $el = $(this),
            form = $el.find('form'),
            input = form.find('input[type="search"]');
        if ($el.length === 0) {
            throw new Error('setSize: element not found');
        }

        function setSize() {
            var maxHeight = $(window).height();
            if (maxHeight < 600) {
                maxHeight = 600;
            }
            $($el).height(maxHeight);
        }

        function addMarquee() {
            var width = $(window).width();
            if (width < 480) {
                input.addClass('marquee');
                input.on('focus', function removeMarquee() {
                    input.removeClass('marquee');
                });
                input.on('focusout', function addMarqueeClass() {
                    input.addClass('marquee');
                });

            }
            else {
                input.removeClass('marquee');
            }
        }

        $(window).ready(function () {
            setSize();
            addMarquee();
        });
        $(window).on('resize', function () {
            setSize();
            addMarquee();
        });
        // setSize();
        // addMarquee();


    };


})(jQuery);