/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.formToggle = function (toglable, block) {
        var $el = $(this),
            $control = $el.find('.slider.round'),
            $toggleArea = $el.find('.toggle-options'),
            $toggleAreaHeight = $toggleArea.height(),
            $toggle = undefined ? false : toglable,
            $block = $(block);


        if ($control.length === 0) {
            throw new Error('formToggle: switch button is not found');
        }

        if ($toggleArea.length === 0) {
            throw new Error('formToggle: toggle block is not found');
        }

        if ($toggle === true) {
            $control.on('click', function () {
                $toggleArea.slideToggle('slow');
                if ($(this).hasClass('special-before') === false) {
                    $block.css({height: $toggleAreaHeight + 'px'});
                }
                else {
                    $block.css({height: '0px'});
                }
                $(this).toggleClass('special-before');
            });
        }
        else {
            $control.on('click', function () {
                $toggleArea.slideToggle('slow');
                $(this).toggleClass('special-before');
            });
        }

        if ($(window).width() < 768) {
            $(document).on('click', function (event) {
                if ($(event.target).closest($el).length === 0) {
                    if ($control.hasClass('special-before')) {
                        $control.trigger('click');
                    }
                }
            });
        }


    };
})(jQuery);