/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($, window) {
    'use strict';
    $.fn.preloader = function (circle1, circle2) {

        /**
         *
         * @param el
         * @param  circleBack (string) - id of the back circle canvas element without #
         * @param circleMain (string) - id of the main circle canvas element without #
         * @constructor
         */
        function AreaLoader(el, circleBack, circleMain) {
            this.$el = $(el);
            this.circ = Math.PI * 2;
            this.quart = Math.PI / 2;
            this.increment = 2;
            this.isLoaded = false;
            this.startValue = 0;
            this.endValue = 100;
            this.circleBack = circleBack;
            this.circleMain = circleMain;

        }

        /**
         * draw back circle function
         */
        AreaLoader.prototype.drawCircleBack = function () {
            var canvas = document.getElementById(this.circleBack);
            if (canvas.getContext) {
                var ctx = canvas.getContext('2d');
                ctx.beginPath();
                ctx.arc(50, 50, 45, 0, 6.3, false);
                ctx.strokeStyle = '#fff';
                ctx.lineWidth = 5;
                ctx.stroke();

            }
        };

        /**
         *  draw main circle function
         */
        AreaLoader.prototype.drawCircleMain = function () {
            var canvas = document.getElementById(this.circleMain);
            var that = this;
            if (canvas.getContext) {
                var ctx = canvas.getContext('2d');
                ctx.clearRect(0, 0, 100, 100);
                ctx.beginPath();
                ctx.arc(50, 50, 45, -this.quart, (this.circ * (this.startValue / 100)) - this.quart, false);
                ctx.strokeStyle = '#6495fe';
                ctx.lineWidth = 5;
                ctx.font = "11px Open Sans";
                ctx.fillText(Math.floor(this.startValue) + '%', 50, 55);
                ctx.fillStyle = "#6495fe";
                ctx.textAlign = "center";
                ctx.stroke();
                if (this.isLoaded === false) {
                    if (this.startValue <= 40) {
                        this.startValue = this.startValue + this.increment;
                        window.requestAnimationFrame(function () {
                            that.drawCircleMain();
                        });
                    }
                    else if (this.startValue > 40 && this.startValue <= 60) {
                        this.increment = 0.1;
                        this.startValue = this.startValue + this.increment;
                        window.requestAnimationFrame(function () {
                            that.drawCircleMain();
                        });
                    }
                }
                else {
                    if (this.startValue < this.endValue) {
                        this.startValue = Math.ceil(this.startValue);
                        this.startValue = this.startValue + this.increment;
                        window.requestAnimationFrame(function () {
                            that.drawCircleMain();
                        });
                    }
                    else if (this.startValue === this.endValue || this.startValue > this.endValue) {
                        this.startValue = 100;
                        window.requestAnimationFrame(function () {
                            ctx.fillText(Math.floor(that.startValue) + '%', 50, 55);
                            that.offLoad();
                        });
                    }
                }
            }
        };

        /**
         * element is loaded
         */
        AreaLoader.prototype.loaded = function () {
            this.isLoaded = true;
            this.increment = 2;
            this.drawCircleMain();

        };

        /**
         * off preloader
         */
        AreaLoader.prototype.offLoad = function () {
            this.$el.css({display: 'none'});
            this.$el.trigger('preloader-animation-over');
        };

        /**
         * start preloader
         */
        AreaLoader.prototype.start = function () {
            var that = this;
            this.startValue = 0;
            this.$el.css({display: 'flex'});
            this.drawCircleBack();
            window.requestAnimationFrame(function () {
                that.drawCircleMain();
            });
        };


        return this.each(function () {
            var $this = $(this),
                data = $(this).data('preloader');

            if (!data) {
                data = new AreaLoader($this, circle1, circle2);
                $this.data('preloader', data);
            }

        });


    };
})(jQuery, window);