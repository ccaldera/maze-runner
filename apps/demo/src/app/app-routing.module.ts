import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListOfGames } from './components/list-of-games/list-of-games.component';

const routes: Routes = [
  { path: 'games', component: ListOfGames, pathMatch: 'full' },
  { path: 'games', component: ListOfGames, pathMatch: 'full' },
  { path: '', redirectTo: '/games', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }