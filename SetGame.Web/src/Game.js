import React, { Component } from 'react';
import "./App.css";
import { Board } from './Board';
import { GameMenu } from './GameMenu';

export class Game extends Component {
    constructor(props) {
        super(props);
        this.state = {
            game: props.game
        }
    }

    render() {
        return (
            <>
                <GameMenu />
                <Board board={this.props.game.board} />
            </>
        );
    }
}
