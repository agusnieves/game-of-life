using System;
using System.Collections.Generic;

namespace GameOfLife.Api.Models
{
    public class Board
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required List<List<int>> State { get; set; }

        public Board() { }

        public Board(List<List<int>> initialState)
        {
            State = initialState;
        }
    }
}
