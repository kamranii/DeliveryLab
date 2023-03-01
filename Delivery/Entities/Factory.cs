using System;
namespace Delivery.Entities
{
	public class Factory
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//nav props
		public virtual ICollection<Product>? Products { get; set; }
	}
}

