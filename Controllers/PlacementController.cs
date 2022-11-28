using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Controllers
{
	public class PlacementController : Controller
	{
        private readonly DataContext _db;

        public PlacementController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Placement> placements = _db.Placements
                .Include(c => c.Company)
                .Include(a => a.Associate)
                .ToList();
            return View(placements);
        }

        public IActionResult Create()
        {
            List<SelectListItem> companies = _db.Companies
                .Where(c => c.IsActive == true)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CompanyName })
                .ToList();
            List<SelectListItem> associates = _db.Associates
                .Where(a => a.Placement == null)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FirstName + " " + a.LastName })
                .ToList();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Placement placement, string CompanyId, string AssociateId)
        {
            var company = _db.Companies.Find(Int32.Parse(CompanyId));
            if (company != null)
            {
                placement.Company = company;
                ModelState.Remove("Company");
            }

            var associate = _db.Associates.Find(Int32.Parse(AssociateId));
            if (associate != null)
            {
                placement.Associate = associate;
                ModelState.Remove("Associate");
            }

            if (ModelState.IsValid)
            {
                _db.Placements.Add(placement);
                _db.SaveChanges();
                TempData["success"] = "Placement added successfully";
                return RedirectToAction("Index");
            }

            List<SelectListItem> companies = _db.Companies
                .Where(c => c.IsActive == true || c.Id == placement.Company.Id)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CompanyName })
                .ToList();
            List<SelectListItem> associates = _db.Associates
                .Where(a => a.Placement == null || a.Id == placement.Associate.Id)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FirstName + " " + a.LastName })
                .ToList();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var placement = _db.Placements
                .Include(c => c.Company)
                .Include(a => a.Associate)
                .FirstOrDefault(p => p.Id == id);
            if (placement == null)
            {
                return NotFound();
            }

            List<SelectListItem> companies = _db.Companies
                .Where(c => c.IsActive == true)
                .Select(c => new SelectListItem {
                    Value = c.Id.ToString(),
                    Text = c.CompanyName,
                    Selected = (c.Id == placement.Company.Id) ? true : false
                })
                .ToList();
            List<SelectListItem> associates = _db.Associates
                .Where(a => a.Placement == null || a.Id == placement.Associate.Id)
                .Select(a => new SelectListItem {
                    Value = a.Id.ToString(),
                    Text = a.FirstName + " " + a.LastName,
                    Selected = (a.Id == placement.Associate.Id) ? true : false
                })
                .ToList();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Placement placement, string CompanyId, string AssociateId)
        {
            var company = _db.Companies.Find(Int32.Parse(CompanyId));
            if (company != null)
            {
                placement.Company = company;
                ModelState.Remove("Company");
            }

            var associate = _db.Associates.Find(Int32.Parse(AssociateId));
            if (associate != null)
            {
                placement.Associate = associate;
                ModelState.Remove("Associate");
            }

            if (ModelState.IsValid)
            {
                _db.Placements.Update(placement);
                _db.SaveChanges();
                TempData["success"] = "Placement added successfully";
                return RedirectToAction("Index");
            }


            List<SelectListItem> companies = _db.Companies
                .Where(c => c.IsActive == true || c.Id == placement.Company.Id)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CompanyName })
                .ToList();
            List<SelectListItem> associates = _db.Associates
                .Where(a => a.Placement == null || a.Id == placement.Associate.Id)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FirstName + " " + a.LastName })
                .ToList();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var placement = _db.Placements
                .Include(c => c.Company)
                .Include(a => a.Associate)
                .FirstOrDefault(p => p.Id == id);
            if (placement == null)
            {
                return NotFound();
            }
            return View(placement);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePlacment(int? id)
        {
            var placement = _db.Placements.Find(id);
            if (placement == null)
            {
                return NotFound();
            }

            _db.Placements.Remove(placement);
            _db.SaveChanges();
            TempData["success"] = "Placement deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

