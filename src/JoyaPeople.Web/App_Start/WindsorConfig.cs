using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using JoyaPeople.Persistence;
using JoyaPeople.Web.Infrastructure;

namespace JoyaPeople.Web.App_Start
{
    public class WindsorConfig
    {
        private static IWindsorContainer _container;

        public static void Config()
        {
            _container = new WindsorContainer()
                .Install(
                    FromAssembly.This(),
                    FromAssembly.Containing<RepositoryInstaller>());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}