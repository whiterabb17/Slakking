using MargieBot;
using System;
using System.Text;

namespace Slakking
{
    public class HelloResponder : IResponder
    {
        public bool CanRespond(ResponseContext context)
        {
            return context.Message.MentionsBot
                  && !context.BotHasResponded
                  && context.Message.Text.ToLower().Contains("hello");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();
            builder.Append("Hello ").Append(context.Message.User.FormattedUserID);

            return new BotMessage { Text = builder.ToString() };
        }

        public static void SSend(string WebHook, string content)
        {
            string urlWithAccessToken = WebHook;

            SlackClient client = new SlackClient(urlWithAccessToken);

            client.PostMessage(username: Variables.ResponderAgent,
                       text: ":: Notification message to be delivered to channel: " + DateTime.UtcNow.ToString() + "\r\n" + content,
                       channel: "#BotChannel");
        }
        public BotMessage CommandSender(ResponseContext context)
        {
            string responder = null;
            var builder = new StringBuilder();
            string respondee = context.Message.User.FormattedUserID;
            string[] _ = context.Message.Text.Split(':');
            if (context.Message.MentionsBot && !context.BotHasResponded && !context.Message.Text.ToLower().Contains(respondee + " cmd:"))
            {
                foreach (Commands cmd in CommandHolder.CommandList)
                {
                    if (_[1] == cmd.Command1)
                    {
                        foreach (string file in Functions.getFiles())
                        {
                            responder += file + Environment.NewLine;
                        }
                        builder.Append(responder);
                    }
                }
            }

            SlackClient client = new SlackClient(Variables.urlWithAccessToken);

            client.PostMessage(username: Variables.ResponderAgent,
                       text: ":: New Command recieved from Controller at " + DateTime.UtcNow.ToString() + "\r\n" + "Command specified: " + _[1] + "\r\n" + "Send to client: " + respondee,
                       channel: "#kingdomsfoundation");

            return new BotMessage { Text = builder.ToString() };
        }
    }
}