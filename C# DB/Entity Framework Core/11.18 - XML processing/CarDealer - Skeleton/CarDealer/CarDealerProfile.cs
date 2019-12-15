using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Dtos.Export;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDto, Supplier>();
            this.CreateMap<PartDto, Part>();
            this.CreateMap<CustomerDto, Customer>();
            this.CreateMap<SaleDto, Sale>();

            this.CreateMap<Car, GetCarsWithDistanceDto>();
            this.CreateMap<Car, GetCarsFromMakeBmwDto>();
            this.CreateMap<Supplier, GetLocalSuppliersDto>();
        }
    }
}
