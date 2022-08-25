import React, { Component } from 'react';
import "./App.css";

export class Card extends Component {
    render() {
        return (
            <div
                className="board__card"
            >
                <div><img src="./Images/diamond_open_blue.png" /></div>
                <div><img src="./Images/diamond_open_blue.png" /></div>
                <div><img src="./Images/diamond_open_blue.png" /></div>
            </div>
        );
    }
}