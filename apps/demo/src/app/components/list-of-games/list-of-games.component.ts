import { Component, OnInit } from "@angular/core";
import { ValantDemoApiClient } from "../../api-client/api-client";
import { MazeService } from "../../services/maze.service";

@Component({
    selector: 'list-of-games',
    templateUrl: './list-of-games.component.html',
    styleUrls: ['./list-of-games.component.scss']
})
export class ListOfGames implements OnInit
{
    games:ValantDemoApiClient.Maze[];
    selectedGame:ValantDemoApiClient.Maze = {};
    newGame:string = "";

    constructor(private mazeService:MazeService){

    }

    async ngOnInit() {
        this.games = await this.mazeService.getGames();
    }

    public selectGame(game:ValantDemoApiClient.Maze){
        this.selectedGame = game;
    }  
}