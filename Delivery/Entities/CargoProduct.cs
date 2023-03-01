using System;
namespace Delivery.Entities
{
	public class CargoProduct
	{
		public int Id { get; set; }
		public int CargoId { get; set; }
		public int ProductId { get; set; }

		//nav props
		public virtual Cargo Cargo { get; set; }
		public virtual Product Product { get; set; }
	}
}

