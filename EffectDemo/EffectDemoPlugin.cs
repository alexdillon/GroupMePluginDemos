using System;
using System.Reflection;
using System.Threading.Tasks;
using GroupMeClientPlugin.MessageCompose;

namespace EffectDemo
{
    public class EffectDemoPlugin : GroupMeClientPlugin.PluginBase, IMessageComposePlugin
    {
        public string EffectPluginName => this.PluginDisplayName;

        public override string PluginDisplayName => "Dummy Effect";

        public override string PluginVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public override Version ApiVersion => new Version(2, 0, 0);

        public Task<MessageSuggestions> ProvideOptions(string typedMessage)
        {
            var results = new MessageSuggestions();
            results.TextOptions.Add("DEMO: " + typedMessage.ToUpper());
            return Task.FromResult(results);
        }
    }
}
