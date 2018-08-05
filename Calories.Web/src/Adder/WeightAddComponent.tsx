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

  constructor(props: WeightAddComponent.Props) {
    super(props);
    this.state = {
      Weight: -1,
      WeightInput : ""
    };
    
    this.api = new WeightApi();
  }

  onChange = (event: ChangeEvent<HTMLInputElement>) => {
    if(Number(event.target.value) > 0 == false)
    {
      this.setState({
        Weight: -1
      })
      
      return;
    }
    this.setState({
      Weight: Number(event.target.value),
      WeightInput : event.target.value
    });
  }

  submit() {
    if (this.state.Weight > 0 == false) {
      alert("Wrong number!");
      return;
    }

    this.api.InsertWeight(
      this.state.Weight,
      new Date()
    ).then(() => {
      alert("Inserted!");
    }).catch((reason:any) => {
      alert("Error!");
    })

    this.setState({
      Weight: -1,
      WeightInput : ""
    });
  }

  renderComponent(): JSX.Element {
    return (
      <div className="Weight">
        <input placeholder="Today's weight" value={this.state.WeightInput} onChange={this.onChange} />
        <button
          onClick={() => {
            this.submit();
          }}
        >
          Submit
        </button>
      </div>
    );
  }
}
