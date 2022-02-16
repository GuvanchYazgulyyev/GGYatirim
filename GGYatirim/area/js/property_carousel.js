/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.propertySlider = function () {
        var $el = $(this),
            $arrowNext=$el.find('.arrow-next'),
            $arrowPrev=$el.find('.arrow-prev');

        if ($el.length === 0) {
            throw new Error("propertySlider : target element not found");
        }

        var slider = $el.find('.owl-carousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            dots: false,
            responsive: {
                300:{
                    items: 1
                },
                768:{
                    items:2
                },
                992: {
                    items: 3
                }
            }
        });

        $($arrowPrev).on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [700]);
        });
        $($arrowNext).on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [700]);
        });

    };
})(jQuery);