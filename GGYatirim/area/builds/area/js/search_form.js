/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($) {
    "use strict";
    $.fn.searchForm = function () {

        /**
         *
         * @param el
         * @constructor
         */
        function FormSelector(el) {
            this.$el = $(el);
            this.formObject = {
                create: false,
                persist: true,
                placeholder: '',
                searchField: ['name'],
                valueField: ['name'],
                options: [],
                render: {}
            };
        }

        /**
         * checks and creates select placeholder
         */
        FormSelector.prototype.setPlaceholder = function () {
            if (this.$el.attr('data-placeholder').length > 0) {
                this.formObject.placeholder = this.$el.attr('data-placeholder');
            }
        };

        /**
         * set select options
         */
        FormSelector.prototype.setOption = function () {
            var that = this,
                options = this.$el.find('option');

            if (options.length !== 0) {
                options.each(function () {
                    that.formObject.options.push({
                        name: $(this).attr('value'),
                        text: $(this).attr('data-text')
                    });
                });
            }

        };

        /**
         * render functions for select with badge
         */
        FormSelector.prototype.renderSelect = function () {
            if (this.$el.hasClass('badge-test')) {
                this.formObject.render.item = function (data, escape) {
                    var $item = $('<div>');
                    var $div = $('<div>').addClass('item').attr('data-value', data.value);
                    var $wrap = $('<div>').addClass('option-wrapper');
                    var $badge = $('<div>').addClass(data.text);
                    var $name = $('<div>');
                    $name.append(escape(data.name));
                    $($wrap).append($badge, $name);
                    $($div).append($wrap);
                    $item.append($div);
                    return $item.html();
                };
                this.formObject.render.option = function (data, escape) {
                    var $item = $('<div>');
                    var $div = $('<div>').addClass('option').attr('data-value', data.value);
                    var $wrap = $('<div>').addClass('option-wrapper');
                    var $badge = $('<div>').addClass(data.text);
                    var $name = $('<div>');
                    $name.append(escape(data.name));
                    $($wrap).append($badge, $name);
                    $($div).append($wrap);
                    $item.append($div);
                    return $item.html();
                };
            }
        };

        /**
         * initialize Selectize
         */
        FormSelector.prototype.initializeSelectise = function () {
            this.select = this.$el.selectize(this.formObject);
        };

        /**
         * clear selected item from the control
         */
        FormSelector.prototype.clearSelect = function () {
            var control = this.select[0].selectize;
            control.clear();
        };

        /**
         * FormSelector initialize function
         */
        FormSelector.prototype.initialize = function () {
            this.setPlaceholder();
            this.setOption();
            this.renderSelect();
            this.initializeSelectise();
        };


        return this.each(function () {
            var $this = $(this),
                data = $(this).data('form-select');

            if (!data) {
                data = new FormSelector(this);
                data.initialize();
                $this.data('form-select', data);
            }

        });

    };
})(jQuery);