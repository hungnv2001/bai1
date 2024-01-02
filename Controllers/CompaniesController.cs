using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bai1.Context;
using bai1.Models;
using bai1.Service;

namespace bai1.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _coms;

        public CompaniesController()
        {
            _coms=new CompanyService();
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var x= _coms.GetAll();
              return _coms.GetAll().Count>0 ? 
                          View( _coms.GetAll()) :
                          Problem("Entity set 'MyDbContext.Companys'  is null.");
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _coms.GetAll() == null)
            {
                return NotFound();
            }

            var company =  _coms.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Company company)
        {
            if (!ModelState.IsValid)
            {
                _coms.Create(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
        

            var company = _coms.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
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

            if (!ModelState.IsValid)
            {
                try
                {
                    _coms.Update(company);
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

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
          

            var company = _coms.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if ( _coms.GetAll() == null)
            {
                return Problem("Entity set 'MyDbContext.Companys'  is null.");
            }
            var company = _coms.GetById(id);
            if (company != null)
            {
                _coms.Delete(id);
            }
            
           
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return (_coms.GetById(id) == null?false:true) ;
        }
    }
}
