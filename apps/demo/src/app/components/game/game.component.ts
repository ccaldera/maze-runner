import { Component, Input, OnChanges, OnInit, SimpleChanges } from "@angular/core";
import { ValantDemoApiClient } from "../../api-client/api-client";
import { MazeService } from "../../services/maze.service";

@Component({
    selector: 'game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})
export class Game implements OnInit, OnChanges
{
    @Input() game:ValantDemoApiClient.Maze = {};
    currentCell:ValantDemoApiClient.Cell = {};
    isUpEnabled:boolean;
    isDownEnabled:boolean;
    isLeftEnabled:boolean;
    isRightEnabled:boolean;

    constructor(private mazeService:MazeService){

    }

    async ngOnInit() {
        await this.Relaod();    
    }

    private async Relaod() {
        this.currentCell = this.game.start;

        await this.Move(this.currentCell.row, this.currentCell.column);
    }

    async ngOnChanges(changes: SimpleChanges) {        
        await this.Relaod();        
    }

    private async Move(row:number, column:number) {
        let request: ValantDemoApiClient.GetNextAvailableMovesRequest = {
            row: row,
            column: column
        };

        let moves = await this.mazeService.getMoves(this.game.id, request);
        
        let cell: ValantDemoApiClient.Cell = {
            row: row,
            column: column,
        };
        
        this.currentCell = cell;

        if (moves.gameEnded) {
            alert("You Win!");
        }

        this.disableArrows();
        for (let move of moves.moves) {
            if (move == "Up") {
                this.isUpEnabled = true;
            }
            else if (move == "Down") {
                this.isDownEnabled = true;
            }
            else if (move == "Right") {
                this.isRightEnabled = true;
            }
            else if (move == "Left") {
                this.isLeftEnabled = true;
            }
        }
    }

    async moveDown(){
        await this.Move(this.currentCell.row + 1, this.currentCell.column);
    }

    async moveUp(){
        await this.Move(this.currentCell.row - 1, this.currentCell.column);
    }

    async moveLeft(){
        await this.Move(this.currentCell.row, this.currentCell.column - 1);
    }

    async moveRight(){
        await this.Move(this.currentCell.row, this.currentCell.column + 1);
    }

    disableArrows(){
        this.isUpEnabled = false;
        this.isDownEnabled = false;
        this.isLeftEnabled = false;
        this.isRightEnabled = false;
    }

    isActiveCell(cell:ValantDemoApiClient.Cell){
        return this.currentCell.row == cell.row && this.currentCell.column == cell.column
    }    
}