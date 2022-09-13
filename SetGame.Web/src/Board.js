import React, { Component } from 'react';
import "./App.css";
import { Card } from './Card';

export class Board extends Component {
    
    // really need to fix this and remove the timeout since I'm probably inviting race conditions
    checkIfSet = function () { // should truncate the "set" to first 3 (or set size) if longer

        setTimeout(function () { // this is awful but without it the selection of last card clicked has not been removed as it is not yet in the classList DOMTokenList
            // do the check and update board if necessary

            // find selected cards and deselect
            var selected = document.getElementsByClassName('board__card--selected');
            //while (selected.length > 0) {
            //    selected[0].classList.remove('board__card--selected');
            //}
            for (var elements = document.getElementsByClassName('board__card--selected'), i = 0, l = elements.length; l > i; i++) {
                elements[0].classList.remove("board__card--selected");
            }
        }, 10);

        var gameState = this.props.getGame();
        gameState.selectedCards = [];
        this.props.updateGame(gameState);
    }

    incrementSelectedCount = function (event) {
        var position = parseInt(event.currentTarget.attributes.position.value);
        var gameState = this.props.getGame()
        gameState.selectedCards.push(position);
        this.props.updateGame(gameState);
        if (gameState.selectedCards.length >= 3) {
            this.checkIfSet();
        }
        return this.props.getGame().selectedCards.length; // use function as checkIfSet will update count
    }

    decrementSelectedCount = function (event) {
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
                array={array} incrementCount={this.incrementSelectedCount.bind(this)} decrementCount={this.decrementSelectedCount.bind(this)} position={position}
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