using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Common.ServiceContracts;

namespace XFCustomControlSample.Proxy.Services
{
    public class ProductService : IProductService
    {
        public async Task<PagedReponse<ProductGroup>> GetGroups(CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedReponse<Product>> GetProductsInGroup(Guid groupId, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedReponse<ProductGroup>> Search(string keyword, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }
    }
}
