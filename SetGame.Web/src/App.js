import React, { Component } from 'react';
import logo from "./logo.svg";
import "./App.css"; 
import { Game } from './Game';

export default class App extends Component {
    constructor(props) {
        super(props);

        this.state = {
            game: {
            }, 
            loading: true
        };
    }

    componentDidMount() {
        this.populateGame();
    }

    static renderGame(input) {
        return (
            <Game game={input}/>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderGame(this.state.game);

        return (
            <div className="row game">
                { contents }
            </div>
        );
    }

    async populateGame() {
        const url = 'https://localhost:7072/Game/NewGame?variations=3&features=4';
        const response = await fetch(url, { method: 'GET' })
        const data = await response.json();
        this.setState({ game: data, loading: false });
    }
}