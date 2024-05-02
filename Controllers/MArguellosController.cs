using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenProgreso1.Data;
using ExamenProgreso1.Models;

namespace ExamenProgreso1.Controllers
{
    public class MArguellosController : Controller
    {
        private readonly ExamenProgreso1Context _context;

        public MArguellosController(ExamenProgreso1Context context)
        {
            _context = context;
        }

        // GET: MArguellos
        public async Task<IActionResult> Index()
        {
            var examenProgreso1Context = _context.MArguello.Include(m => m.Carrera);
            return View(await examenProgreso1Context.ToListAsync());
        }

        // GET: MArguellos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mArguello = await _context.MArguello
                .Include(m => m.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mArguello == null)
            {
                return NotFound();
            }

            return View(mArguello);
        }

        // GET: MArguellos/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "nombre_Carrera");
            return View();
        }

        // POST: MArguellos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fechaNacimiento,peso,esEcuatoriano,CarreraId")] MArguello mArguello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mArguello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "nombre_Carrera", mArguello.CarreraId);
            return View(mArguello);
        }

        // GET: MArguellos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mArguello = await _context.MArguello.FindAsync(id);
            if (mArguello == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "nombre_Carrera", mArguello.CarreraId);
            return View(mArguello);
        }

        // POST: MArguellos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fechaNacimiento,peso,esEcuatoriano,CarreraId")] MArguello mArguello)
        {
            if (id != mArguello.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mArguello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MArguelloExists(mArguello.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "Id", "nombre_Carrera", mArguello.CarreraId);
            return View(mArguello);
        }

        // GET: MArguellos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mArguello = await _context.MArguello
                .Include(m => m.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mArguello == null)
            {
                return NotFound();
            }

            return View(mArguello);
        }

        // POST: MArguellos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mArguello = await _context.MArguello.FindAsync(id);
            if (mArguello != null)
            {
                _context.MArguello.Remove(mArguello);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MArguelloExists(int id)
        {
            return _context.MArguello.Any(e => e.Id == id);
        }
    }
}
