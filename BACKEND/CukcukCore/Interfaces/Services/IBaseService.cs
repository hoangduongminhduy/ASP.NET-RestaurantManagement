using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CukcukCore.Entities;
namespace CukcukCore.Interfaces.BusinessServices
{
	/// <summary>
	/// Interface liệt kê các service phục vụ cho Api
	/// CreatedBy; hnminh (10/11/2021)
	/// </summary>
	public interface IBaseService<Entity>
	{
		public ServiceResult GetAll();
		public ServiceResult GetById(Guid EntityId);
		public ServiceResult Insert(Entity entity);
		public ServiceResult Update(Guid EntityId, Entity entity);
		public ServiceResult Delete(Guid EntityId);

		#region Additional methods
		/// <check>
		/// not null props: CustomerCode, FullName
		/// duplicate Customercode 
		/// format of some props (such as Email)
		/// </check>
		/// <returns>null if pass validation, otherwise return error information string</returns>
		public string ValidateData(Entity entity);
		public void SetId(Entity entity, Guid id);
<<<<<<< HEAD
		/// <summary>
		/// Check Code field format
		/// </summary>
		/// <returns>null if entity code is right format, otherwise notify users right Code format</returns>
		public string checkEntityCodeFormat(Entity entity);
		public void normalizeEntityName(Entity entity);
=======
>>>>>>> 495147494cb1372ec32234e7ce040c8240242c80
		#endregion
	}
}
