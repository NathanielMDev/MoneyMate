﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.Entities;

namespace MoneyMate.Data.DataEntities;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Budget> Budgets { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public DbSet<PaymentMethod> PaymentMethods { get; set; }
}
