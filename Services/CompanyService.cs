using System;
using AssociateTracker.Data;
using AssociateTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> DropdownActive()
        {
            var companies = _db.Companies
                .Where(c => c.IsActive == true)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CompanyName
                })
                .ToList();
            return companies;
        }

        public List<SelectListItem> DropdownActive(int SelectedId)
        {
            var companies = _db.Companies
                .Where(c => c.IsActive == true)
                .Select(c => new SelectListItem {
                    Value = c.Id.ToString(),
                    Text = c.CompanyName,
                    Selected = (c.Id == SelectedId) ? true : false
                })
                .ToList();
            return companies;
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
        List<SelectListItem> DropdownActive();
        List<SelectListItem> DropdownActive(int SelectedId);
        Company? ById(int id);
    }
}

