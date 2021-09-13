using Dapper;
using PruebaTecnicaDeloimBackend.Common.Dtos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Common.Dapper
{
    public class DapperHelper : IDapperHelper
    {
        public async Task<IEnumerable<T>> ExecuteQuerySelect<T>(string cnx, string query, object filter = null)
        {
            await using var conn = new SqlConnection(cnx);
            conn.Open();
            var result = filter == null
                ? await conn.QueryAsync<T>(query).ConfigureAwait(false)
                : await conn.QueryAsync<T>(query, filter).ConfigureAwait(false);
            conn.Close();
            conn.Dispose();
            return result;
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedure<T>(string cnx, string storeProcedure, object filter = null) where T : class
        {
            await using var conn = new SqlConnection(cnx);
            conn.Open();
            var result = filter == null
                ? await conn.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)
                : await conn.QueryAsync<T>(storeProcedure, filter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            conn.Close();
            conn.Dispose();
            return result;
        }

        public int ExecuteQueryScalar(string cnx, string query, object filter = null)
        {
            using var conn = new SqlConnection(cnx);
            conn.Open();
            var result = conn.ExecuteScalar<int>(query, filter);
            conn.Close();
            conn.Dispose();
            return result;
        }

        public int ExecuteStoreProcedureScalar(string cnx, string storeProcedure, object filter = null)
        {
            using var conn = new SqlConnection(cnx);
            conn.Open();
            var result = filter == null
                ? conn.ExecuteScalar<int>(storeProcedure, commandType: CommandType.StoredProcedure)
                : conn.ExecuteScalar<int>(storeProcedure, filter, commandType: CommandType.StoredProcedure);
            conn.Close();
            conn.Dispose();
            return result;
        }

        public async Task<QueryMultipleResponse<T>> ExecuteStoreProcedureQueryMultiple<T>(string cnx, string storeProcedure, object filter = null) where T : class
        {
            var queryMultipleResponse = new QueryMultipleResponse<T>();
            await using var conn = new SqlConnection(cnx);
            conn.Open();

            var result = filter == null
                ? await conn.QueryMultipleAsync(storeProcedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)
                : await conn.QueryMultipleAsync(storeProcedure, filter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

            queryMultipleResponse.Results = result.Read<T>();
            queryMultipleResponse.TotalRecords = result.Read<long>().FirstOrDefault();

            conn.Close();
            conn.Dispose();

            return queryMultipleResponse;
        }
    }
}
