using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBfirstCORE.Models;

namespace DBfirstCORE.Controllers
{
    public class ClassTblsController : Controller
    {
        private readonly CrudNewContext _context;

        public ClassTblsController(CrudNewContext context)
        {
            _context = context;
        }

        // GET: ClassTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassTbls.ToListAsync());
        }

        // GET: ClassTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTbl = await _context.ClassTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classTbl == null)
            {
                return NotFound();
            }

            return View(classTbl);
        }

        // GET: ClassTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Selery,Age,Add")] ClassTbl classTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classTbl);
        }

        // GET: ClassTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTbl = await _context.ClassTbls.FindAsync(id);
            if (classTbl == null)
            {
                return NotFound();
            }
            return View(classTbl);
        }

        // POST: ClassTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Selery,Age,Add")] ClassTbl classTbl)
        {
            if (id != classTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTblExists(classTbl.Id))
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
            return View(classTbl);
        }

        // GET: ClassTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTbl = await _context.ClassTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classTbl == null)
            {
                return NotFound();
            }

            return View(classTbl);
        }

        // POST: ClassTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classTbl = await _context.ClassTbls.FindAsync(id);
            if (classTbl != null)
            {
                _context.ClassTbls.Remove(classTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTblExists(int id)
        {
            return _context.ClassTbls.Any(e => e.Id == id);
        }
    }
}
