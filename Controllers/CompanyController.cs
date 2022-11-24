using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssociateTracker.Controllers
{
	public class CompanyController : Controller
	{
        private readonly DataContext _db;

        public CompanyController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companiesList = _db.Companies.ToList();
            return View(companiesList);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Add(company);
                _db.SaveChanges();
                TempData["success"] = "Company added successfully";
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var company = _db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Update(company);
                _db.SaveChanges();
                TempData["success"] = "Associate updated successfully";
                return RedirectToAction("Index");
            }
            return View(company);
        }
    }
}

