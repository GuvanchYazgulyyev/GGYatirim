/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */
(function ($) {
    "use strict";
    $.fn.agentCarousel = function () {
        var $el = $(this);

        if ($el.length === 0) {
            throw new Error("agentCarousel : target element not found");
        }

        var slider = $el.find('.owl-carousel').owlCarousel({
            items: 1,
            loop: true,
            margin: 10,
            merge: true,
            dots: false,
            nav: false
        });
        $(".agent-carousel-arrow-block .arrow-prev").on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [2700]);
        });
        $(".agent-carousel-arrow-block .arrow-next").on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [2700]);
        });


    };

})(jQuery);
