using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;

namespace BigCorp.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductLine, ProductLineModel>().ReverseMap();
            CreateMap<Stock, StockModel>().ReverseMap();
            CreateMap<Storage, StorageModel>().ReverseMap();
        }
    }
}
