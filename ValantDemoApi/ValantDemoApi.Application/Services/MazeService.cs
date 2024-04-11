using System;
using System.Collections.Generic;
using ValantDemoApi.Application.Entities;
using ValantDemoApi.Application.Repositories;
using ValantDemoApi.Models;

namespace ValantDemoApi.Application.Services
{
    public class MazeService : IMazeService
    {
        private readonly IMazeRepository _mazeRepository;
        public MazeService(IMazeRepository mazeRepository)
        {
            _mazeRepository = mazeRepository
                ?? throw new ArgumentNullException(nameof(mazeRepository));
        }

        public Maze CreateGame(string rawGame)
        {
            var maze = Maze.Create(rawGame);

            return _mazeRepository.Add(maze);
        }

        public IEnumerable<Maze> GetGames()
        {
            return _mazeRepository.GetAll();
        }

        public Maze? Get(Guid id)
        {
            return _mazeRepository.Get(id);
        }

        public GetNextAvailableMovesResponse GetNextAvailableMoves(
            Maze maze,
            GetNextAvailableMovesRequest request)
        {
            var gameEnded = maze.GameEnded(request.X, request.Y);

            var response = new GetNextAvailableMovesResponse();

            if (gameEnded)
            {
                response.GameEnded = true;
                return response;
            }

            var moves = maze.GetValidMoves(request.Y, request.Y);

            if (moves.CanMoveUp)
            {
                response.Moves.Add("Down");
            }

            if (moves.CanMoveDown)
            {
                response.Moves.Add("Down");
            }

            if (moves.CanMoveLeft)
            {
                response.Moves.Add("Left");
            }

            if (moves.CanMoveRight)
            {
                response.Moves.Add("Right");
            }

            return response;
        }
    }
}