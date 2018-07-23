import React from "react";
import { DashboardComponent } from "./DashboardComponent";

interface StatProps
{
    text: String,
    value: String
}

function Stat(props: StatProps) : JSX.Element
    {
        return (
            <div className="stat">
                <span className="text">{props.text}</span>
                <span className="value">{props.value}</span>
            </div>
        )
    } 

export class DayOverview extends DashboardComponent<DayOverview.Props>
{
    public static defaultProps : Partial<DayOverview.Props> = 
    {
        title: "Day overview"
    };

    constructor(props: DayOverview.Props)
    {
        super(props);
    }

    

    renderComponent() : JSX.Element 
    {
        return (
            <div className="dayOverview">    
                <Stat text="Date: " value={this.props.date.toDateString()} />
                <Stat text="Calories: " value={this.props.calories.toString()} />
                <Stat text="Weight: " value={this.props.weight + " kg"} />
            </div>
        )
    }
}