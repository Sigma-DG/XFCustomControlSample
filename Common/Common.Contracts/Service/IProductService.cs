using Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Contracts.Service
{
    public interface IProductService
    {
        Task<PagedReponse<Data.Product>> GetProductsInGroup(Guid groupId, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<PagedReponse<ProductGroup>> GetGroups(CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<PagedReponse<ProductGroup>> Search(string keyword, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<ResultPack<Product>> GetProduct(Guid productId, CancellationToken cancellationToken);
    }
}
