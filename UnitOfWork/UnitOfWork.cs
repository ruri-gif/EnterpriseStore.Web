using System;
using System.Threading.Tasks;
using EnterpriseStore.Web.Data;
using EnterpriseStore.Web.Models;
using EnterpriseStore.Web.Repositories.Implementations;
using EnterpriseStore.Web.Repositories.Interfaces;

namespace EnterpriseStore.Web.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Product> _products;
        private IRepository<Order> _orders;
        private IRepository<OrderItem> _orderItems;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new Repository<Product>(_context);
                return _products;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new Repository<Order>(_context);
                return _orders;
            }
        }

        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (_orderItems == null)
                    _orderItems = new Repository<OrderItem>(_context);
                return _orderItems;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
