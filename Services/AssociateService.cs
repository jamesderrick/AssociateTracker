using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Services
{
	public class AssociateService : IAssociateService
	{
        private readonly DataContext _db;

        public AssociateService(DataContext db)
        {
            _db = db;
        }

        public bool Create(Associate associate)
        {
            _db.Associates.Add(associate);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Associate associate)
        {
            _db.Associates.Update(associate);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(Associate associate)
        {
            _db.Associates.Remove(associate);
            _db.SaveChanges();
            return true;
        }

        public List<Associate> All()
        {
            List<Associate> associatesList = _db.Associates
                .Include(a => a.Placement)
                .ThenInclude(p => p.Company)
                .ToList();
            return associatesList;
        }

        public Associate ById(int id)
        {
            var associate = _db.Associates.Find(id);
            return associate;
        } 
    }
}

public interface IAssociateService
{
    bool Create(Associate associate);
    bool Update(Associate associate);
    bool Delete(Associate associate);
    List<Associate> All();
    Associate ById(int id);
}

