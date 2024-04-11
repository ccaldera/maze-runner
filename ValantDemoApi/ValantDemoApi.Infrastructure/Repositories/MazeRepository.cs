using System;
using System.Collections.Generic;
using System.Linq;
using ValantDemoApi.Application.Entities;
using ValantDemoApi.Application.Repositories;

namespace ValantDemoApi.Infrastructure.Repositories
{
    public class MazeRepository : IMazeRepository
    {
        private static readonly List<Maze> _collection = new List<Maze>();

        public Maze Add(Maze maze)
        {
            _collection.Add(maze);
            return maze;
        }

        public Maze? Get(Guid id)
        {
            return _collection.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Maze> GetAll()
        {
            return _collection;
        }
    }
}