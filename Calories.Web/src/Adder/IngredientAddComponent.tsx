import React from "react";
import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";

namespace IngredientAddComponent
{
    export interface Props extends DashboardComponent.Props
    {

    }
    export interface State extends DashboardComponent.State, Ingredient
    {

    }
}

function ucfirst(str: string) :string {
    var firstLetter = str.substr(0, 1);
    return firstLetter.toUpperCase() + str.substr(1);
}

interface InputProps
{
    name: string;
}

class IngredientAddComponent extends DashboardComponent<IngredientAddComponent.Props, IngredientAddComponent.State>
{
    constructor(props : IngredientAddComponent.Props) {
        super(props);

    }

    Input(props: InputProps) : JSX.Element
    {
        return (<input
        placeholder={ucfirst(props.name)}
        name={props.name} />
        )
    }

    trySubmitForm() {

    }

    renderComponent() : JSX.Element
    {
        return (
            <div className="ingredientAdd">
                <this.Input name="name" />
                <this.Input name="calories" />
                <this.Input name="proteins" />
                <this.Input name="fat" />
                <this.Input name="carbonhydrates" />
                <this.Input name="roughage" />
                <this.Input name="magnes" />
                <this.Input name="potas" />
                <this.Input name="calcium" />
                <this.Input name="phosphor" />
                <this.Input name="iron" />
                <this.Input name="zinc" />
                <this.Input name="cooper" />
                <this.Input name="mangan" />
                <this.Input name="sodium" />
                <this.Input name="jod" />

                <button onClick={this.trySubmitForm}> Send </button>
            </div>
        )
    }
}
