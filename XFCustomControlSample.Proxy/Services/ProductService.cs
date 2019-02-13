using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Common.ServiceContracts;

namespace XFCustomControlSample.Proxy.Services
{
    public class ProductService : IProductService
    {
        #region Mock Data
        private List<ProductGroup> groups = new List<ProductGroup>();
        private List<Product> products = new List<Product>();
        #endregion

        public ProductService()
        {
            #region Filling Mock data
            products.Add(new Product
            {
                Id = 1,
                DisplayText = "P1",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 13.99
            });
            products.Add(new Product
            {
                Id = 2,
                DisplayText = "P2",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 24.99
            });
            products.Add(new Product
            {
                Id = 3,
                DisplayText = "P3",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 8.99
            });
            products.Add(new Product
            {
                Id = 4,
                DisplayText = "P4",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 34.99
            });
            products.Add(new Product
            {
                Id = 5,
                DisplayText = "P5",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 20.99
            });
            products.Add(new Product
            {
                Id = 6,
                DisplayText = "P6",
                Descriptions = "Some texts some texts some texts some texts some texts\nsome texts some texts some texts\nsome texts some texts...",
                Price = 49.99
            });


            groups.Add(new ProductGroup
            {
                Id = 1,
                DisplayText = "Group 1",
                Descriptions = "Few group descriptions and lorem ipsum texts...",
            });
            groups.Add(new ProductGroup
            {
                Id = 2,
                DisplayText = "Group 2",
                Children = new List<Item> {
                    new ProductGroup
                    {
                        Id = 21,
                        DisplayText = "Sub Group 2-1",
                        Descriptions = "Few group descriptions and lorem ipsum texts...",
                        Children = new List<Item>{
                            products[0],
                            products[3],
                            products[2]
                        }
                    },
                    new ProductGroup
                    {
                        Id = 22,
                        DisplayText = "Sub Group 2-2",
                        Descriptions = "Few group descriptions and lorem ipsum texts...",
                        Children = new List<Item>{
                            products[0],
                            products[1],
                            products[4],
                            products[5],
                        }
                    },
                    new ProductGroup
                    {
                        Id = 23,
                        DisplayText = "Sub Group 2-3",
                        Descriptions = "Few group descriptions and lorem ipsum texts...",
                    }
                }
            });
            groups.Add(new ProductGroup
            {
                Id = 3,
                DisplayText = "Group 3",
                Descriptions = "Few group descriptions and lorem ipsum texts...",
                Children = new List<Item>{
                    products[0],
                    products[2],
                    products[3],
                    products[1],
                }
            });
            #endregion
        }

        public async Task<PagedReponse<ProductGroup>> GetGroups(CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            await Task.Delay(1000);

            var res = new PagedReponse<ProductGroup>
            {
                TotalServerItems = groups.Count,
                IsSucceeded = true,
            };

            if (pageSize.HasValue && pageIndex.HasValue)
                res.ReturnParam = groups.Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value).ToList();
            else res.ReturnParam = groups;

            return res;
        }

        public async Task<ResultPack<Product>> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            return new ResultPack<Product>
            {
                IsSucceeded = true,
                ReturnParam = products.FirstOrDefault(x=>x.ProductId.Equals(productId))
            };
        }

        public async Task<PagedReponse<Product>> GetProductsInGroup(Guid groupId, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            var group = groups.FirstOrDefault(x => x.GroupId.Equals(groupId));

            if(group == null)
                return new PagedReponse<Product>
                {
                    IsSucceeded = false
                };

            return new PagedReponse<Product> {

            };
        }

        public async Task<PagedReponse<ProductGroup>> Search(string keyword, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }
    }
}
