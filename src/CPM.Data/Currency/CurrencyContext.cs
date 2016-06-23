using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Currency
{
    public interface ICurrencyContext :IDbContextBase
    {
        DbSet<CurrencyEntity> Currency { get; set; }
    }

    public class CurrencyContext : DbContextBase, ICurrencyContext
    {
        public CurrencyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<CurrencyEntity> Currency {get;set;}
    }
}
