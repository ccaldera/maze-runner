using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ValantDemoApi.Application.Entities;
using ValantDemoApi.Application.Services;
using ValantDemoApi.Models;

namespace ValantDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeController : ControllerBase
    {
        private readonly IMazeService _mazeService;

        public MazeController(IMazeService mazeService)
        {
            _mazeService = mazeService
                ?? throw new ArgumentException(nameof(mazeService));
        }

        [HttpPost("{id}/moves")]
        public ActionResult<GetNextAvailableMovesResponse> GetNextAvailableMoves(
            [FromRoute] Guid id,
            [FromBody] GetNextAvailableMovesRequest request)
        {
            var maze = _mazeService.Get(id);

            if(maze == null)
            {
                return NotFound();
            }

            return _mazeService.GetNextAvailableMoves(maze, request);
        }

        [HttpGet]
        public IEnumerable<Maze> GetAll()
        {
            return _mazeService.GetGames();
        }

        [HttpGet("{id}")]
        public Maze Get([FromRoute] Guid id)
        {
            return _mazeService.Get(id);
        }

        [HttpPost()]
        public Maze Post([FromBody] CreateMazeRequest request)
        {
            return _mazeService.CreateGame(request.Maze);
        }
    }
}
