using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Services.Clients;
using CMS.Services.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace CMS.Services.Factories
{
    public class CardFactory : BaseFactory<ICardService>
    {
        protected override void RegisterInterfaces()
        {
            //Container.RegisterType<ICardService, TestCardService>();

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "unity.config" };
            System.Configuration.Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

            Container.LoadConfiguration(unitySection, "CardContainer");
        }
    }
}
