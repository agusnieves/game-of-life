using Microsoft.AspNetCore.Mvc;
using GameOfLife.Api.Models;
using GameOfLife.Api.Services;

namespace GameOfLife.Api.Controllers
{
    [ApiController]
    [Route("board")]
    public class GameOfLifeController : ControllerBase
    {
        private readonly GameOfLifeService _service;
        private static readonly Dictionary<Guid, Board> _boardStore = new();


        public GameOfLifeController(GameOfLifeService service)
        {
            _service = service;
        }

        // POST /board
        [HttpPost]
        public IActionResult UploadBoard([FromBody] Board board)
        {
            _boardStore[board.Id] = board;
            return Ok(new { board.Id });
        }

        // GET /board/{id}
        [HttpGet("{id}/next")]
        public IActionResult GetNextState(Guid id)
        {
            if (!_boardStore.TryGetValue(id, out var board))
                return NotFound();

            var nextState = _service.GetNextState(board.State);

            return Ok(nextState);
        }

        // GET /board/{id}/next/{steps}
        [HttpGet("{id}/next/{steps}")]
        public IActionResult GetSelectedStepAheadState(Guid id, int steps)
        {
            if (!_boardStore.TryGetValue(id, out var board))
                return NotFound();

            var expectedState = _service.GetSelectedStepAheadState(board.State, steps);

            return Ok(expectedState);
        }

        // GET /board/{id}/final
        [HttpGet("{id}/final")]
        public IActionResult GetFinalState(Guid id)
        {
            if (!_boardStore.TryGetValue(id, out var board))
                return NotFound();

            var finalState = _service.GetFinalState(board.State, out bool converged);

            return Ok(finalState);
        }
    }
}
