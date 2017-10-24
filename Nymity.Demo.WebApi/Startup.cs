using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Reflection;
using System.Web.Http;
using Nymity.Demo.IoC;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Nymity.Demo.WebApi.Startup))]

namespace Nymity.Demo.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();

            WebApiConfig.Register(webApiConfiguration);

            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(webApiConfiguration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            RegisterServices(kernel);

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            //Carregar os Modulos com definições de Bind aqui
            //Ou trocar a a implementação do CreateKernel para utilizar o NinjectBuilder do projeto de IoC
            kernel.Load(new RepositoryModule());
            kernel.Load(new ServiceModule());

        }
    }
}
