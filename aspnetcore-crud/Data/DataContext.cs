﻿using aspnetcore_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_crud.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, DateCreated = new DateTime(2003, 12, 15), AccountType = "Domestic", OwnerId = 1},
                new Account { Id = 1, DateCreated = new DateTime(1996, 2, 15), AccountType = "Domestic", OwnerId = 2 },
                new Account { Id = 1, DateCreated = new DateTime(1999, 5, 4), AccountType = "Domestic", OwnerId = 3 },
                new Account { Id = 1, DateCreated = new DateTime(1999, 12, 21), AccountType = "Savings", OwnerId = 3 },
                new Account { Id = 1, DateCreated = new DateTime(2010, 5, 28), AccountType = "Domestic", OwnerId = 4 },
                new Account { Id = 1, DateCreated = new DateTime(1999, 5, 12), AccountType = "Foreign", OwnerId = 3 },
                new Account { Id = 1, DateCreated = new DateTime(1996, 2, 16), AccountType = "Foreign", OwnerId = 2 },
                new Account { Id = 1, DateCreated = new DateTime(2010, 6, 20), AccountType = "Foreign", OwnerId = 4 }
            );

            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Name = "Nguyễn Văn A", DateOfBirth = new DateTime(1978, 3, 21), Address = "123 Phan Châu Trinh"},
                new Owner { Id = 2, Name = "Trần Văn B", DateOfBirth = new DateTime(1985, 7, 12), Address = "456 Phan Bội Châu"},
                new Owner { Id = 3, Name = "Nguyễn Thị C", DateOfBirth = new DateTime(1970, 11, 2), Address = "789 Ngô Quyền" },
                new Owner { Id = 4, Name = "Nguyễn Thị D", DateOfBirth = new DateTime(1992, 9, 15), Address = "1010 Nguyễn Trãi" }
            );

        }
    }
}
