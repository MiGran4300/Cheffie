#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cheffie.Data;
using Cheffie.Models;

namespace Cheffie.Controllers
{
    public class CooksController : Controller
    {
        private readonly CheffieContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CooksController(CheffieContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Cooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cook.ToListAsync());
        }

        // GET: Cooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cook
                .FirstOrDefaultAsync(m => m.CookId == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // GET: Cooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CookId,Name,Email,Skill,DOB,FilePath")] Cook cook)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(cook.File.FileName);
                string extension = Path.GetExtension(cook.File.FileName);
                cook.FilePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/upload/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await cook.File.CopyToAsync(fileStream);
                }

                _context.Add(cook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cook);
        }

        // GET: Cooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cook.FindAsync(id);
            if (cook == null)
            {
                return NotFound();
            }
            return View(cook);
        }

        // POST: Cooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CookId,Name,Email,Skill,DOB")] Cook cook)
        {
            if (id != cook.CookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookExists(cook.CookId))
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
            return View(cook);
        }

        // GET: Cooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cook
                .FirstOrDefaultAsync(m => m.CookId == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // POST: Cooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cook = await _context.Cook.FindAsync(id);
            _context.Cook.Remove(cook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookExists(int id)
        {
            return _context.Cook.Any(e => e.CookId == id);
        }
    }
}
