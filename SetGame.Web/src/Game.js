import React, { Component } from 'react';
import "./App.css";
import { Board } from './Board';
import { GameMenu } from './GameMenu';

export class Game extends Component {
    constructor(props) {
        super(props);
        console.log('The Original', props.game);
        this.state = {
            game: props.game,
            //gameFunctions: props.gameFunctions
        }
    }

    updateGame = function (gameState) {
        console.log(gameState);
        console.log('state', this.state);
        this.setState({game: gameState});
        //this.state.game = gameState;
        //this.state.game = gameState;
        console.log('game is updated');
    }

    render() {
        return (
            <>
                <GameMenu updateGame={this.updateGame.bind(this) } />
                <Board board={this.props.game.board} updateGame={this.updateGame.bind(this)} />
            </>
        );
    }
}
