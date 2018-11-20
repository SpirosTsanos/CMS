using CMS.Services.Clients;
using CMS.Services.Interfaces;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Reflection;

namespace CMS.Services.Factories
{
    public class ClientFactory : BaseFactory<IClientService>
    {
        protected override void RegisterInterfaces()
        {
            //Container.RegisterType<IClientService, TestClientService>();

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "unity.config" };
            System.Configuration.Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

            Container.LoadConfiguration(unitySection, "ClientContainer");
        }
    }
}
