using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public class ProductRepository : GenericReposotory<Product>, IProductRepository
    {
        
        public ProductRepository(DataContext context) : base(context)
        {
            
        }
    }
}
