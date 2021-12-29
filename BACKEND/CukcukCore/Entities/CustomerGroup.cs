using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukcukCore.Entities
{
	public class CustomerGroup
	{
		#region Properties
		public Guid CustomerGroupId { get; set; } = Guid.NewGuid();
		public string CustomerGroupName { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
		#endregion
	}
}
