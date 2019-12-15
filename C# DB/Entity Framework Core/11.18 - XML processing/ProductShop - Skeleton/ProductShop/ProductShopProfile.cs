using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(x=>x.Buyer,y=>y.MapFrom(z=>$"{z.Buyer.FirstName} {z.Buyer.LastName}"));
            this.CreateMap<User, GetSoldProductDto>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));

            this.CreateMap<Category, GetCategoriesByProductsCountDto>();

            this.CreateMap<User, GetUsersWithProductsDto>();
                
        }
    }
}
