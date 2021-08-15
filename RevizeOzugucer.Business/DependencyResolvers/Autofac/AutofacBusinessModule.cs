using Autofac;
using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Business.Concrete;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.DataAccess.Concrete.EntityFramework;
using RevizeOzugucer.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using RevizeOzugucer.Core.Utilities.Interceptors;

namespace RevizeOzugucer.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Iproductservice istenirse ProductManager veriyoruz.
            //WebApi altında bulunan startup'tan bu katmana çektik.
            builder.RegisterType<ONSurucuManager>().As<IONSurucuService>().SingleInstance();
            builder.RegisterType<EFONSurucuDal>().As<IONSurucuDal>().SingleInstance();

            builder.RegisterType<ONIrsaliyeManager>().As<IONIrsaliyeService>().SingleInstance();
            builder.RegisterType<EFONIrsaliyeDal>().As<IONIrsaliyeDal>().SingleInstance();

            builder.RegisterType<ONIrsaliyeDetayManager>().As<IONIrsaliyeDetayService>().SingleInstance();
            builder.RegisterType<EFONIrsaliyeDetayDal>().As<IONIrsaliyeDetayDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

