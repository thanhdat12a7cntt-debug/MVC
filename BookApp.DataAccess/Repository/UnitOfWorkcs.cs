using BBookWeb.DataAccess.Data;
using BBookWeb.DataAccess.Repository.IRepository;
using BookUserWeb.Data.Repository;
using BookUserWeb.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBookWeb.DataAccess.Repository
{
    public class UnitOfWorkcs : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; } 

        public UnitOfWorkcs(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
