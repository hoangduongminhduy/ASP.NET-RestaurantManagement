using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;

using CukcukCore.Interfaces.Repositories;
using CukcukCore.Entities;

namespace MariaInfrastructure.Repositories
{
	public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(IConfiguration _config) : base(_config)
		{}
		public object GetCustomersPaging(string searchText, Guid? customerGroupId, int pageSize, int pageNumber)
		{
			DynamicParameters dparams = new();
			var numRecords = 0;
			var numPages = 0;
			dparams.Add("@m_FullName", searchText);
			dparams.Add("@m_CustomerCode", searchText);
			dparams.Add("@m_CustomerGroupId", customerGroupId);
			dparams.Add("@m_pageSize", pageSize);
			dparams.Add("@m_pageNumber", pageNumber);
			dparams.Add("@m_numRecords", direction: System.Data.ParameterDirection.Output);
			dparams.Add("@m_numRecords", direction: System.Data.ParameterDirection.Output);
			var customers = conn.Query<Customer>("Proc_GetCustomersPaging", dparams, commandType: System.Data.CommandType.StoredProcedure).ToList();

			numRecords = dparams.Get<int>("@m_numRecords");
			numRecords = dparams.Get<int>("@m_numPages");
			return new
			{
				customers = customers,
				numRecords = numRecords,
				numPages = numPages
			};
		}
	}
}
