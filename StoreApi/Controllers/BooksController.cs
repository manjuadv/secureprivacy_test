using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.DataServices;
using Microsoft.AspNetCore.Mvc;
using Task1.Core.DBRepository;
using Task1.Core.Models;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookService;

        public BooksController(IBookRepository bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.Get();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            Book createdBook = await _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Book bookIn)
        {
            bool suceess = await _bookService.Update(id, bookIn);

            if (!suceess)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _bookService.Delete(id);

            return NoContent();
        }
    }
}
