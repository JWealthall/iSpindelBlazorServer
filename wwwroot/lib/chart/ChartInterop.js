function drawChart(id, dateSrc, gravities, temperatures) {
    var dates = dateSrc.map(d => new Date(d));
    var ctx = document.getElementById(id).getContext('2d');
    var chart = new Chart(ctx,
        {
            // The type of chart we want to create
            type: 'line',

            // The data for our dataset
            data: {
                labels: dates,
                datasets: [
                    {
                        label: 'Gravity',
                        yAxisID: 'y-axis-0',
                        fill: false,
                        backgroundColor: '#3366CC',
                        borderColor: '#3366CC',
                        data: gravities,
                        borderWidth: 2,
                        pointRadius: 0,
                        trendlineLinear: {
                            style: "#3e95cd",
                            lineStyle: "line",
                            width: 1
                        }
                    },
                    {
                        label: 'Temperature',
                        yAxisID: 'y-axis-1',
                        fill: false,
                        backgroundColor: '#DC3912',
                        borderColor: '#DC3912',
                        borderWidth: 2,
                        data: temperatures,
                        pointRadius: 0,
                        trendlineLinear: {
                            style: "#EA8A73",
                            lineStyle: "line",
                            width: 1
                        }
                    }
                ]
            },

            // Configuration options go here
            options: {
                scales: {
                    xAxes: [
                        {
                            type: 'time',
                            time: {
                                minUnit: "day"
                            }
                        }
                    ],
                    yAxes: [
                        {
                            id: 'y-axis-0',
                            position: 'left'
                        }, {
                            id: 'y-axis-1',
                            type: 'linear',
                            position: 'right',
                            ticks: {
                                min: 0
                            },
                            gridLines: {
                                display: false
                            }
                        }
                    ]
                },
                tooltips: {
                    mode: 'index',
                    callbacks: {
                        label: function (tooltipItem, data) {
                            return data.datasets[tooltipItem.datasetIndex].label +
                                ': ' +
                                data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        }
                    }
                }
            }
        });
}