using AutoMapper;

namespace OnlineShop.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}