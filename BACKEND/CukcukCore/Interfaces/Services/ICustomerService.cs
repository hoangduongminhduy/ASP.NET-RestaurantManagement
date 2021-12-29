using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CukcukCore.Entities;
namespace CukcukCore.Interfaces.BusinessServices
{
	public interface ICustomerService : IBaseService<Customer>
	{
		public ServiceResult GetCustomersPaging(string searchText, Guid? customerGroupId, int pageSize, int pageNumber);
	}
}
