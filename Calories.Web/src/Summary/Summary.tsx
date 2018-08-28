import React from "react";
import { IngredientIntake } from "../Models/IngredientIntake";
import { IngredientIntakeApi } from "../Api/IngredientIntakeApi";
import { IngredientIntakeItem } from "./IngredientIntakeItem";
import { WeightApi } from "../Api/WeightApi";

export interface SummaryState {
    intakes: IngredientIntake[],
    weight?: Number
}

export class Summary extends React.Component<{}, SummaryState>
{
    api: IngredientIntakeApi;
    weightApi: WeightApi;
    isAlive: boolean;
    constructor(props: {})
    {
        super(props)
        this.api = new IngredientIntakeApi();
        this.weightApi = new WeightApi();
        this.isAlive = false;

        this.state = {
            intakes: []
        }
    }

    componentDidMount() {
        this.isAlive = true;
        this.api.getIngredientIntakeForDay(new Date())
        .then( (intakes: IngredientIntake[]) => {
            if(this.isAlive)
            this.setState({intakes:intakes})
        });

        this.weightApi.GetWeight(new Date()).then((weight: Number | null) => {
            if(weight !== null && this.isAlive)
                this.setState({weight:weight});
        })
    }

    componentWillUnmount() {
        //this.isAlive = false;
    }

    TodayWeight = () => {
        if(this.state.weight === undefined)
        return null;
        
        return (<div className="weight">
            Today: {this.state.weight.toString()} kg
        </div>)
    }



    render() {

        var items = this.state.intakes
        .map((i:IngredientIntake) => {
            return <IngredientIntakeItem key={i.id.toString()} calories= {i.calories} date ={i.date} id={i.id} ingredientId={i.ingredientId} ingredientName={i.ingredientName} weight={i.weight} />
        })

        return (<div className="summary">
        <div className="title">Summary</div>
            <this.TodayWeight />
            {items}
        </ div>)
    }
}