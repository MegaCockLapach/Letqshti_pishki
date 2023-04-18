using MagazinORM.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MagazinORM.Data.Model;

namespace MagazinORM.Presentation
{
    public class Display
    {
        private void ConsoleOptions()
        {
            Console.WriteLine(new string('-',40));
            Console.WriteLine(new string(' ',16)+"Options"+ new string(' ', 16));
            Console.WriteLine(new string('-',40));
            Console.WriteLine("1. Show all products.");
            Console.WriteLine("2. Show one product by certain ID.");
            Console.WriteLine("3. Add new product.");
            Console.WriteLine("4. Update product by certain ID.");
            Console.WriteLine("5. Delete product by certain ID.");
            Console.WriteLine("6. Exit.");
        }
        public void ConsoleApplication()
        {
            int operation = -1;
            do
            {
                ConsoleOptions();
                Console.WriteLine(new string(' ',40));
                Console.WriteLine("Choose an option from above by typing a number here:");
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ShowAll(); break;
                    case 2: ShowOneProduct(); break;
                    case 3: Add(); break;
                    case 4: Update(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            } 
            while (operation!=6);
        }
        private void ShowAll()
        {
            List<Product> products = ProductCommands.GetAll();
            foreach(var item in products)
            {
                Console.WriteLine("ID:"+item.ID);
                Console.WriteLine("Name:"+item.ID);
                Console.WriteLine("Price"+item.Price);
                Console.WriteLine("Amount of the product:"+item.Stock);
            }
        }
        private void ShowOneProduct()
        {
            Console.WriteLine("Type the certain ID:");
            int id = int.Parse(Console.ReadLine());
            Product product = ProductCommands.Get(id);
            if (product!=null)
            {
                Console.WriteLine("Name:"+product.Name);
                Console.WriteLine("Price:" + product.Price);
                Console.WriteLine("Amount of the product:" + product.Stock);
            }
        }
        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Enter product's ID:");
            product.ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product's name:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter product's price:");
            product.Price=decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount of the product:");
            product.Stock=int.Parse(Console.ReadLine());
            ProductCommands.Add(product);
        }
        private void Update()
        {
            Console.WriteLine("Enter the certain ID:");
            int id=int.Parse(Console.ReadLine());
            Product product = ProductCommands.Get(id);
            if (product != null)
            {
                Product updatedProduct = new Product();
                updatedProduct.ID = id;
                Console.WriteLine("Enter new product name:");
                updatedProduct.Name = Console.ReadLine();
                Console.WriteLine("Enter new product price:");
                updatedProduct.Price=decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter new amount of the product:");
                updatedProduct.Stock=int.Parse(Console.ReadLine());
                ProductCommands.Update(updatedProduct);
            }
            else Console.WriteLine("Product does not exist.");
        }
        private void Delete()
        {
            Console.WriteLine("Enter the certain ID:");
            int id=int.Parse(Console.ReadLine());
            ProductCommands.Delete(id);
            Console.WriteLine("Action was completed succesfully.");
        }
        public Display()
        {
            ConsoleApplication();
        }
    }
}
