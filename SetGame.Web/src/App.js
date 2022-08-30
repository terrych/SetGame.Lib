import React, { Component } from 'react';
import logo from "./logo.svg";
import "./App.css"; 
import { Game } from './Game';

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            game: {},
            //loading: true
        };
    }

    render() {


        //let contents =
            //this.state.loading ?
            //<p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p> :
            //App.renderGame();

        return (
            <div className="row game">
                <Game />
            </div>
        );
    }

    componentDidMount() {
        this.populateGame();
    }

    async populateGame() {
        const response = await fetch('https://localhost:7072/Game/NewGame?variations=3&features=4', { method: 'GET'})
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }

    //componentDidMount() {
    //    this.populateGame();
    //}
    
    //static renderGame() {
    //    return (<Game/>);
    //}

    //async populateGame() {
    //    console.log('testing');
    //    const response = await fetch('weatherforecast');
    //    console.log('testing2');
    //    const data = await response.json();
    //    this.setState({ forecasts: data, loading: false });
    //}
}
