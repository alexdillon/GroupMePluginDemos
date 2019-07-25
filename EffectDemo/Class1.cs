using System;
using System.Threading.Tasks;
using GroupMeClientPlugin.MessageCompose;

namespace EffectDemo
{
    public class Class1 : GroupMeClientPlugin.IPluginBase, GroupMeClientPlugin.MessageCompose.IMessageComposePlugin
    {
        public string EffectPluginName => throw new NotImplementedException();

        public Task<MessageSuggestions> ProvideOptions(string typedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
