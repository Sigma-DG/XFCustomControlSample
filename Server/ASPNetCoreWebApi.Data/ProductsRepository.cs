using Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreWebApi.Data
{
    public class ProductsRepository
    {
        #region Singleton
        private static object locker = new object();
        private ProductsRepository()
        {
            #region Filling up mock
            MockProducts = new List<Product>();
            MockGroups = new List<ProductGroup>();
            SeedData();
            #endregion
        }
        private static ProductsRepository _current = null;
        public static ProductsRepository Current
        {
            get {
                lock (locker)
                {
                    if (_current == null)
                        _current = new ProductsRepository();
                }
                return _current;
            }
        }
        #endregion

        #region Public Instance Methods and Properties

        public List<ProductGroup> MockGroups { get; private set; }
        public List<Product> MockProducts { get; private set; }

        public ResultPack<Product> AddProduct(Product newProduct)
        {
            if (MockProducts.Contains(newProduct)) return new ResultPack<Product> { IsSucceeded = false, Message = "Product already exists" };

            if(newProduct.Id != 0 && MockProducts.Any(x => x.Id == newProduct.Id)) return new ResultPack<Product> { IsSucceeded = false, Message = "Product Id is duplicate" };

            if (newProduct.Id == 0) newProduct.Id = MockProducts.Max(x => x.Id) + 1;

            MockProducts.Add(newProduct);

            return new ResultPack<Product> { IsSucceeded = true, ReturnParam = newProduct };
        }
        #endregion

        #region Private Methods
        private void SeedData()
        {
            var rand = new Random();

            MockGroups.Add(new ProductGroup
            {
                Id = 1,
                DisplayText = $"Main Group 1",
                Descriptions = "Few group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions"
            });
            MockGroups.Add(new ProductGroup
            {
                Id = 2,
                DisplayText = $"Main Group 2",
                Descriptions = "Few group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions"
            });
            MockGroups.Add(new ProductGroup
            {
                Id = 3,
                DisplayText = $"Main Group 3",
                Descriptions = "Few group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions"
            });

            for (int j = 0; j < 7; j++)
            {
                var parent = MockGroups.First(x => x.Id == rand.Next(1, 3));
                if (parent == null) continue;

                if (parent.Children == null) parent.Children = new List<Item>();

                parent.Children.Add(new ProductGroup {
                    Id = 4+j,
                    Parent = parent,
                    DisplayText = $"Sub Group {4+j}",
                    Descriptions = "Few group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions and few more group descriptions"
                });
            }
            for (int i = 0; i < 20; i++)
            {
                MockProducts.Add(new Product
                {
                    Id = i,
                    DisplayText = $"Product {i}",
                    Price = (double)rand.Next(100, 1500),
                    Descriptions = "Some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions and some descriptions"
                });
            }
        } 
        #endregion
    }
}
