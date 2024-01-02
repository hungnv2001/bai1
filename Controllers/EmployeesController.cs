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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _db;
        private readonly ICompanyService _coms;

        public EmployeesController()
        {
            _db=new EmployService();
            _coms=new CompanyService();
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var myDbContext = _db.GetAll();
            return View( myDbContext.ToList());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _db.GetAll()==null)
            {
                return NotFound();
            }

            var employee = _db.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_coms.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,CompanyID")] Employee employee)
         {
            if (!ModelState.IsValid)
            {
                _db.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID"] = new SelectList(_coms.GetAll(), "Id", "Name", employee.CompanyID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          

            var employee = _db.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_coms.GetAll(), "Id", "Name", employee.CompanyID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Gender,CompanyID")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _db.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["CompanyID"] = new SelectList(_db.GetAll(), "Id", "Name", employee.CompanyID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var employee = _db.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (id != null)
            {
                _db.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_db.GetById(id)!=null?true:false);
        }
    }
}
