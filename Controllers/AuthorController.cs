using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryDbContext _context;

        public AuthorController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> authorList = _context.Authors;
            return View(authorList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Author authobj)
        {
            if (ModelState.IsValid)
            {

                object value = _context.Authors.Add(authobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Author Added Successfully!";
            }
            return View(authobj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var afromdb = _context.Authors.Find(id);

            if (afromdb == null)
            {
                return NotFound();
            }
            return View(afromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author authobj)
        {
            if (ModelState.IsValid)
            { _context.Authors.Update(authobj); }
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Updated Successfully!";
            return RedirectToAction("Index");
            return View(authobj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var afromdb = _context.Authors.Find(id);

            if (afromdb == null)
            {
                return NotFound();
            }
            return View(afromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuthor(int? id)
        {
            var deleterecord = _context.Authors.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }

    }
}

