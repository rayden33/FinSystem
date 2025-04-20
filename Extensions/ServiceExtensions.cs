namespace FinSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();         // Need for analyse endpoints
            services.AddSwaggerGen(options =>
            {
                var xmlFIleName = $"{typeof(ServiceExtensions).Assembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFIleName));
            });                   // Genarates Swagger JSON and UI
            services.AddCors(options =>
            {
                options.AddPolicy("Frontend", policy =>
                {
                    policy.WithOrigins("http://myfrontend.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
