/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($, window) {
    "use strict";
    $.fn.propertyMainSlider = function (time, element, width) {

        var $el = $(this),
            $prev = $(this).find('.left-arrow'),
            $next = $(this).find('.right-arrow'),
            $items,
            $itemActive,
            responsiveWidth = undefined ? 880 : width;


        if ($el.length === 0) {
            throw new Error("propertyMainSlider : target element not found");
        }


        var slider = $el.find('.owl-carousel');
        slider.owlCarousel({
            items: 1,
            loop: true,
            margin: 10,
            merge: true,
            dots: false,
            nav: false,
            onInitialized: carouselInitialized
        });


        function carouselInitialized() {
            console.log("initialized");
            $items = $(slider).find('.owl-item');


        }

        $prev.on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [time]);
        });

        $next.on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [time]);
        });


        function checkWindowWidth() {
            if ($(window).width() > responsiveWidth) {
                setCarouselListener();
            }
            else {
                resetCarouselListener();
            }
        }

        function setCarouselListener() {
            slider.on('translated.owl.carousel', function () {
                $itemActive = $(slider).find('.owl-item.active').find(element);
                if ($itemActive.hasClass('inactive') === true) {
                    $itemActive.removeClass('inactive');
                    $itemActive.addClass('active');
                }

                $items.each(function () {
                    if ($(this).hasClass('active') === false) {
                        $(this).find('.property-information').removeClass('active');
                        $(this).find('.property-information').addClass('inactive');
                    }
                });
            });
        }


        function resetCarouselListener() {
            slider.off('translated.owl.carousel');
            $items.each(function () {
                if ($(this).hasClass('active') === false) {
                    $(this).find('.property-information').removeClass('inactive');
                    $(this).find('.property-information').addClass('active');
                }
            });
        }

        $(window).on('load', checkWindowWidth);
        $(window).on('resize', checkWindowWidth);
        checkWindowWidth();


    };
})(jQuery, window);