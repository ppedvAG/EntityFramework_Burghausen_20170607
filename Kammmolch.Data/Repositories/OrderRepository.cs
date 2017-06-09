using Kammmolch.Core.Models;
using Kammmolch.Core.Repositories;

namespace Kammmolch.Data.Repositories
{
    public class OrderRepository : Repository<ErpContext, Order>, IOrderRepository
    {
        public OrderRepository(ErpContext context) 
            : base(context)
        { }
    }
}
