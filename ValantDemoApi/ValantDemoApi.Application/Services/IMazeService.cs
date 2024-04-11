using System;
using System.Collections.Generic;
using ValantDemoApi.Application.Entities;
using ValantDemoApi.Models;

namespace ValantDemoApi.Application.Services
{
    public interface IMazeService
    {
        Maze CreateGame(string rawGame);

        IEnumerable<Maze> GetGames();

        Maze? Get(Guid id);

        GetNextAvailableMovesResponse GetNextAvailableMoves(
            Maze maze,
            GetNextAvailableMovesRequest request);
    }
}
