namespace CarDealer
{
    using AutoMapper;
    using Dtos.Import;
    using Dtos.Export;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //import
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<ImportPartDTO, Part>();
            this.CreateMap<ImportCarDTO, Car>();
            this.CreateMap<ImportCustomerDTO, Customer>();
            this.CreateMap<ImportSaleDTO, Sale>();

            //export
            this.CreateMap<Car, ExportCarDistanceDTO>();
            this.CreateMap<Car, ExportCarPartsDTO>();
            this.CreateMap<Supplier, ExportLocalSuppliersDTO>();
            this.CreateMap<Part, ExportPartDTO>();
            this.CreateMap<PartCar, ExportCarPartsDTO>();
            this.CreateMap<PartCar, ExportPartDTO>();
        }
    }
}
