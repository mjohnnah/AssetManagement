using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class AssigneesController : Controller
    {
        private readonly AssetConetxt _context;

        public AssigneesController(AssetConetxt context)
        {
            _context = context;    
        }

        // GET: Assignees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assignees.ToListAsync());
        }

        // GET: Assignees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignees.SingleOrDefaultAsync(m => m.ID == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // GET: Assignees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastMidName,LastName")] Assignee assignee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assignee);
        }

        // GET: Assignees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignees.SingleOrDefaultAsync(m => m.ID == id);
            if (assignee == null)
            {
                return NotFound();
            }
            return View(assignee);
        }

        // POST: Assignees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastMidName,LastName")] Assignee assignee)
        {
            if (id != assignee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssigneeExists(assignee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(assignee);
        }

        // GET: Assignees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignees.SingleOrDefaultAsync(m => m.ID == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // POST: Assignees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignee = await _context.Assignees.SingleOrDefaultAsync(m => m.ID == id);
            _context.Assignees.Remove(assignee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AssigneeExists(int id)
        {
            return _context.Assignees.Any(e => e.ID == id);
        }
    }
}
