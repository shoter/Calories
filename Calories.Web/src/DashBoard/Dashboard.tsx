import React from "react";
import { TestComponent } from "./TestComponent";
import { DayOverview } from "./DayOverview"; 
import { DayApi, DaySummary } from "../Api/DayApi";


export class Dashboard extends React.Component<Dashboard.Props, Dashboard.State>
{
    dayApi: DayApi;
    constructor(props: Dashboard.Props)
    {
        super(props);
        this.dayApi = new DayApi();

        this.state = {
            summaries: []
        }
    }

    componentDidMount() {
        this.dayApi.GetSummary(new Date())
        .then((sum : DaySummary) => {
            this.addNewSummary({
                calories: sum.calories,
                caloriesIntakeLeft: sum.allowedIntakeLeft,
                exerciseCalories: sum.exerciseCalories,
                weight: sum.weight,
                date: new Date(),
                text: "Today"
            })
        });
        var yesterday = new Date();
        yesterday.setDate(yesterday.getDate() - 1);

        this.dayApi.GetSummary(yesterday)
        .then((sum : DaySummary) => {
            this.addNewSummary({
                calories: sum.calories,
                caloriesIntakeLeft: sum.allowedIntakeLeft,
                exerciseCalories: sum.exerciseCalories,
                weight: sum.weight,
                date: new Date(),
                text: "Yesterday"
            })
        });
    }

    addNewSummary(summary: Dashboard.DaySummary) {
        this.setState((prevState: Dashboard.State) => {
            var newSummaries = prevState.summaries.concat(summary);
            newSummaries = newSummaries.sort((a: Dashboard.DaySummary, b: Dashboard.DaySummary) => {
                return a.date.getDate() - b.date.getDate();
            })
            return {
                summaries: newSummaries
            }
        })
    }

    render()
    {
        var components: JSX.Element[] = [];
        

        this.state.summaries
        .forEach((sum: Dashboard.DaySummary) => {
            components.push(<DayOverview calories={sum.calories} weight={sum.weight}
                allowedIntakeLeft = {sum.caloriesIntakeLeft} 
                exerciseCalories = {sum.exerciseCalories}
                date={sum.date}
                title={sum.text + " Summary"}
                />);
        })


        return( <div className="dashboard"> 
        {components}
        </div>) 
    }
}