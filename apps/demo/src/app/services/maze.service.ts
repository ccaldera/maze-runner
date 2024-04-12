import { Injectable } from "@angular/core";
import { ValantDemoApiClient } from "../api-client/api-client";
import { firstValueFrom } from 'rxjs';

@Injectable({
    providedIn: 'root',
  })
  export class MazeService {
    constructor(private httpClient: ValantDemoApiClient.Client) {}
  
    public getGames(): Promise<ValantDemoApiClient.Maze[]> {
      return firstValueFrom(this.httpClient.mazeAll());
    }

    public getMoves(id:string, request:ValantDemoApiClient.GetNextAvailableMovesRequest): Promise<ValantDemoApiClient.GetNextAvailableMovesResponse> {
      return firstValueFrom(this.httpClient.moves(id, request));
    }
  }