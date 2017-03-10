$(function() {
    //Easy Pie Chart
    //------------------------

    try {
        $('.easypiechart#newvisits').easyPieChart({
            barColor: "#ed1a3b",
            trackColor: 'transparent',
            scaleColor: '#eee',
            scaleLength: 8,
            lineCap: 'square',
            lineWidth: 2,
            size: 96,
            onStep: function(from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });

        $('.easypiechart#bouncerate').easyPieChart({
            barColor: "#4295d1",
            trackColor: 'transparent',
            scaleColor: '#eee',
            scaleLength: 8,
            lineCap: 'square',
            lineWidth: 2,
            size: 96,
            onStep: function(from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });

        $('.easypiechart#clickrate').easyPieChart({
            barColor: "#f8981d",
            trackColor: 'transparent',
            scaleColor: '#eee',
            scaleLength: 8,
            lineCap: 'square',
            lineWidth: 2,
            size: 96,
            onStep: function(from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });
        $('.easypiechart#covertionrate').easyPieChart({
            barColor: "#0c4da2",
            trackColor: 'transparent',
            scaleColor: '#eee',
            scaleLength: 8,
            lineCap: 'square',
            lineWidth: 2,
            size: 96,
            onStep: function(from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });


        $('#updatePieCharts').on('click', function() {
            $('.easypiechart#newvisits').data('easyPieChart').update(Math.random()*100);
            $('.easypiechart#bouncerate').data('easyPieChart').update(Math.random()*100);
            $('.easypiechart#clickrate').data('easyPieChart').update(Math.random()*100);
            $('.easypiechart#covertionrate').data('easyPieChart').update(Math.random()*100);
            return false;
        });
    }
    catch(e) {}

});