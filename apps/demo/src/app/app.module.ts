import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoggingService } from './logging/logging.service';
import { environment } from '../environments/environment';
import { ValantDemoApiClient } from './api-client/api-client';
import { MazeService } from './services/maze.service';
import { ListOfGames } from './components/list-of-games/list-of-games.component';
import { AppRoutingModule } from './app-routing.module';
import { Game } from './components/game/game.component';
import { FormsModule } from '@angular/forms';

export function getBaseUrl(): string {
  return environment.baseUrl;
}

export const routes = [];

@NgModule({
  declarations: [
    AppComponent, 
    ListOfGames,
    Game
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    LoggingService,
    MazeService,
    ValantDemoApiClient.Client,
    { provide: ValantDemoApiClient.API_BASE_URL, useFactory: getBaseUrl },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
