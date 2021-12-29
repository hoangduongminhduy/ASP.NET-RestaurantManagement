using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;

using CukcukCore.Interfaces.Repositories;
using CukcukCore.Entities;

namespace MariaInfrastructure.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(IConfiguration _config) : base(_config)
		{ }
	}
}
