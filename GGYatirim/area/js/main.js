(function ($, window, document) {
    "use strict";
    $(document).ready(function () {

        /**Common components js **/

        /*
         *      Init page preloader
         *      @html: ./html-components/preloader.html
         *      @js: ./js/preloader.js
         */

        if ($('#preloader').length > 0) {
            $('#preloader').preloader('circleback', 'circlemain');
            $('#preloader').data('preloader').start();

            $(window).on('load', function () {
                $('#preloader').data('preloader').loaded();
            });
            setTimeout(function () {
                $('#preloader').data('preloader').loaded();
            }, 7000);
        }

        /*
         *      Init page sticky header
         *      @html: ./html-components/header.html
         *      @js: ./js/header.js
         */
        if ($('.header').length > 0) {
            $('.header').areaHeader(1199);
        }

        /*
         *      Init post slider
         *      @html: ./html-components/post_grid.html
         *      @js:   ./js/post_slider.js
         */

        if ($(".post-grid").length > 0) {
            $(".post-grid").postSlider();
        }

        /*
         *      Init apartment grid slider for rent and for sale
         *      @html: ./html-components/apartment_grid_control_up.html
         *      @js: ./js/one_element_slider.js
         */
        if ($('.apartment-grid-control-up.for-rent').length > 0) {
            $('.apartment-grid-control-up.for-rent').oneElementCarousel(2700);
        }

        if ($('.apartment-grid-control-up.for-sale').length > 0) {
            $('.apartment-grid-control-up.for-sale').oneElementCarousel(2700);
        }

        /*
         *      Init apartment grid slider
         *      @html: ./html-components/apartment_grid.html
         *      @js: ./js/one_element_slider.js
         */
        if ($('.apartment-grid').length > 0) {
            $('.apartment-grid').oneElementCarousel(2700);
        }

        /*
         *      Init recent property block slider
         *      @html: ./html-components/recent_property_block.html
         *      @js: ./js/ome_element_slider.js
         */
        if ($('.recent-property-block').length > 0) {
            $('.recent-property-block').oneElementCarousel(2700);
        }

        /*
         *      Init agent grid slider
         *      @html: ./html-components/agent_grid.html
         *      @js: ./js/agent_slider.js
         */
        if ($('.agent-container').length > 0) {
            $('.agent-container').agentSlider();
        }

        /*
         *      Init featured property slider
         *      @html: ./html-components/featured_carousel.html
         *      @js:   ./js/featured_carousel.js
         */

        if ($('.featured-carousel-container').length > 0) {
            $('.featured-carousel-container').oneElementCarousel(700);
        }

        /*
         *      Init property slider
         *      @html: ./html-components/property_carousel.html
         *      @js:   ./js/property_carousel.js
         */

        if ($('.property-carousel-container').length > 0) {
            $('.property-carousel-container').propertySlider();
        }

        /*
         *      Init partners/sponsor slider
         *      @html: ./html-components/partner_carousel.html
         *      @js:   ./js/partner_carousel.js
         */

        if ($('.partner-container').length > 0) {
            $('.partner-container').sponsorSlider();
        }

        /*
         *      Init agents carousel
         *      @html: ./html-components/agents_carousel.html
         *      @js:   ./js/agents_carousel.js
         */

        if ($('.agents-carousel-container').length > 0) {
            $('.agents-carousel-container').agentCarousel();
        }

        /*
         *      Init counters
         *      @html: ./html-components/counters.html
         *      @js:   ./js/counters.js
         */

        if ($('.counters-wrapper').length > 0) {
            $('.counter-element').counters(5000, '.counters-wrapper');
            $('.counters-wrapper').showVisible();
        }

        /*
         *      Init main slider(text)
         *      @html: ./html-components/slider_text.html
         *      @js:   ./js/slider_text.js
         */

        if ($('.slider-text-section').length > 0) {
            $('.slider-text-section').showVisible();
            $('.slider-text-section').sliderText();
        }

        /*
         *      Init property gallery
         *      @html: ./html-components/property_gallery.html
         *      @js:   ./js/property_gallery.js
         *             ./js/preloader.js
         */
        if ($('.property_gallery').length > 0) {
            $('.property_gallery').propertyGallery();
            $('.js-image-preloader').preloader('imagecircleback', 'imagecirclemain');
        }

        /*
         *      Init tab component
         *      @html: ./html-components/area_tabs.html
         *      @js: ./js/area_tabs.js
         */
        if ($('.area-tabs').length > 0) {
            $('.area-tabs').areaTabs();
        }

        /*
         *      Init rate article component
         *      @html: ./html-components/rate_article.html
         *      @js: ./js/rate_article.js
         */
        if ($('.rate-article').length > 0) {
            $('.rate-article').rateArticle();
        }

        /*
         *      Init area accordion component
         *      @html:
         *      @js: ./js/library/accordion.js
         */
        if ($('.accordion').length > 0) {
            $('.accordion').areaAccordion(300);
        }

        /*
         *        Init search-form-1
         *        @html: ./html-components/search_form.html
         *        @js:   ./js/search_form.js
         *               ./js/search_form_slider.js
         *               ./js/count_checker.js
         *               ./js/form_toggle.js
         */

        if ($('.faq-form-wrapper').length > 0) {
            $('.question-form-select').searchForm();

        }

        /*
         *        Init sidebar_search2
         *        @html: ./html-components/sidebar_search2.html
         *        @js:   ./js/search_form.js
         *               ./js/search_form_slider.js
         *               ./js/count_checker.js
         *               ./js/form_toggle.js
         *               ./js/clear_form.js
         */

        if ($('#searchform-sidebar').length > 0) {
            $('#price, #bedrooms, #bathrooms, #garages').formSlider();
            $('#searchform-sidebar .property-select, #searchform-sidebar .location-select,' +
                '  #searchform-sidebar .status-select').searchForm();

            $('#searchform-sidebar').clearForm('.clear-btn');
            $('.sidebar-search').formToggle();
            $('#searchform-sidebar .apartment-features').countCheck();
        }


        if ($('.select-property-price').length > 0) {
            $('.select-property-price').searchForm();
        }

        if ($('.mortage-calculator .payout-cycle').length > 0) {
            $('.mortage-calculator .payout-cycle').searchForm();
        }

        if ($('.account-property .choose-option').length > 0) {
            $('.account-property .choose-option').searchForm();
        }


        /*
         *      Init search form small
         *      @html: ./html-components/search_form_small.html
         *      @js:   ./js/search_form.js
         *             ./js/search_form_slider.js
         *             ./js/count_checker.js
         *             ./js/form_toggle.js
         *             ./js/clear_form.js
         */
        if ($('.search-form-small').length > 0) {
            $('#form-small .property-select, #form-small .location-select,' +
                '  #form-small .status-select').searchForm();
            $('#price, #bedrooms, #bathrooms, #garages').formSlider();
            $('#form-small .apartment-features').countCheck();
            $('#form-small').formToggle();

        }


        /*
         *      Init testimonials slider
         *      @html: ./html-components/testimonials_section.html
         *      @js: ./js/testimonials.js
         */
        if ($('.testimonials').length > 0) {
            $('.testimonials').testimonials();
        }

        /**Hearts active class  **/
        $(".heart i").on("click", function (event) {
            event.preventDefault();
            $(this).toggleClass("active");
        });


        if ($('.ct-chart').length > 0) {
            $('.ct-chart').pageviewsChart();
        }


        /*
         *      Init partner small carousel
         *      @html: ./html-components/partners_small.html
         *      @js: ./js/partners_small.html
         */
        if ($('.partners-small-container').length > 0) {
            $('.partners-small-container').smallPartners(700);
        }


        /*
         *      Init map component
         *      @html: ./html-components/map_component.html
         *      @js: ./js/map_component.js
         */
        if ($('#map').length > 0) {
            $('#map').createMap('map');
        }

        /***Intro page  begin***/

        /*
         *      Set size of intro page main wrapper
         *      @html:  ./templates/intro_page.html
         *      @js:    ./js/intro_page.js
         */

        if ($('.intro-main-wrap').length > 0) {
            $('.intro-main-wrap').setSize();

        }

        /***Intro page end***/

        /***Coming soon page begin***/

        /*
         *      Init coming soon page timer and page height
         *      @html: ./templates/coming_soon.html
         *      @js:    ./js/coming-soon.js
         *              ./js/service-page-size.js
         */

        if ($('.coming-soon').length > 0) {
            $('.coming-soon').comingSoon();
            $('.coming-soon').pageSize();
        }

        /***Coming soon page end***/

        /***Maintenance page begin***/

        /*
         *      Set maintenance page height
         *      @html: ./templates/maintenance.html
         *      @js:   ./js/service-page-size.js
         */
        if ($('.maintenance-page').length > 0) {
            $('.maintenance-page').pageSize();
        }

        /***Maintenance page end***/

        /***HOME 1 begin***/

        /*
         *        Init search-form-1
         *        @html: ./html-components/search_form.html
         *        @js:   ./js/search_form.js
         *               ./js/search_form_slider.js
         *               ./js/count_checker.js
         *               ./js/form_toggle.js
         */

        if ($('.js-home-1-search #search-form-1').length > 0) {
            $('#search-form-1 .property-select, #search-form-1 .location-select,' +
                '  #search-form-1 .status-select').searchForm();
            $('.bedrooms-select-min, .bedroom-select-max, .bathrooms-select-min, ' +
                '.bathrooms-select-max, .garages-select-min, .garages-select-max').searchForm();
            $('#search-form-1 #price').formSlider();
            $('#search-form-1 .apartment-features').countCheck();
            $('#search-form-1').formToggle();

        }

        /*
         *      Init main property slider
         *      @html: ./html-components/property_slider.html
         *      @js: ./js/property_slider.js
         */
        if ($('.property-slider').length > 0) {
            $('.property-slider').propertyMainSlider(1500, '.property-information', 880);
        }

        /***HOME 1 end***/

        /***HOME 2 begin ***/

        /*
        *        Init search-form-1
        *        @html: ./html-components/search_form.html
        *        @js:   ./js/search_form.js
        *               ./js/search_form_slider.js
        *               ./js/count_checker.js
        *               ./js/form_toggle.js
        */

        if ($('.js-home-2-search #search-form-1').length > 0) {
            $('#search-form-1 .property-select, #search-form-1 .location-select,' +
                '  #search-form-1 .status-select').searchForm();
            $('.bedrooms-select-min, .bedroom-select-max, .bathrooms-select-min, ' +
                '.bathrooms-select-max, .garages-select-min, .garages-select-max').searchForm();
            $('#search-form-1 #price').formSlider();
            $('#search-form-1 .apartment-features').countCheck();
            $('#search-form-1').formToggle();

        }

        /***HOME 2 end***/

        /***HOME 3  begin***/

        /*
         *        Init search-form-2
         *        @html: ./html-components/search_form2.html
         *        @js:   ./js/search_form.js
         *               ./js/search_form_slider.js
         *               ./js/count_checker.js
         *               ./js/form_toggle.js
         */

        if ($('.js-home-3-search #search-form-2').length > 0) {
            $('#search-form-2 .property-select, #search-form-2 .location-select,' +
                '  #search-form-2 .status-select').searchForm();
            $('#price, #bedrooms, #bathrooms, #garages').formSlider();
            $('#search-form-2 .apartment-features').countCheck();
            $('#search-form-2').formToggle();
        }

        /***HOME 3  end***/


        /***HOME 4 begin***/

        /*
         *        Init search-form-1
         *        @html: ./html-components/search_form.html
         *        @js:   ./js/search_form.js
         *               ./js/search_form_slider.js
         *               ./js/count_checker.js
         *               ./js/form_toggle.js
         */

        if ($('.js-home-4-search #search-form-1').length > 0) {
            $('#search-form-1 .property-select, #search-form-1 .location-select,' +
                '  #search-form-1 .status-select').searchForm();
            $('.bedrooms-select-min, .bedroom-select-max, .bathrooms-select-min, ' +
                '.bathrooms-select-max, .garages-select-min, .garages-select-max').searchForm();
            $('#search-form-1 #price').formSlider();
            $('#search-form-1 .apartment-features').countCheck();
            $('#search-form-1').formToggle();

        }

        /***HOME 4 end***/


        /***HOME 5 begin***/

        /*
        *        Init search-form-2
        *        @html: ./html-components/search_form2.html
        *        @js:   ./js/search_form.js
        *               ./js/search_form_slider.js
        *               ./js/count_checker.js
        *               ./js/form_toggle.js
        */

        if ($('.js-home-5-search #search-form-2').length > 0) {
            $('#search-form-2 .property-select, #search-form-2 .location-select,' +
                '  #search-form-2 .status-select').searchForm();
            $('#price, #bedrooms, #bathrooms, #garages').formSlider();
            $('#search-form-2 .apartment-features').countCheck();
            $('#search-form-2').formToggle(true, '.home__5__form-toggling');
        }

        /***HOME 5 end***/

        /**
         * init map components
         * @html: ./html-components/contact_map_light.html
         *        ./html-components/contact_map_dark.html
         * @js: ./js/map_component.js
         */
        if ($('#map-small-light').length > 0) {
            $('#map-small-light').createMap('map-small-light');
        }

        if ($('#map-small-dark').length > 0) {
            $('#map-small-dark').createMap('map-small-dark', {

                mapStyle: {
                    styles: [
                        {
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#bdbdbd"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.neighborhood",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.business",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#ffffff"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#dadada"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "road.local",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.line",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.station",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#c9c9c9"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        }
                    ]
                }

            });
        }


        /*
         *      Init sign in form
         *      @html: ./html-components/sign_in_form.less
         *      @js: ./js/sign_in.js
         */
        if ($('#signin-wrap').length > 0) {
            // $('#signin-wrap').signIn('.subscribe-buttons .js-sign-in');
            $('#signin-wrap').signIn('.js-sign-in');
        }


        if ($('.account-page').length > 0) {
            $('.account-page').accountPage();
        }

        if ($('.account-page').length > 0) {
            $('.account-page').chatComponent();
            //$('.account-page').AccountComponent();
        }

        /*
        *      Init light search form
        *      @html: ./html-components/light_search_form.html
        *      @js:   ./js/search_form.js
        *             ./js/search_form_slider.js
        *             ./js/count_checker.js
        *             ./js/form_toggle.js
        */
        if ($('.light-search-form').length > 0) {
            $('#light-form .property-select, #light-form .location-select,' +
                '  #light-form .status-select').searchForm();
            $('#price, #bedrooms, #bathrooms, #garages').formSlider();
            $('#light-form .apartment-features').countCheck();
            $('#light-form').formToggle();
        }

        /*
         * Init circle-bar statistic elements
         * @html: ./html-component/account_donat_chart.html
         * @js: ./js/account_chart.js
         */
        if ($(".circle-bar").length > 0) {
            $(".circle-bar").each(function () {
                $(this).CircleBar();
            });

        }

        /*
        *      Init page sticky header2
        *      @html: ./html-components/header_2.html
        *      @js: ./js/header.js
        */
        if ($('.header2').length > 0) {
            $('.header2').areaHeader(1199);
        }

        /*
         *      Init map component at home7 page
         *      @html: ./html-components/map_component.html
         *      @js: ./js/map_component.js
         */
        if ($('.home-7-style #map').length > 0) {
            $('.home-7-style #map').createMap('map', {

                mapStyle: {
                    styles: [
                        {
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#bdbdbd"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.neighborhood",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.business",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#ffffff"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#dadada"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "road.local",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.line",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.station",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#c9c9c9"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        }
                    ]
                }

            });
        }


        /*
         *      Init map component at listings_half_screen_table.html page
         *      @html: ./html-components/map_component.html
         *      @js: ./js/map_component.js
         */
        if ($('.half-screen-table #map').length > 0) {
            $('.half-screen-table #map').createMap('map', {

                mapStyle: {
                    styles: [
                        {
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#f5f5f5"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#bdbdbd"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.neighborhood",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.business",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#ffffff"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#dadada"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "road.local",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.line",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#e5e5e5"
                                }
                            ]
                        },
                        {
                            "featureType": "transit.station",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#eeeeee"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#c9c9c9"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        }
                    ]
                },
                fullHeight: true

            });
        }


        $('.submit-property-wild-block .property-select, .submit-property-wild-block .label-select,' +
            '  .submit-property-wild-block .status-select , .submit-property-wild-block .price-select, .submit-property-wild-block .value-select').searchForm();
        $('#bedrooms, #bathrooms, #garages').formSlider();

        $('#editor').textEditor();

    });

})(jQuery, window, document);
