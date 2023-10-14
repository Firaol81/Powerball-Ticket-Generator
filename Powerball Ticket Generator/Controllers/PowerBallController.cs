using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Powerball_Ticket_Generator.Models;

namespace Powerball_Ticket_Generator.Controllers
{
    public class PowerBallController : Controller
    {
        private readonly LottaryContext _context;

        public PowerBallController(LottaryContext context)
        {
            _context = context;
        }

        // Action to list Powerball tickets
        public IActionResult Index()
        {
            var powerballTickets = _context.Lottary.ToList();
            return View(powerballTickets);
        }

        // Action to create a new Powerball ticket
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lottary lottary)
        {
            if (ModelState.IsValid)
            {
                _context.Lottary.Add(lottary);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lottary);
        }

        // Action to edit an existing Powerball ticket
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lottary = _context.Lottary.Find(id);
            if (lottary == null)
            {
                return NotFound();
            }
            return View(lottary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Lottary lottary)
        {
            if (id != lottary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(lottary).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lottary);
        }

        // Action to delete a Powerball ticket
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var lottary = _context.Lottary.Find(id);
            if (lottary == null)
            {
                return NotFound();
            }
            return View(lottary);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var lottary = _context.Lottary.Find(id);
            if (lottary == null)
            {
                return NotFound();
            }
            _context.Lottary.Remove(lottary);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
