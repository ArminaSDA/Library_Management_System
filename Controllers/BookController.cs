using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _context.Books;
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Book bookobj)
        {
            if (ModelState.IsValid)
            {
                object value = _context.Books.Add(bookobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Book Added Successfully!";
            }
            return View(bookobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookfromdb = _context.Books.Find(id);

            if (bookfromdb == null)
            {
                return NotFound();
            }
            return View(bookfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book bookobj)
        {
            if (ModelState.IsValid)
            { _context.Books.Update(bookobj); }
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Updated Successfully!";
            return RedirectToAction("Index");
            return View(bookobj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookfromdb = _context.Books.Find(id);

            if (bookfromdb == null)
            {
                return NotFound();
            }
            return View(bookfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var deleterecord = _context.Books.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Books.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
