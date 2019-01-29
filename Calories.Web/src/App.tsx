import React from "react";
import Menu from "./Menu";
import {BrowserRouter, Route, Switch } from "react-router-dom";
import About from "./About";
import { Dashboard } from "./DashBoard/Dashboard"; 
import {AdderDashboard} from "./Adder/AdderDashboard";
import { Summary } from "./Summary/Summary";
import { WeightDashboard } from "./Weight/WeightDashboard";

export default class App extends React.Component
{
    links: Menu.Link[] = [
        { to: "/", text: "Home"},
        { to: "/about", text: "About"},
        { to: "/add", text: "Add"},
        { to: "/weight", text: "Weight"},
    ]

    constructor(props: {})
    {
        super(props);
    }

    render(){
        return (
            <div className="app">
                <Menu links={this.links} />
                <div className="work">
                <Switch>
                    <Route exact path="/" component={Dashboard}></Route>
                    <Route path="/about" component={About}></Route>
                    <Route path="/add" component={AdderDashboard}></Route>
                    <Route path="/weight" component={WeightDashboard}></Route>
                </Switch>
                </div>
                <Summary />
                
            </div>
        );
    }
}