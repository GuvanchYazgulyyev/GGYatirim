/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.agentSlider = function () {
        var $el = $(this);

        if ($el.length === 0) {
            throw new Error("agentSlider : target element not found");
        }

        var slider = $el.find('.owl-carousel').owlCarousel({
            loop: true,
            margin: 20,
            nav: false,
            dots: false,
            responsive: {
                0: {
                    items: 1
                },
                520: {
                    items: 2
                },
                1000: {
                    items: 3
                },
                1200: {
                    items: 4
                }
            }
        });
        $(".agent-grid-arrow-block .arrow-prev").on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [700]);
        });
        $(".agent-grid-arrow-block .arrow-next").on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [700]);
        });

        
    };

})(jQuery);

