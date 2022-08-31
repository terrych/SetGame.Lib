import React, { Component } from 'react';
import "./App.css";
import { Board } from './Board';
import { GameMenu } from './GameMenu';

export class Game extends Component {
    constructor(props) {
        super(props);
        console.log('props', props);
        this.state = {
            game: props.game
        }
    }

    render() {
        console.log('game board', this.props.game.board);
        //console.log('board board', this.state);
        return (
            <>
                <GameMenu />
                <Board board={ this.props.game.board } />
            </>
        );
    }
}
