/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($) {
    'use strict';
    //TODO определить способ передачи параметров
    $.fn.clearForm = function (button) {
        var $el = $(this),
            $button = $el.find(button),
            $select = $el.find($('select[class]')),
            $slider = $el.find($('input[type="text"][id]')),
            $count = $el.find('.features-count');

        if ($button.length === 0) {
            throw new Error('clearForm: clear button is not found');
        }


        $button.on('click', function cleaForm(event) {
            event.preventDefault();

            $select.each(function () {
                $(this).data('form-select').clearSelect();
            });
            $slider.each(function () {
                $(this).data('form-range-slider').resetSlider();
            });
            $count.html(0);

            $el.trigger('reset');


        });
    };
})(jQuery);