import React, { Component } from 'react';
import "./App.css";
import { Board } from './Board';
import { GameMenu } from './GameMenu';

export class Game extends Component {
    render() {
        var game = this.props.getGame();
        return (
            <>
                <GameMenu updateGame={this.props.updateGame.bind(this) } />
                <Board board={game.board} updateGame={this.props.updateGame.bind(this)} getGame={this.props.getGame.bind(this) } />
            </>
        );
    }
}
