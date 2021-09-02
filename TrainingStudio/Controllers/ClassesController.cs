using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingStudio.Data;
using TrainingStudio.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace TrainingStudio.Controllers
{
        public class ClassesController : Controller
        {
            private readonly TrainingStudioContext _context;

            public ClassesController(TrainingStudioContext context)
            {
                _context = context;
            }

            // GET: Classes
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Classes.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Classes.ToListAsync());
            }
        
            // GET: Classes/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Classes = await _context.Classes
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Classes == null)
                {
                    return NotFound();
                }

                return View(Classes);
            }

            // GET: Classes/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Classes/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,TrainingType,Time,Price")] Classes Classes)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Classes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Classes);
            }

            // GET: Classes/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Classes = await _context.Classes.FindAsync(id);
                if (Classes == null)
                {
                    return NotFound();
                }
                return View(Classes);
            }

            // POST: Classes/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,TrainingType,Time,Price")] Classes Classes)
            {
                if (id != Classes.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Classes);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClassesExists(Classes.Id))
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
                return View(Classes);
            }

            // GET: Classes/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Classes = await _context.Classes
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Classes == null)
                {
                    return NotFound();
                }

                return View(Classes);
            }

            // POST: Classes/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Classes = await _context.Classes.FindAsync(id);
                _context.Classes.Remove(Classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ClassesExists(int id)
            {
                return _context.Classes.Any(e => e.Id == id);
            }
        }
    }