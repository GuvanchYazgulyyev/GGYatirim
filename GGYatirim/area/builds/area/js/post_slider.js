(function ($) {
    "use strict";
    $.fn.postSlider = function () {
        var $el = $(this);

        if ($el.length === 0) {
            throw new Error("postSlider : target element not found");
        }

        var slider = $el.find('.owl-carousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            dots: false,
            responsive: {
                300:{
                    items: 1
                },
                992: {
                    items: 2
                }
            }
        });

        $(".post-grid-arrow-block .arrow-prev").on('click', function (event) {
            event.preventDefault();
            slider.trigger('prev.owl.carousel', [700]);
        });
        $(".post-grid-arrow-block .arrow-next").on('click', function (event) {
            event.preventDefault();
            slider.trigger('next.owl.carousel', [700]);
        });

    };
})(jQuery);