using System;
using CukcukCore.Entities;

namespace CukcukCore.Entities
{
	public class Employee
	{
		#region Properties
		public Guid EmployeeId { get; set; } = Guid.NewGuid();
		[RequiredField("EmployeeCode cannot be null")]
		public string EmployeeCode { get; set; }
		[RequiredField("FullName cannot be null")]
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public Guid DepartmentId { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy{ get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
		#endregion
	}
}
