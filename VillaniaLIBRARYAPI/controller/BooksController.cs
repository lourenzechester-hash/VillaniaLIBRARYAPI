using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using VillaniaLIBRARYAPI.models;


namespace VillaniaLIBRARYAPI.controller
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "DIVERGENT",
                Author = "Veronica Roth",
                Genre = "Dystopian",
                Available = true,
                PublishedYear = 2011,
                },


                new Book
            {
                Id = 2,
                Title = "INSUGENT",
                Author = "Veronica Roth",
                Genre = "Sci-fi, Dystopian",
                Available = true,
                PublishedYear = 2012,
                }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {

                status = "success",
                data = books,
                message = "Books Retrieved",
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found"

                });
            return Ok(new
            {
                status = "success",
                data = book,
                message = " Book Retrieved"
            });
        }
        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetById),
                new { Id = newBook.Id },
                new
                {
                    status = "success",
                    data = newBook,
                    message = "Book Created"
                });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,
            [FromBody] Book updatebook)
        {
            var Book = books.FirstOrDefault(x => x.Id == id);
            if (Book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."
                });
            Book.Title = updatebook.Title;
            Book.Author = updatebook.Author;
            Book.Genre = updatebook.Genre;
            Book.Available = updatebook.Available;
            Book.PublishedYear = updatebook.PublishedYear;

            return Ok(new
            {
                status = "success",
                data = (object?)null,
                message = "Book Updated."
            });

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            var Book = books.FirstOrDefault(x => x.Id == id);
            if (Book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not Found."
                });
            books.Remove(Book);
            return Ok(new
            {
                status = "success",
                data = (object?)null,
                message = "Book Deleted."
            });
        }
    }
            
  }

