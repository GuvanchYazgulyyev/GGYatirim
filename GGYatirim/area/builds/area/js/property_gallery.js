/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */





(function ($) {
    'use strict';
    $.fn.propertyGallery = function () {
        /**
         *
         * @param el
         * @constructor
         */
        function PropertyGallery(el) {
            this.$el = $(el);
            this.$owl = this.$el.find('.owl-carousel');
            this.$slide = this.$el.find('.slide');
            this.$arrowRight = this.$el.find('.right-arrow');
            this.$arrowLeft = this.$el.find('.left-arrow');
            this.$preloader = this.$el.find('.js-image-preloader');
            this.$fullScreenBtn = this.$el.find('.js-fullscreen-btn');
            this.$fullScreenMsg = this.$el.find('.js-fullscreen-message');
            this.$links = this.$el.find('.item a');
            this.owlSmall = {
                loop: true,
                nav: false,
                dots: false,
                margin: 10,
                responsive: {
                    0: {
                        items: 2
                    },
                    600: {
                        items: 3
                    },
                    960: {
                        items: 4
                    },
                    1200: {
                        items: 3
                    }
                }

            };
            this.owlBig = {
                loop: true,
                nav: false,
                dots: false,
                margin: 10,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 3
                    },
                    960: {
                        items: 4
                    },
                    1200: {
                        items: 6
                    }
                }

            };
            this.galleryHeightSmall = this.$slide.attr('data-height');
            this.galleryHeightBig = 0;
            this.isFull = false;
        }


        /**
         * checks gallery height data-attribute
         */
        PropertyGallery.prototype.checkGalleryHeight = function () {
            if (this.galleryHeightSmall === undefined) {
                this.galleryHeightSmall = 450;
            }
        };

        /**
         * sets gallery height
         */
        PropertyGallery.prototype.setSmallGalleryHeight = function () {
            this.$slide.css({'height': this.galleryHeightSmall + 'px', 'background-size': 'cover'});
        };

        /**
         * sets gallery height on full screen
         */
        PropertyGallery.prototype.setGalleryFullHeight = function () {
            var paddingTop = parseInt(this.$el.css('padding-top'), 10);
            var paddingBottom = parseInt(this.$el.css('padding-bottom'), 10);
            this.galleryHeightBig = $(window).height() - paddingTop - paddingBottom;
        };


        /**
         * enable full screen gallery
         */
        PropertyGallery.prototype.enableFullWidth = function () {
            this.$el.addClass('setfull');
            this.$fullScreenBtn.removeClass('fullscreen');
            this.$fullScreenBtn.addClass('exitfullscreen');
            this.$owl.trigger('destroy.owl.carousel');
            this.$slide.css({"height": this.galleryHeightBig + "px", "background-size": "cover"});
            this.$owl.owlCarousel(this.owlBig);
            this.isFull = true;
        };

        /**
         *disable full screen gallery
         */
        PropertyGallery.prototype.disableFullWidth = function () {
            this.$el.removeClass('setfull');
            this.$fullScreenBtn.removeClass('exitfullscreen');
            this.$fullScreenBtn.addClass('fullscreen');
            this.$owl.trigger('destroy.owl.carousel');
            this.$slide.css({"height": this.galleryHeightSmall + "px", "background-size": "cover"});
            this.$owl.owlCarousel(this.owlSmall);
            this.isFull = false;
        };


        /**
         * register gallery events
         */
        PropertyGallery.prototype.eventsRegister = function () {
            var self = this;
            this.$fullScreenBtn.on('click', function (event) {
                event.preventDefault();

                if (self.isFull === false) {
                    self.enableFullWidth();
                    if ($(window).width() > 992) {
                        setTimeout(function () {
                            self.$fullScreenMsg.css({opacity: '1'});
                        }, 100);
                        setTimeout(function () {
                            self.$fullScreenMsg.css({'transition': 'opacity 1.5s 2s', 'opacity': '0'});
                        }, 3000);
                    }
                }
                else {
                    self.disableFullWidth();
                }
            });
            this.$owl.on('mousewheel', '.owl-stage', function (e) {
                if (e.deltaY > 0) {
                    self.$owl.trigger('next.owl');
                } else {
                    self.$owl.trigger('prev.owl');
                }
                e.preventDefault();
            });

            this.$arrowLeft.on('click', function (event) {
                event.preventDefault();
                self.$owl.trigger('prev.owl');
            });

            this.$arrowRight.on('click', function (event) {
                event.preventDefault();
                self.$owl.trigger('next.owl');
            });

            this.$links.on('click', function (event) {
                event.preventDefault();
                var url = $(this).attr('data-image');

                var image = new Image();

                self.$preloader.data('preloader').start();
                image.src = url;
                image.onload = function () {
                    self.$preloader.data('preloader').loaded();
                    self.$preloader.on('preloader-animation-over', function () {
                        self.$slide.css({
                            "background-image": "url('" + url + "')", "background-size": "cover"
                        });
                    });
                };

            });

            $(window).keydown(function (event) {
                if (event.keyCode === 27) {
                    if (self.isFull === true) {
                        self.disableFullWidth();
                    }
                }
            });

            $(window).on('load', function () {
                self.setGalleryFullHeight();
            });
            $(window).on('resize', function () {
                self.setGalleryFullHeight();
            });


        };

        /**
         * initialize gallery
         */
        PropertyGallery.prototype.initialize = function () {
            this.$owl.owlCarousel(this.owlSmall);
            this.eventsRegister();
            this.checkGalleryHeight();
            this.setSmallGalleryHeight();
            var image = this.$el.find('.owl-item.active:first .item a').attr('data-image');
            this.$slide.css({'background-image': 'url("' + image + '")'});
        };


        return this.each(function () {
            var $this = $(this);
            var gallery = new PropertyGallery($this);
            gallery.initialize();
        });


    };
})(jQuery);