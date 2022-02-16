/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($, Simditor) {
    'use strict';
    $.fn.textEditor = function () {
        var area = $(this);

        return this.each(function () {
            Simditor.locale = 'en-US';
            var editor = new Simditor({
                textarea: area
                //optional options
            });
        });
    };
})(jQuery, Simditor);