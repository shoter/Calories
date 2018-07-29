using Calories.Api.Others;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Logging;
using MissingDIExtensions;
using Ninject;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Standard.Ninject;
using Calories.Database.Repositories;
using Calories.Database;

namespace Calories.Api.Setups
{
    public class CaloriesNinject
    {
        internal AsyncLocal<Scope> ScopeProvider = new AsyncLocal<Scope>();
        internal IKernel Kernel { get; set; }

        internal object Resolve(Type type) => Kernel.Get(type);
        internal object RequestScope(IContext context) => ScopeProvider.Value;

        internal IKernel RegisterApplicationComponents(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // IKernelConfiguration config = new KernelConfiguration();
            Kernel = new StandardKernel();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                Kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            bindServices();

            // Cross-wire required framework services
            Kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);
            Kernel.Bind<ILoggerFactory>().ToConstant(loggerFactory);

            return Kernel;
        }

        private void bindServices()
        {
            Kernel.Bind<CaloriesContext>().ToMethod((context) =>
            {
                var factory = new CaloriesContextFactory();
                return factory.CreateDbContext(null);
            });
            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InScope(RequestScope);
        }
    }
}
