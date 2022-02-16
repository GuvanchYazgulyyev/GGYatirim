/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    'use strict';
    $.fn.areaTabs = function () {

        var $el = $(this),
            $headerLinks = $el.find('.area-tab-header a'),
            $items = $el.find('.area-tab-content .item'),
            $tabContent = $el.find('.area-tab-content');

        function activeSlideHeight() {
            var height = $tabContent.find('.active').height();
            $tabContent.css({height: height + 'px'});
        }

        $headerLinks.on('click', function (event) {
            event.preventDefault();
            var that = $(this);
            $headerLinks.each(function () {
                $(this).removeClass('active-tab');
            });
            $(this).addClass('active-tab');
            $items.each(function () {
                if ($(this).attr('data-tabid') === that.attr('data-tabid')) {
                    var x = $(this).height();
                    $tabContent.css({height: x + 'px'});
                    $(this).addClass('active');
                    $(this).on('animationend', function () {
                        var y = $(this).height;
                        x = y.call($(this));
                        $tabContent.css({height: x + 'px'});
                        $(window).trigger('area-redraw-map');
                    });
                }
                else {
                    $(this).removeClass('active');

                }
            });
        });

        $('.tab-header a:first').trigger('click');

        $(window).on('resize', activeSlideHeight);
        $(window).on('load', activeSlideHeight);
        activeSlideHeight();


    };
})(jQuery);