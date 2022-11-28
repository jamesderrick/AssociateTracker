using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using AssociateTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssociateTracker.Controllers
{
	public class CompanyController : Controller
	{
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companiesList = _companyService.All();
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
                if (_companyService.Create(company))
                {
                    TempData["success"] = "Company added successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(company);
        }

        public IActionResult Edit(int id)
        {
            var company = _companyService.ById(id);
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
                if (_companyService.Update(company))
                {
                    TempData["success"] = "Associate updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(company);
        }
    }
}

