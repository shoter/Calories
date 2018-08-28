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
                date: new Date()
            })
        });
    }

    addNewSummary(summary: Dashboard.DaySummary) {
        this.setState((prevState: Dashboard.State) => {
            return {
                summaries: prevState.summaries.concat(summary)
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
                date={sum.date} />);
        })


        return( <div className="dashboard"> 
        {components}
        </div>) 
    }
}