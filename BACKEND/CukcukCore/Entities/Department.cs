using System;

namespace CukcukCore.Entities
{
	public class Department
	{
		#region Properties
		public Guid DepartmentId { get; set; } = Guid.NewGuid();
		[RequiredField("DepartmentName cannot be null")]
		public string DepartmentName { get; set; }
		public string CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
		#endregion
	}
}
