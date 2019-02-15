using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkflowProject.Models;

namespace WorkflowProject.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly WorkflowContext _context;

        public ProcedureController(WorkflowContext context)
        {
            _context = context;
        }

        // GET: Procedure
        public async Task<IActionResult> Index()
        {
            var workflowContext = _context.Procedures.Include(p => p.Policy);
            return View(await workflowContext.ToListAsync());
        }

        // GET: Procedure/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures
                .Include(p => p.Policy)
                .FirstOrDefaultAsync(m => m.ProcedureId == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // GET: Procedure/Create
        public IActionResult Create()
        {
            ViewData["PolicyId"] = new SelectList(_context.Policies, "PolicyId", "PolicyId");
            return View();
        }

        // POST: Procedure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedureId,PrTitle,PrDesc,PrPurpose,PolicyId")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "PolicyId", "PolicyId", procedure.PrTitle);
            return View(procedure);
        }

        // GET: Procedure/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "PolicyId", "PolicyId", procedure.PrTitle);
            return View(procedure);
        }

        // POST: Procedure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedureId,PrTitle,PrDesc,PrPurpose,PolicyId")] Procedure procedure)
        {
            if (id != procedure.ProcedureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.ProcedureId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolicyId"] = new SelectList(_context.Policies, "PolicyId", "PolicyId", procedure.PrTitle);
            return View(procedure);
        }

        // GET: Procedure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures
                .Include(p => p.Policy)
                .FirstOrDefaultAsync(m => m.ProcedureId == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // POST: Procedure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedure = await _context.Procedures.FindAsync(id);
            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureExists(int id)
        {
            return _context.Procedures.Any(e => e.ProcedureId == id);
        }
    }
}
