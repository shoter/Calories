import React from "react";
import { IngredientIntake } from "../Models/IngredientIntake";

export interface IngredientIntakeItemProps extends IngredientIntake {}

export class IngredientIntakeItem extends React.Component<IngredientIntakeItemProps> {
    constructor(props: IngredientIntakeItemProps) {
        super(props);


    }

    render() {
        return (<div className="ingredientIntakeItem">
            <div className="main">
                <span className="kcal">{this.props.calories}</span>
                <span className="kcalNoun">kcal</span>
                <span className="ingredient">{this.props.ingredientName}</span>
            </div>
            <div className="date">
                {this.props.date.toLocaleString()}
            </div>
        </div>)
    }
}