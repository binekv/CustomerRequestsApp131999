using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class CustomerRequestController : Controller
{
    private readonly AppDbContext _context;

    public CustomerRequestController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var requests = _context.CustomerRequests.ToList();
        return View(requests);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CustomerRequest request)
    {
        if (ModelState.IsValid)
        {
            _context.CustomerRequests.Add(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(request);
    }

    public IActionResult Edit(int id)
    {
        var request = _context.CustomerRequests.Find(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CustomerRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Update(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(request);
    }

    public IActionResult Delete(int id)
    {
        var request = _context.CustomerRequests.Find(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var request = _context.CustomerRequests.Find(id);
        if (request == null)
        {
            return NotFound();
        }

        _context.CustomerRequests.Remove(request);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}