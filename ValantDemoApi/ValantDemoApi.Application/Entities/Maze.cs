using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ValantDemoApi.Application.ValueObjects;

namespace ValantDemoApi.Application.Entities
{
    public class Maze
    {
        public Guid Id { get; private set; }
        public Cell[,] Board { get; private set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public static Maze Create(string rawGame)
        {
            if (!rawGame.Contains("S", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidDataException("No start was detected!");
            }

            if (!rawGame.Contains("N", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidDataException("No end was detected!");
            }

            var lines = rawGame.Split(Environment.NewLine);
            var numberOfRows = lines.Count();

            if (numberOfRows < 2)
            {
                throw new InvalidDataException("There must be at least 2 rows");
            }

            var numberOfColumns = lines.First().Length;

            if (numberOfColumns < 2)
            {
                throw new InvalidDataException("There must be at least 2 columns");
            }

            var board = new Cell[numberOfRows, numberOfColumns];

            for (int x = 0; x < lines.Length; x++)
            {
                var column = lines[x];
                for (int y = 0; y < column.Length; y++)
                {
                    var value = column[y].ToString();

                    board[x, y] = new Cell
                    {
                        X = x,
                        Y = y,
                        Value = value
                    };
                }
            }

            return new Maze
            {
                Id = Guid.NewGuid(),
                Board = board,
                Rows = numberOfRows,
                Columns = numberOfColumns
            };
        }
        public bool GameEnded(int x , int y)
        {
            var cell = Board[x, y];
            return cell.IsEnd;
        }

        public Moves GetValidMoves(int x, int y)
        {
            var moves = new Moves();

            if(x - 1 > 0 && Board[x - 1, y].IsValidMovement)
            {
                moves.CanMoveUp = true;
            }

            if (x + 1 < Rows && Board[x + 1, y].IsValidMovement)
            {
                moves.CanMoveDown = true;
            }

            if (y - 1 > 0 && Board[x, y - 1].IsValidMovement)
            {
                moves.CanMoveRight = true;
            }

            if (y + 1 < Columns && Board[x, y + 1].IsValidMovement)
            {
                moves.CanMoveLeft = true;
            }

            return moves;
        }
    }
}