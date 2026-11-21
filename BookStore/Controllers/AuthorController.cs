using BookStore.DTOs.Author;
using BookStore.FIlters;
using BookStore.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController(IAuthorService _authorService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AuthorFilter filter)
        {
            var response = await _authorService.GetAll(filter);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAuthorDto dto)
        {
            var author = await _authorService.Add(dto);
            return Ok(author);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto dto)
        {
            var result = await _authorService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.Delete(id);
            return Ok(result);
        }

    }
}
