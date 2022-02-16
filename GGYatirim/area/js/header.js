/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

/**
 * This is jQuery plugin declaration for header html-component
 * Deps: jQuery,
 * Using examples: /js/main.js
 * @author torbara  (https://themeforest.net/user/torbara)
 */

(function ($, window) {

    "use strict";

    $.fn.areaHeader = function (maxWidth) {

        var $header = $(this),
            stickyStatus = true,
            didStick = false,
            didScroll = false,
            headerHeight = $header.outerHeight(),
            headerOffset = $header.offset().top;

        if ($header.length === 0) {
            throw new Error('Header: header element not found');
        }

        if (maxWidth === undefined) {
            maxWidth = 1199;
        }

        function checkWindowWidth() {
            if ($(window).width() < maxWidth) {
                stickyStatus = false;
            }
            else {
                stickyStatus = true;
            }
        }

        function checkHeaderHeight() {
            headerHeight = $header.outerHeight();
        }

        function stick() {
            if (stickyStatus === true) {
                if ($(window).scrollTop() > headerOffset) {
                    if (didStick === false) {
                        $header.addClass('stick-header');
                        didStick = true;
                    }
                }

                if ($(window).scrollTop() < headerOffset) {
                    if (didStick === true) {
                        $header.removeClass('stick-header');
                        didStick = false;
                    }
                }
            }
            else {
                $header.removeClass('stick-header');
                didStick = false;
            }
        }

        function wrapHeader() {
            $header.wrap('<div class="sticky-wrap">');
            $('.sticky-wrap').css({height: headerHeight + 'px'});
        }

        function headerStick() {
            checkHeaderHeight();
            wrapHeader();
            checkWindowWidth();

        }

        $(document).ready(headerStick());
        $(window).on('resize', checkHeaderHeight);
        $(window).on('resize', checkWindowWidth);
        $(window).on('scroll', function setScrollStatus() {
            didScroll = true;
        });

        setInterval(function stackStickFunction() {
            if (didScroll) {
                didScroll = false;
                stick();
            }
        }, 100);


    };

})(jQuery, window, document);


