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
    public class PolicyController : Controller
    {
        private readonly WorkflowContext _context;

        public PolicyController(WorkflowContext context)
        {
            _context = context;
        }

        // GET: Policies
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

           

            var policies = from pol in _context.Policies select pol;
            if (!String.IsNullOrEmpty(searchString))
            {
                policies = policies.Where(q => q.PTitle.Contains(searchString));
            }

            policies = policies.OrderByDescending(q => q.PTitle);

            int pageSize = 5;

            return View(await PaginatedList<Policy>.CreateAsync(policies.AsNoTracking(), page ?? 1, pageSize));
        }



        // GET: Policies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies
                //.Include(p => p.Procedures)             
                //.ThenInclude(p => p.Processes)
                //.ThenInclude(a=>a.Actions)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PolicyId == id);

            //var policy = await _context.Actions
            //    .Include(a => a.Process)
            //    .ThenInclude(p => p.Procedure)
            //    .ThenInclude(q => q.Policy)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.Process.Procedure.Policy.PolicyId == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // GET: Policies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //, string[] procedures, string[] processes, string[] actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolicyId,PTitle,PDescription,PScope")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policy);

            //if(procedures != null)
            //{
            //    policy.Procedures = new List<Procedure>();

            //    foreach(var proc in procedures)
            //    {
            //        var procToAdd = new Procedure { PolicyId = policy.PolicyId, ProcedureId = int.Parse(proc) };
            //        policy.Procedures.Add(procToAdd);

            //        if (processes != null)
            //        {
            //            procToAdd.Processes = new List<Process>();

            //            foreach(var p in processes)
            //            {
            //                var pToAdd = new Process { ProcedureId = procToAdd.ProcedureId, ProcessId = int.Parse(p) };
            //                procToAdd.Processes.Add(pToAdd);

            //                if (actions != null)
            //                {
            //                    pToAdd.Actions = new List<Action>();

            //                    foreach(var a in actions)
            //                    {
            //                        var actToAdd = new Action { ProcessId = pToAdd.ProcessId, Id = int.Parse(a) };
            //                        pToAdd.Actions.Add(actToAdd);
            //                    }
            //                }
            //            }                        
            //        }
            //    }           
            //}

            //if (ModelState.IsValid)
            //{
            //    _context.Add(policy);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(policy);
        }

        // GET: Policies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PolicyId,PTitle,PDescription,PScope")] Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyExists(policy.PolicyId))
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
            return View(policy);
        }

        // GET: Policies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policies
                .FirstOrDefaultAsync(m => m.PolicyId == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyExists(int id)
        {
            return _context.Policies.Any(e => e.PolicyId == id);
        }

        
    }
}
