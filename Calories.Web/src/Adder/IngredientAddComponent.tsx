import React, { ChangeEvent } from "react";
import { Ingredient } from "../Models/Ingredient";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import { IngredientValidator } from "../Validators/Ingredients/IngredientValidator";
import { IngredientApi } from "../Api/IngredientApi";
import { SizeType } from "../Models/SizeType";
import { SizeApi } from "../Api/SizeApi";
import Select from "react-select";
import { SelectStyle } from "../Common/SelectStyle";
import { ValueType, ActionMeta } from "../../node_modules/@types/react-select/lib/types";

namespace IngredientAddComponent {
  export interface Props extends DashboardComponent.Props {}
  export interface State extends DashboardComponent.State
  {
      ingredient: Ingredient,
      sizeTypes: SizeType[]
  }
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
    sizeApi: SizeApi;

  constructor(props: IngredientAddComponent.Props) {
    super(props);

    this.validator = new IngredientValidator();
    this.api = new IngredientApi();
    this.sizeApi = new SizeApi();

    this.state = {
      ingredient: {
        id: -1,
        calories: 0,
        sizeTypeID: -1,
        name: ""
      },
      sizeTypes: []
    };
  }

  componentDidMount()
  {
    this.sizeApi.GetSizeTypes()
    .then((sizes: SizeType[]) => {
      this.setState({
        sizeTypes: sizes
      })
    });
  }

  Input = (props: InputProps): JSX.Element => {
    var onChange = (event: ChangeEvent<HTMLInputElement>) => {
        var target = event.target;
        var value :any = target.value;
        var name = target.getAttribute("name");

        //@ts-ignore    
        this.setState((prevState: IngredientAddComponent.State) => ({
          ...prevState,
          ingredient: {
            ...prevState.ingredient,
            [name as any]: value
          }
        }))
        //My dear god... really typescript?
    };

    var value = (this.state.ingredient[props.name] || "").toString();

    return <input placeholder={ucfirst(props.name)} name={props.name} value={value} onChange={onChange} />;
  }

  trySubmitForm = () => 
  {
      var result = this.validator.validate(this.state.ingredient);
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
        this.api.InsertIngredient(state.ingredient)
        .then(() => {
            alert("Udao sie!1");
        }).catch(() => {
            alert("Error :(");
        })
        
  }

  clearState()
  {
    this.setState({ ingredient: {
        sizeTypeID: -1,
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
    }});
  }

  onSizeTypeSelect= (sizeType: ValueType<SizeType>, action: ActionMeta) => {
     if(sizeType && !(sizeType instanceof Array)) 
     {
       
       this.setState((prevState : IngredientAddComponent.State) => ({
         ...prevState,
         ingredient: {
           ...prevState.ingredient,
           sizeTypeID: sizeType.id
         }
       }));
     }
  }

  renderComponent(): JSX.Element {
    return (
      <div className="ingredientAdd">
        <this.Input name="name" />
        <this.Input name="calories" />
        <Select<SizeType>
            options={this.state.sizeTypes}
            getOptionLabel={(t:SizeType) => t.name}
            getOptionValue={(t:SizeType)=>t.id.toString()}
            styles={SelectStyle}
            onChange={this.onSizeTypeSelect}
            />
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
