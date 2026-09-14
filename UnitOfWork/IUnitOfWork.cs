using System;
using System.Threading.Tasks;
using EnterpriseStore.Web.Models;
using EnterpriseStore.Web.Repositories.Interfaces;

namespace EnterpriseStore.Web.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }

        Task<int> CompleteAsync();
    }
}