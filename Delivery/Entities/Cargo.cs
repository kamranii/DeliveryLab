using System;
namespace Delivery.Entities
{
	public class Cargo
	{
		public int Id { get; set; }
		//nav props
		public virtual ICollection<CargoProduct> CargoProducts { get; set; }
	}
}

