import React from "react"


export default class Dupa extends React.Component<Dupa.Props, Dupa.State>
{
    constructor(props : Dupa.Props)
    {
        super(props);

        this.state = {
            isChecked: props.isChecked || false
        }
    }

    onClick() {
        this.setState((prevState : Dupa.State) => ({
            isChecked: !prevState.isChecked
        }));
    }

    render()
    {
        return (
            <div>
                <input onClick={this.onClick.bind(this)} type="checkbox" defaultChecked={this.state.isChecked} />
                <span>
                    {this.props.message}
                </span>
            </div>
        );
    }
}


