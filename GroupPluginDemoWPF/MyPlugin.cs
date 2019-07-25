using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupMeClientApi.Models;

namespace GroupPluginDemoWPF
{
    public class MyPlugin : GroupMeClientPlugin.IPluginBase, GroupMeClientPlugin.GroupChat.IGroupChatPlugin
    {
        public string PluginName => "Group Stats Demo WPF";

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
