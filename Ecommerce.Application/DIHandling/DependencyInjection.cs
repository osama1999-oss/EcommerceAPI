using Ecommerce.Application.IService;
using Ecommerce.Application.Service;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.BaseRepository;
using Ecommerce.Infrastructure.IBaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DIHandling
{
    public static class DependencyInjection
    {
        public static void Handle(IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>
                (options =>
                {
                    options.UseSqlServer
                    (
                        "server = localhost; database = EcommerceSys; trusted_connection = true;",
                        options => options.MigrationsAssembly("Ecommerce.Web")
                    );
                });

            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Brand>, Repository<Brand>>();

            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService,ProductService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
