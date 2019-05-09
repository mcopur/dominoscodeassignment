using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using Vouchers.API.App_Start;
using System.Web.Routing;
using Vouchers.API.Repository;
using System;

namespace Vouchers.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);



            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            container.Register<IVoucherDataSource>(
                () => new VoucherJsonDataSource($"{AppDomain.CurrentDomain.BaseDirectory}data.json")
                , Lifestyle.Scoped);

            container.Register<IVoucherRepository, VoucherRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}
