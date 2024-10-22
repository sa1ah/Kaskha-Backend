using AutoMapper;
using Kashkha.API;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class ProductPictureUrlResolver : IValueResolver<Product, GetProductDto, string>
	{
		private readonly IConfiguration configuration;

		public ProductPictureUrlResolver(IConfiguration configuration) {
			this.configuration = configuration;
		}
		public string Resolve(Product source, GetProductDto destination, string destMember, ResolutionContext context)
		{
			if(!string.IsNullOrEmpty(source.PictureUrl))
			{
				return $"{configuration["ApiBaseUrl"]}{source.PictureUrl}";

			}

			return string.Empty;
		}
	}
}
