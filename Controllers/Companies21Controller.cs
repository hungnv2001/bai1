﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bai1.Context;
using bai1.Models;

namespace bai1.Controllers
{
    public class Companies21Controller : Controller
    {
        private readonly MyDbContext _context;

        public Companies21Controller(MyDbContext context)
        {
            _context = context;
        }

        // GET: Companies21
        public async Task<IActionResult> Index()
        {
              return _context.Companys != null ? 
                          View(await _context.Companys.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Companys'  is null.");
        }

        // GET: Companies21/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companys == null)
            {
                return NotFound();
            }

            var company = await _context.Companys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies21/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies21/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies21/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companys == null)
            {
                return NotFound();
            }

            var company = await _context.Companys.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies21/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Companies21/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Companys == null)
            {
                return NotFound();
            }

            var company = await _context.Companys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies21/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Companys == null)
            {
                return Problem("Entity set 'MyDbContext.Companys'  is null.");
            }
            var company = await _context.Companys.FindAsync(id);
            if (company != null)
            {
                _context.Companys.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return (_context.Companys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
