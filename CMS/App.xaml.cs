using CMS.Services.Factories;
using System.Windows;

namespace CMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static LoginFactory LoginFactory { get; } = new LoginFactory();
        internal static ClientFactory ClientFactory { get; } = new ClientFactory();
        internal static CardFactory CardFactory { get; } = new CardFactory();

        public App()
        {
            var flowManager = FlowManager.Instance;
        }
    }
}
