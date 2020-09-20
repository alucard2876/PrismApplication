using Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace DomainAccess
{
    public class Context
    {
        private readonly string _productsFile = "products.xml";
        private readonly string _categoriesFile = "categories.xml";

        public List<Product> Products { get;  set; } 
        public List<Category> Categories { get;  set; } 

        public Context()
        {
            Products = OpenProducts().ToList();
            Categories = OpenCategorys().ToList();
            Seed();
        }

        private void Seed()
        {
            if(!Categories.Any())
            {
                Categories.Add(new Category { Id = 0, CategoryTitle = "Whiskey" });
                Categories.Add(new Category { Id = 1, CategoryTitle = "Beer" });
                Categories.Add(new Category { Id = 2, CategoryTitle = "Vodka" });
                SaveCategories();
            }
            if(!Products.Any())
            {
                Products.Add(new Product(0,"Jameson","Great Irish whiskey",600,0,Categories.ElementAt(0)));
                Products.Add(new Product(1,"jim Beam","Nice bourbon",700,0,Categories.ElementAt(0)));
                Products.Add(new Product(2,"Balentise","American whiskey",400,0,Categories.ElementAt(0)));
                Products.Add(new Product(3, "jim Beam", "Nice bourbon", 700, 0, Categories.ElementAt(0)));
                Products.Add(new Product(4, "Guiness", "Great beer", 35, 1, Categories.ElementAt(1)));
                Products.Add(new Product(5, "Corona", "Nice with lime", 25, 1, Categories.ElementAt(1)));
                Products.Add(new Product(6, "Absolute", "Absolutley vodka", 666, 2, Categories.ElementAt(2)));
                SaveProducts();
            }
            
            
        }
        public void AddProductRange(IEnumerable<Product> products)
        {
            Products = products.ToList();
        }
        public void SaveCategories()
        {
            var serializator = new XmlSerializer(typeof(List<Category>));
            using (var fs = new FileStream(_categoriesFile,FileMode.Create))
            {
                serializator.Serialize(fs, Categories);
                
            }
            Categories = OpenCategorys().ToList();
        }       
        public void SaveProducts()
        {
            var serializator = new XmlSerializer(typeof(List<Product>));
            using (var fs = new FileStream(_productsFile,FileMode.Create))
            {
                serializator.Serialize(fs, Products);
                
            }
            Products = OpenProducts().ToList();
        }
        private IEnumerable<Category> OpenCategorys()
        {
            var serializator = new XmlSerializer(typeof(List<Category>));
            using (var fs = new FileStream(_categoriesFile, FileMode.OpenOrCreate))
            {
                var data = serializator.Deserialize(fs);
                return data == null ? new List<Category>() : data as IEnumerable<Category>;
            }
        }
        public IEnumerable<Product> OpenProducts()
        {
            var serializator = new XmlSerializer(typeof(List<Product>));
            using (var fs = new FileStream(_productsFile, FileMode.Open))
            {
                if (fs == null) return new List<Product>();
                var data = serializator.Deserialize(fs);
                return data == null ? new List<Product>() : data as IEnumerable<Product>;
            }
        }
    }
}
