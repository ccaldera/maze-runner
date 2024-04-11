using System;
using System.Collections.Generic;
using ValantDemoApi.Application.Entities;

namespace ValantDemoApi.Application.Repositories
{
    public interface IMazeRepository
    {
        public IEnumerable<Maze> GetAll();
        public Maze? Get(Guid id);
        public Maze Add(Maze maze);
    }
}
