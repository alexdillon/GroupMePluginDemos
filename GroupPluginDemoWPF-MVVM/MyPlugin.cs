using System;
using System.Reflection;
using System.Threading.Tasks;
using GroupMeClientApi.Models;
using GroupMeClientPlugin;
using GroupMeClientPlugin.GroupChat;

namespace GroupPluginDemoWPF_MVVM
{
    public class MyPlugin : PluginBase, IGroupChatPlugin
    {
        public string PluginName => this.PluginDisplayName;

        public override string PluginDisplayName => "Group Plugin Demo";

        public override string PluginVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public override Version ApiVersion => new Version(2, 0, 0);

        public Task Activated(IMessageContainer groupOrChat, CacheSession cacheSession, IPluginUIIntegration integration, Action<CacheSession> cleanup)
        {
            MainWindow mainWindow = new MainWindow(); // application entry point
            MainWindowViewModel vm = new MainWindowViewModel(groupOrChat, cacheSession); 
            mainWindow.DataContext = vm;

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.ShowDialog();    
            });

            mainWindow.Closing += (s, e) =>
            {
                cleanup(cacheSession);
            };

            return Task.CompletedTask;
        }
    }
}
