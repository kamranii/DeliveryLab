using System;
namespace Delivery.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public int FactoryId { get; set; }
		public int CategoryId { get; set; }

		//nav props
		public virtual Factory Factory { get; set; }
		public virtual Category Category { get; set; }
		public virtual ICollection<CargoProduct> ProductCargoes { get; set; }
	}
}

