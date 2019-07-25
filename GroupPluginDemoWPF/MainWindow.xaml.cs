using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupMeClientApi.Models;

namespace GroupPluginDemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMessageContainer messageContainer)
        {
            this.MessageContainer = messageContainer;

            InitializeComponent();
        }

        public IMessageContainer MessageContainer { get; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DemoLabel.Content = "Stats for " + this.MessageContainer.Name;
            // TODO - implement plugin content here
            // TODO - OR, switch to MMVM
        }
    }
}
