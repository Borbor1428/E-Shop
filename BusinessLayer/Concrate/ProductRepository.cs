using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EmptyLayer.Entities;

namespace BusinessLayer.Concrate
{
    public class ProductRepository:GenericRepository<Product>
    {
        DataContext db = new DataContext();

         public List<Product> GetPopularProduct()
        {
            return db.Products.Where(x => x.Popular == true).Take(3).ToList();
        }
    }
}
