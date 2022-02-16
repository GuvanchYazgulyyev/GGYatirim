/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    'use strict';
    $.fn.accountPage = function (options) {

        var defaultSettings = {
            toggleLink: '.js-test-toggle',
            menu: '.account_menu',
            menuLinks: '.js-menu-link',
            contentBlocks: '.js-content-blocks',
            notificationClass: 'new-notification__enabled'


        };


        /**
         *
         * @constructor
         */
        function AccountPage(options) {
            this.menuOpen = true;
            this.hideButton = false;
            this.pageOptions = $.extend(true, {}, defaultSettings, options);
        }


        /**
         *@description initialize page elements
         */
        AccountPage.prototype.initializeElements = function () {
            this.$toggleLink = $(this.pageOptions.toggleLink);
            this.$menu = $(this.pageOptions.menu);
            this.$menuLinks = $(this.pageOptions.menuLinks);
            this.$contentBlocks = $(this.pageOptions.contentBlocks);
        };


        /**
         * @description toggle menu
         * @param event
         */
        AccountPage.prototype.toggleMenu = function (event) {
            event.preventDefault();
            $('.js-test-toggle').toggleClass('js-close');
            if (this.menuOpen === true) {
                this.$menu.addClass('menu-close-class');
                this.menuOpen = false;
            }
            else {
                this.$menu.removeClass('menu-close-class');
                this.menuOpen = true;
            }
            $(window).trigger('chartist-update');

        };

        /**
         * @description
         * @param event
         */
        AccountPage.prototype.linkClick = function (event) {
            event.preventDefault();
            var $target = $(event.currentTarget),
                $blockToDisplay = ($target.attr('href'));


            this.$menuLinks.each(function () {
                $(this).removeClass('active');
            });
            $target.addClass('active');
            if ($(window).width() < 900) {
                $(this.$toggleLink[0]).trigger('click');
            }
            this.$contentBlocks.each(function () {
                $(this).addClass('js-display-none');
            });

            $($blockToDisplay).removeClass('js-display-none');
            if ($target.hasClass(this.pageOptions.notificationClass)) {
                $target.removeClass(this.pageOptions.notificationClass);
            }
            $(window).trigger('init-chat');

        };

        AccountPage.prototype.hashChange = function () {
            var hash = window.location.hash;
            if (hash.length > 0) {
                this.$menuLinks.each(function () {

                    if ($(this).attr('href') === hash) {
                        $(this).trigger('click');

                    }


                });
                window.scrollTo(0, 0);
            }

            else {
                window.location.hash = '#dashboard';
                window.scrollTo(0, 0);
            }

        };


        AccountPage.prototype.hideMenu = function () {
            var width = $(window).width();
            if (width >= 1025 && width < 1200) {
                if (this.menuOpen === true) {
                    this.$menu.addClass('menu-close-class');
                    this.$toggleLink.addClass('js-display-none');
                    this.$toggleLink.addClass('js-close');
                    this.menuOpen = false;
                    this.hideButton = true;

                }
                else {
                    if (this.hideButton === false) {
                        this.$toggleLink.addClass('js-display-none');
                        this.hideButton = true;
                    }
                }

            }
            else {
                if (this.hideButton === true) {
                    this.$toggleLink.removeClass('js-display-none');
                    this.hideButton = false;
                }
            }
            $(window).trigger('chartist-update');
        };

        /**
         * @description initialize event listeners
         */
        AccountPage.prototype.initializeEvents = function () {
            this.$toggleLink.on('click', this.toggleMenu.bind(this));
            this.$menuLinks.on('click', this.linkClick.bind(this));
            $(this.$menuLinks[0]).trigger('click');
            $(window).on('load', this.hideMenu.bind(this));
            $(window).on('load', this.hashChange.bind(this));
            $(window).on('hashchange', this.hashChange.bind(this));
            $(window).on('resize', this.hideMenu.bind(this));

        };


        return this.each(function () {
            var account = new AccountPage(options);
            account.initializeElements();
            account.initializeEvents();
            account.hashChange();
            account.hideMenu();

        });


    };

})(jQuery);