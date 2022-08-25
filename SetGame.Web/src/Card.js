import React, { Component } from 'react';
import "./App.css";
import diamondOpenBlue from "./Images/diamond_open_blue.png";

export class Card extends Component {
    render() {
        return (
            <div
                className="board__card"
            >
                <div><img src={diamondOpenBlue} /></div>
                <div><img src={diamondOpenBlue} /></div>
                <div><img src={diamondOpenBlue} /></div>
            </div>
        );
    }
}