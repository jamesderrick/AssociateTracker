using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssociateTracker.Data;
using AssociateTracker.Models;
using AssociateTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssociateTracker.Controllers
{
    public class AssociateController : Controller
    {
        private readonly IAssociateService _associateService;

        public AssociateController(IAssociateService associateService)
        {
            _associateService = associateService;
        }

        public IActionResult Index()
        {
            var associates = _associateService.All();
            return View(associates);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Associate associate)
        {
            if (ModelState.IsValid)
            {
                if (_associateService.Create(associate))
                {
                    TempData["success"] = "Associate added successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(associate);
        }

        public IActionResult Edit(int id)
        {
            var associate = _associateService.ById(id);
            if(associate == null)
            {
                return NotFound();
            }
            return View(associate);
        }

        [HttpPost]
        public IActionResult Edit(Associate associate)
        {
            if (ModelState.IsValid)
            {
                if (_associateService.Update(associate))
                {
                    TempData["success"] = "Associate updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(associate);
        }

        public IActionResult Delete(int id)
        {
            var associate = _associateService.ById(id);
            if (associate == null)
            {
                return NotFound();
            }
            return View(associate);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAssociate(int id)
        {
            var associate = _associateService.ById(id);
            if (associate == null)
            {
                return NotFound();
            }

            _associateService.Delete(associate);
            TempData["success"] = "Associate deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

