/**
 * @encoding     UTF-8
 * @copyright    Copyright (C) 2016 Torbara (http://torbara.com). All rights reserved.
 * @license      Envato Standard License http://themeforest.net/licenses/standard?ref=torbara
 * @author       Alexei Andriyashevskyi (a.andriyashevskyi@gmail.com)
 * @support      support@torbara.com
 */

(function ($, google, MarkerClusterer) {
    "use strict";
    $.fn.createMap = function (mapselector, options) {

        var defaults = {
                mapStyle: {
                    zoom: 12,
                    center: {lat: -37.777110, lng: 144.967965},
                    gestureHandling: 'cooperative',
                    styles: [
                        {
                            "featureType": "administrative",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "geometry.fill",
                            "stylers": [
                                {
                                    "visibility": "on"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "geometry.stroke",
                            "stylers": [
                                {
                                    "visibility": "on"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry.fill",
                            "stylers": [
                                {
                                    "color": "#9ef699"
                                },
                                {
                                    "visibility": "on"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry.stroke",
                            "stylers": [
                                {
                                    "color": "#9ef699"
                                },
                                {
                                    "visibility": "on"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway.controlled_access",
                            "elementType": "geometry.fill",
                            "stylers": [
                                {
                                    "color": "#7facfb"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway.controlled_access",
                            "elementType": "geometry.stroke",
                            "stylers": [
                                {
                                    "color": "#7facfb"
                                }
                            ]
                        },
                        {
                            "featureType": "transit",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        }
                    ]
                },
                clusterStyles: [{
                    url: './images/oval1.png',
                    width: 64,
                    height: 64,
                    textColor: '#ffffff'

                }],
                locations: [
                    {lat: -31.563910, lng: 147.154312},
                    {lat: -33.718234, lng: 150.363181},
                    {lat: -33.727111, lng: 150.371124},
                    {lat: -33.848588, lng: 151.209834},
                    {lat: -33.851702, lng: 151.216968},
                    {lat: -34.671264, lng: 150.863657},
                    {lat: -35.304724, lng: 148.662905},
                    {lat: -36.817685, lng: 175.699196},
                    {lat: -36.828611, lng: 175.790222},
                    {lat: -37.750000, lng: 145.116667},
                    {lat: -37.759859, lng: 145.128708},
                    {lat: -37.765015, lng: 145.133858},
                    {lat: -37.770104, lng: 145.143299},
                    {lat: -37.773700, lng: 145.145187},
                    {lat: -37.774785, lng: 145.137978},
                    {lat: -37.819616, lng: 144.968119},
                    {lat: -38.330766, lng: 144.695692},
                    {lat: -39.927193, lng: 175.053218},
                    {lat: -41.330162, lng: 174.865694},
                    {lat: -42.734358, lng: 147.439506},
                    {lat: -42.734358, lng: 147.501315},
                    {lat: -42.735258, lng: 147.438000},
                    {lat: -43.999792, lng: 170.463352}
                ],
                fullHeight: false

            },
            settings = $.extend(true, {}, defaults, options);


        function initMap() {

            var map = new google.maps.Map(document.getElementById(mapselector), {
                zoom: settings.mapStyle.zoom,
                center: settings.mapStyle.center,
                gestureHandling: settings.mapStyle.gestureHandling,
                styles: settings.mapStyle.styles,
                fullscreenControlOptions: {
                    position: google.maps.ControlPosition.LEFT_BOTTOM
                }

            });

            // Create an array of alphabetical characters used to label the markers.
            var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

            // Add some markers to the map.
            // Note: The code uses the JavaScript Array.prototype.map() method to
            // create an array of markers based on a given "locations" array.
            // The map() method here has nothing to do with the Google Maps API.
            var markers = settings.locations.map(function (location, i) {
                return new google.maps.Marker({
                    position: location,
                    label: {text: labels[i % labels.length], color: "#ffffff"},
                    icon: './images/oval.png'


                });
            });

            // Add a marker clusterer to manage the markers.
            var markerCluster = new MarkerClusterer(map, markers, {
                styles: settings.clusterStyles


            });
            $(window).one('area-redraw-map', function mapRedraw() {
                google.maps.event.trigger(map, 'resize');
            });
        }

        function setHeight() {
            if (settings.fullHeight === true) {
                var offset = $('#' + mapselector).offset().top,
                    windowWidth = $(window).height();

                var mapHeight = 800;
                if (windowWidth > 800) {
                    mapHeight = windowWidth - offset;
                }


                $('#' + mapselector).css({height: mapHeight + 'px'});

            }
        }

        return this.each(function () {
            initMap();
            setHeight();
            $(window).on('resize', setHeight);
            $(window).on('load', setHeight);
        });

    };
})(jQuery, google, MarkerClusterer);