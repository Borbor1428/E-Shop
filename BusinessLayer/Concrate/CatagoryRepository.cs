using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EmptyLayer.Entities;

namespace BusinessLayer.Concrate
{
    public class CatagoryRepository:GenericRepository<Category>
    {
        DataContext db = new DataContext();

        public List<Product> CategoryDetails(int id)
        {
            return db.Products.Where(x => x.CategoryId == id).ToList();
        }
    }
}
