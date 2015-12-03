using AutoMapper;
using OnlineShop.Infrastructure.Mapping;
using OnlineShop.Models;
using OnlineShop.ViewModels.Products;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineShop
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Automapper settings

            // After
            #region AutoMapperConfig
                var autoMapperConfig = new AutoMapperConfig(Assembly.GetExecutingAssembly());
                autoMapperConfig.Execute();
            #endregion

            // Before
            #region AutoMapper
                Mapper.CreateMap<Product, ProductViewModel>();
            #endregion
        }
    }
}
