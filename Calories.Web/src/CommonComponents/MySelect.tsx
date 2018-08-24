import React, { ChangeEvent } from "react";


export class MySelect extends React.Component<MySelect.Props, MySelect.State>
{
    static defaultProps = {
       ingredients: []
    }
    constructor(props: MySelect.Props)
    {
        super(props);

        this.state = {
            selectedValue: this.props.selectedValue
        };
    }

    onSelect = (event: ChangeEvent<HTMLSelectElement>) => {
        if(this.props.onSelect === undefined)
            return;

        this.props.onSelect(event.target.value);
    }

    render()
    {
        var options = (this.props.options || []).map((option) => (
        <option key={option.value} value={option.value}>
        {option.text}
        </option>
        ))
        
        return (<select onChange={this.onSelect} defaultValue={this.state.selectedValue}>
                {options}
            </select>)
    }
}