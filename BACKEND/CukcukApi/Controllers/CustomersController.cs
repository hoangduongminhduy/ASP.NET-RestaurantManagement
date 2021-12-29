using System;
using Microsoft.AspNetCore.Mvc;

using CukcukCore.Entities;
using CukcukCore.Interfaces.BusinessServices;
using System.Collections.Generic;

namespace CukcukApi.Controllers
{
	public class CustomersController : BasesController<Customer>
	{
		private readonly ICustomerService customerService;
		public CustomersController(ICustomerService mCustomerService) :base(mCustomerService)
		{
			customerService = mCustomerService;
		}
	}

}
