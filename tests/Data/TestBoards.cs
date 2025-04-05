using System.Collections.Generic;

namespace GameOfLife.Tests.Data
{
    public static class TestBoards
    {

        public static List<List<int>> FullAliveBoard => new()
        {
            new() { 1, 1, 1 },
            new() { 1, 1, 1 },
            new() { 1, 1, 1 }
        };

        public static List<List<int>> CornersBoard => new()
        {
            new() { 1, 0, 1 },
            new() { 0, 0, 0 },
            new() { 1, 0, 1 }
        };

        public static List<List<int>> DeadBoard => new()
        {
            new() { 0, 0, 0 },
            new() { 0, 0, 0 },
            new() { 0, 0, 0 }
        };

        public static List<List<int>> LoopVertical => new()
        {
            new() { 0, 1, 0 },
            new() { 0, 1, 0 },
            new() { 0, 1, 0 }
        };

        public static List<List<int>> LoopHorizontal => new()
        {
            new() { 0, 0, 0 },
            new() { 1, 1, 1 },
            new() { 0, 0, 0 }
        };

        public static List<List<int>> CentralBoard => new()
        {
            new() { 0, 0, 0 },
            new() { 0, 1, 0 },
            new() { 0, 0, 0 }
        };

        public static List<List<int>> XBoard => new()
        {
            new() { 0, 1, 0 },
            new() { 1, 0, 1 },
            new() { 0, 1, 0 }
        };
    }
}