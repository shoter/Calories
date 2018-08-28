import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import React, { ChangeEvent } from "react";
import { MySelect } from "../CommonComponents/MySelect";
import { IngredientApi } from "../Api/IngredientApi";
import { NumberInput } from "../CommonComponents/NumberInput";
import { ValidationResult } from "../Validators/ValidationResult";
import { IngredientIntakeApi } from "../Api/IngredientIntakeApi";
import DatePicker from "react-date-picker";
import Select from "react-select";
import {
  ActionMeta,
  ValueType
} from "../../node_modules/@types/react-select/lib/types";
import { SelectStyle } from "../Common/SelectStyle";
import { SizeApi } from "../Api/SizeApi";
import { SizeType } from "../Models/SizeType";

interface IngredientIntakeAddComponentState extends DashboardComponent.State {
  ingredients: Ingredient[];
  selectedIngredientId?: Number;
  weight?: Number;
  date?: Date;
  weightText: string;
}

export class IngredientIntakeAddComponent extends DashboardComponent<
  DashboardComponent.Props,
  IngredientIntakeAddComponentState
> {
  public static defaultProps: Partial<DashboardComponent.Props> = {
    title: "Add new ingredient intake"
  };

  ingredientApi: IngredientApi;
  ingredientIntakeApi: IngredientIntakeApi;
  isAlive: boolean;
  sizeApi: SizeApi;
  constructor(props: DashboardComponent.Props) {
    super(props);
    this.ingredientApi = new IngredientApi();
    this.ingredientIntakeApi = new IngredientIntakeApi();
    this.sizeApi = new SizeApi();
    this.isAlive = true;
    this.state = {
      ingredients: [],
      selectedIngredientId: undefined,
      date: new Date(),
      weightText: "grams"
    };
  }

  componentDidMount() {
    this.isAlive = true;
    this.ingredientApi.GetAllIngredients().then(ingredients => {
      if (this.isAlive)
        this.setState({
          ingredients: ingredients
        });
    });
  }

  componentWillUnmount() {
    this.isAlive = false;
  }

  onNumberChange = (number?: Number) => {
    this.setState({
      weight: number
    });
  };

  trySubmitForm = () => {
    var validationResult = this.validateForm();
    if (validationResult.isValid()) {
      this.submitForm();
    }
  };

  submitForm = () => {
    this.ingredientIntakeApi
      .insertIngredientIntake(
        this.state.selectedIngredientId || -1,
        this.state.date || new Date(),
        this.state.weight || -1
      )
      .then(() => {
        alert("Success!");
      });
  };

  validateForm(): ValidationResult {
    return ValidationResult.prototype.success;
  }

  onDateChange = (date?: Date) => {
    this.setState({
      date: date
    });
  };

  onSelect = (ingredient: ValueType<Ingredient>, action: ActionMeta) => {
    if (ingredient && !(ingredient instanceof Array)) {
      this.setState({
        selectedIngredientId: ingredient.id
      });
      this.sizeApi.GetSizeType(ingredient.sizeTypeID)
      .then((st: SizeType) => {
          this.setState({
              weightText: st.name
          })
      })
    }
  };
  renderComponent(): JSX.Element {
    return (
      <div className="ingredientIntakeAdd">
        <Select<Ingredient>
          options={this.state.ingredients}
          getOptionValue={(i: Ingredient) => {
            return i.id.toString();
          }}
          getOptionLabel={(i: Ingredient) => {
            return i.name;
          }}
          onChange={this.onSelect}
          styles={SelectStyle}
        />
        <NumberInput
          placeholder={"weight (" + this.state.weightText + ")"}
          value={this.state.weight}
          onNumberChange={this.onNumberChange}
        />
        <DatePicker onChange={this.onDateChange} value={this.state.date} />
        <button onClick={this.trySubmitForm}> submit </button>
      </div>
    );
  }
}
