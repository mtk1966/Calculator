using Calculator.Common.Models;
using Calculator.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Data
{
    public class CalculatorDbContext : IdentityDbContext<AplicationUser>
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {

        }
        public DbSet<UsagePeriod> UsagePeriod { get; set; }
        public DbSet<UsersIpAddress> UsersIpAdress { get; set; } 
    }
}
