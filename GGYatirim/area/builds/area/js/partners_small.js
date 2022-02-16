/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.smallPartners = function (time) {
        var $el = $(this),
            $prev = $(this).find('.arrow-prev'),
            $next = $(this).find('.arrow-next');

        if ($el.length === 0) {
            throw new Error("smallPartners : target element not found");
        }

        var slider = $el.find('.owl-carousel').owlCarousel({
            items: 6,
            loop: true,
            margin: 30,
            merge: true,
            dots: false,
            nav: false,
            responsive: {
                320: {
                    items: 1
                },
                400: {
                    items: 2
                },
                520: {
                    items: 3
                },
                800: {
                    items: 4
                },

                1200: {
                    items: 6
                }
            }
        });
        $prev.on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [time]);
        });

        $next.on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [time]);
        });


    };

})(jQuery);
