using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Data.Interfeaces;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Data
{
    /// <summary>
    /// SQL Dapper Repository Layer
    /// </summary>
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;
        private readonly int _commandTimeout;

        /// <summary>
        /// SMTP Model is nullable for tesing purposes
        /// </summary>
        /// <param name="ConnectionString">Valid SQL Conneciton String</param>
        /// <param name="SmtpModel">Represents the SMTP Settings</param>
        public DapperRepository(string ConnectionString, int CommandTimeout)
        {
            _connectionString = ConnectionString;
            _commandTimeout = CommandTimeout;
        }

        /// <summary>
        /// Selects a single row from database given a condition
        /// </summary>
        /// <typeparam name="T">Model type to returned</typeparam>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns one record of type T</returns>
        public async Task<T> QuerySingle<T>(string ProcedureName, List<ParameterModel> ParameterList)
        {
            DynamicParameters parameters = ParameterManager.CreateParameters(ParameterList);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(ProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw e;
                }
            }

        }

        /// <summary>
        /// Returns multiple row from database given a condition
        /// </summary>
        /// <typeparam name="T">Model type to returned</typeparam>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns a list of type T</returns>
        public async Task<IEnumerable<T>> QueryData<T>(string ProcedureName)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.QueryAsync<T>(ProcedureName,
                        null,
                        commandTimeout: _commandTimeout,
                        commandType: CommandType.StoredProcedure);
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw e;
                }
            }
        }

        /// <summary>
        /// Common Execute Proc with results
        /// </summary>
        /// <param name="ProcedureName">SQL Procedure Name</param>
        /// <param name="Parameters">DyanmicParameters</param>
        /// <returns>Returns results from proc as int</returns>
        public async Task<T> ExecuteProc<T>(string ProcedureName, List<ParameterModel> ParameterList)
        {
            DynamicParameters parameters = ParameterManager.CreateParameters(ParameterList);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.ExecuteScalarAsync<T>(ProcedureName,
                        parameters,
                        commandTimeout: _commandTimeout,
                        commandType: CommandType.StoredProcedure);
                }
                catch (System.Exception e)
                {
                    //Throw Exception
                    throw e;
                }

            }

        }
    }
}
