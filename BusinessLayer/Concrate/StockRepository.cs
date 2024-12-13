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
    public class StockRepository : GenericRepository<Stock>
    {
        DataContext db = new DataContext();

        public void AddStock(Stock stock)
        {
            db.Stocks.Add(stock);
            db.SaveChanges();
        }

        // Ürün ID'ye göre stok bilgisi getirme metodu
        public List<Stock> GetStockByProductId(int productId)
        {
            return db.Stocks.Where(s => s.ProductId == productId).ToList();
        }
    }
}

