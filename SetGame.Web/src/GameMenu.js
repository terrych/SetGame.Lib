import React, { Component } from 'react';
import "./App.css";

function GameMenuButton(props) {
    console.log('props', props);
    return (
        <div class="menu-button"><a href="{props.url}"> { props.text } </a></div>
    );
}

export class GameMenu extends Component {
    constructor(props) {
        super(props);
        this.buttons = [
            { url: "/Home/NewGame", text: "New Game" },
            { url: "/Home/FindSet", text: "Find Set" },
            { url: "/Home/OpenThreeCards", text: "OpenThreeCards" },
        ]
    }

    renderGameMenuButton(button) {
        return (
            <GameMenuButton url={button.url} text={button.text} />
        );
    }

    render() {
        return (
            <div id="menu" className="col-3">
                <div id="buttons">
                    {this.buttons.map(button =>
                        this.renderGameMenuButton(button)
                    )}
                </div>
                <div id="settings"></div>
                <div id="stats"></div>
            </div>            
        );
    }
}