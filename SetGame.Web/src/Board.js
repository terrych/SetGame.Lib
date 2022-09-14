import React, { Component } from 'react';
import "./App.css";
import { Card } from './Card';

export class Board extends Component {

    async submitSet(theSet) {
        console.log('theSet', theSet);
        fetch(
            'https://localhost:7072' + "/Game/SubmitSet?gameid=" + this.props.getGame().id,
            {
                method: "PUT",
                body: JSON.stringify(theSet),
                headers: {
                    "Content-Type": "application/json",
                },
            })
            .then((response) => response.json())
            .then((result) => this.props.updateGame(result));
        //const data = await response.json().then(this.props.updateGame(data));
    }

    
    async checkIfSet() {
        var gameState = this.props.getGame();
        var submittedSet = gameState.selectedCards.slice(0, gameState.setSize);
        console.log('submitted', submittedSet);
        await this.submitSet(submittedSet);

        gameState.selectedCards = [];
        this.props.updateGame(gameState);
        console.log(this.props.getGame());
    }

    selectCard = function (event) {
        var position = parseInt(event.currentTarget.attributes.position.value);
        var gameState = this.props.getGame()
        gameState.selectedCards.push(position);
        this.props.updateGame(gameState);
        if (gameState.selectedCards.length >= gameState.setSize) {
            this.checkIfSet();
        }
        return this.props.getGame().selectedCards.length; // use function as checkIfSet will update count
    }

    deselectCard = function (event) {
        var position = parseInt(event.currentTarget.attributes.position.value);
        var gameState = this.props.getGame();
        for (var i = 0; i < gameState.selectedCards.length; i++) {
            if (gameState.selectedCards[i] === position) {
                gameState.selectedCards.splice(i, 1);
            }

        }
        this.props.updateGame(gameState);

        return this.props.getGame().selectedCards.length;
    }

    renderCard(array, position) {
        return (
            <Card
                array={array}
                position={position}
                selectCard={this.selectCard.bind(this)}
                deselectCard={this.deselectCard.bind(this)}
                getGame={this.props.getGame.bind(this)}
                updateGame={this.props.updateGame.bind(this)}
            />
        );
    }

    render() {
        var board = this.props.getGame().board;
        var columns = 4;
        var rows = Math.ceil(board.length / columns);

        return (
            <div className="col-9 board">
                {Array(rows).fill(1).map((el, i) =>
                    <div className="row">
                        {Array(board.length - columns * i > columns ? columns : board.length - columns * i).fill(1).map((el2, j) =>
                            <div className="col-3">
                                {this.renderCard((board && board.length > 0 ? board[columns * i + j] : [0, 0, 0, 0]), columns * i + j)}
                            </div>
                        )}
                    </div>
                )}
            </div>
            /*{this.props.getGame().message}*/
        );
    }
}