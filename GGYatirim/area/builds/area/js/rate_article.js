/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($) {


    'use strict';
    $.fn.rateArticle = function () {
        return this.each(function () {
            var $el = $(this),
                liked = false,
                unliked = false;

            var likeButton = $el.find('.button-like');
            var unlikeButton = $el.find('.button-unlike');


            $el.on('unlike-click', function () {
                if (liked === true) {
                    likeButton.removeClass('button_active');
                }
                unlikeButton.toggleClass('button_active');
            });

            $el.on('like-click', function () {
                if (unliked === true) {
                    unlikeButton.removeClass('button_active');
                }
                likeButton.toggleClass('button_active');
            });


            likeButton.on('click', function (event) {
                event.preventDefault();
                liked = true;
                $el.trigger('like-click');

            });

            unlikeButton.on('click', function (event) {
                event.preventDefault();
                unliked = true;
                $el.trigger('unlike-click');

            });
        });


    };
})(jQuery);