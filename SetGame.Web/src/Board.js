import React, { Component } from 'react';
import "./App.css";
import { Card } from './Card';

export class Board extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cards: Array(12).fill(null)
        }
    }

    handleCardClick(i) {
        console.log(this);
        //const squares = this.state.cards.slice();
        //squares[i] = 'X';
        //this.setState({ squares: squares });
    }

    renderCard(input) {
        return (
            <Card
                value={input}
                onClick={() => this.handleClick(input)}
            />
        );
    }

    render() {
        return (
            <div class="col-9 board">
                {Array(3).fill(1).map((el, i) =>
                    <div class="row">
                        {Array(4).fill(1).map((el, i) =>
                            <div class="col-3">
                                {this.renderCard(7)}
                            </div>
                        )}
                    </div>
                )}
            </div>
        );
        //const status = 'Next player: X';
        //
        //return (
        //    <div>
        //        <div className="status">{status}</div>
        //        <div className="board-row">
        //            {this.renderSquare(0)}{this.renderSquare(1)}{this.renderSquare(2)}
        //        </div>
        //        <div className="board-row">
        //            {this.renderSquare(3)}{this.renderSquare(4)}{this.renderSquare(5)}
        //        </div>
        //        <div className="board-row">
        //            {this.renderSquare(6)}{this.renderSquare(7)}{this.renderSquare(8)}
        //        </div>
        //    </div>
        //);
    }
}