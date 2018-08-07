import React, { ChangeEvent } from "react";
import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import { IngredientValidator } from "../Validators/Ingredients/IngredientValidator";
import { IngredientApi } from "../Api/IngredientApi";

namespace IngredientAddComponent {
  export interface Props extends DashboardComponent.Props {}
  export interface State extends DashboardComponent.State, Ingredient {}
}

function ucfirst(str: string): string {
  var firstLetter = str.substr(0, 1);
  return firstLetter.toUpperCase() + str.substr(1);
}

interface InputProps {
  name: string;
}

export class IngredientAddComponent extends DashboardComponent<
  IngredientAddComponent.Props,
  IngredientAddComponent.State
> {
    validator: IngredientValidator;
    api: IngredientApi;
  constructor(props: IngredientAddComponent.Props) {
    super(props);

    this.validator = new IngredientValidator();
    this.api = new IngredientApi();

    this.state = {
      id: -1, //unused
      calories: 0,
      name: ""
    };
  }

  Input = (props: InputProps): JSX.Element => {
    var onChange = (event: ChangeEvent<HTMLInputElement>) => {
        var target = event.target;
        var value :any = target.value;
        var name = target.getAttribute("name");

        //@ts-ignore    
        this.setState({
            [name as any] : value
        }); //My dear god... really typescript?
    };

    var value = (this.state[props.name] || "").toString();

    return <input placeholder={ucfirst(props.name)} name={props.name} value={value} onChange={onChange} />;
  }

  trySubmitForm = () => 
  {
      var result = this.validator.validate(this.state);
      if(result.isValid())
      {
          this.submitForm();
      }
      else
      {
          alert("Problems!");
          console.log(result);
      }
  }

  submitForm()
  {
        var state = this.state;
        this.clearState();
        this.api.InsertIngredient(state)
        .then(() => {
            alert("Udao sie!1");
        }).catch(() => {
            alert("Error :(");
        })
        
  }

  clearState()
  {
    this.setState({
        calcium: undefined,
        calories: 0,
        carbonhydrates: undefined,
        copper: undefined,
        fat: undefined,
        id: -1,
        iron: undefined,
        jod: undefined,
        magnes: undefined,
        mangan: undefined,
        name : "",
        phosphor: undefined,
        potas: undefined,
        proteins: undefined,
        roughage: undefined,
        sodium: undefined,
        zinc: undefined
    });
  }

  renderComponent(): JSX.Element {
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
    );
  }
}
