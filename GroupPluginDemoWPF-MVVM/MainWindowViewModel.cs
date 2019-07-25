using GroupMeClientApi.Models;

namespace GroupPluginDemoWPF_MVVM
{
    class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private string someGeneratedString;

        public MainWindowViewModel(IMessageContainer messageContainer)
        {
            this.MessageContainer = messageContainer;

            this.SomeGeneratedString = System.DateTime.Now.ToLongTimeString();
        }

        public string Name => this.MessageContainer.Name;

        public string SomeGeneratedString
        {
            get { return this.someGeneratedString; }
            private set { this.Set(() => this.SomeGeneratedString, ref this.someGeneratedString, value); }
        }

        private IMessageContainer MessageContainer { get; }
    }
}
