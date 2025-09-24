using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.Shared
{
    public class DapperService
    {
        public readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T> Query<T>(string query) 
            // <T>, T ny yr mhr kyite tae variable pyy lo ya tl
            //like <ShinnThant>, ..... its a placeholder for data type....
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst = db.Query<T>(query).ToList();
            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.QueryFirstOrDefault<T>(query, param);
            return item;
        }

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }

    }
}
