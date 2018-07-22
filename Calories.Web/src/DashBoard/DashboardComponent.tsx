import React from "react";
import { Dashboard } from "./Dashboard";


namespace DashboardComponent
{
    export interface Props
    {
        columnSpan?: number,
        rowSpan?: number
        title?: string
    }

    export interface State{

    }
}


abstract class DashboardComponent
<
TProps extends DashboardComponent.Props = DashboardComponent.Props,
TState extends DashboardComponent.State = DashboardComponent.State
> 
extends React.Component<TProps, TState>
{
    constructor(props: TProps)
    {
        super(props);
    }

    renderComponent() : JSX.Element 
    {
        return <div>A</div>
    }

    render() : JSX.Element
    {
        var body = this.renderComponent();

        return(
            <div className="dashboardComponent">
                <div className="title">
                    {this.props.title}
                </div>
                <div className="body">
                    {body}
                </div>
            </div>
        )
    }
}


export default DashboardComponent;