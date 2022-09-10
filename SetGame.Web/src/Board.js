import React, { Component } from 'react';
import "./App.css";
import { Card } from './Card';

export class Board extends Component {
    constructor(props) {
        super(props);
        this.state = {
            board: this.props.board ?? [],
            selectedCount: 0,
            selectedCards: []
        }
    }

    // really need to fix this and remove the timeout since I'm probably inviting race conditions
    checkIfSet = function () {
        console.log('board', this.state.board);

        console.log('before');
        setTimeout(function () { // this is awful but without it the selection of last card clicked has not been removed as it is not yet in the classList DOMTokenList
            // do the check and update board if necessary

            // find selected cards and deselect
            var selected = document.getElementsByClassName('board__card--selected');
            console.log('selected', selected);
            //while (selected.length > 0) {
            //    selected[0].classList.remove('board__card--selected');
            //}
            for (var elements = document.getElementsByClassName('board__card--selected'), i = 0, l = elements.length; l > i; i++) {
                elements[0].classList.remove("board__card--selected");
            }
        }, 10);
        this.state.selectedCards = [];
    }

    incrementSelectedCount = function (event) {
        var position = parseInt(event.currentTarget.attributes.position.value);
        console.log('position', position);
        this.state.selectedCards.push(position); // suspicious about this since it is not using setState but it seems to work
        console.log(this.state.selectedCards);
        if (this.state.selectedCards.length >= 3) {
            this.checkIfSet();
        }
        return this.state.selectedCards.length;
    }

    decrementSelectedCount = function (event) {
        var position = parseInt(event.currentTarget.attributes.position.value);
        for (var i = 0; i < this.state.selectedCards.length; i++) {

            if (this.state.selectedCards[i] === position) {

                this.state.selectedCards.splice(i, 1);
            }

        }
        return this.state.selectedCards.length;
    }

    renderCard(array, position) {
        return (
            <Card
                array={array} incrementCount={this.incrementSelectedCount.bind(this)} decrementCount={this.decrementSelectedCount.bind(this)} position={position}
            />
        );
    }

    render() {
        return (
            <div className="col-9 board">{/* onClick={this.props.updateGame }*/}
                {Array(3).fill(1).map((el, i) =>
                    <div className="row">
                        {Array(4).fill(1).map((el2, j) =>
                            <div className="col-3">
                                {this.renderCard((this.state.board && this.state.board.length > 0 ? this.state.board[4 * i + j] : [0, 0, 0, 0]), 4 * i + j)}
                            </div>
                        )}
                    </div>
                )}
            </div>
        );
    }
}