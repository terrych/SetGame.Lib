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
        console.log(i);
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
            <div className="col-9 board">
                {Array(3).fill(1).map((el, i) =>
                    <div className="row">
                        {Array(4).fill(1).map((el, i) =>
                            <div className="col-3">
                                {this.renderCard(7)}
                            </div>
                        )}
                    </div>
                )}
            </div>
        );
    }
}