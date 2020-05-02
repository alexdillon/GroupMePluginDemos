using GroupMeClientApi.Models;
using System.Linq;

namespace GroupPluginDemoWPF_MVVM
{
    class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private string someGeneratedString;

        public MainWindowViewModel(IMessageContainer messageContainer, IQueryable<Message> cacheForGroupOrChat, IQueryable<Message> globalCache)
        {
            this.MessageContainer = messageContainer;
            this.MessagesForGroup = cacheForGroupOrChat;
            this.GlobalCache = globalCache;

            var mostRecentGroupMessage = this.MessagesForGroup.OrderByDescending(m => m.CreatedAtUnixTime).First();
            var mostRecentGlobalMessage = this.GlobalCache.OrderByDescending(m => m.CreatedAtUnixTime).First();

            this.SomeGeneratedString = $"The most recent message in this group was {mostRecentGroupMessage.Text}. The most recent message in the cache from all groups is {mostRecentGlobalMessage.Text}";
        }

        public string Name => this.MessageContainer.Name;

        public string SomeGeneratedString
        {
            get => this.someGeneratedString;
            private set => this.Set(() => this.SomeGeneratedString, ref this.someGeneratedString, value);
        }

        private IMessageContainer MessageContainer { get; }

        private IQueryable<Message> MessagesForGroup { get; }

        private IQueryable<Message> GlobalCache { get; }
    }
}
