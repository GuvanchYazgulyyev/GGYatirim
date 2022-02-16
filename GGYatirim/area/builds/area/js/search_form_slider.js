/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */


(function ($) {
    "use strict";

    $.fn.formSlider = function () {

        /**
         *
         * @param el
         * @constructor
         */
        function FormRangeSlider(el) {
            this.$el = $(el);
            this.sliderObject = {
                grid: false,
                hide_min_max: "true",
                hide_from_to: "true",
                step: NaN
            };

        }

        /**
         * get values for slider
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.getValues = function () {
            this.firstNumber = Number(this.$el.prop("value").split(';')[0]);
            this.secondNumber = Number(this.$el.prop("value").split(";")[1]);
            return this;
        };

        /**
         * set slider type ( single or double )
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.setSliderType = function () {
            this.type = this.$el.attr('data-type');
            return this;
        };

        /**
         * set slider values
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.setSliderValues = function () {
            var that = this;
            if (this.type === 'single') {
                delete this.sliderObject.to;
            }
            else {
                this.sliderObject.to = this.$el.attr("data-to");
            }
            this.sliderObject.type = this.$el.attr("data-type");
            this.sliderObject.min = Number(this.$el.attr("data-min"));
            this.sliderObject.max = Number(this.$el.attr("data-max"));
            this.sliderObject.from = Number(this.$el.attr("data-from"));
            this.sliderObject.step = Number(this.$el.attr("data-step"));
            this.sliderObject.onStart = function onStartEvent() {
                that.getValues();
                that.displayValues();
            };
            this.sliderObject.onChange = function onChangeEvent() {
                that.getValues();
                that.displayValues();
            };
            this.sliderObject.onUpdate = function onChangeEvent() {
                that.getValues();
                that.displayValues();
            };

            return this;
        };

        /**
         * set wrapper class for number and separator fields
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.setElementClass = function () {
            this.$class = $("." + this.$el.attr("id"));
            return this;
        };


        /**
         * set fields to display slider values
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.setValuesFields = function () {
            this.firstNumberField = this.$class.find('.js-first-number');
            this.secondNumberField = this.$class.find('.js-second-number');
            this.separatorNumberField = this.$class.find('.js-separator');
            return this;
        };


        /**
         * checks prettify option
         */
        FormRangeSlider.prototype.getPrettify = function () {
            if (this.$el.attr('data-prettify') !== undefined) {
                this.prettify = true;
                this.prettifyValues = this.$el.attr('data-prettify');
            }
            else {
                this.prettify = false;
            }
        };

        /**
         * set prettify values
         */
        FormRangeSlider.prototype.setPrettifyValues = function () {
            if (this.prettify === true) {
                this.prettifyBasis = this.prettifyValues.split('-')[0];
                this.prettifyUnit = this.prettifyValues.split('-')[1];
                this.prettifyCurrency = this.prettifyValues.split('-')[2];
            }
        };


        /**
         * display values function
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.displayValues = function () {
            var firstNumber,
                secondNumber;

            if (this.prettify === true) {
                var basis = this.prettifyBasis === "0" ? 1 : parseInt(this.prettifyBasis, 10),
                    unit = this.prettifyUnit === "0" ? ' ' : this.prettifyUnit,
                    currency = this.prettifyCurrency === "0" ? ' ' : this.prettifyCurrency;

                firstNumber = currency + Math.ceil(this.firstNumber / basis) + unit;
                secondNumber = currency + Math.ceil(this.secondNumber / basis) + unit;

            }
            else {
                firstNumber = this.firstNumber;
                secondNumber = this.secondNumber;

            }


            if (this.type === 'single') {
                this.firstNumberField.html(firstNumber);
            }
            else {
                if (this.firstNumber === 0 && this.secondNumber === 0) {
                    this.firstNumberField.html(firstNumber);
                    this.separatorNumberField.css({display: "none"});
                    this.secondNumberField.css({display: "none"});
                    this.firstNumberField.css({display: "inline-block"});
                }
                else if (this.firstNumber === this.secondNumber) {
                    this.firstNumberField.html(firstNumber);
                    this.separatorNumberField.css({display: "none"});
                    this.secondNumberField.css({display: "none"});
                }


                else if (this.firstNumber === 0) {
                    this.firstNumberField.css({display: "none"});
                    this.separatorNumberField.css({display: "inline-block"});
                    this.secondNumberField.css({display: "inline-block"});
                    this.separatorNumberField.html("<");
                    this.secondNumberField.html(secondNumber);
                }
                else {
                    this.firstNumberField.css({display: "inline-block"});
                    this.separatorNumberField.css({display: "inline-block"});
                    this.secondNumberField.css({display: "inline-block"});
                    this.separatorNumberField.html("-");
                    this.secondNumberField.html(secondNumber);
                    this.firstNumberField.html(firstNumber);

                }
            }
            return this;
        };


        /**
         * initialize ionRangeSlider
         */
        FormRangeSlider.prototype.initializeSlider = function () {
            this.$el.ionRangeSlider(this.sliderObject);
        };

        /**
         * initialize FormRangeSlider
         * @returns {FormRangeSlider}
         */
        FormRangeSlider.prototype.initialize = function () {
            this.setSliderType();
            this.setSliderValues();
            this.setElementClass();
            this.setValuesFields();
            this.getPrettify();
            this.setPrettifyValues();
            this.initializeSlider();
            return this;
        };


        /**
         * reset slider values function
         */
        FormRangeSlider.prototype.resetSlider = function () {
            var slider = this.$el.data('ionRangeSlider');
            slider.reset();
        };


        return this.each(function () {
            var $this = $(this),
                dataSlider = $(this).data('form-range-slider');

            if (!dataSlider) {
                dataSlider = new FormRangeSlider(this);
                dataSlider.initialize();
                $this.data('form-range-slider', dataSlider);
            }

        });


    };

})(jQuery);