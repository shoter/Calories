import React from "react";
import Menu from "./Menu";
import {BrowserRouter, Route, Switch } from "react-router-dom";
import About from "./About";
import { Dashboard } from "./DashBoard/Dashboard"; 

export default class App extends React.Component
{
    links: Menu.Link[] = [
        { to: "/", text: "home"},
        { to: "/about", text: "about"}
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
                </Switch>
                </div>
            </div>
        );
    }
}