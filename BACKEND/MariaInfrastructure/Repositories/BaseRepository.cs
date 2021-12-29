using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySqlConnector;
using CukcukCore.Interfaces.Repositories;

namespace MariaInfrastructure.Repositories
{
	public class BaseRepository<Entity> : IBaseRepository<Entity>
	{
		#region props and constructor
		protected readonly string connString;
		protected readonly MySqlConnection conn;
		protected readonly string tableName;
		public BaseRepository(IConfiguration config)
		{
			tableName = typeof(Entity).Name;
			// Create connection:
			connString = config.GetConnectionString("CukcukConnection");
			conn = new MySqlConnection(connString);
		}
		#endregion

		public List<Entity> GetAll()
		{
			var sqlCmd = $"SELECT * FROM {tableName}";
			return conn.Query<Entity>(sqlCmd).ToList();
		}
		public Entity GetById(Guid EntityId)
		{
			/**
			* Lay du lieu tu DB
			* QueryFirstOrDefault: Lay first record, neu k co thi tra ve NULL
			* Ky thuat: Dung dparams de tranh injection. VD: truyen cau sql delete vao tham so :)
			*/
			string sqlCmd = $"SELECT * FROM {tableName} WHERE {tableName}Id = @{tableName}Id";
			var dparams = new DynamicParameters();
			dparams.Add($"@{tableName}Id", EntityId.ToString());
			return conn.QueryFirstOrDefault<Entity>(sqlCmd, dparams);
		}
		

		public int Insert(Entity entity)
		{
			var dparams = new DynamicParameters();
			var sqlCols = "";
			var sqlDParams = "";
			var props = entity.GetType().GetProperties();
			foreach (var prop in props)
			{
				var propName = prop.Name;
				sqlCols += $"{propName},";
				sqlDParams += $"@{propName},";

				var propValue = prop.GetValue(entity);
				dparams.Add($"@{propName}", propValue);
			}
			sqlCols = sqlCols.Substring(0, sqlCols.Length - 1);
			sqlDParams = sqlDParams.Substring(0, sqlDParams.Length - 1);
			var sqlCmd = $"INSERT INTO {tableName}({sqlCols}) VALUES({sqlDParams})";
			return conn.Execute(sqlCmd, dparams);
		}

		public int Update(Guid EntityId, Entity entity)
		{
			var dparams = new DynamicParameters();
			var col_param = "";
			var props = entity.GetType().GetProperties();
			foreach (var prop in props)
			{
				var propName = prop.Name;
				col_param += $"{propName}=@{propName},";

				var propValue = prop.GetValue(entity);
				dparams.Add($"@{propName},", propValue);
			}
			col_param = col_param.Substring(0, col_param.Length - 1);
			var sqlCmd = $"UPDATE {tableName} SET {col_param} WHERE {tableName}Id = @{tableName}Id";
			return conn.Execute(sqlCmd, dparams);
		}

		public int Delete(Guid EntityId)
		{
			string sqlCmd = $"DELETE FROM {tableName} WHERE {tableName}Id = @{tableName}Id";
			DynamicParameters dparams = new();
			dparams.Add($"@{tableName}Id", EntityId);
			return conn.Execute(sqlCmd, dparams);
		}


		#region Additional methods
		public virtual bool checkDuplicateCode(Guid EntityCode)
		{
			var sqlCmd = $"SELECT {tableName}Code from {tableName} WHERE {tableName}Code = '@{tableName}Code'";
			var dparams = new DynamicParameters();
			dparams.Add($"@{tableName}Code", EntityCode);
			var duplicateCode = conn.QueryFirstOrDefault<string>(sqlCmd, dparams);
			return (duplicateCode != null);
		}
		#endregion
	}
}
