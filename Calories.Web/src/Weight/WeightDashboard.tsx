import React from "react";
import { DayWeight } from "../Models/DayWeight";
import { WeightApi } from "../Api/WeightApi";
import { WeightChart } from "./WeightChart";
import { WeightBetween } from "../Models/WeightBetween";
import { NumberInput } from "../CommonComponents/NumberInput";
namespace WeightDashboard
{
    export interface State {
        startDate: Date,
        endDate: Date,
        weights: DayWeight[] | null,
        daysShown: number
    }
}

export class WeightDashboard extends React.Component<{}, WeightDashboard.State>
{
    api: WeightApi;

    constructor(props: {})
    {
        super(props);
        this.api = new WeightApi();
        var startDate = new Date();
        startDate.setDate(startDate.getDate() - 5);
        this.state = {
            startDate : startDate, 
            endDate: new Date(),
            weights: null,
            daysShown: 5
        }
    }

    componentDidMount()
    {
        this.updateWeights();
    }

    updateWeights = () => {
        this.api.GetWeightsBetween(this.state.startDate, this.state.endDate)
        .then((weightBetween: WeightBetween) => {
            this.setState({
                weights: weightBetween.weights
            });
        })
    }

onDaysChange = (days?: Number) => {
       if(days)
       {
           this.setState({
               daysShown: days.valueOf()
           });
       } 
    }

refresh = () => {
    var startDate = new Date();
    startDate.setDate(startDate.getDate() - this.state.daysShown.valueOf());
    this.setState({
        startDate: startDate
    });
    console.log(startDate);
    this.updateWeights();
}

    render()
    {
        let chart: JSX.Element | null = null;
        
        if(this.state.weights !== null)
        {
            chart = (<WeightChart data={this.state.weights} />);
        }
        
        return (<div className="dashboard chart">
        <div className="chartImg">
            {chart}
            </div>
            <div>
            <NumberInput value={this.state.daysShown} onNumberChange={this.onDaysChange} />
            <button onClick={this.refresh}>Refresh</button>
            </div>
        </div>)
    }

}