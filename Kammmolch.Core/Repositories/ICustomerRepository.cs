using Kammmolch.Core.Models;

namespace Kammmolch.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetWithOrders(int id);
    }
}
