using Microsoft.EntityFrameworkCore;
using RetailStoreAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRetailStoreDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
