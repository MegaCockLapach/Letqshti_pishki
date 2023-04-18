using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazinORM.Data;
using MagazinORM.Data.Model;

namespace MagazinORM.Business
{
    public class ProductCommands
    {
        private static ProductContext context { get; set; }
        public static List<Product> GetAll()
        {
            using(context=new ProductContext())
            {
                return context.Products.ToList();
            }
        }
        public static Product Get(int id)
        {
            using(context=new ProductContext())
            {
                return context.Products.Find(id);
            }
        }
        public static void Add(Product product)
        {
            using (context=new ProductContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public static void Update(Product product)
        {
            using (context=new ProductContext())
            {
                var item = context.Products.Find(product.ID);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(product);
                    context.SaveChanges();
                }
            }
        }
        public static void Delete(int id)
        {
            using (context=new ProductContext())
            {
                var product = context.Products.Find(id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
