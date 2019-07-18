using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Command
{
    public class UnityContainerHelp
    {
        private IUnityContainer container;
        public UnityContainerHelp()
        {
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)System.Configuration.ConfigurationManager.GetSection("unity");
            container.LoadConfiguration(section, "FirstClass");
        }

        public T GetServer<T>()
        {
            return container.Resolve<T>();
        }

        public T GetServer<T>(string Name)
        {
            return container.Resolve<T>(Name);
        }
    }
}
