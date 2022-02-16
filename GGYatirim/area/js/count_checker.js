/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.countCheck = function () {
        var $el = $(this),
            countSpan = $el.find('.features-count'),
            count = 0;

        countSpan.html(count);

        if ($el.find('input').length === 0) {
            throw new Error("countCheckek: inputs are not found");
        }

        $el.on('click', 'input', function () {
            var inputs = $el.find('input:checked').length;
            if (count !== inputs) {
                countSpan.html(inputs);
                count = inputs;
            }
        });


    };

})(jQuery);