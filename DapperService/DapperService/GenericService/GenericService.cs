using Dapper;
using DapperService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperService.GenericService
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected IDbConnection db;
        protected string connectionString;
        protected string tableName;
        protected string primaryKey;
        protected string insertColumns;
        protected string updateColumns;

        public GenericService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolContext"].ConnectionString;
        }

        public async Task<IEnumerable<T>> GetAllEntities()
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.QueryAsync<T>(String.Format("SELECT * FROM {0}", tableName));
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error in Get all entities",ex);
                throw;
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.QuerySingleOrDefaultAsync<T>(String.Format("SELECT * FROM {0} where {1} = @id", tableName, primaryKey), new { id = id });
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error in Get entity by id", ex);
                throw;
            }
        }

        public async Task<T> CreateEntity(T entity)
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.QuerySingleOrDefaultAsync<T>(String.Format("INSERT INTO {0} VALUES {1}; SELECT TOP 1 * FROM {2} ORDER BY {3} DESC", tableName, insertColumns, tableName, primaryKey), entity);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error in create an entity", ex);
                throw;
            }
        }

        public async Task<int> UpdateEntity(T entity)
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.ExecuteAsync(String.Format("UPDATE {0} SET {1} WHERE {2} = @{3}", tableName, updateColumns, primaryKey, primaryKey), entity);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error in update an entity", ex);
                throw;
            }
        }

        public async Task<int> DeleteEntity(int id)
        {
            try
            {
                using (db = new SqlConnection(connectionString)) 
                {
                    return await db.ExecuteAsync(String.Format("DELETE FROM {0} WHERE {1} = @id", tableName, primaryKey), new { id = id });
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error in delete an entity", ex);
                throw;
            }
        }
    }
}
