/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

/**попытка переосмыслить чат **/

/**
 *
 * @constructor
 */

/*
(function ($) {
    'use strict';
    $.fn.AccountComponent = function (options) {

        function Component(options) {
            this.windowWidth = undefined;
            this.componentWindowHeight = undefined;
            this.defaultSettings = {
                emptyPageEnabled: true,
                fullWindowHeight: true,
                width: 1024,
                componentSelectors: {
                    linkClass: '.chat-user-item',
                    blocks: '.chat-window',
                    wrapper: '.msg-wrapper',
                    firstPage: '#no-msg'
                }

            };
            this.settings = $.extend(true, {}, this.defaultSettings, options);

        }

        Component.prototype.setWindowWidth = function () {
            this.windowWidth = $(window).width;
        };

        Component.prototype.initializeElements = function () {
            this.$links = $(this.settings.componentSelectors.linkClass);
            this.$blocks = $(this.settings.componentSelectors.blocks);
            this.$firstPage = $(this.settings.componentSelectors.firstPage);
            this.$wrapper = $(this.settings.componentSelectors.wrapper)

        };


        Component.prototype.displayBlock = function () {
            event.preventDefault();

            var $target = $(event.currentTarget),
                $blocktoDisplay = $($target.attr('href'));

            this.$links.each(function () {
                $(this).removeClass('active');
            });

            $target.addClass('active');


            this.$blocks.each(function () {
                $(this).addClass('js-display-none');
            });

            $blocktoDisplay.removeClass('js-display-none');
        };


        /!**
         *
         *!/
        Component.prototype.setHeight = function () {
            var offset = this.$wrapper.offset().top,
                windowHeight = $(window).height();

            console.log('--->', offset, this.$wrapper);
            console.log('--->', windowHeight);

            function largeHeight() {
                this.$wrapper.css({height: windowHeight - offset + 'px'});
            }

            function largeSmall() {
                this.$wrapper.css({height: windowHeight + 'px'});
            }

            if (this.settings.fullWindowHeight === true) {
                if (this.windowWidth < this.settings.width) {
                    largeSmall.call(this);
                }
                else {
                    largeHeight.call(this);
                }
            }
        };

        Component.prototype.eventsRegister = function () {
            $(window).on('load', this.setWindowWidth.bind(this));
            $(window).on('resize', this.setWindowWidth.bind(this));
            $(window).on('resize', this.setHeight.bind(this));
            this.$links.on('click', this.displayBlock.bind(this));
        };


        /!**
         *
         * @param options
         * @constructor
         *!/
        function Settings(options) {
            Component.apply(this, options);
        }

        Settings.prototype = Object.create(Component.prototype);
        Settings.prototype.constructor = Settings;


        /!**
         *
         * @param options
         * @constructor
         *!/
        function Chat(options) {
            Component.apply(this, options);
        }

        Chat.prototype = Object.create(Component.prototype);
        Chat.prototype.constructor = Chat;

        /!**
         *
         *!/
        Chat.prototype.initializeElements = function () {
            Component.prototype.initializeElements.call(this);
            this.$backButton = $('.js-chat-back');
            this.$emptyWindow = $('#' + 'no-msg');

        };


        /!**
         *
         *!/
        Chat.prototype.back = function () {
            event.preventDefault();
            this.$blocks.each(function () {
                $(this).addClass('js-display-none');
                $(this).removeClass('open');
            });

            this.$linkClass.each(function () {
                $(this).removeClass('active');
            });

            this.$usersWindow.removeClass('js-display-none');


        };


        Chat.prototype.eventsRegister = function () {
            Component.prototype.eventsRegister.call(this);
            this.$backButton.on('click', this.back.bind(this));
            $(window).on('load', this.setHeight.bind(this));
        };


        var z = new Chat();
        z.initializeElements();
        z.setWindowWidth();
        z.setHeight();
        z.eventsRegister();
    };
})(jQuery);


*/

