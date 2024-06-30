using ShoppingOnline.DataAccess.Data;
using ShoppingOnline.DataAccess.Repository.IRepository;
using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicatinDbContext _db;
        public ProductRepository(ApplicatinDbContext db) : base(db)
        {
            _db = db;
        
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
