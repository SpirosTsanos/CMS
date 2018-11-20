using CMS.Repositories;
using CMS.Repositories.Interfaces;
using CMS.Services.Interfaces;
using CMS.Services.Login;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace CMS.Services.Factories
{
    public class LoginFactory : BaseFactory<ILoginService>
    {
        protected override void RegisterInterfaces()
        {
            //Container.RegisterType<ILoginRepository, LoginRepository>();
            //Container.RegisterType<ILoginService, UsernamePasswordLogin>();

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "unity.config" };
            System.Configuration.Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

            Container.LoadConfiguration(unitySection, "LoginContainer");
        }
    }
}
