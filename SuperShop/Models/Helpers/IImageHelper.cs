using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuperShop.Models.Helpers
{
	public interface IImageHelper
	{
		Task<string> UploadImageAsync(IFormFile imageFile, string folder);


	}
}
