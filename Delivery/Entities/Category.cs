using System;
namespace Delivery.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DeliveryTime { get; set; }

		//nav props
		public virtual ICollection<Product>? Products { get; set; }
	}
}

