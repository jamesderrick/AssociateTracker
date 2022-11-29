using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssociateTracker.Data;
using AssociateTracker.Models;
using AssociateTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Controllers
{
	public class PlacementController : Controller
	{
        private readonly IPlacementService _placementService;
        private readonly ICompanyService _companyService;
        private readonly IAssociateService _associateService;

        public PlacementController(IPlacementService placementService, ICompanyService companyService, IAssociateService associateService)
        {
            _placementService = placementService;
            _companyService = companyService;
            _associateService = associateService;
        }

        public IActionResult Index()
        {
            var placements = _placementService.All();
            return View(placements);
        }

        public IActionResult Create()
        {
            var companies = _companyService.DropdownActive();
            var associates = _associateService.NotPlaced();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Placement placement, string CompanyId, string AssociateId)
        {
            var company = _companyService.ById(Int32.Parse(CompanyId));
            if (company != null)
            {
                placement.Company = company;
                ModelState.Remove("Company");
            }

            var associate = _associateService.ById(Int32.Parse(AssociateId));
            if (associate != null)
            {
                placement.Associate = associate;
                ModelState.Remove("Associate");
            }

            if (ModelState.IsValid)
            {
                if (_placementService.Create(placement))
                {
                    TempData["success"] = "Placement added successfully";
                    return RedirectToAction("Index");
                }
            }

            var companies = _companyService.DropdownActive();
            var associates = _associateService.NotPlaced();
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        public IActionResult Edit(int id)
        {
            var placement = _placementService.ById(id);
            if (placement == null)
            {
                return NotFound();
            }
            var companies = _companyService.DropdownActive(placement.Company.Id);
            var associates = _associateService.NotPlaced(placement.Associate.Id);
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Placement placement, string CompanyId, string AssociateId)
        {
            var companyId = Int32.Parse(CompanyId);
            if (companyId != 0)
            {
                var company = _companyService.ById(companyId);
                if (company != null)
                {
                    placement.Company = company;
                    ModelState.Remove("Company");
                }
            }

            var associateId = Int32.Parse(AssociateId);
            if (AssociateId != null)
            {
                var associate = _associateService.ById(associateId);
                if (associate != null)
                {
                    placement.Associate = associate;
                    ModelState.Remove("Associate");
                }
            }

            if (ModelState.IsValid)
            {
                if (_placementService.Update(placement))
                {
                    TempData["success"] = "Placement added successfully";
                    return RedirectToAction("Index");
                }
            }

            var companies = _companyService.DropdownActive(placement.Company.Id);
            var associates = _associateService.NotPlaced(placement.Associate.Id);
            ViewBag.Company = companies;
            ViewBag.Associate = associates;
            return View(placement);
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var placement = _db.Placements
        //        .Include(c => c.Company)
        //        .Include(a => a.Associate)
        //        .FirstOrDefault(p => p.Id == id);
        //    if (placement == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(placement);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePlacment(int? id)
        //{
        //    var placement = _db.Placements.Find(id);
        //    if (placement == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Placements.Remove(placement);
        //    _db.SaveChanges();
        //    TempData["success"] = "Placement deleted successfully";
        //    return RedirectToAction("Index");

        //}
    }
}

