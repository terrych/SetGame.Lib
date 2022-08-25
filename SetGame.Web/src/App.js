import React, { Component } from 'react';
import logo from "./logo.svg";
import "./App.css"; 
import { Game } from './Game';

export default class App extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        let contents = App.renderGame();

        return (
            <div className="row game">
                {contents}
            </div>
        );
    }
    
    static renderGame() {
        return (<Game/>);
    }
}
