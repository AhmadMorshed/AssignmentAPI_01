using Store.Services.Services.ProductServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.ProductServices.Dto
{
    public interface IProductService
    {
        Task<ProductDetailsDto> GetProductByIdsAsync(int? ProductId);
        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductAsync();

        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsyns();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();

    }
}
