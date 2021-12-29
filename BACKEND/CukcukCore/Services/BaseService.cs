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
	public class BaseService<Entity> : IBaseService<Entity>
	{
		#region props and constructor
		protected IBaseRepository<Entity> baseRepository;
		protected ServiceResult result;
		protected string tableName;
		public BaseService(IBaseRepository<Entity> mBaseRepository) //tiêm
		{
			baseRepository = mBaseRepository;
			result = new ServiceResult();
			tableName = typeof(Entity).Name;
		}
		#endregion

		#region GET INSERT UPDATE DELETE
		/// <summary>
		/// process business CRUD then call IEntityRepository operating with DB
		/// </summary>
		public ServiceResult GetAll()
		{
			result.setField(true, "", baseRepository.GetAll());
			return result;
		}

		public ServiceResult GetById(Guid EntityId)
		{
			result.setField(true, "", baseRepository.GetById(EntityId));
			return result;
		}
		public ServiceResult Insert(Entity entity)
		{
			// 1. Validate data: 
			string errorInfo = ValidateData(entity);
			if (errorInfo != null)
			{
				result.setField(false, errorInfo, null);
				return result;
			}
			// 2. Assign new id to entity
			SetId(entity, new Guid());
			// 3. Insert new record to database
			if (baseRepository.Insert(entity) > 0)
			{
				result.setField(true, "", entity);
				return result;
			}
			throw new NotImplementedException();
		}

		public ServiceResult Update(Guid EntityId, Entity entity)
		{
			// 1. Validate data: 
			string errorInfo = ValidateData(entity);
			if (errorInfo != null)
			{
				result.setField(false, errorInfo, null);
				return result;
			}
			// 2. Assign id to entity
			SetId(entity, EntityId);
			// 3. Update a record to database
			if (baseRepository.Update(EntityId, entity) > 0)
			{
				result.setField(true, "", entity);
				return result;
			}
			throw new NotImplementedException();
		}

		public ServiceResult Delete(Guid EntityId)
		{
			if (baseRepository.Delete(EntityId) > 0)
			{
				//1. Check if there is EntityId in database
				if(baseRepository.GetById(EntityId)==null)
				{
					result.setField(false, "EntityId not found", null);
					return result;
				}

				//2. Delete record in database
				baseRepository.Delete(EntityId);
				result.setField(true, "", EntityId);
				return result;
				throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}
		#endregion

		#region Additional methods
		public virtual string ValidateData(Entity entity)
		{
			// 0. Normalize entity name field
			normalizeEntityName(entity);
			// 1. Check required fields
			var requiredFields = entity.GetType().GetProperties();
			foreach (var prop in requiredFields)
			{
				var propName = prop.Name;
				var propValue = prop.GetValue(entity);
				var propType = prop.PropertyType;

				var requiredAttributes = prop.GetCustomAttributes(typeof(RequiredField), false);
				if (requiredAttributes != null)
				{
					if (propType == typeof(string) && (string.IsNullOrEmpty(propValue.ToString())))
					{
						return (requiredAttributes[0] as RequiredField).ErrorMsg;
					}
				}
			}
			// 2a. Is EntityCode duplicated?
			var code = entity.GetType().GetProperty($"{tableName}Code").GetValue(entity);
			if (code != null) { 			
				if(baseRepository.checkDuplicateCode(new Guid(code.ToString())))
				return "Duplicate code!!";
			}
<<<<<<< HEAD
			// 3a. Check entity code format
			string errorMsg = checkEntityCodeFormat(entity);
			if ( ! string.IsNullOrEmpty(errorMsg)) return errorMsg;
			// 3b. Check entity email format if exist
=======
			// 3a. Is Email format correct?
>>>>>>> 495147494cb1372ec32234e7ce040c8240242c80
			var email = entity.GetType().GetProperty("Email").GetValue(entity);
			if(email != null) {
				var emailString = email.ToString();
				if (!string.IsNullOrEmpty(emailString)) { 
					if (!Regex.IsMatch(emailString, "/^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_-]+.[a-zA-Z0-9_.-]+$/")) { 
						return "Email format is wrong";
					}
				}
			}
			// Pass validation
			return null;
		}

		public virtual void SetId(Entity entity, Guid id) {}
<<<<<<< HEAD
		public virtual string checkEntityCodeFormat(Entity entity) { return null; }
		public virtual void normalizeEntityName(Entity entity) { }
=======
>>>>>>> 495147494cb1372ec32234e7ce040c8240242c80
		#endregion
	}
}
