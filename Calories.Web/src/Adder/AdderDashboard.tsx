import React from "react";
import {WeightAddComponent} from "./WeightAddComponent";
import { IngredientAddComponent } from "./IngredientAddComponent";
import { IngredientIntakeAddComponent } from "./IngredientIntakeAddComponent";
import { ExerciseAddComponent } from "./ExerciseAddComponent";
export class AdderDashboard extends React.Component<AdderDashboard.Props, AdderDashboard.State>
{
    constructor(props: AdderDashboard.Props)
    {
        super(props);

    }

    render()
    {
        return (
            <div className="dashboard adder">
                <WeightAddComponent />
                <IngredientAddComponent />
                <IngredientIntakeAddComponent />
                <ExerciseAddComponent />
            </div>
        )
    }
} 