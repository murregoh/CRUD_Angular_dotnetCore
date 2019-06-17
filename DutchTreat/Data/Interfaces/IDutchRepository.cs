using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data.Interfaces
{
    public interface IDutchRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        void AddEntity(object model);
        bool SaveAll();
    }
}