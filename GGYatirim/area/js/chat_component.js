/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($) {
    'use strict';
    $.fn.chatComponent = function (settings) {

        /**
         *
         * @type {{wrapper: string, users: string, chatWindow: string, backButton: string, linkClass: string, emptyMsg: boolean}}
         */
        var defaultOptions = {
            wrapper: 'msg-wrapper',
            users: 'chat-users',
            chatWindow: 'chat-window',
            backButton: 'js-chat-back',
            linkClass: 'chat-user-item',
            emptyMsg: true,
            emptyWindow: 'no-msg'
        };


        /**
         *
         * @constructor
         */
        function Chat() {
            this.width = 0;
            this.options = $.extend(true, {}, defaultOptions, settings);
            this.activeTab = undefined;

        }

        /**
         *  @description initialize component elements
         */
        Chat.prototype.initializeElements = function () {
            this.$chatWrapper = $('.' + this.options.wrapper);
            this.$usersWindow = $('.' + this.options.users);
            this.$chatWindow = $('.' + this.options.chatWindow);
            this.$backButton = $('.' + this.options.backButton);
            this.$linkClass = $('.' + this.options.linkClass);
            this.$emptyWindow = $('#' + this.options.emptyWindow);
        };


        /**
         * @description displays the selected dialog
         */

        Chat.prototype.selectDialog = function () {
            event.preventDefault();

            var $target = $(event.currentTarget),
                $chat = $($target.attr('href'));

            this.activeTab = $chat;

            this.$linkClass.each(function () {
                $(this).removeClass('active');
            });

            /**hide chat selectors on small screens **/
            if (this.width < 1024) {
                this.$usersWindow.addClass('js-display-none');
                $target.addClass('active');
            }
            else {
                $target.addClass('active');
            }


            this.$chatWindow.each(function () {
                $(this).addClass('js-display-none');
                $(this).removeClass('open');

            });

            /**displays active chat window **/
            $chat.removeClass('js-display-none');
            $chat.addClass('open');
        };

        /**
         *@description back click function on small screen devices
         */
        Chat.prototype.back = function () {

            this.$chatWindow.each(function () {
                $(this).addClass('js-display-none');
                $(this).removeClass('open');

            });

            this.$linkClass.each(function () {
                $(this).removeClass('active');
            });

            this.$usersWindow.removeClass('js-display-none');

            this.activeTab = undefined;
        };

        /**
         *@description register events
         */
        Chat.prototype.registerEvents = function () {
            this.$linkClass.on('click', this.selectDialog.bind(this));
            this.$backButton.on('click', this.back.bind(this));
            $(window).on('load', this.setHeight.bind(this));
            $(window).on('load', this.setWidth.bind(this));
            $(window).on('resize', this.resizeFunctions.bind(this));
            $(window).on('init-chat', this.setHeight.bind(this));

        };

        /**
         * @description displays default chat window
         */
        Chat.prototype.displayDefault = function () {
            if (this.options.emptyMsg === true) {
                this.$chatWindow.each(function () {
                    $(this).addClass('js-display-none');
                });
            }
            if (this.width > 1024) {
                this.$emptyWindow.removeClass('js-display-none');
            }


        };


        /**
         * @description declare functions that must run on window resize event
         */
        Chat.prototype.resizeFunctions = function () {
            this.setWidth();
            this.setHeight();
            this.resizeChat();
        };

        /**
         * @description sets width parameter
         */
        Chat.prototype.setWidth = function () {
            this.width = $(window).width();
        };

        /**
         * @description sets chat window height
         */
        Chat.prototype.setHeight = function () {
            var offset = this.$chatWrapper.offset().top,
                windowHeight = $(window).height();

            function largeHeight() {
                this.$chatWindow.css({height: windowHeight - offset + 'px'});
            }

            function largeSmall() {
                this.$chatWindow.css({height: windowHeight + 'px'});
            }

            if (this.width < 1024) {
                largeSmall.call(this);
            }
            else {
                largeHeight.call(this);
            }

        };

        /***
         * @description  resize chat
         */
        Chat.prototype.resizeChat = function () {
            var $self = this;
            if (this.width > 1024 && this.$usersWindow.hasClass('js-display-none')) {
                this.$usersWindow.removeClass('js-display-none');

            }
            else {
                this.$chatWindow.each(function () {
                    if ($self.width < 1024 && !$(this).hasClass('js-display-none')) {
                        $(this).addClass('js-display-none');
                    }
                });
            }

            if (this.width > 1024) {
                if (this.activeTab !== undefined) {
                    this.activeTab.removeClass('js-display-none');
                }
                else {
                    this.$emptyWindow.removeClass('js-display-none');
                }
            }
        };


        /**
         * @description initialize component
         */
        Chat.prototype.initialize = function () {
            this.initializeElements();
            this.setWidth();
            this.displayDefault();
            this.setHeight();
            this.registerEvents();
        };

        var z = new Chat();
        z.initialize();


    };
})(jQuery);