import React from "react";
import { DayWeight } from "../Models/DayWeight";
import { Line, ChartData } from "react-chartjs-2";
import * as chartjs from "chart.js"

namespace WeightChart
{
    export interface Props 
    {
        data: DayWeight[]
    }
}

export class WeightChart extends React.Component<WeightChart.Props>
{
    constructor(props: WeightChart.Props)
    {
        super(props)
    }

    render()
    {
        let weights: DayWeight[] = this.props.data;
        let data:ChartData<chartjs.ChartData> = {
            labels: weights.map( (x:DayWeight) => { return x.dateTime} ),
            datasets: [
                {
                    label: "Weight",
                    fill: false,
                    lineTension: 0.1,
                    backgroundColor: 'rgba(192,192,192,0.6)',
                    borderColor: 'rgba(75,192,192,1)',
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: 'rgba(75,192,192,1)',
                    pointBackgroundColor: '#fff',
                    pointBorderWidth: 1,
                    pointHoverRadius: 5,
                    pointHoverBackgroundColor: 'rgba(75,192,192,1)',
                    pointHoverBorderColor: 'rgba(220,220,220,1)',
                    pointHoverBorderWidth: 2,
                    pointRadius: 1,
                    pointHitRadius: 10,
                    data: weights.map( (x:DayWeight) => {return x.value})
                }
            ]
        }
        return <Line data={data} />
    }
}