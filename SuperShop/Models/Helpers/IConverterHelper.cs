using SuperShop.Data.Entities;

namespace SuperShop.Models.Helpers
{
	public interface IConverterHelper
	{
		Product ToProduct(ProductViewModel model, string path, bool isNew);

		ProductViewModel ToProductViewModel(Product product);
	}
}
