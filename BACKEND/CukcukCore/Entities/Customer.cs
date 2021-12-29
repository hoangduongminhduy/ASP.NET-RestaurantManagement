using System;

namespace CukcukCore.Entities
{
	public class Customer
	{
		#region Properties
		public Guid CustomerId { get; set; }
		[RequiredField("CustomerCode cannot be null")]
		public string CustomerCode { get; set; }
		[RequiredField("FullName cannot be null")]
		public string FullName { get; set; }
		public string Gender { get; set; } //0 Nữ, 1 Nam, 2 Khác
		public DateTime? DateOfBirth { get; set; } //return null instead of default(01 01 0001)
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public double DebitAmount { get; set; }
		public string Address { get; set; }
		public Guid? CustomerGroupId { get; set; }
		public string MemberCardNo { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy{ get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
		#endregion
	}
}
