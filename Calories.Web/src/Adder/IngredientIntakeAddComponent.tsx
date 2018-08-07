import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import {SelectBase} from "react-select"
import { OptionProps, ActionMeta, ValueType, GroupedOptionsType, GroupType } from "../../node_modules/@types/react-select/lib/types";
import React from "react";

interface SelectOption extends GroupType<any>
{
    value: string,
    label: string
}

interface IngredientIntakeAddComponentState extends DashboardComponent.State
{
    ingredients: GroupedOptionsType<any>
    selectedIngredientId? : Number
}

export class IngredientIntakeAddComponent extends DashboardComponent<DashboardComponent.Props, IngredientIntakeAddComponentState>
{
    constructor(props: DashboardComponent.Props)
    {
        super(props);
        this.state = {
            ingredients: [],
            selectedIngredientId: undefined
        };
    }

    onSelect = (value: ValueType<Number>, action: ActionMeta) => {

    }

    renderComponent() :JSX.Element
    {
        return (<div className="ingredientIntakeAdd">
            <SelectBase 
           // value={this.state.selectedIngredientId || 0}
         //   onChange={this.onSelect}
         //   options={this.state.ingredients}
            />
        </div>)
    }
}

