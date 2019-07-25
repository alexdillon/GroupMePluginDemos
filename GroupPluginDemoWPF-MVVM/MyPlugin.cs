using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupMeClientApi.Models;

namespace GroupPluginDemoWPF_MVVM
{
    public class MyPlugin : GroupMeClientPlugin.IPluginBase, GroupMeClientPlugin.GroupChat.IGroupChatPlugin
    {
        public string PluginName => "Group Stats Demo WPF with MVVM";

        public Task Activated(IMessageContainer groupOrChat)
        {
            MainWindow mainWindow = new MainWindow(); // application entry point
            MainWindowViewModel vm = new MainWindowViewModel(groupOrChat); // manually bind the ViewModel since App.xaml is missing in libraries
            mainWindow.DataContext = vm;

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.ShowDialog();    
            });

            // Do any cleanup needed

            return Task.CompletedTask;
        }
    }
}
