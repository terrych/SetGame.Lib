import React, { Component } from 'react';
import "./App.css";
import diamondOpenRed from "./Images/diamond_open_red.png";
import diamondOpenGreen from "./Images/diamond_open_green.png";
import diamondOpenBlue from "./Images/diamond_open_blue.png";
import diamondStripedRed from "./Images/diamond_striped_red.png";
import diamondStripedGreen from "./Images/diamond_striped_green.png";
import diamondStripedBlue from "./Images/diamond_striped_blue.png";
import diamondSolidRed from "./Images/diamond_solid_red.png";
import diamondSolidGreen from "./Images/diamond_solid_green.png";
import diamondSolidBlue from "./Images/diamond_solid_blue.png";
import squiggleOpenRed from "./Images/squiggle_open_red.png";
import squiggleOpenGreen from "./Images/squiggle_open_green.png";
import squiggleOpenBlue from "./Images/squiggle_open_blue.png";
import squiggleStripedRed from "./Images/squiggle_striped_red.png";
import squiggleStripedGreen from "./Images/squiggle_striped_green.png";
import squiggleStripedBlue from "./Images/squiggle_striped_blue.png";
import squiggleSolidRed from "./Images/squiggle_solid_red.png";
import squiggleSolidGreen from "./Images/squiggle_solid_green.png";
import squiggleSolidBlue from "./Images/squiggle_solid_blue.png";
import ovalOpenRed from "./Images/oval_open_red.png";
import ovalOpenGreen from "./Images/oval_open_green.png";
import ovalOpenBlue from "./Images/oval_open_blue.png";
import ovalStripedRed from "./Images/oval_striped_red.png";
import ovalStripedGreen from "./Images/oval_striped_green.png";
import ovalStripedBlue from "./Images/oval_striped_blue.png";
import ovalSolidRed from "./Images/oval_solid_red.png";
import ovalSolidGreen from "./Images/oval_solid_green.png";
import ovalSolidBlue from "./Images/oval_solid_blue.png";

export class Card extends Component {

    handleCardClick(event) {
        var gameState = this.props.getGame();
        gameState.highlightedCards = [];

        this.props.updateGame(gameState);

        if (event.currentTarget.classList.contains('board__card--selected')) {
            this.props.deselectCard(event);
        } else {
            this.props.selectCard(event);
        }

        //console.log(event.currentTarget.classList);
        //if (selectedCount < 3) {
        //event.currentTarget.classList.toggle('board__card--selected');
        //}
    }

    render() {
        // array in back end ranks features by count, then shape, then colour then finally shading

        const cardIcons = [ // shape
            [ // squiggle
                [ // red
                    squiggleSolidRed,
                    squiggleStripedRed,
                    squiggleOpenRed
                ],
                [ // green
                    squiggleSolidGreen,
                    squiggleStripedGreen,
                    squiggleOpenGreen
                ],
                [ // blue
                    squiggleSolidBlue,
                    squiggleStripedBlue,
                    squiggleOpenBlue
                ]
            ],
            [ // diamond
                [ // red
                    diamondSolidRed,
                    diamondStripedRed,
                    diamondOpenRed
                ],
                [ // green
                    diamondSolidGreen,
                    diamondStripedGreen,
                    diamondOpenGreen
                ],
                [ // blue
                    diamondSolidBlue,
                    diamondStripedBlue,
                    diamondOpenBlue
                ]
            ],
            [ // oval
                [ // red
                    ovalSolidRed,
                    ovalStripedRed,
                    ovalOpenRed
                ],
                [ // green
                    ovalSolidGreen,
                    ovalStripedGreen,
                    ovalOpenGreen
                ],
                [ // blue
                    ovalSolidBlue,
                    ovalStripedBlue,
                    ovalOpenBlue
                ]
            ],
        ];

        const countRank = 0;
        const shapeRank = 1;
        const colourRank = 2;
        const shadingRank = 3;

        function getIcon(array) {
            return cardIcons[array[shapeRank]][array[colourRank]][array[shadingRank]];
        }

        function returnImage(el, i, array) {
            return <div><img src={array} /></div>
        }

        return (
            <div
                className={"board__card " +
                    (this.props.getGame().selectedCards.includes(this.props.position) ? "board__card--selected " : "") +
                    (this.props.getGame().highlightedCards.includes(this.props.position) ? "board__card--highlighted " : "")}
                onClick={(e) => this.handleCardClick(e)}
                position={this.props.position}
            >
                <div>
                    {Array(this.props.array[countRank] + 1).fill(1).map((el, i) =>
                        returnImage(el, i, getIcon(this.props.array))
                    )}
                </div>
            </div>/*{color }*/
        );
    }
}