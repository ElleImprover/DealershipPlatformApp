using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DealerLead;

namespace DealerLead.Web.Controllers
{
    public class SupportedStatesController : Controller
    {
        private readonly DealerLeadDBContext _context;

        public SupportedStatesController(DealerLeadDBContext context)
        {
            _context = context;
        }

        // GET: SupportedState
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportedState.ToListAsync());
        }

        // GET: SupportedState/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedState = await _context.SupportedState
                .FirstOrDefaultAsync(m => m.Abbreviation == id);
            if (supportedState == null)
            {
                return NotFound();
            }

            return View(supportedState);
        }

        // GET: SupportedState/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportedState/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Abbreviation,Name")] SupportedState supportedState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportedState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportedState);
        }

        // GET: SupportedState/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedState = await _context.SupportedState.FindAsync(id);
            if (supportedState == null)
            {
                return NotFound();
            }
            return View(supportedState);
        }

        // POST: SupportedState/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Abbreviation,Name")] SupportedState supportedState)
        {
            if (id != supportedState.Abbreviation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportedState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportedStateExists(supportedState.Abbreviation))
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
            return View(supportedState);
        }

        // GET: SupportedState/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedState = await _context.SupportedState
                .FirstOrDefaultAsync(m => m.Abbreviation == id);
            if (supportedState == null)
            {
                return NotFound();
            }

            return View(supportedState);
        }

        // POST: SupportedState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var supportedState = await _context.SupportedState.FindAsync(id);
            _context.SupportedState.Remove(supportedState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportedStateExists(string id)
        {
            return _context.SupportedState.Any(e => e.Abbreviation == id);
        }
    }
}
