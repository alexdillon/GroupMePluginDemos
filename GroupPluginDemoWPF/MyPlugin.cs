using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GroupMeClientApi.Models;

namespace GroupPluginDemoWPF
{
    public class MyPlugin : GroupMeClientPlugin.PluginBase, GroupMeClientPlugin.GroupChat.IGroupChatPlugin
    {
        public string PluginName => this.PluginDisplayName;

        public override string PluginDisplayName => "Group Stats Demo WPF";

        public override string PluginVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public Task Activated(IMessageContainer groupOrChat)
        {
            MainWindow mainWindow = new MainWindow(groupOrChat);

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.ShowDialog();    
            });

            // Do any cleanup needed

            return Task.CompletedTask;
        }
    }
}
