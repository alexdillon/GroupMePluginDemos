using System;
using System.Reflection;
using System.Threading.Tasks;
using GroupMeClientPlugin.MessageCompose;

namespace EffectDemo
{
    public class Class1 : GroupMeClientPlugin.PluginBase, GroupMeClientPlugin.MessageCompose.IMessageComposePlugin
    {
        public string EffectPluginName => this.PluginDisplayName;

        public override string PluginDisplayName => "Dummy Effect";

        public override string PluginVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public Task<MessageSuggestions> ProvideOptions(string typedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
