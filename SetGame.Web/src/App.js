import React, { Component } from 'react';
import logo from "./logo.svg";
import "./App.css"; 
import { Game } from './Game';
import axios from 'axios'

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            game: {
            }
        };
        //const url = 'https://localhost:7072/Game/NewGame?variations=3&features=4';
        //axios.get(url)
        //    .then((response) => {
        //        console.log('response', response);
        //        this.state.game = response.data;
        //    });
    }

    render() {
        console.log('app state', this.state);
        return (
            <div className="row game">
                <Game game={ this.state.game }/>
            </div>
        );
    }

    componentDidMount() {
        const url = 'https://localhost:7072/Game/NewGame?variations=3&features=4';
        axios.get(url)
            .then((response) => {
                console.log('response', response);
                this.setState({ game: response.data });
            });
    }

    async populateGame() {
        const response = await fetch('https://localhost:7072/Game/NewGame?variations=3&features=4', { method: 'GET'})
        const data = await response.json();
        this.setState({ game: data });
    }
}