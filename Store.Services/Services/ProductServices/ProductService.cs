using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Services.ProductServices.Dto;
using ProductEntity = Store.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Store.Services.Services.ProductServices.Dto
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsyns()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTraAsync();
            //IReadOnlyList<BrandTypeDetailsDto> mappedBrands = brands.Select(x => new BrandTypeDetailsDto 
            //    {
            //    Id= x.Id,
            //    Name= x.Name,
            //    CreateAt=x.CreateAt
            //}).ToList();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
            return mappedBrands;

        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductAsync()
        {
            var products=await _unitOfWork.Repository<ProductEntity, int>().GetAllAsNoTraAsync();
            //var mappedProduts = products.Select(x => new ProductDetailsDto
            //{
            //    Id= x.Id,
            //    Name= x.Name,
            //    Description= x.Description,
            //    PictureUrl= x.PictureUrl,
            //    Price= x.Price,
            //    CreateAt= x.CreateAt,
            //    BrandName=x.Brand.Name,
            //    TypeName=x.Type.Name
                

            //}
            //).ToList();
            var mappedProduts=_mapper.Map<IReadOnlyList< ProductDetailsDto >>(products);

            return mappedProduts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTraAsync();
            
            //IReadOnlyList<BrandTypeDetailsDto> mappedTypes = types.Select(x => new BrandTypeDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreateAt = x.CreateAt
            //}).ToList();
            var mappedTypes= _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return mappedTypes;

        }

        public async Task<ProductDetailsDto> GetProductByIdsAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id is Null");
            var product = await _unitOfWork.Repository<ProductEntity, int>().GetByIdAsync(productId.Value);
            if (product is null)
                throw new Exception("Product Not Found");

            var mappedProduct=_mapper.Map<ProductDetailsDto>(product);
            //= new ProductDetailsDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    CreateAt = product.CreateAt,
            //    BrandName = product.Brand.Name,
            //    TypeName = product.Type.Name

            //};
            return mappedProduct;

        }
    }
}
