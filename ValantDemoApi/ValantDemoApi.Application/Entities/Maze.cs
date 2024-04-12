using System;
using System.IO;
using System.Linq;
using ValantDemoApi.Application.ValueObjects;

namespace ValantDemoApi.Application.Entities
{
    public class Maze
    {
        public Guid Id { get; private set; }
        public Cell[][] Board { get; private set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell Start { get; set; }
        public Cell End { get; set; }

        public static Maze Create(string rawGame)
        {
            if (!rawGame.Contains("S", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidDataException("No start was detected!");
            }

            if (!rawGame.Contains("E", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidDataException("No end was detected!");
            }

            var rows = rawGame.Replace("\r\n", "\n").Split('\n');
            var numberOfRows = rows.Count();

            if (numberOfRows < 2)
            {
                throw new InvalidDataException("There must be at least 2 rows");
            }

            var numberOfColumns = rows.First().Length;

            if (numberOfColumns < 2)
            {
                throw new InvalidDataException("There must be at least 2 columns");
            }

            var board = new Cell[numberOfRows][];

            Cell? start = null;
            Cell? end = null;

            for (int rowNumber = 0; rowNumber < rows.Length; rowNumber++)
            {
                var column = rows[rowNumber];
                board[rowNumber] = new Cell[numberOfColumns];
                for (int columnNumber = 0; columnNumber < column.Length; columnNumber++)
                {
                    var value = column[columnNumber].ToString();

                    var cell = new Cell
                    {
                        Row = rowNumber,
                        Column = columnNumber,
                        Value = value
                    };

                    if (cell.IsStart)
                    {
                        start = cell;
                    }
                    else if (cell.IsEnd)
                    {
                        end = cell;
                    }

                    board[rowNumber][columnNumber] = cell;
                }
            }

            return new Maze
            {
                Id = Guid.NewGuid(),
                Board = board,
                Rows = numberOfRows,
                Columns = numberOfColumns,
                Start = start!,
                End = end!
            };
        }
        public bool GameEnded(int row, int column)
        {
            var cell = Board[row][column];
            return cell.IsEnd;
        }

        public Moves GetValidMoves(int row, int column)
        {
            var moves = new Moves();

            if(row - 1 >= 0 && Board[row - 1][column].IsValidMovement)
            {
                moves.CanMoveUp = true;
            }

            if (row + 1 < Rows && Board[row + 1][column].IsValidMovement)
            {
                moves.CanMoveDown = true;
            }

            if (column - 1 >= 0 && Board[row][column - 1].IsValidMovement)
            {
                moves.CanMoveLeft = true;
            }

            if (column + 1 < Columns && Board[row][column + 1].IsValidMovement)
            {
                moves.CanMoveRight = true;
            }

            return moves;
        }
    }
}