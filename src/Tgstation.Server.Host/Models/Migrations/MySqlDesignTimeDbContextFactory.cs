﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Tgstation.Server.Host.Security;

namespace Tgstation.Server.Host.Models.Migrations
{
	/// <inheritdoc />
	sealed class MySqlDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MySqlDatabaseContext>
	{
		/// <inheritdoc />
		public MySqlDatabaseContext CreateDbContext(string[] args) => new MySqlDatabaseContext(new DbContextOptions<MySqlDatabaseContext>(), DesignTimeDbContextFactoryHelpers.GetDbContextOptions(), new DatabaseSeeder(new CryptographySuite(new PasswordHasher<User>())), new LoggerFactory().CreateLogger<MySqlDatabaseContext>());
	}
}
