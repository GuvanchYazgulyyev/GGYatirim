/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */




(function ($) {
    "use strict";

    /**
     * Slider constructor
     * @param element
     * @param options
     * @constructor
     */
    function Slider(element, options) {
        this.$el = $(element);
        this.options = $.extend({}, Slider.defaults, options);
        this.carouselStatus = 0;
    }


    Slider.defaults = {
        carousel: true,
        formOnSlide: true,
        speed: 700,


        controls: true,
        arrowRight: '.arrow-next',
        arrowLeft: '.arrow-prev',


        progressBarStatus: true,
        progressbarElement: '.bar-line',
        animationTime: 4800,
        loopTime: 5000,
        loopStatus: false

    };

    /**
     * initialize slider
     */
    Slider.prototype.initialize = function () {
        this.checkLoopStatus();
        this.createCarousel();
        this.setItemsCount();
        this.initializeArrows();
        this.initializeBar();
        this.progressBarAnimation();
        this.initializeFormElement();
        this.createEvents();

    };

    /**
     * set carousel wrapper and elements height
     */
    Slider.prototype.setHeight = function () {
        //  console.log("%c setHeight", 'color:red');
        var top = this.$el.offset().top;
        var maxHeight = $(window).height() - top;

        if (maxHeight < 600) {
            maxHeight = 600;
        }
        this.$el.height(maxHeight);
        this.$el.find('.item').height(maxHeight);
    };

    /**
     * create owl-carousel
     * */
    Slider.prototype.createCarousel = function () {
        //   console.log("%c createCarousel", 'color:green');
        this.carousel = this.$el.find('.owl-carousel').owlCarousel({
            items: 1,
            dots: false,
            nav: false,
            loop: this.options.loopStatus

        });
    };

    /**
     * initialize carousel control arrows
     *
     */
    Slider.prototype.initializeArrows = function () {
        //   console.log("%c setControls", 'color:yellow');
        if (this.options.controls) {
            this.arrowRight = this.$el.find(this.options.arrowRight);
            this.arrowLeft = this.$el.find(this.options.arrowLeft);
            if (this.arrowLeft === undefined || this.arrowRight === undefined) {
                console.warn('arrows not found');
            }
        }
    };


    /**
     * switch to the next slide
     *
     * **/
    Slider.prototype.nextSlide = function () {
        // console.log("%c nextSlide", 'color:orange');
        var status;
        if (this.options.loopStatus) {
            this.carousel.trigger('next.owl.carousel', [this.options.speed]);
        }
        else {
            if (this.carouselStatus !== this.itemsCount - 1) {
                status = this.carouselStatus + 1;
                this.carousel.trigger('to.owl.carousel', [status, this.options.speed]);
                this.carouselStatus = status;
            }
            else {
                status = 0;
                this.carousel.trigger('to.owl.carousel', [status, this.options.speed]);
                this.carouselStatus = status;
            }
        }
    };


    /**
     * switch to the prev slide
     *
     */
    Slider.prototype.prevSlide = function () {
        // console.log("%c prevSlide", 'color:orange');
        var status;
        if (this.options.loopStatus) {
            this.carousel.trigger('prev.owl.carousel', [this.options.speed]);
        }
        else {
            if (this.carouselStatus !== 0) {
                status = this.carouselStatus - 1;
                this.carousel.trigger('to.owl.carousel', [status, this.options.speed]);
                this.carouselStatus = status;
            }
            else {
                status = this.itemsCount - 1;
                this.carousel.trigger('to.owl.carousel', [status, this.options.speed]);
                this.carouselStatus = status;
            }
        }
    };


    /**
     * initialize progress bar
     * @returns {boolean}
     */
    Slider.prototype.initializeBar = function () {
        //console.log('%c initializeBar', 'color:#ff9999');
        if (this.options.progressBarStatus) {
            this.bar = this.$el.find(this.options.progressbarElement);
            if (this.bar === undefined) {
                console.warn('progress bar element not found');
                this.options.progressBarStatus = false;

            }

        }

        return this.options.progressBarStatus;
    };

    /**
     * progress bar animation function
     *
     * **/
    Slider.prototype.progressBarAnimation = function () {
        var that = this;
        //  console.log('%c progressBarAnimation', 'color:#ccff00');
        if (this.options.progressBarStatus) {
            this.animateId = setTimeout(function animateBar() {
                that.bar.animate(({width: '100%'}), that.options.animationTime, function () {
                    that.bar.css({width: '0%'});
                    that.nextSlide(that.options.loopStatus);
                });
                that.animateId = setTimeout(animateBar, that.options.loopTime);
            }, that.options.loopTime);
        }
    };


    /**
     * stop progress bar animation function
     * */
    Slider.prototype.resetProgressBarAnimation = function () {
        console.log('%c resetProgressBar Animation', 'color:#ccff00');
        clearTimeout(this.animateId);
    };


    /**
     * events registration
     */
    Slider.prototype.createEvents = function () {
        console.log("%c createEvents", 'color:white');
        var that = this;
        this.arrowRight.on('click', function (event) {
            event.preventDefault();
            that.stopAnimation();
            that.nextSlide();
        });

        this.arrowLeft.on('click', function (event) {
            event.preventDefault();
            that.stopAnimation();
            that.prevSlide();
        });

        this.$form.find('input').on('focusin', function () {
            $(this).parent().addClass('focus');
            that.stopAnimation();
            that.resetProgressBarAnimation();
        });
        this.$form.find('input').on('focusout', function () {
            $(this).parent().removeClass('focus');
            that.progressBarAnimation();
        });

        if (this.options.formOnSlide === true) {

            this.carousel.on('drag.owl.carousel', function () {
                // console.log('%c dragged', 'color:white,font-size:20px');
                that.stopAnimation();
                that.resetProgressBarAnimation();
            });
        }


    };


    /**
     * checks loop status for carousel options
     * @returns {boolean}
     */
    Slider.prototype.checkLoopStatus = function () {
        if (this.options.formOnSlide === true) {
            this.options.loopStatus = false;
        }
        return this.options.loopStatus;

    };


    /**
     * определяет количество элементов в карусели
     * @returns {Slider}
     */
    Slider.prototype.setItemsCount = function () {
        if (!this.options.loopStatus) {
            this.itemsCount = this.$el.find('.item').length;
        }
        return this;
    };

    /**
     * stop progress bar animation
     *@param {boolean} barStatus - включенный ли прогресс бар
     * */
    Slider.prototype.stopAnimation = function () {
        if (this.options.progressBarStatus) {
            this.bar.stop();
            this.bar.css({width: '0%'});
        }
        return this;
    };

    /**
     * initialize form element
     * @param {boolean} formStatus -
     */
    Slider.prototype.initializeFormElement = function () {
        if (this.options.formOnSlide) {
            this.$form = this.$el.find('form');
        }
    };


    $.fn.sliderText = function () {

        return this.each(function () {
            var slider = new Slider(this);
            slider.initialize();

            $(document).ready(function () {
                slider.setHeight();
            });
            $(window).on('resize', function () {
                slider.setHeight();
            });


        });

    };
})(jQuery);