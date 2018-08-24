import React from "react";
import Menu from "./Menu";
import {BrowserRouter, Route, Switch } from "react-router-dom";
import About from "./About";
import { Dashboard } from "./DashBoard/Dashboard"; 
import {AdderDashboard} from "./Adder/AdderDashboard";
import { Summary } from "./Summary/Summary";

export default class App extends React.Component
{
    links: Menu.Link[] = [
        { to: "/", text: "home"},
        { to: "/about", text: "about"},
        { to: "/add", text: "Add"}
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
                    <Route Path="/add" component={AdderDashboard}></Route>
                </Switch>
                </div>
                <Summary />
                
            </div>
        );
    }
}