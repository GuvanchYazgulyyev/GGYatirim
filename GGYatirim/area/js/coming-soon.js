/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    'use strict';
    $.fn.comingSoon = function () {
        var $el = $(this),
            $timer = $($el).find('.counter-wrapper');

        if ($el.length === 0) {
            throw new Error('Coming soon: target element not found');
        }

        if ($timer.length === 0) {
            throw new Error('Coming soon: counter-wrapper not found');
        }

        var $day = $el.find('.counter_day'),
            $hours = $el.find('.counter_hours'),
            $minutes = $el.find('.counter_minutes'),
            $seconds = $el.find('.counter_seconds');

        if ($timer.attr('data-time') === undefined || $timer.attr('data-time').length === 0) {
            console.warn('no time in UTC format');
            countDownDate = new Date("12" + " 13," + " 2018 18:30:25").getTime();
        }
        else {
            countDownDate = parseInt($timer.attr('data-time'), 10);
        }


        // setPageHeight();


        var countDownDate;


        var counterInterval = setInterval(function comingSoonCounterInterval() {

            var now = new Date().getTime();
            var distance = countDownDate - now;

            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            $day.html(days);
            $hours.html(hours);
            $minutes.html(minutes);
            $seconds.html(seconds);

            if (distance < 0) {
                clearInterval(counterInterval);

            }
        }, 1000);
    };

})(jQuery);

