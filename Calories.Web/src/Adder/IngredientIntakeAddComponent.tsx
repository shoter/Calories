import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import React, { ChangeEvent } from "react";
import { MySelect } from "../CommonComponents/MySelect";
import { IngredientApi } from "../Api/IngredientApi";
import { NumberInput } from "../CommonComponents/NumberInput";
import { ValidationResult } from "../Validators/ValidationResult";
import { IngredientIntakeApi } from "../Api/IngredientIntakeApi";
import DatePicker from "react-date-picker";

interface IngredientIntakeAddComponentState extends DashboardComponent.State
{
    ingredients: MySelect.Option[],
    selectedIngredientId? : Number,
    weight?: Number,
    date? :Date
}

export class IngredientIntakeAddComponent extends DashboardComponent<DashboardComponent.Props, IngredientIntakeAddComponentState>
{
    public static defaultProps : Partial<DashboardComponent.Props> = {
        title: "Add new ingredient intake"
    };

    ingredientApi: IngredientApi;
    ingredientIntakeApi: IngredientIntakeApi;
    constructor(props: DashboardComponent.Props)
    {
        super(props);
        this.ingredientApi = new IngredientApi();
        this.ingredientIntakeApi = new IngredientIntakeApi();
        this.state = {
            ingredients: [],
            selectedIngredientId: undefined,
            date: new Date()
        };
    }

    componentDidMount() {
        this.ingredientApi.GetAllIngredients()
        .then((ingredients) => {
            this.setState({
                ingredients: ingredients.map<MySelect.Option>(ingredient => ({
                    text: ingredient.name,
                    value: ingredient.id.toString()
                }))
            });
        });
    }

    onNumberChange = (number? :Number) => {
        this.setState({
            weight: number
        });
    }

    trySubmitForm = () => {
        var validationResult = this.validateForm();
        if(validationResult.isValid())
        {
            this.submitForm();
        }
    }

    submitForm = () => {


        this.ingredientIntakeApi
        .insertIngredientIntake(
        this.state.selectedIngredientId || -1,
        this.state.date || new Date(),
        this.state.weight || -1)
        .then(() => {
            alert("Success!");
        });
    }

    validateForm() : ValidationResult {
        return ValidationResult.prototype.success;
    }

    onDateChange = (date? : Date) => {
        this.setState({
            date: date
        });
    }

    onSelect = (value: string) => {
        this.setState({
            selectedIngredientId: Number(value)
        });
    }
    renderComponent() :JSX.Element
    {
        return (<div className="ingredientIntakeAdd">
        <MySelect
            options={this.state.ingredients}
            onSelect={this.onSelect}
        />
        <NumberInput placeholder="weight (grams)" value={this.state.weight} onNumberChange={this.onNumberChange} />
        <DatePicker onChange={this.onDateChange} value={this.state.date} />
        <button onClick={this.trySubmitForm}> submit </button>
        </div>)
    }
}

