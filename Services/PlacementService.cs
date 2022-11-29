using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Services
{
    public class PlacementService : IPlacementService
    {
        private readonly DataContext _db;

        public PlacementService(DataContext db)
        {
            _db = db;
        }

        public bool Create(Placement placement)
        {
            _db.Placements.Add(placement);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Placement placement)
        {
            _db.Placements.Update(placement);
            _db.SaveChanges();
            return true;
        }

        public List<Placement> All()
        {
            List<Placement> placementList = _db.Placements
                .Include(c => c.Company)
                .Include(a => a.Associate)
                .ToList();
            return placementList;
        }

        public Placement? ById(int id)
        {
            var placement = _db.Placements
                .Include(c => c.Company)
                .Include(a => a.Associate)
                .FirstOrDefault(p => p.Id == id);
            return placement;
        }
    }

    public interface IPlacementService
    {
        bool Create(Placement placement);
        bool Update(Placement placement);
        List<Placement> All();
        Placement? ById(int id);
    }
}
