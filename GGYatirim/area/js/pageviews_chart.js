(function ($, Chartist) {
    "use strict";
    $.fn.pageviewsChart = function () {
        var chart = new Chartist.Line('#pageviews', {
            labels: [19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30],
            series: [[345, 390, 400, 500, 560, 510, 320, 359, 419, 310, 330, 350]]
        }, {
            low: 0,
            showArea: true,
            fullWidth: true,
            height: 250,
            axisY: {
                showGrid: false,
                onlyInteger: true,
                type: Chartist.FixedScaleAxis,
                ticks: [200, 400, 600],
                low: 0,
                high: 650,
                offset: 25
            }

        });

        chart.on('draw', function (data) {
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: [data.x],
                    cy: [data.y],
                    r: [4]
                }, 'ct-circle');
                data.element.replace(circle);
            }
        });

        $(window).on('chartist-update', function () {
            setTimeout(function () {
                chart.update();
            }, 1500);
        });
    };
})(jQuery, Chartist);