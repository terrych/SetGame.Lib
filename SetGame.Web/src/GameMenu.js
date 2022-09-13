import React, { Component } from 'react';
import "./App.css";

function GameMenuButton(props) {
    return (
        <div className="menu-button" onClick={ props.onClick }>{props.text}</div>
    );
}
//<a href="{props.url}"> {props.text} </a>

export class GameMenu extends Component {

    settings = [
        { key: "variation-number", text: "Variations", value: 3 },
        { key: "feature-number", text: "Features", value: 4 }
    ];

    async fetch(url, verb) {
        const response = await fetch('https://localhost:7072/' + url, { method: verb })
        const data = await response.json();
        console.log('data', data)
    }

    async mutateGameState(url, verb) {
        console.log(url, verb);
        const response = await fetch('https://localhost:7072' + url, { method: verb })
        const data = await response.json();
        this.props.updateGame(data);
    }

    async newGame() {
        this.mutateGameState("/Game/NewGame?variations=3&features=4", "GET");
    }

    async findSet() {
        this.mutateGameState("/Game/FindSet?gameid=" + this.props.getGame().id, "GET");
    }

    async openThreeCards() {
        this.mutateGameState("/Game/OpenThreeCards?gameid=" + this.props.getGame().id, "GET");
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
                    <GameMenuButton text="New Game" onClick={async () => { await this.newGame() }} />
                    <GameMenuButton text="Find Set" onClick={async () => { await this.findSet() }} />
                    <GameMenuButton text="Open Three Cards" onClick={async () => { await this.openThreeCards() }} />
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