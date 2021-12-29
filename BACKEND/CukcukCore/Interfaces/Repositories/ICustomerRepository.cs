using CukcukCore.Entities;
using CukcukCore.Interfaces.BusinessServices;
using System;
using System.Collections.Generic;

namespace CukcukCore.Interfaces.Repositories
{
	public interface ICustomerRepository : IBaseRepository<Customer>
	{
		public object GetCustomersPaging(string searchText, Guid? customerGroupId, int pageSize, int pageNumber);
	}
}
