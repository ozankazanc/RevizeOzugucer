using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using RevizeOzugucer.Core.CrossCuttingConcerns.Caching;
using RevizeOzugucer.Core.CrossCuttingConcerns.Caching.Microsoft;
using RevizeOzugucer.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
