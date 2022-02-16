/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($) {
    "use strict";
    $.fn.areaAccordion = function (duration) {
        var accordion = function () {
            var $el = $(this),
                $header = $el.find('.accordion-header'),
                $content = $el.find('.accordion-content'),
                $button = $el.find('i'),
                time = duration;

            function activeButton() {
                $button.toggleClass('open');
                $el.toggleClass('open');
            }

            function showContent() {
                $content.toggle(time, activeButton);
            }

            $header.on('click', showContent);
        };

        $(this).each(function () {
            accordion.call(this);
        });
    };

})($);