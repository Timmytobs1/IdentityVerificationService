using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IdentityVerificationService.EntityFrameworkCore
{
    public static class IdentityVerificationServiceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityVerificationServiceDbContext> builder, string connectionString)
        {
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.UseMySql(connectionString, serverVersion);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityVerificationServiceDbContext> builder, DbConnection connection)
        {
            var serverVersion = ServerVersion.AutoDetect(connection.ConnectionString);
            builder.UseMySql(connection, serverVersion);
        }
    }




}