import React from "react";
import TestComponent from "./TestComponent";
import DayOverview from "./DayOverview";
export namespace Dashboard
{
    export interface Props
    {

    }

    export interface State
    {
        
    }
}

class Dashboard extends React.Component<Dashboard.Props, Dashboard.State>
{
    constructor(props: Dashboard.Props)
    {
        super(props);
    }

    render()
    {
        return( <div className="dashboard"> 
            <TestComponent title="One" />
            <DayOverview calories={2000} date={new Date()} weight={100}/>
            <DayOverview calories={1900} date={new Date()} weight={101} />
            <TestComponent title="Three" />
            <TestComponent title="Four"/>
            <TestComponent title="Five" />
            <TestComponent title="Six"/>

        </div>) 
    }
}

export default Dashboard;