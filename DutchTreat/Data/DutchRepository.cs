using System.Collections.Generic;
using System.Linq;
using DutchTreat.Data.Entities;
using DutchTreat.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        public DutchRepository(DutchContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }
    }
}