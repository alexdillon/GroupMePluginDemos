using System.Threading.Tasks;
using GroupMeClientPlugin.MessageCompose;

namespace CommonMessagesPlugin
{
    public class CommonMessagesPlugin : GroupMeClientPlugin.IPluginBase, IMessageComposePlugin
    {
        public string EffectPluginName => "Common Messages";

        public Task<MessageSuggestions> ProvideOptions(string typedMessage)
        {
            var result = new MessageSuggestions();
            result.TextOptions.Add(@"¯\_(ツ)_/¯");

            return Task.FromResult<MessageSuggestions>(result);
        }
    }
}
