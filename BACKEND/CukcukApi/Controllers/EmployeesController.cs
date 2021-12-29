using System;
using Microsoft.AspNetCore.Mvc;

using CukcukCore.Entities;
using CukcukCore.Interfaces.BusinessServices;
using System.Collections.Generic;

namespace CukcukApi.Controllers
{
	public class EmployeesController : BasesController<Employee>
	{
		private readonly IEmployeeService employeeService;
		public EmployeesController(IEmployeeService mEmployeeService) : base (mEmployeeService)
		{
			employeeService = mEmployeeService;
		}
	}

}
