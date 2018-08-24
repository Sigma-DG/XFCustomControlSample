using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;

namespace XFCustomControlSample.Common.ServiceContracts
{
    public interface IProductService
    {
        Task<PagedReponse<Product>> GetProductsInGroup(Guid groupId, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<PagedReponse<ProductGroup>> GetGroups(CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<PagedReponse<ProductGroup>> Search(string keyword, CancellationToken cancellationToken, int? pageSize = null, int? pageIndex = null);

        Task<Product> GetProduct(Guid productId, CancellationToken cancellationToken);
    }
}
