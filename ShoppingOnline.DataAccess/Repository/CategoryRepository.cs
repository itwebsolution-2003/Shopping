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
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {

        private ApplicatinDbContext _db;
        public CategoryRepository(ApplicatinDbContext db) : base(db)
        {
            _db = db;
        
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
