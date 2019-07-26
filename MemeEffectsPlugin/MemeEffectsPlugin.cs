using System;
using System.Linq;
using System.Threading.Tasks;
using GroupMeClientPlugin.MessageCompose;

namespace MemeEffectsPlugin
{
    public class MemeEffectsPlugin : GroupMeClientPlugin.IPluginBase, IMessageComposePlugin
    {
        public string EffectPluginName => "Meme Effects";

        public Task<MessageSuggestions> ProvideOptions(string typedMessage)
        {
            var result = new MessageSuggestions();
            result.TextOptions.Add(this.DoRandomSpongebobText(typedMessage));
            result.TextOptions.Add(this.DoAlternatingSpongebobText(typedMessage, true));
            result.TextOptions.Add(this.DoAlternatingSpongebobText(typedMessage, false));

            return Task.FromResult<MessageSuggestions>(result);
        }

        private string DoRandomSpongebobText(string text)
        {
            Random rnd = new Random();
            return string.Concat(text.Select(b => (rnd.Next(0,2) == 1 ? b : char.ToUpper(b))));
        }

        private string DoAlternatingSpongebobText(string text, bool startUpper)
        {
            return string.Concat(text.Select(b =>
            {
                startUpper = !startUpper;
                return (startUpper ? b : char.ToUpper(b));
            }));
        }
    }
}
