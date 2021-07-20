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
    public class SupportedMakesController : Controller
    {
        private readonly DealerLeadDBContext _context;

        public SupportedMakesController(DealerLeadDBContext context)
        {
            _context = context;
        }

        // GET: SupportedMake
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportedMake.ToListAsync());
        }

        // GET: SupportedMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMake = await _context.SupportedMake
                .FirstOrDefaultAsync(m => m.MakeID == id);
            if (supportedMake == null)
            {
                return NotFound();
            }

            return View(supportedMake);
        }

        // GET: SupportedMake/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportedMake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakeID,MakeName")] SupportedMake supportedMake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportedMake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportedMake);
        }

        // GET: SupportedMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMake = await _context.SupportedMake.FindAsync(id);
            if (supportedMake == null)
            {
                return NotFound();
            }
            return View(supportedMake);
        }

        // POST: SupportedMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakeID,MakeName")] SupportedMake supportedMake)
        {
            if (id != supportedMake.MakeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportedMake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportedMakeExists(supportedMake.MakeID))
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
            return View(supportedMake);
        }

        // GET: SupportedMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportedMake = await _context.SupportedMake
                .FirstOrDefaultAsync(m => m.MakeID == id);
            if (supportedMake == null)
            {
                return NotFound();
            }

            return View(supportedMake);
        }

        // POST: SupportedMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportedMake = await _context.SupportedMake.FindAsync(id);
            _context.SupportedMake.Remove(supportedMake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportedMakeExists(int id)
        {
            return _context.SupportedMake.Any(e => e.MakeID == id);
        }
    }
}
