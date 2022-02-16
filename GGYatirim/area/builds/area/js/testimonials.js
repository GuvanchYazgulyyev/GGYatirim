/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    'use strict';
    $.fn.testimonials = function () {
        return this.each(function () {
            var $el = $(this),
                $carousel = $el.find('.owl-carousel');

            if ($carousel.length === 0) {
                throw new Error('testimonials: carousel element not found');
            }

            $carousel.owlCarousel({
                items: 1,
                loop: false,
                margin: 10,
                merge: true,
                dots: true,
                nav: false,
                autoHeight: false
            });

        });

    };

})(jQuery);