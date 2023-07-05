using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class MarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.marks.Include(m => m.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.marks == null)
            {
                return NotFound();
            }

            var marks = await _context.marks
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["studentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkId,studentId,Telugu,Hindi,English,Maths,Science,SocialStudies,TotalMarks")] Marks marks)
        {
           
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["studentId"] = new SelectList(_context.Students, "Id", "Id", marks.studentId);
            return View(marks);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.marks == null)
            {
                return NotFound();
            }

            var marks = await _context.marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            ViewData["studentId"] = new SelectList(_context.Students, "Id", "Id", marks.studentId);
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkId,studentId,Telugu,Hindi,English,Maths,Science,SocialStudies,TotalMarks")] Marks marks)
        {
            if (id != marks.MarkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.MarkId))
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
            ViewData["studentId"] = new SelectList(_context.Students, "Id", "Id", marks.studentId);
            return View(marks);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.marks == null)
            {
                return NotFound();
            }

            var marks = await _context.marks
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.marks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.marks'  is null.");
            }
            var marks = await _context.marks.FindAsync(id);
            if (marks != null)
            {
                _context.marks.Remove(marks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int id)
        {
          return (_context.marks?.Any(e => e.MarkId == id)).GetValueOrDefault();
        }
    }
}
