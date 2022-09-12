import React, { Component } from 'react';
import "./App.css";

function GameMenuButton(props) {
    return (
        <div className="menu-button" onClick={ props.onClick }>{props.text}</div>
    );
}
//<a href="{props.url}"> {props.text} </a>

export class GameMenu extends Component {

    buttons = [
        { key: "game-button-1", url: "/Game/NewGame?variations=3&features=4", text: "New Game", verb: "GET" },
        { key: "game-button-2", url: "/Game/FindSet", text: "Find Set", verb: "GET" },
        { key: "game-button-3", url: ("/Game/OpenThreeCards?gameid" + this.props.getGame().id), text: "Open Three Cards", verb: "GET" },
    ];
    settings = [
        { key: "variation-number", text: "Variations", value: 3 },
        { key: "feature-number", text: "Features", value: 4 }
    ];

    async fetch(url, verb) {
        //const url = 'https://localhost:7072/Game/NewGame?variations=3&features=4';
        const response = await fetch('https://localhost:7072/' + url, { method: verb })
        const data = await response.json();
        //this.setState({ game: data, loading: false });
        console.log('data', data)
    }

    async mutateGame(url, verb) {
        console.log(url, verb);
        const response = await fetch('https://localhost:7072' + url, { method: verb })
        const data = await response.json();
        this.props.updateGame(data);
    }

    renderGameMenuButton(button) {
        return (
            <GameMenuButton key={button.key} url={button.url} text={button.text} onClick={async () => {await this.mutateGame(button.url, button.verb)} } />/*this.callUrl(button.url)*/
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