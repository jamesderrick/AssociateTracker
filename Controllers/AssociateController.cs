using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssociateTracker.Controllers
{
    public class AssociateController : Controller
    {
        private readonly DataContext _db;

        public AssociateController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Associate> associatesList = _db.Associates;
            return View(associatesList);
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
                _db.Associates.Add(associate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(associate);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var associate = _db.Associates.Find(id);
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
                _db.Associates.Update(associate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(associate);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var associate = _db.Associates.Find(id);
            if (associate == null)
            {
                return NotFound();
            }
            return View(associate);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteAssociate(int? id)
        {
            var associate = _db.Associates.Find(id);
            if(associate == null)
            {
                return NotFound();
            }

            _db.Associates.Remove(associate);
            _db.SaveChanges();
            return RedirectToAction("Index");
         
        }
    }
}

