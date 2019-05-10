using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //importing
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //exporting
            this.CreateMap<Product, ExportProductInRangeDTO>();
            this.CreateMap<User, ExportUsersSoldProductDTO>();
            this.CreateMap<Product, ExportSoldProductDTO>();
            this.CreateMap<Category, ExportCategoryDTO>();
            this.CreateMap<User, ExportUserAgeSoldProductDTO>();
            this.CreateMap<Product, ExportSoldProductsCollectionDTO>();
        }
    }
}
