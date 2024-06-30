using ShoppingOnline.DataAccess.Data;
using ShoppingOnline.DataAccess.Repository.IRepository;
using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicatinDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicatinDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
    }
       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
