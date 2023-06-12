using System;
using SuperShop.Data.Entities;

namespace SuperShop.Models.Helpers
{
	public interface IConverterHelper
	{
		Product ToProduct(ProductViewModel model, Guid imageId, bool isNew);

		ProductViewModel ToProductViewModel(Product product);
	}
}
