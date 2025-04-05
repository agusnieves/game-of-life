using GameOfLife.Api.Models;

namespace GameOfLife.Api.Services
{
    public class GameOfLifeService
    {
        private readonly Dictionary<Guid, Board> _boards = new();

        public void SaveBoard(Board board)
        {
            _boards[board.Id] = board;
        }

        public List<List<int>> GetNextState(List<List<int>> currentState)
        {
            int rows = currentState.Count;
            int cols = currentState[0].Count;

            var nextState = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                nextState.Add(new List<int>());
                for (int j = 0; j < cols; j++)
                {
                    int aliveNeighbors = CountAliveNeighbors(currentState, i, j);
                    bool isAlive = currentState[i][j] == 1;

                    if (isAlive && (aliveNeighbors < 2 || aliveNeighbors > 3))
                        nextState[i].Add(0); 
                    else if (!isAlive && aliveNeighbors == 3)
                        nextState[i].Add(1);
                    else
                        nextState[i].Add(currentState[i][j]);
                }
            }

            return nextState;
        }
    
        private int CountAliveNeighbors(List<List<int>> board, int x, int y)
        {
            int count = 0;
            int rows = board.Count;
            int cols = board[0].Count;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue;
                    if (i >= 0 && i < rows && j >= 0 && j < cols)
                        count += board[i][j];
                }
            }

            return count;
        }
    

        public List<List<int>> GetSelectedStepAheadState(List<List<int>> currentState, int stepsAhead)
        {
            var state = currentState;

            for (int i = 0; i < stepsAhead; i++)
            {
                state = GetNextState(state);
            }

            return state;
        }

        public List<List<int>> GetFinalState(List<List<int>> currentState, int attempts = 300)
        {
            for (int i = 0; i < attempts; i++)
            {
                var next = GetNextState(currentState);

                if (EqualState(currentState, next))
                {
                    return next;
                }

                currentState = next;
            }

            return currentState;
        }

        private bool EqualState(List<List<int>> currentState, List<List<int>> next)
        {
            if (currentState.Count != next.Count) return false;

            for (int i = 0; i < currentState.Count; i++)
            {
                if (currentState[i].Count != next[i].Count) return false;

                for (int j = 0; j < currentState[i].Count; j++)
                {
                    if (currentState[i][j] != next[i][j]) return false;
                }
            }

            return true;
        }
    }
}