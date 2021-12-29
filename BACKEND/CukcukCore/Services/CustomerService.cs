using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using CukcukCore.Interfaces.BusinessServices;
using CukcukCore.Interfaces.Repositories;
using CukcukCore.Entities;

namespace CukcukCore.BusinessServices
{
	public class CustomerService : BaseService<Customer>, ICustomerService
	{
		#region props and constructor
		ICustomerRepository customerRepository;
		public CustomerService(ICustomerRepository mCustomerRepository) : base(mCustomerRepository)
		{
			customerRepository = mCustomerRepository;
		}
		#endregion

		#region GET INSERT UPDATE DELETE
		public ServiceResult GetCustomersPaging(string searchText, Guid? customerGroupId, int pageSize, int pageNumber)
		{

			return null;
		}
		#endregion

		#region Additional methods
		public override void SetId(Customer customer, Guid id)
		{
			customer.CustomerId = id;
		}
<<<<<<< HEAD
		public override string checkEntityCodeFormat(Customer customer)
		{
			if (!string.IsNullOrEmpty(customer.CustomerCode))
			{
				if (!Regex.IsMatch(customer.CustomerCode, "/^[KH-]+[0-9]+$/"))
				{
					return "CustomerCode format must be like KH-001, KH-9191, ...";
				}
			}
			return null;
		}
		public override void normalizeEntityName(Customer customer)
		{
			string code = customer.CustomerCode;
			code = string.IsNullOrEmpty(code) ? "" : code.Trim(); // Xóa đầu cuối
			Regex trimInner = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
			code = trimInner.Replace(code, " ");
			customer.CustomerCode = code;
		}
=======
>>>>>>> 495147494cb1372ec32234e7ce040c8240242c80
		#endregion
	}
}
