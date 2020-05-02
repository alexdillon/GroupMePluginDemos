using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GroupMeClientApi.Models;
using GroupMeClientPlugin.GroupChat;

namespace GroupPluginDemoWPF_MVVM
{
    public class MyPlugin : GroupMeClientPlugin.PluginBase, GroupMeClientPlugin.GroupChat.IGroupChatPlugin
    {
        public string PluginName => this.PluginDisplayName;

        public override string PluginDisplayName => "Group Stats Demo WPF with MVVM";

        public override string PluginVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public override Version ApiVersion => new Version(2, 0, 0);

        public Task Activated(IMessageContainer groupOrChat, IQueryable<Message> cacheForGroupOrChat, IQueryable<Message> globalCache, IPluginUIIntegration integration)
        {
            MainWindow mainWindow = new MainWindow(); // application entry point
            MainWindowViewModel vm = new MainWindowViewModel(groupOrChat, cacheForGroupOrChat, globalCache); 
            mainWindow.DataContext = vm; // Manually bind the DataContext since the library version of MvvmLight

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.ShowDialog();    
            });

            // Do any cleanup needed

            return Task.CompletedTask;
        }
    }
}
