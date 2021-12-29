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
	public class EmployeeService : BaseService<Employee>, IEmployeeService
	{
		#region props and constructor
		private IEmployeeRepository employeeRepository;
		public EmployeeService(IEmployeeRepository mEmployeeRepository) : base(mEmployeeRepository)
		{
			employeeRepository = mEmployeeRepository;
		}
		#endregion

		#region Additional methods
		public override void SetId(Employee employee, Guid id)
		{
			employee.EmployeeId = id;
		}
<<<<<<< HEAD
		public override string checkEntityCodeFormat(Employee employee) {
			if (!string.IsNullOrEmpty(employee.EmployeeCode))
			{
				if (!Regex.IsMatch(employee.EmployeeCode, "/^[NV-]+[0-9]+$/"))
				{
					return "EmployeeCode format must be like NV-001, NV-9191, ...";
				}
			}
			return null;
		}
		public override void normalizeEntityName(Employee employee) {
			string code = employee.EmployeeCode;
			code = code.Trim(); // Xóa đầu cuối
			Regex trimInner = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
			code = trimInner.Replace(code, " ");
			employee.EmployeeCode = code;
		}
=======
>>>>>>> 495147494cb1372ec32234e7ce040c8240242c80
		#endregion
	}
}
