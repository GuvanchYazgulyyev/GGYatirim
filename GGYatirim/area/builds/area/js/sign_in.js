/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    'use strict';
    $.fn.signIn = function (signbutton) {
        var $el = $(this),
            closeButton = $el.find('.js-button-close'),
            signButton = $(signbutton),
            signInVisible = false;

        if (closeButton.length === 0) {
            console.warn('signIn: no  close button found');
        }

        signButton.on('click', function (event) {
            event.preventDefault();
            $el.css({display: 'flex'});
            signInVisible = true;
        });

        closeButton.on('click', function (event) {
            event.preventDefault();
            $el.css({display: 'none'});
            signInVisible = false;
        });

        $(window).keydown(function (event) {
            if (event.keyCode === 27) {
                if (signInVisible === true) {
                    $el.css({display: 'none'});
                    signInVisible = false;
                }
            }
        });


    };
})(jQuery);