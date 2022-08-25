import React, { Component } from 'react';
import "./App.css";
import { Board } from './Board';
import { GameMenu } from './GameMenu';

export class Game extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <>
                <GameMenu />
                <Board />
            </>
        );
    }
}