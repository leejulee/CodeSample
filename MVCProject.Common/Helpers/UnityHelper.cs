using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MVCProject.Common
{
    public static class UnityHelper
    {
        //http://kevintsengtw.blogspot.tw/2013/09/unitymvc4-enterprsie-library-unity-21.html#.U8OJzPmSyVM
        private static IUnityContainer _container;

        public static IUnityContainer GetUnityContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
            }

            return _container;
        }

        public static void SetUnityContainer(IUnityContainer container)
        {
            if (_container == null)
            {
                _container = container;
            }
        }

        public static TInterface Resolve<TInterface, TModel>()
        {
            TInterface ret = default(TInterface);

            if (_container.IsRegistered(typeof(TInterface)))
            {
                ret = _container.Resolve<TInterface>();
            }
            else
            {
                _container.RegisterType(typeof(TInterface), typeof(TModel), new TransientLifetimeManager());
                ret = _container.Resolve<TInterface>();
            }

            return ret;
        }
    }
}
