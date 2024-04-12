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

    newGame:string = `SOXXXXXXXX
OOOXXXXXXX
OXOOOXOOOO
XXXXOXOXXO
OOOOOOOXXO
OXXOXXXXXO
OOOOXXXXXE`;
    creationModeEnabled:boolean = false;

    constructor(private mazeService:MazeService){

    }

    async ngOnInit() {
        await this.Reload();
    }

    private async Reload() {
        this.games = await this.mazeService.getGames();
    }

    public selectGame(game:ValantDemoApiClient.Maze){
        this.selectedGame = game;
    }

    async create(){

        if(!this.newGame){
            alert("Invaid imput");
        }

        var request: ValantDemoApiClient.CreateMazeRequest = {
            maze: this.newGame
        }

        await this.mazeService.create(request);

        this.Reload();
        this.creationModeEnabled = false;
    }
}