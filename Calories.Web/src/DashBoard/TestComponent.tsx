import React from "react";
import DashboardComponent from "./DashboardComponent";

export default class TestComponent extends DashboardComponent
{
    constructor(props: DashboardComponent.Props)
    {
        super(props);
    }

    renderComponent() : JSX.Element
    {
        return (
            <div>
                Test component
            </div>
        )
    }
}