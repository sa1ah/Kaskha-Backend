using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductManager _productManager;

		public ProductController(IProductManager productManager)
		{
			_productManager = productManager;
		}

		[HttpGet]

		public ActionResult GetAll([FromQuery] string? categoryName,Guid? shopId)
		{
			return Ok(new { message = "seccess", data = _productManager.GetAll(categoryName, shopId) });

		}


		[HttpGet("{id:int}")]
		public ActionResult GetProduct([FromRoute] int id)
		{


			return Ok(new { message = "success", Data = _productManager.Get(id) });
		}

		[HttpPost]
		[Authorize(Roles ="Shop Owner")]
		public ActionResult PostProduct([FromForm] AddProductDto productDto)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			_productManager.Add(productDto,userId);
			return Ok(new { message = "success" });
		}

		[HttpDelete("{id:int}")]
		[Authorize(Roles = "Shop Owner")]
		public ActionResult DeleteProduct([FromRoute] int id)
		{
			if (!_productManager.isFound(id))
			{
				return NotFound("this product not fount");

			}
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var result = _productManager.Delete(_productManager.GetWithOutUrl(id), userId);
			if (result is null)
				return BadRequest(new { message ="you not have access to this data" });
			return Ok(new { message = "seccess" });
		}

		[HttpPut]
		[Authorize(Roles = "Shop Owner")]
		public ActionResult UpdateProduct([FromForm] UpdateProductDto updateProduct)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var result=_productManager.Update(updateProduct,userId);
			if(result is null)
			{
				BadRequest( new { message = "you not have access to this data" });
			}
			return Ok(new { message = "seccess" });

		}


	}
}
