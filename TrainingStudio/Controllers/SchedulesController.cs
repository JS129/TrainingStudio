using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingStudio.Data;
using TrainingStudio.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrainingStudio.Controllers
{
        public class SchedulesController : Controller
        {
            private readonly TrainingStudioContext _context;

            public SchedulesController(TrainingStudioContext context)
            {
                _context = context;
            }

        // GET: Schedules
        public async Task<IActionResult> Index()
            {
               return View(await _context.Schedules.ToListAsync());               
            }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Schedules == null)
                {
                    return NotFound();
                }

                return View(Schedules);
            }
        public IActionResult ClassNotFound()
        {
            return View();
        }
         public IActionResult Schedulesed()
        {
            return View();
        }
        
        // GET: Schedules/Create
        public IActionResult Create()
            {
            var Classes = _context.Classes.ToList();
            if (Classes.Count > 0)
            {
                Classes.Insert(0, new Classes { Id = 0, TrainingType = "Select Classes" });
                ViewBag.ListClasses = Classes;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(ClassNotFound));
            }
            }



        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,NumberOfPersons,StartDate,ClassId")] Schedules Schedules)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Schedules);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Schedules);
            }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules.FindAsync(id);
                if (Schedules == null)
                {
                    return NotFound();
                }
                return View(Schedules);
            }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,NumberOfPersons,StartDate,ClassId")] Schedules Schedules)
            {
                if (id != Schedules.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                    var item = _context.Schedules.FirstOrDefault(x => x.Id == Schedules.Id);
                    item.Id = Schedules.Id;
                    item.Name = Schedules.Name;
                    item.Contact = Schedules.Contact;
                    item.NumberOfPersons = Schedules.NumberOfPersons;
                    item.StartDate = Schedules.StartDate;
                    _context.Schedules.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SchedulesExists(Schedules.Id))
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
                return View(Schedules);
            }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Schedules == null)
                {
                    return NotFound();
                }

                return View(Schedules);
            }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Schedules = await _context.Schedules.FindAsync(id);
                _context.Schedules.Remove(Schedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SchedulesExists(int id)
            {
                return _context.Schedules.Any(e => e.Id == id);
            }
        }
    }
