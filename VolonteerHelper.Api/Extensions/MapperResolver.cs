using AutoMapper;

namespace VolonteerHelper.Api.Extensions
{
    public static class MapperResolver
    {
        public static Mapper InitiateMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}