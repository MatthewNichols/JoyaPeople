using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace JoyaPeople.Web.Infrastructure
{
    /// <summary>
    /// Replacement Controller Factory adding dependency injection
    /// Lifted from http://docs.castleproject.org/Default.aspx?Page=Windsor-tutorial-part-two-plugging-Windsor-in&NS=Windsor&AspxAutoDetectCookieSupport=1
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", 
                    requestContext.HttpContext.Request.Path));
            }

            return (IController) _kernel.Resolve(controllerType);
        }
    }
}