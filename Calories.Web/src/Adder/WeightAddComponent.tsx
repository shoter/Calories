import React, { ChangeEvent } from "react";
import { DashboardComponent } from "../DashBoard/DashboardComponent";
import { WeightApi } from "../Api/WeightApi";

export class WeightAddComponent extends DashboardComponent<
  WeightAddComponent.Props,
  WeightAddComponent.State
> {
  public static defaultProps: Partial<DayOverview.Props> = {
    title: "Add new weight"
  };

   api : WeightApi;
   isAlive: boolean;

  constructor(props: WeightAddComponent.Props) {
    super(props);
    this.isAlive = false;
    this.state = {
      weight: -1,
      weightInput : "",
      hasWeightToday : false
    };
    
    this.api = new WeightApi();
  }

  onChange = (event: ChangeEvent<HTMLInputElement>) => {
    if(Number(event.target.value) > 0 == false)
    {
      this.setState({
        weight: -1
      })
      
      return;
    }
    this.setState({
      weight: Number(event.target.value),
      weightInput : event.target.value
    });
  }

  submit() {
    if (this.state.weight > 0 == false) {
      alert("Wrong number!");
      return;
    }

    this.api.InsertWeight(
      this.state.weight,
      new Date()
    ).then(() => {
      alert("Inserted!");
    }).catch((reason:any) => {
      alert("Error!");
    })

    this.setState({
      weight: -1,
      weightInput : ""
    });
  }

  componentDidMount() {
    this.isAlive = true;
    this.api.HasWeightToday()
    .then((value : any) => {
      let hasWeight: Boolean = JSON.parse(value);
      if(hasWeight && this.isAlive)
        this.setState({
          hasWeightToday: true
        });
        
    });
  }

  componentWillUnmount() {
    //this.isAlive = false;
  }

  HasWeightToday = (): JSX.Element => {
    let text = "You have not weighted yourself today";
    if(this.state.hasWeightToday)
    {
      text = "You have weight for today. Keep it up";
    }

    return (<div className="hasWeightToday">
      {text}
    </div>);
  }

  renderComponent(): JSX.Element {
    return (
      <div className="weight">
        <input placeholder="Today's weight" value={this.state.weightInput} onChange={this.onChange} />
        <button
          onClick={() => {
            this.submit();
          }}
        >
          Submit
        </button>
        <this.HasWeightToday />
      </div>
    );
  }
}
