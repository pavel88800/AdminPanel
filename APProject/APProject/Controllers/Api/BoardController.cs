using APP.Board.Dto;
using APP.Board.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    /// <summary>
    ///     Контроллер по работе с доской.
    /// </summary>
    public class BoardController : BaseApiController
    {
        private readonly IBoardService _board;
        public BoardController(IBoardService board)
        {
            _board = board;
        }
        [HttpGet("")]
        public IActionResult GetBoard(long id)
        {
            var result = _board.GetBoard(id);
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult CreateBoard(BoardDto dto)
        {
            var result = _board.CreateBoard(dto);
            return Ok(result);
        }

        [HttpGet("/list")]
        public IActionResult GetList()
        {
            var result = _board.GetBoardses();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteBoard(long id)
        {
            _board.DeleteBoard(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBoard(BoardDto dto)
        {
            _board.UpdateBoard(dto);
            return Ok();
        }

    }
}