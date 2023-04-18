using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazinORM.Data.Model;
using System.Data.Entity;

namespace MagazinORM.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext():base("name=ProductContext")
        {
        }
        public DbSet<Product> Products { get; set;}
    }
}
