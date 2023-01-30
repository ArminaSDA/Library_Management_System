using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers;

public class ClientController : Controller
{
    private readonly LibraryDbContext _context;

    public ClientController(LibraryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<Client> clientList = _context.Clients;
        return View(clientList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(Client cliobj)
    {
        if (ModelState.IsValid)
        {
            object value = _context.Clients.Add(cliobj);
            _context.SaveChanges();
            TempData["ResultOk"] = "New Client Added Successfully!";
        }
        return View(cliobj);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var clifromdb = _context.Clients.Find(id);

        if (clifromdb == null)
        {
            return NotFound();
        }
        return View(clifromdb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Client cliobj)
    {
        if (ModelState.IsValid)
        { _context.Clients.Update(cliobj); }
        _context.SaveChanges();
        TempData["ResultOk"] = "Data Updated Successfully!";
        return RedirectToAction("Index");
        return View(cliobj);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var clifromdb = _context.Clients.Find(id);

        if (clifromdb == null)
        {
            return NotFound();
        }
        return View(clifromdb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteClient(int? id)
    {
        var deleterecord = _context.Clients.Find(id);
        if (deleterecord == null)
        {
            return NotFound();
        }
        _context.Clients.Remove(deleterecord);
        _context.SaveChanges();
        TempData["ResultOk"] = "Data Deleted Successfully !";
        return RedirectToAction("Index");
    }

}
