/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($, window, document) {
    "use strict";

    function isVisible(elem) {
        var coords = elem.getBoundingClientRect();
        var windowHeight = document.documentElement.clientHeight;
        var topVisible = coords.top > 0 && coords.top < windowHeight;
        var bottomVisible = coords.bottom < windowHeight && coords.bottom > 0;

        return topVisible || bottomVisible;
    }

    $.fn.showVisible = function () {

        var $el = $(this),
            didScroll = false;

        function visibleOnScroll() {
            if (didScroll === true) {
                didScroll = false;
                if (isVisible($el[0])) {
                    $el.trigger('visible');
                }
                else {
                    $el.trigger('no-visible');
                }
            }
        }

        function visibleOnLoad() {

            if (isVisible($el[0])) {
                $el.trigger('visible');
            }
            else {
                $el.trigger('no-visible');
            }
        }

        $(window).on('scroll', function () {
            didScroll = true;

        });

        $(window).on('load', visibleOnLoad);
        setInterval(visibleOnScroll, 100);

    };

})(jQuery, window, document);
