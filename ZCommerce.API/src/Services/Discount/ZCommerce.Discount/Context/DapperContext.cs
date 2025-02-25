using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using ZCommerce.Discount.Entities;

namespace ZCommerce.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);


    }
}
