using Kammmolch.Core.Models;
using Kammmolch.Core.Repositories;

namespace Kammmolch.Data.Repositories
{
    public class ArticleRepository : Repository<ErpContext, Article>, IArticleRepository
    {
        public ArticleRepository(ErpContext context) 
            : base(context)
        { }
    }
}
