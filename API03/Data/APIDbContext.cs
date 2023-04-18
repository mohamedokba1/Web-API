﻿using API03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API03.Data
{
    public class APIDbContext : IdentityDbContext<ApplicationUser>
    {
        public APIDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Claims");
        }
    }
}
