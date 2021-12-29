using CukcukCore.Entities;
using CukcukCore.Interfaces.BusinessServices;
using System;
using System.Collections.Generic;

namespace CukcukCore.Interfaces.Repositories
{
	/// <summary>
	/// Giao diện giao tiếp với MariaInfrastructure subsystem
	/// </summary>
	public interface IBaseRepository<Entity>
	{
		public List<Entity> GetAll();
		public Entity GetById(Guid EntityId);
		public int Insert(Entity entity);
		public int Update(Guid EntityId, Entity entity);
		public int Delete(Guid EntityId);
		public bool checkDuplicateCode(Guid EntityCode);
	}
}
