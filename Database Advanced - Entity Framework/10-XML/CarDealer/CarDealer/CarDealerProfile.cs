namespace CarDealer
{
    using AutoMapper;
    using Dtos.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<ImportPartDTO, Part>();
            this.CreateMap<ImportCarDTO, Car>();
            this.CreateMap<ImportCustomerDTO, Customer>();
            this.CreateMap<ImportSaleDTO, Sale>();
        }
    }
}
