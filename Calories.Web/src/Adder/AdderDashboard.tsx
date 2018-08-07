import React from "react";
import {WeightAddComponent} from "./WeightAddComponent";
import { IngredientAddComponent } from "./IngredientAddComponent";
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
            </div>
        )
    }
} 