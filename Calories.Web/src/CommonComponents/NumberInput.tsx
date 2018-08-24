import React, { ChangeEvent } from "react";

export class NumberInput extends React.Component<NumberInput.Props, NumberInput.State> {
    constructor(props: NumberInput.Props) {
        super(props);

        let input = "";
        if(props.value !== undefined)
            input = props.value.toString();

        this.state = {
            input: input,
            lastNumber: props.value
        };
    }

    onChange = (event : ChangeEvent<HTMLInputElement>) => {
        var str = event.target.value;
        let number = Number(str); 

        if(isNaN(number))
        return;

        if(str.trim() === "")
        {
            this.informAboutNewNumber(undefined);
        }
        else
        {
            this.informAboutNewNumber(number);
        }

        this.setState({
            input: str
        });
    }

    informAboutNewNumber(number? : Number)
    {
        if(this.state.lastNumber !== number)
                this.props.onNumberChange(number);
    }

    render() {
        return (<input
        onChange={this.onChange}
        value={this.state.input}
        placeholder={this.props.placeholder}
        />)
    }
}