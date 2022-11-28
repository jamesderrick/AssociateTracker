using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AssociateTracker.Services
{
	public class CompanyService : ICompanyService
	{
        private readonly DataContext _db;

        public CompanyService(DataContext db)
        {
            _db = db;
        }

        public bool Create(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return true;
        }

        public List<Company> All()
        {
            List<Company> companyList = _db.Companies.ToList();
            return companyList;
        }

        public Company? ById(int id)
        {
            var company = _db.Companies.Find(id);
            return company;
        }
    }

    public interface ICompanyService
    {
        bool Create(Company company);
        bool Update(Company company);
        List<Company> All();
        Company? ById(int id);
    }
}

