
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class Review:BaseEntity
	{
        public string UserId { get; set; }

		public string UserName {  get; set; }

		public string UserComment { get; set; }

		public int ProductId { get; set; }

		[JsonIgnore]
		public Product? Product { get; set; }

			public DateTime? CreatedDate { get; set; }=DateTime.Now;

	}
}
