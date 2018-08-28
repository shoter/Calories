import React, {ChangeEvent} from "react";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import { ExerciseType } from "../Models/ExerciseType";
import { ExerciseApi } from "../Api/ExerciseApi";
import Select from "react-select";
import { ActionMeta, ValueType } from "../../node_modules/@types/react-select/lib/types";
import { NumberInput } from "../CommonComponents/NumberInput"
import { SelectStyle } from "../Common/SelectStyle";

namespace ExerciseAddComponent {
    export interface State extends DashboardComponent.State
    {
        exerciseTypes: ExerciseType[],
        exerciseTypeID? :Number,
        Calories?: Number
    }
}

export class ExerciseAddComponent extends DashboardComponent<DashboardComponent.Props, ExerciseAddComponent.State>
{
    public static defaultProps : Partial<DashboardComponent.Props> = {
        title: "Add new exercise"
    }

    api: ExerciseApi;
    constructor(props: DashboardComponent.Props)
    {
        super(props);
        this.api = new ExerciseApi();
        this.state = {
            exerciseTypes: []
        };
    }

    componentDidMount() {
        this.api.GetAllExerciseTypes()
        .then((types: ExerciseType[]) => {
            this.setState({
                exerciseTypes: types
            })
        });
    }

    onSelect = (exerciseType: ValueType<ExerciseType>, action: ActionMeta) =>
    {
        if(exerciseType && !(exerciseType instanceof Array))
        {
            this.setState({
                exerciseTypeID: exerciseType.id
            });
        }
    }

    onCalorieChange = (calorie?: Number) =>
    {
        this.setState({
            Calories: calorie
        });
    }

    submitForm = () => {
        if(this.state.exerciseTypeID && this.state.Calories)
        {
        this.api.InsertExercise(new Date(),
        this.state.exerciseTypeID,
        this.state.Calories)
        }
    }

   renderComponent() : JSX.Element
   {
       return (<div className="exerciseAddComponent">
       <Select<ExerciseType>
            options={this.state.exerciseTypes}
            getOptionValue={(e:ExerciseType) => e.id.toString()}
            getOptionLabel={(e:ExerciseType) => e.name}
            onChange={this.onSelect}
            styles={SelectStyle}
       />
       <NumberInput placeholder="Calories" onNumberChange={this.onCalorieChange} value={this.state.Calories} />
       <button type="button" onClick={this.submitForm}>submit</button>
       </div>)
   }
}
