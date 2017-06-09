using Kammmolch.Core.Models;
using Kammmolch.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Kammmolch.Data.Repositories
{
    public class CustomerRepository : Repository<ErpContext, Customer>, ICustomerRepository
    {
        public CustomerRepository(ErpContext context) 
            : base(context)
        { }

        public Customer GetWithOrders(int id)
        {
            return Entries.Include(c => c.Orders)
                          .SingleOrDefault(c => c.Id == id);
        }
    }
}
