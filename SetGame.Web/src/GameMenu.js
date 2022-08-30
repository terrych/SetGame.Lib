import React, { Component } from 'react';
import "./App.css";

function GameMenuButton(props) {
    console.log('props', props);
    return (
        <div className="menu-button">{props.text}</div>
    );
}
//<a href="{props.url}"> {props.text} </a>

export class GameMenu extends Component {
    constructor(props) {
        super(props);
        this.buttons = [
            { key: "game-button-1", url: "/Home/NewGame", text: "New Game" },
            { key: "game-button-2", url: "/Home/FindSet", text: "Find Set" },
            { key: "game-button-3", url: "/Home/OpenThreeCards", text: "OpenThreeCards" },
        ];
        this.settings = [
            { key: "variation-number", text: "Variations", value: 3 },
            { key: "feature-number", text: "Features", value: 4 }
        ];
    }

    renderGameMenuButton(button) {
        return (
            <GameMenuButton key={button.key} url={button.url} text={button.text} />
        );
    }

    renderSettings(setting) {
        return (
            <div>{setting.text}: { setting.value }</div>
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
                    {this.settings.map(setting =>
                        this.renderSettings(setting)
                    )}
                <div id="stats"></div>
            </div>            
        );
    }
}