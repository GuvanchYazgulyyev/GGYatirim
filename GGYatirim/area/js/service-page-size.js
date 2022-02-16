/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($, document, window) {
    'use strict';

    $.fn.pageSize = function () {
        var $el = $(this);
        var setPageHeight = function () {
            var $top = parseInt($el.css('padding-top'), 10),
                $bottom = parseInt($el.css('padding-bottom'), 10),
                maxHeight = $(window).height(),
                finalHeight = maxHeight - $top - $bottom;

            if (maxHeight < 700) {
                finalHeight = 800 - $top - $bottom;
            }

            $el.height(finalHeight);


        };

        $(document).ready(setPageHeight());
        $(window).on("resize", setPageHeight);
    };

})(jQuery, document, window);