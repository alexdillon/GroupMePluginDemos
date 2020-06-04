using GroupMeClientApi.Models;
using GroupMeClientPlugin;
using System.Linq;

namespace GroupPluginDemoWPF_MVVM
{
    class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private string someGeneratedString;

        public MainWindowViewModel(IMessageContainer messageContainer, CacheSession cacheSession)
        {
            this.MessageContainer = messageContainer;
            this.CacheSession = cacheSession;

            var mostRecentGroupMessage = this.CacheSession.GlobalCache.OrderByDescending(m => m.CreatedAtUnixTime).First();
            var mostRecentGlobalMessage = this.CacheSession.CacheForGroupOrChat.OrderByDescending(m => m.CreatedAtUnixTime).First();

            this.SomeGeneratedString = $"The most recent message in this group was {mostRecentGroupMessage.Text}. The most recent message in the cache from all groups is {mostRecentGlobalMessage.Text}";
        }

        public string Name => this.MessageContainer.Name;

        public string SomeGeneratedString
        {
            get => this.someGeneratedString;
            private set => this.Set(() => this.SomeGeneratedString, ref this.someGeneratedString, value);
        }

        private IMessageContainer MessageContainer { get; }

        private CacheSession CacheSession { get; }
    }
}
