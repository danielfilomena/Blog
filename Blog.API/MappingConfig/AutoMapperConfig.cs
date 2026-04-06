using Blog.Application.Mapping;

namespace Blog.API.MappingConfig
{
    public static class AutoMapperConfig
    {

        public static void AddAutoMapperConfig(this IServiceCollection services)
        {

            if(services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(AutoMapperProfile)));

        }

    }
}
