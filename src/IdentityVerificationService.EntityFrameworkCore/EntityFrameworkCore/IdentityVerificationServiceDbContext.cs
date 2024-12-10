﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IdentityVerificationService.Authorization.Roles;
using IdentityVerificationService.Authorization.Users;
using IdentityVerificationService.MultiTenancy;

namespace IdentityVerificationService.EntityFrameworkCore
{
    public class IdentityVerificationServiceDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityVerificationServiceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public IdentityVerificationServiceDbContext(DbContextOptions<IdentityVerificationServiceDbContext> options)
            : base(options)
        {
        }
    }
}
